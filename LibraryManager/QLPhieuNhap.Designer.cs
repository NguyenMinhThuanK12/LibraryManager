namespace LibraryManager
{
    partial class QLPhieuNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnNhapHang = new Button();
            label2 = new Label();
            tbDanhSachPhieuNhap = new TableLayoutPanel();
            cbKieuTimKiem = new ComboBox();
            txtTimKiem = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btnNhapHang);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbDanhSachPhieuNhap);
            panel1.Controls.Add(cbKieuTimKiem);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1303, 850);
            panel1.TabIndex = 5;
            // 
            // btnNhapHang
            // 
            btnNhapHang.BackColor = Color.Lime;
            btnNhapHang.Location = new Point(967, 79);
            btnNhapHang.Name = "btnNhapHang";
            btnNhapHang.Size = new Size(201, 46);
            btnNhapHang.TabIndex = 6;
            btnNhapHang.Text = "Nhập Hàng";
            btnNhapHang.UseVisualStyleBackColor = false;
            btnNhapHang.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(463, 12);
            label2.Name = "label2";
            label2.Size = new Size(421, 60);
            label2.TabIndex = 5;
            label2.Text = "Quản Lý Phiếu Nhập";
            // 
            // tbDanhSachPhieuNhap
            // 
            tbDanhSachPhieuNhap.AutoScroll = true;
            tbDanhSachPhieuNhap.AutoSize = true;
            tbDanhSachPhieuNhap.ColumnCount = 1;
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle());
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachPhieuNhap.Location = new Point(24, 144);
            tbDanhSachPhieuNhap.Name = "tbDanhSachPhieuNhap";
            tbDanhSachPhieuNhap.RowCount = 1;
            tbDanhSachPhieuNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbDanhSachPhieuNhap.Size = new Size(1144, 643);
            tbDanhSachPhieuNhap.TabIndex = 4;
            tbDanhSachPhieuNhap.Paint += tbDanhSachPhieuNhap_Paint;
            // 
            // cbKieuTimKiem
            // 
            cbKieuTimKiem.FormattingEnabled = true;
            cbKieuTimKiem.Items.AddRange(new object[] { "Mã Phiếu Nhập", "Mã Quản Lý" });
            cbKieuTimKiem.Location = new Point(553, 91);
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
            // QLPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QLPhieuNhap";
            Size = new Size(1306, 853);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cbKieuTimKiem;
        private TextBox txtTimKiem;
        private Label label1;
        private TableLayoutPanel tbDanhSachPhieuNhap;
        private Label label2;
        private Button btnNhapHang;
    }
}
