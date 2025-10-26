namespace Measurement_System
{
    partial class Admin_Landing
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
            splitter1 = new Splitter();
            Adminlbl = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            MainPanel = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.BackColor = Color.OliveDrab;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(323, 775);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // Adminlbl
            // 
            Adminlbl.AutoSize = true;
            Adminlbl.BackColor = Color.OliveDrab;
            Adminlbl.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Adminlbl.Location = new Point(105, 106);
            Adminlbl.Name = "Adminlbl";
            Adminlbl.Size = new Size(89, 28);
            Adminlbl.TabIndex = 1;
            Adminlbl.Text = "Admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(21, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 36);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(21, 288);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(21, 365);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 36);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(21, 442);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(36, 36);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.OliveDrab;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 14.25F);
            button2.Location = new Point(0, 191);
            button2.Name = "button2";
            button2.Size = new Size(323, 73);
            button2.TabIndex = 4;
            button2.Text = "Dashboard";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.OliveDrab;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 14.25F);
            button3.Location = new Point(0, 269);
            button3.Name = "button3";
            button3.Size = new Size(323, 73);
            button3.TabIndex = 4;
            button3.Text = "Clients";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.OliveDrab;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 14.25F);
            button4.Location = new Point(0, 348);
            button4.Name = "button4";
            button4.Size = new Size(323, 73);
            button4.TabIndex = 4;
            button4.Text = "Transactions";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.OliveDrab;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 14.25F);
            button5.Location = new Point(0, 427);
            button5.Name = "button5";
            button5.Size = new Size(323, 73);
            button5.TabIndex = 4;
            button5.Text = "Staff";
            button5.UseVisualStyleBackColor = false;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(322, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(964, 783);
            MainPanel.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Sign out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Admin_Landing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 775);
            Controls.Add(button1);
            Controls.Add(MainPanel);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Adminlbl);
            Controls.Add(splitter1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_Landing";
            Text = "Admin_Landing";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Splitter splitter1;
        private Label Adminlbl;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel MainPanel;
        private Button button1;
    }
}