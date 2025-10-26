using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Measurement_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Login.Click += Login_Click;
            Passbx.UseSystemPasswordChar = true;
        }

        private async void Login_Click(object? sender, EventArgs e)
        {
            string username = Userbx.Text.Trim();
            string password = Passbx.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: update this connection string to your DB
            string connectionString = "server=localhost;port=3306;database=MSrecords;user=root;password=Richter_06;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // request role and common name fields; we'll build a display name from what's available
                    string query = "SELECT Role, Username, First_Name FROM Users WHERE Username = @u AND Password = @p";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password); // consider hashing in production

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (!await reader.ReadAsync())
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            static string GetCol(IDataRecord r, string name)
                            {
                                try
                                {
                                    var idx = r.GetOrdinal(name);
                                    if (r.IsDBNull(idx)) return string.Empty;
                                    return r.GetValue(idx)?.ToString() ?? string.Empty;
                                }
                                catch
                                {
                                    return string.Empty;
                                }
                            }

                            string role = GetCol(reader, "Role");
                            // Build a best-effort display name from available columns
                            string first_name = GetCol(reader, "first_name");
                            if (string.IsNullOrEmpty(first_name))
                            {
                                var first = GetCol(reader, "FirstName");
                                var last = GetCol(reader, "LastName");
                                first_name = string.Join(" ", new[] { first, last }.Where(s => !string.IsNullOrEmpty(s))).Trim();
                            }
                            if (string.IsNullOrEmpty(first_name))
                                first_name = GetCol(reader, "Username");
                            if (string.IsNullOrEmpty(first_name))
                                first_name = username; // fallback

                            // Create the landing form and, if it contains a TextBox named "staff_name", set it.
                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                var adminForm = new Admin_Landing();
                                TrySetNamedTextBox(adminForm, "staff_name", first_name);
                                adminForm.Show();
                                Hide();
                            }
                            else
                            {
                                var staffForm = new Staff_Landing();
                                TrySetNamedTextBox(staffForm, "staff_name", first_name);
                                staffForm.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper: find a control by name anywhere in the form and set its Text if it's a TextBox
        private static void TrySetNamedTextBox(Form form, string controlName, string text)
        {
            if (form == null) return;
            try
            {
                var matches = form.Controls.Find(controlName, true);
                if (matches.Length > 0 && matches[0] is TextBox tb)
                    tb.Text = text ?? string.Empty;
                else
                {
                    // If the designer used a different container or naming, optionally search for a Label or other control:
                    // if (matches.Length > 0 && matches[0] is Label lbl) lbl.Text = text ?? string.Empty;
                }
            }
            catch
            {
                // Suppress any errors here; setting the name is best-effort.
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
