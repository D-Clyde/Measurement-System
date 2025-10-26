using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Measurement_System
{
    public partial class Add_client : Form
    {
        // Use the same connection string pattern used elsewhere in your app
        private const string ConnectionString = "server=localhost;port=3306;database=MSrecords;user=root;password=Richter_06;";

        public Add_client()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Call this method from your Save/Add button's Click event (wire it in the designer)
        private async void Save_Click(object? sender, EventArgs e)
        {
            // Gather all TextBox controls recursively
            var textBoxes = GetAllTextBoxes(this).ToList();

            // Map each TextBox to a DB column name:
            // - Prefer the TextBox.Tag property (set this in the Designer to the exact DB column name)
            // - Fallback to the TextBox.Name (sanitized minimally)
            var filled = textBoxes
                .Where(tb => !string.IsNullOrWhiteSpace(tb.Text))
                .Select(tb => new
                {
                    Control = tb,
                    Column = (tb.Tag?.ToString() ?? tb.Name).Trim()
                })
                .Where(x => !string.IsNullOrEmpty(x.Column))
                .ToList();

            if (filled.Count == 0)
            {
                MessageBox.Show("No data entered to save.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Optional: require a client_name column (adjust to your schema)
            if (!filled.Any(f => string.Equals(f.Column, "client_name", StringComparison.OrdinalIgnoreCase)))
            {
                var ask = MessageBox.Show("No client_name provided. Continue anyway?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;
            }

            // Build parameterized INSERT
            var columns = filled.Select((f, i) => f.Column).ToArray();
            var paramNames = filled.Select((f, i) => $"@p{i}").ToArray();

            var sql = $"INSERT INTO `ClientsData` ({string.Join(", ", columns.Select(c => $"`{c}`"))}) VALUES ({string.Join(", ", paramNames)})";

            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand(sql, conn);
                for (int i = 0; i < filled.Count; i++)
                {
                    // store raw textbox text; you can add conversions/validation here
                    cmd.Parameters.AddWithValue(paramNames[i], filled[i].Control.Text.Trim());
                }

                var rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    MessageBox.Show("Client added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // clear inputs or close form
                    foreach (var tb in textBoxes) tb.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Insert completed but no rows were affected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding client: " + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recursively finds all TextBox controls under a parent control
        private static IEnumerable<TextBox> GetAllTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb) yield return tb;
                if (c.HasChildren)
                {
                    foreach (var child in GetAllTextBoxes(c))
                        yield return child;
                }
            }
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(client_name.Text))
            {
                MessageBox.Show("Please enter a client name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop here
            }

            string connectionString = "server=localhost;port=3306;database=MSrecords;user=root;password=Richter_06;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Call the procedure by its name
                    using (MySqlCommand cmd = new MySqlCommand("sp_AddNewClient", conn))
                    {
                        // This is the magic part, tells C# it's a procedure, not a text query
                        cmd.CommandType = CommandType.StoredProcedure;

                        // --- Step 2: Add all parameters ---
                        // Get values from your textboxes.
                        // Note: This will crash if a textbox is empty. See the "Bro Tip" below.
                        cmd.Parameters.AddWithValue("p_client_name", client_name.Text.Trim());
                        cmd.Parameters.AddWithValue("p_back_length_in", decimal.Parse(back_length.Text));
                        cmd.Parameters.AddWithValue("p_shoulder_width_in", decimal.Parse(shoulder_width.Text));
                        cmd.Parameters.AddWithValue("p_sleeve_length_in", decimal.Parse(sleeve_length.Text));
                        cmd.Parameters.AddWithValue("p_cuffs_circumference_in", decimal.Parse(cuffs_circumference.Text));
                        cmd.Parameters.AddWithValue("p_chest_circumference_in", decimal.Parse(chest_circumference.Text));
                        cmd.Parameters.AddWithValue("p_abdomen_circumference_in", decimal.Parse(abdomen_circumference.Text));
                        cmd.Parameters.AddWithValue("p_hips_circumference_in", decimal.Parse(hips_circumference.Text));
                        cmd.Parameters.AddWithValue("p_neck_circumference_in", decimal.Parse(neck_circumference.Text));
                        cmd.Parameters.AddWithValue("p_crotch_length_in", decimal.Parse(crotch_length.Text));
                        cmd.Parameters.AddWithValue("p_leg_length_in", decimal.Parse(leg_length.Text));
                        cmd.Parameters.AddWithValue("p_waist_line_circumference_in", decimal.Parse(waist_line_circumference.Text));
                        cmd.Parameters.AddWithValue("p_thigh_circumference_in", decimal.Parse(thigh_circumference.Text));
                        cmd.Parameters.AddWithValue("p_knee_circumference_in", decimal.Parse(knee_circumference.Text));
                        cmd.Parameters.AddWithValue("p_seam_circumference_in", decimal.Parse(seam_circumference.Text));

                        // --- Step 3: Run the command ---
                        // Use ExecuteNonQueryAsync for INSERT, UPDATE, or DELETE
                        await cmd.ExecuteNonQueryAsync();

                        MessageBox.Show("New client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // You might want to clear all the textboxes here
                        // ClearAllTextboxes();
                    }
                }
            }
            catch (FormatException)
            {
                // This catch block will fire if you use decimal.Parse() on an empty or invalid textbox
                MessageBox.Show("Please make sure all measurement fields are filled in and contain valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // This catches any other errors, like database connection problems
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
