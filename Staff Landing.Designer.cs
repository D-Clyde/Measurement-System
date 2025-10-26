namespace Measurement_System
{
    partial class Staff_Landing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBox staff_name;
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            Log_out = new Button();
            button2 = new Button();
            panel1 = new Panel();
            button1 = new Button();
            staff_name = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // staff_name
            // 
            staff_name.BackColor = Color.FromArgb(41, 128, 185);
            staff_name.BorderStyle = BorderStyle.None;
            staff_name.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            staff_name.Location = new Point(249, 17);
            staff_name.Name = "staff_name";
            staff_name.ReadOnly = true;
            staff_name.Size = new Size(411, 59);
            staff_name.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(1064, 655);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1064, 655);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(245, 49);
            label1.TabIndex = 0;
            label1.Text = "WELCOME,";
            label1.Click += label1_Click;
            // 
            // Log_out
            // 
            Log_out.BackColor = Color.FromArgb(41, 128, 185);
            Log_out.FlatAppearance.BorderSize = 0;
            Log_out.FlatStyle = FlatStyle.Flat;
            Log_out.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Log_out.ForeColor = Color.Red;
            Log_out.Location = new Point(956, 24);
            Log_out.Name = "Log_out";
            Log_out.Size = new Size(96, 37);
            Log_out.TabIndex = 2;
            Log_out.Text = "Log Out";
            Log_out.UseVisualStyleBackColor = false;
            Log_out.Click += Log_out_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(688, 29);
            button2.Name = "button2";
            button2.Size = new Size(137, 33);
            button2.TabIndex = 3;
            button2.Text = "ADD CLIENT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(Log_out);
            panel1.Controls.Add(staff_name);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 93);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(831, 28);
            button1.Name = "button1";
            button1.Size = new Size(113, 34);
            button1.TabIndex = 4;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Staff_Landing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 748);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Staff_Landing";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff_Landing";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox staff_name;
        private Button Log_out;
        private Button button2;
        private Panel panel1;
        private Button button1;
    }
}