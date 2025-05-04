namespace LibraryManager
{
    partial class QLPhieuPhat
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
            panel1 = new Panel();
            label2 = new Label();
            tbDanhSachPhieuPhat = new TableLayoutPanel();
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbDanhSachPhieuPhat);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1332, 853);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(463, 12);
            label2.Name = "label2";
            label2.Size = new Size(354, 60);
            label2.TabIndex = 5;
            label2.Text = "Quản Lý Vi Phạm";
            // 
            // tbDanhSachPhieuPhat
            // 
            tbDanhSachPhieuPhat.ColumnCount = 8;
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tbDanhSachPhieuPhat.Location = new Point(39, 143);
            tbDanhSachPhieuPhat.Name = "tbDanhSachPhieuPhat";
            tbDanhSachPhieuPhat.RowCount = 2;
            tbDanhSachPhieuPhat.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbDanhSachPhieuPhat.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbDanhSachPhieuPhat.Size = new Size(1223, 586);
            tbDanhSachPhieuPhat.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(745, 86);
            button1.Name = "button1";
            button1.Size = new Size(191, 33);
            button1.TabIndex = 3;
            button1.Text = "Download Excel";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Mã Vi Phạm", "Mã Thành Viên", "Mã Quản Lý" });
            comboBox1.Location = new Point(573, 91);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(368, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 85);
            label1.Name = "label1";
            label1.Size = new Size(109, 31);
            label1.TabIndex = 0;
            label1.Text = "Tìm Kiếm";
            // 
            // QLPhieuPhat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QLPhieuPhat";
            Size = new Size(1335, 853);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private TableLayoutPanel tbDanhSachPhieuPhat;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
    }
}