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
            cbKieuTimKiem = new ComboBox();
            txtTimKiem = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbDanhSachPhieuPhat);
            panel1.Controls.Add(cbKieuTimKiem);
            panel1.Controls.Add(txtTimKiem);
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
            // cbKieuTimKiem
            // 
            cbKieuTimKiem.FormattingEnabled = true;
            cbKieuTimKiem.Items.AddRange(new object[] { "Mã Vi Phạm", "Mã Thành Viên", "Mã Quản Lý" });
            cbKieuTimKiem.Location = new Point(573, 91);
            cbKieuTimKiem.Name = "cbKieuTimKiem";
            cbKieuTimKiem.Size = new Size(151, 28);
            cbKieuTimKiem.TabIndex = 2;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(165, 91);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(368, 27);
            txtTimKiem.TabIndex = 1;
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
        private ComboBox cbKieuTimKiem;
        private TextBox txtTimKiem;
        private Label label1;
    }
}