using Microsoft.VisualBasic.Logging;
using System;
using System.Windows.Forms;

namespace Measurement_System
{
    public partial class Admin_Landing : Form
    {
        private readonly AdminDashboard _dashboard = new AdminDashboard();
        private readonly AdminMeasurements _measurements = new AdminMeasurements();
        private readonly AdminTransactions _transactions = new AdminTransactions();
        private readonly AdminStaffs _staffs = new AdminStaffs();

        public Admin_Landing()
        {
            InitializeComponent();

            // Wire button clicks to swap the main panel content
            button2.Click += (s, e) => ShowControl(_dashboard);       // Dashboard
            button3.Click += (s, e) => ShowControl(_measurements);   // Clients / Measurements
            button4.Click += (s, e) => ShowControl(_transactions);   // Transactions
            button5.Click += (s, e) => ShowControl(_staffs);         // Staff

            // Show default view
            ShowControl(_dashboard);
        }

        private void ShowControl(UserControl uc)
        {
            MainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(uc);
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
