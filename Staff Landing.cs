using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Measurement_System
{
    public partial class Staff_Landing : Form
    {
        public Staff_Landing()
        {
            InitializeComponent();
            LoadTransactionData();
        }

        // New constructor that accepts the staff display name
        public Staff_Landing(string staffName) : this()
        {
            SetStaffName(staffName);
        }

        private void LoadTransactionData()
        {
            string connectionString = "server=localhost;port=3306;database=MSrecords;user=root;password=Richter_06;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM ClientsData";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Best-effort setter: finds a TextBox named "staff_name" (searches children) and sets its Text.
        // If your control has a different name, change "staff_name" to the actual control name.
        private void SetStaffName(string staff_name)
        {
            if (string.IsNullOrEmpty(staff_name)) return;

            try
            {
                var matches = this.Controls.Find("staff_name", true);
                if (matches.Length > 0)
                {
                    if (matches[0] is TextBox tb)
                    {
                        tb.Text = staff_name;
                        return;
                    }

                    // if the designer used a Label instead of TextBox, set it too
                    if (matches[0] is Label lbl)
                    {
                        lbl.Text = staff_name;
                        return;
                    }
                }

                // If not found at root, try common alternative names (optional)
                var altMatches = this.Controls.Find("staffName", true);
                if (altMatches.Length > 0 && altMatches[0] is TextBox altTb)
                    altTb.Text = staff_name;
            }
            catch
            {
                // best-effort; swallow exceptions so login won't fail
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Logout button handler (wired to button2 in the designer)
        private void button2_Click(object sender, EventArgs e)
        {
            var add = new Add_client();
            add.Show();
        }

        private void Log_out_Click(object sender, EventArgs e)
        {
            // Try to find an existing login form instance
            var loginForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (loginForm != null)
            {
                // Clear credentials for security and UX (best-effort)
                var passCtrl = loginForm.Controls.Find("Passbx", true).FirstOrDefault() as TextBox;
                var userCtrl = loginForm.Controls.Find("Userbx", true).FirstOrDefault() as TextBox;
                if (passCtrl != null) passCtrl.Text = string.Empty;
                // optionally clear username:
                // if (userCtrl != null) userCtrl.Text = string.Empty;

                loginForm.Show();
            }
            else
            {
                // If the original login form was disposed, open a fresh one
                var f = new Form1();
                f.Show();
            }

            // Close this landing form to complete logout
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTransactionData();
        }
    }
}
