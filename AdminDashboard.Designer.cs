namespace Measurement_System
{
    partial class AdminDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Clients = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            Orders = new Panel();
            textBox3 = new TextBox();
            label3 = new Label();
            Sales = new Panel();
            Clients.SuspendLayout();
            Orders.SuspendLayout();
            Sales.SuspendLayout();
            SuspendLayout();
            // 
            // Clients
            // 
            Clients.BackColor = Color.Silver;
            Clients.Controls.Add(textBox1);
            Clients.Controls.Add(label1);
            Clients.Location = new Point(16, 229);
            Clients.Name = "Clients";
            Clients.Size = new Size(240, 240);
            Clients.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Silver;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(47, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 59);
            textBox1.TabIndex = 1;
            textBox1.Text = "100";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 186);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 0;
            label1.Text = "Amount of Clients";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Silver;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(45, 89);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(142, 59);
            textBox2.TabIndex = 1;
            textBox2.Text = "10";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 186);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 0;
            label2.Text = "Pending Orders";
            // 
            // Orders
            // 
            Orders.BackColor = Color.Silver;
            Orders.Controls.Add(textBox2);
            Orders.Controls.Add(label2);
            Orders.Location = new Point(350, 229);
            Orders.Name = "Orders";
            Orders.Size = new Size(240, 240);
            Orders.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Silver;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(49, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(142, 59);
            textBox3.TabIndex = 1;
            textBox3.Text = "120";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 186);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 0;
            label3.Text = "Total Sales";
            // 
            // Sales
            // 
            Sales.BackColor = Color.Silver;
            Sales.Controls.Add(textBox3);
            Sales.Controls.Add(label3);
            Sales.Location = new Point(700, 229);
            Sales.Name = "Sales";
            Sales.Size = new Size(240, 240);
            Sales.TabIndex = 8;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Clients);
            Controls.Add(Orders);
            Controls.Add(Sales);
            Name = "AdminDashboard";
            Size = new Size(964, 735);
            Clients.ResumeLayout(false);
            Clients.PerformLayout();
            Orders.ResumeLayout(false);
            Orders.PerformLayout();
            Sales.ResumeLayout(false);
            Sales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Clients;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Panel Orders;
        private TextBox textBox3;
        private Label label3;
        private Panel Sales;
    }
}
