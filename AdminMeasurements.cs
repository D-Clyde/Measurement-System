using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Measurement_System
{
    public partial class AdminMeasurements : UserControl
    {
        // Replace with your real connection string (move to settings in production)
        private const string ConnectionString = "Server=localhost;Database=MSrecords;Uid=root;Pwd=Richter_06;";

        // store currently loaded client id so update can use it
        private int? _currentClientId;

        public AdminMeasurements()
        {
            InitializeComponent();

            // wire the search button (button1) to the lookup handler
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            var name = Client_Name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter a client name to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadClientByName(name);
        }

        public void LoadClientByName(string clientName)
        {
            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();

                using var cmd = new MySqlCommand(
                    "SELECT * FROM ClientsData WHERE client_name = @name LIMIT 1",
                    conn);
                cmd.Parameters.AddWithValue("@name", clientName);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    ClearFields();
                    MessageBox.Show("Client not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                static string GetSafe(IDataRecord r, string columnName)
                {
                    try
                    {
                        var idx = r.GetOrdinal(columnName);
                        if (r.IsDBNull(idx)) return string.Empty;
                        return r.GetValue(idx)?.ToString() ?? string.Empty;
                    }
                    catch
                    {
                        return string.Empty;
                    }
                }

                int? TryGetId(IDataRecord r)
                {
                    foreach (var candidate in new[] { "id", "client_id", "clientId" })
                    {
                        try
                        {
                            var idx = r.GetOrdinal(candidate);
                            if (!r.IsDBNull(idx))
                                return Convert.ToInt32(r.GetValue(idx));
                        }
                        catch { }
                    }
                    return null;
                }

                _currentClientId = TryGetId(reader);

                // Map DB columns to Designer controls (names must match exactly)
                Back_Length.Text = GetSafe(reader, "Back_Length_in");
                Shoulder_Width.Text = GetSafe(reader, "Shoulder_Width_in");
                Sleeve_Length.Text = GetSafe(reader, "Sleeve_Length_in");
                Chest_Circumference.Text = GetSafe(reader, "Chest_Circumference_in");
                Abdomen_Circumference.Text = GetSafe(reader, "Abdomen_Circumference_in");
                Hips_Circumference.Text = GetSafe(reader, "Hips_Circumference_in");
                Neck_Circumference.Text = GetSafe(reader, "Neck_Circumference_in");
                Crotch_Length.Text = GetSafe(reader, "crotch_length_in");
                Leg_Length.Text = GetSafe(reader, "Leg_Length_in");
                Waist_Line_Circumference.Text = GetSafe(reader, "Waist_Line_Circumference_in");
                Thigh_Circumference.Text = GetSafe(reader, "Thigh_Circumference_in");
                Seam_Circumference.Text = GetSafe(reader, "Seam_Circumference_in");
                Knee_Circumference.Text = GetSafe(reader, "Knee_Circumference_in");
                Cuffs_Circumference.Text = GetSafe(reader, "Cuffs_Circumference_in");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading client: {ex.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            _currentClientId = null;

            var boxes = new TextBox[] {
        Back_Length, Shoulder_Width, Sleeve_Length, Cuffs_Circumference,
        Chest_Circumference, Leg_Length, Crotch_Length, Neck_Circumference,
        Hips_Circumference,  Waist_Line_Circumference,
        Thigh_Circumference, Seam_Circumference, Knee_Circumference,
        Abdomen_Circumference
    };

            foreach (var tb in boxes)
                if (tb != null) tb.Text = string.Empty;
        }


        private void AdminMeasurements_Load(object sender, EventArgs e)
        {
            // optional: preload or other initialization
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (!_currentClientId.HasValue)
            {
                MessageBox.Show("No client loaded. Search and load a client before updating.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(Back_Length.Text, out var backLength);
            decimal.TryParse(Shoulder_Width.Text, out var shoulderWidth);
            decimal.TryParse(Sleeve_Length.Text, out var sleeveLength);
            decimal.TryParse(Cuffs_Circumference.Text, out var cuffs);
            decimal.TryParse(Chest_Circumference.Text, out var chest);
            decimal.TryParse(Abdomen_Circumference.Text, out var abdomen);
            decimal.TryParse(Hips_Circumference.Text, out var hips);
            decimal.TryParse(Neck_Circumference.Text, out var neck);
            decimal.TryParse(Crotch_Length.Text, out var crotch);
            decimal.TryParse(Leg_Length.Text, out var legLength);
            decimal.TryParse(Waist_Line_Circumference.Text, out var waist);
            decimal.TryParse(Thigh_Circumference.Text, out var thigh);

            // seam & knee use textBox14/textBox15 as inputs
            decimal.TryParse(Seam_Circumference.Text, out var seamCircumference);
            decimal.TryParse(Knee_Circumference.Text, out var kneeCircumference);

            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("sp_Update_tMeasurements", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("p_client_id", _currentClientId.Value);
                cmd.Parameters.AddWithValue("p_back_length_in", backLength);
                cmd.Parameters.AddWithValue("p_shoulder_width_in", shoulderWidth);
                cmd.Parameters.AddWithValue("p_sleeve_length_in", sleeveLength);
                cmd.Parameters.AddWithValue("p_cuffs_circumference_in", cuffs);
                cmd.Parameters.AddWithValue("p_chest_circumference_in", chest);
                cmd.Parameters.AddWithValue("p_abdomen_circumference_in", abdomen);
                cmd.Parameters.AddWithValue("p_hips_circumference_in", hips);
                cmd.Parameters.AddWithValue("p_neck_circumference_in", neck);
                cmd.Parameters.AddWithValue("p_crotch_length_in", crotch);
                cmd.Parameters.AddWithValue("p_leg_length_in", legLength);
                cmd.Parameters.AddWithValue("p_waist_line_circumference_in", waist);
                cmd.Parameters.AddWithValue("p_thigh_circumference_in", thigh);
                cmd.Parameters.AddWithValue("p_knee_circumference_in", kneeCircumference);
                cmd.Parameters.AddWithValue("p_seam_circumference_in", seamCircumference);

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show("Client measurements updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var add = new Add_client();
            add.Show(); 
        }
    }
}

