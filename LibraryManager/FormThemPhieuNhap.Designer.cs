namespace MinhViLap05
{
    partial class FormThemPhieuNhap
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
            label1 = new Label();
            panel1 = new Panel();
            tbDanhSachSP = new TableLayoutPanel();
            label4 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            txtConLai = new TextBox();
            label12 = new Label();
            btnXoaSP = new Button();
            btnThemSP = new Button();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtThanhTien = new TextBox();
            txtSoLuong = new TextBox();
            txtDonGia = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            cbNhaCungCap = new ComboBox();
            label14 = new Label();
            txtTongGiaTri = new TextBox();
            label13 = new Label();
            btnHuy = new Button();
            btnXacNhan = new Button();
            tbPhieuNhapTam = new TableLayoutPanel();
            label11 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(468, 9);
            label1.Name = "label1";
            label1.Size = new Size(252, 38);
            label1.TabIndex = 0;
            label1.Text = "Thêm Phiếu Nhập";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(tbDanhSachSP);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 671);
            panel1.TabIndex = 1;
            // 
            // tbDanhSachSP
            // 
            tbDanhSachSP.AutoScroll = true;
            tbDanhSachSP.AutoSize = true;
            tbDanhSachSP.ColumnCount = 5;
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbDanhSachSP.Location = new Point(12, 83);
            tbDanhSachSP.Name = "tbDanhSachSP";
            tbDanhSachSP.RowCount = 2;
            tbDanhSachSP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbDanhSachSP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbDanhSachSP.Size = new Size(715, 30);
            tbDanhSachSP.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 46);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 3;
            label4.Text = "Sản Phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(264, 0);
            label2.Name = "label2";
            label2.Size = new Size(182, 31);
            label2.TabIndex = 0;
            label2.Text = "Chọn Sản Phẩm";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(txtConLai);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(btnXoaSP);
            panel2.Controls.Add(btnThemSP);
            panel2.Controls.Add(txtMaSP);
            panel2.Controls.Add(txtTenSP);
            panel2.Controls.Add(txtThanhTien);
            panel2.Controls.Add(txtSoLuong);
            panel2.Controls.Add(txtDonGia);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(752, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(806, 334);
            panel2.TabIndex = 2;
            // 
            // txtConLai
            // 
            txtConLai.Location = new Point(113, 143);
            txtConLai.Name = "txtConLai";
            txtConLai.ReadOnly = true;
            txtConLai.Size = new Size(279, 27);
            txtConLai.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 143);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 13;
            label12.Text = "Còn Lại :";
            // 
            // btnXoaSP
            // 
            btnXoaSP.BackColor = Color.Red;
            btnXoaSP.ForeColor = SystemColors.ButtonFace;
            btnXoaSP.Location = new Point(458, 185);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(133, 42);
            btnXoaSP.TabIndex = 12;
            btnXoaSP.Text = "Xóa";
            btnXoaSP.UseVisualStyleBackColor = false;
            btnXoaSP.Click += btnXoaSP_Click;
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = Color.Lime;
            btnThemSP.Location = new Point(458, 260);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(133, 42);
            btnThemSP.TabIndex = 11;
            btnThemSP.Text = "Thêm";
            btnThemSP.UseVisualStyleBackColor = false;
            btnThemSP.Click += btnThemSP_Click;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(113, 44);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(279, 27);
            txtMaSP.TabIndex = 10;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(113, 93);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.ReadOnly = true;
            txtTenSP.Size = new Size(279, 27);
            txtTenSP.TabIndex = 9;
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(113, 293);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Size = new Size(279, 27);
            txtThanhTien.TabIndex = 8;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(143, 238);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(249, 27);
            txtSoLuong.TabIndex = 7;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(143, 185);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(249, 27);
            txtDonGia.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 293);
            label10.Name = "label10";
            label10.Size = new Size(95, 20);
            label10.TabIndex = 5;
            label10.Text = "Thành Tiền :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 238);
            label9.Name = "label9";
            label9.Size = new Size(125, 20);
            label9.TabIndex = 4;
            label9.Text = "Số Lượng Nhập :";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(12, 185);
            label8.Name = "label8";
            label8.Size = new Size(115, 20);
            label8.TabIndex = 3;
            label8.Text = "Đơn Giá Nhập :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 93);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 2;
            label7.Text = "Tên SP :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 44);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 1;
            label6.Text = "Mã SP :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(323, 5);
            label5.Name = "label5";
            label5.Size = new Size(120, 31);
            label5.TabIndex = 0;
            label5.Text = "Sản Phẩm";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(cbNhaCungCap);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(txtTongGiaTri);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(btnHuy);
            panel3.Controls.Add(btnXacNhan);
            panel3.Controls.Add(tbPhieuNhapTam);
            panel3.Controls.Add(label11);
            panel3.Location = new Point(752, 349);
            panel3.Name = "panel3";
            panel3.Size = new Size(811, 419);
            panel3.TabIndex = 3;
            // 
            // cbNhaCungCap
            // 
            cbNhaCungCap.FormattingEnabled = true;
            cbNhaCungCap.Location = new Point(133, 336);
            cbNhaCungCap.Name = "cbNhaCungCap";
            cbNhaCungCap.Size = new Size(278, 28);
            cbNhaCungCap.TabIndex = 0;
            cbNhaCungCap.SelectedIndexChanged += cbNhaCungCap_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(11, 336);
            label14.Name = "label14";
            label14.Size = new Size(116, 20);
            label14.TabIndex = 16;
            label14.Text = "Nhà Cung Cấp :";
            // 
            // txtTongGiaTri
            // 
            txtTongGiaTri.Location = new Point(132, 377);
            txtTongGiaTri.Name = "txtTongGiaTri";
            txtTongGiaTri.ReadOnly = true;
            txtTongGiaTri.Size = new Size(279, 27);
            txtTongGiaTri.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(11, 380);
            label13.Name = "label13";
            label13.Size = new Size(102, 20);
            label13.TabIndex = 14;
            label13.Text = "Tổng Giá Trị :";
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.ForeColor = SystemColors.ButtonFace;
            btnHuy.Location = new Point(470, 336);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(133, 42);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click_1;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Lime;
            btnXacNhan.Location = new Point(637, 336);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(133, 42);
            btnXacNhan.TabIndex = 12;
            btnXacNhan.Text = "Xác Nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click_1;
            // 
            // tbPhieuNhapTam
            // 
            tbPhieuNhapTam.ColumnCount = 2;
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbPhieuNhapTam.Location = new Point(11, 41);
            tbPhieuNhapTam.Name = "tbPhieuNhapTam";
            tbPhieuNhapTam.RowCount = 2;
            tbPhieuNhapTam.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbPhieuNhapTam.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbPhieuNhapTam.Size = new Size(793, 279);
            tbPhieuNhapTam.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(340, 0);
            label11.Name = "label11";
            label11.Size = new Size(139, 31);
            label11.TabIndex = 1;
            label11.Text = "Phiếu Nhập";
            // 
            // FormThemPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1575, 780);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FormThemPhieuNhap";
            Text = "Form Thêm Phiếu Nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tbDanhSachSP;
        private Label label4;
        private ComboBox cbChonNCC;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Label label5;
        private Panel panel3;
        private Button btnXoaSP;
        private Button btnThemSP;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtThanhTien;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label11;
        private Button btnHuy;
        private Button btnXacNhan;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox1;
        private Label label12;
        private TextBox txtConLai;
        private TableLayoutPanel tbPhieuNhapTam;
        private TextBox txtTongGiaTri;
        private Label label13;
        private Label label14;
        private ComboBox cbNhaCungCap;
    }
}