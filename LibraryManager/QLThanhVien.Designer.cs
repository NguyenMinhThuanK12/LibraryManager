namespace LibraryManager
{
    partial class QLThanhVien
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
            pn_QLTV = new Panel();
            lb_QuanLyThanhVien = new Label();
            pn_QLTV2 = new Panel();
            btn_XemLichSu = new Button();
            pn_ViPham_DatCho = new Panel();
            btn_DatCho = new Button();
            btn_ViPham = new Button();
            pn_Button = new Panel();
            btn_NhapExcel = new Button();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            pn_ThongTin = new Panel();
            dateTime_NgaySinh = new DateTimePicker();
            tbox_Email = new TextBox();
            tbox_SoDienThoai = new TextBox();
            tbox_DiaChi = new TextBox();
            tbox_HoTen = new TextBox();
            lb_Email = new Label();
            lb_soDienThoai = new Label();
            lb_DiaChi = new Label();
            lb_Sdt = new Label();
            lb_HoTen = new Label();
            pn_QLTV1 = new Panel();
            pn_TimKiem = new Panel();
            tbox_TimKiem = new TextBox();
            lb_TimKiem = new Label();
            data_Tb_QLTV = new DataGridView();
            maThanhVien = new DataGridViewTextBoxColumn();
            hoTen = new DataGridViewTextBoxColumn();
            ngaySinh = new DataGridViewTextBoxColumn();
            diaChi = new DataGridViewTextBoxColumn();
            sdt = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            ngayDangKy = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            pn_QLTV.SuspendLayout();
            pn_QLTV2.SuspendLayout();
            pn_ViPham_DatCho.SuspendLayout();
            pn_Button.SuspendLayout();
            pn_ThongTin.SuspendLayout();
            pn_QLTV1.SuspendLayout();
            pn_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)data_Tb_QLTV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pn_QLTV);
            panel1.Controls.Add(pn_QLTV2);
            panel1.Controls.Add(pn_QLTV1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 703);
            panel1.TabIndex = 0;
            // 
            // pn_QLTV
            // 
            pn_QLTV.BackColor = Color.FromArgb(255, 128, 128);
            pn_QLTV.Controls.Add(lb_QuanLyThanhVien);
            pn_QLTV.Location = new Point(0, 0);
            pn_QLTV.Name = "pn_QLTV";
            pn_QLTV.Size = new Size(1282, 83);
            pn_QLTV.TabIndex = 5;
            // 
            // lb_QuanLyThanhVien
            // 
            lb_QuanLyThanhVien.AutoSize = true;
            lb_QuanLyThanhVien.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_QuanLyThanhVien.Location = new Point(413, 6);
            lb_QuanLyThanhVien.Name = "lb_QuanLyThanhVien";
            lb_QuanLyThanhVien.Size = new Size(444, 62);
            lb_QuanLyThanhVien.TabIndex = 2;
            lb_QuanLyThanhVien.Text = "Quản Lý Thành Viên";
            lb_QuanLyThanhVien.Click += lb_QuanLyThanhVien_Click;
            // 
            // pn_QLTV2
            // 
            pn_QLTV2.BackColor = Color.FromArgb(224, 224, 224);
            pn_QLTV2.Controls.Add(btn_XemLichSu);
            pn_QLTV2.Controls.Add(pn_ViPham_DatCho);
            pn_QLTV2.Controls.Add(pn_Button);
            pn_QLTV2.Controls.Add(pn_ThongTin);
            pn_QLTV2.Location = new Point(884, 74);
            pn_QLTV2.Name = "pn_QLTV2";
            pn_QLTV2.Size = new Size(398, 629);
            pn_QLTV2.TabIndex = 4;
            // 
            // btn_XemLichSu
            // 
            btn_XemLichSu.BackColor = Color.FromArgb(192, 192, 255);
            btn_XemLichSu.Location = new Point(111, 566);
            btn_XemLichSu.Name = "btn_XemLichSu";
            btn_XemLichSu.Size = new Size(198, 29);
            btn_XemLichSu.TabIndex = 2;
            btn_XemLichSu.Text = "Xem Lịch Sử Mượn Trả";
            btn_XemLichSu.UseVisualStyleBackColor = false;
            btn_XemLichSu.Click += btn_XemLichSu_Click;
            // 
            // pn_ViPham_DatCho
            // 
            pn_ViPham_DatCho.Controls.Add(btn_DatCho);
            pn_ViPham_DatCho.Controls.Add(btn_ViPham);
            pn_ViPham_DatCho.Location = new Point(51, 498);
            pn_ViPham_DatCho.Name = "pn_ViPham_DatCho";
            pn_ViPham_DatCho.Size = new Size(298, 43);
            pn_ViPham_DatCho.TabIndex = 5;
            pn_ViPham_DatCho.Paint += pn_ViPham_DatCho_Paint;
            // 
            // btn_DatCho
            // 
            btn_DatCho.BackColor = Color.FromArgb(255, 128, 128);
            btn_DatCho.Location = new Point(180, 6);
            btn_DatCho.Name = "btn_DatCho";
            btn_DatCho.Size = new Size(94, 29);
            btn_DatCho.TabIndex = 4;
            btn_DatCho.Text = "Đặt Chỗ";
            btn_DatCho.UseVisualStyleBackColor = false;
            btn_DatCho.Click += btn_DatCho_Click;
            // 
            // btn_ViPham
            // 
            btn_ViPham.BackColor = Color.FromArgb(255, 128, 128);
            btn_ViPham.Location = new Point(35, 6);
            btn_ViPham.Name = "btn_ViPham";
            btn_ViPham.Size = new Size(94, 29);
            btn_ViPham.TabIndex = 3;
            btn_ViPham.Text = "Vi Phạm";
            btn_ViPham.UseVisualStyleBackColor = false;
            btn_ViPham.Click += btn_ViPham_Click;
            // 
            // pn_Button
            // 
            pn_Button.Controls.Add(btn_NhapExcel);
            pn_Button.Controls.Add(btn_Sua);
            pn_Button.Controls.Add(btn_Xoa);
            pn_Button.Location = new Point(22, 444);
            pn_Button.Name = "pn_Button";
            pn_Button.Size = new Size(363, 35);
            pn_Button.TabIndex = 1;
            pn_Button.Paint += pn_Button_Paint;
            // 
            // btn_NhapExcel
            // 
            btn_NhapExcel.BackColor = Color.FromArgb(192, 255, 192);
            btn_NhapExcel.Location = new Point(0, 3);
            btn_NhapExcel.Name = "btn_NhapExcel";
            btn_NhapExcel.Size = new Size(94, 29);
            btn_NhapExcel.TabIndex = 3;
            btn_NhapExcel.Text = "Nhập Excel";
            btn_NhapExcel.UseVisualStyleBackColor = false;
            btn_NhapExcel.Click += btn_NhapExcel_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.BackColor = Color.FromArgb(255, 255, 192);
            btn_Sua.Enabled = false;
            btn_Sua.Location = new Point(138, 3);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(94, 29);
            btn_Sua.TabIndex = 1;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = false;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.BackColor = Color.FromArgb(255, 192, 192);
            btn_Xoa.Location = new Point(270, 3);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 29);
            btn_Xoa.TabIndex = 2;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = false;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // pn_ThongTin
            // 
            pn_ThongTin.Controls.Add(dateTime_NgaySinh);
            pn_ThongTin.Controls.Add(tbox_Email);
            pn_ThongTin.Controls.Add(tbox_SoDienThoai);
            pn_ThongTin.Controls.Add(tbox_DiaChi);
            pn_ThongTin.Controls.Add(tbox_HoTen);
            pn_ThongTin.Controls.Add(lb_Email);
            pn_ThongTin.Controls.Add(lb_soDienThoai);
            pn_ThongTin.Controls.Add(lb_DiaChi);
            pn_ThongTin.Controls.Add(lb_Sdt);
            pn_ThongTin.Controls.Add(lb_HoTen);
            pn_ThongTin.Location = new Point(6, 26);
            pn_ThongTin.Name = "pn_ThongTin";
            pn_ThongTin.Size = new Size(379, 381);
            pn_ThongTin.TabIndex = 0;
            // 
            // dateTime_NgaySinh
            // 
            dateTime_NgaySinh.CalendarMonthBackground = Color.WhiteSmoke;
            dateTime_NgaySinh.Location = new Point(138, 93);
            dateTime_NgaySinh.Name = "dateTime_NgaySinh";
            dateTime_NgaySinh.Size = new Size(216, 27);
            dateTime_NgaySinh.TabIndex = 12;
            // 
            // tbox_Email
            // 
            tbox_Email.BackColor = Color.WhiteSmoke;
            tbox_Email.Location = new Point(138, 292);
            tbox_Email.Name = "tbox_Email";
            tbox_Email.Size = new Size(216, 27);
            tbox_Email.TabIndex = 10;
            // 
            // tbox_SoDienThoai
            // 
            tbox_SoDienThoai.BackColor = Color.WhiteSmoke;
            tbox_SoDienThoai.Location = new Point(138, 223);
            tbox_SoDienThoai.Name = "tbox_SoDienThoai";
            tbox_SoDienThoai.Size = new Size(216, 27);
            tbox_SoDienThoai.TabIndex = 9;
            tbox_SoDienThoai.TextChanged += textBox5_TextChanged;
            // 
            // tbox_DiaChi
            // 
            tbox_DiaChi.BackColor = Color.WhiteSmoke;
            tbox_DiaChi.Location = new Point(138, 161);
            tbox_DiaChi.Name = "tbox_DiaChi";
            tbox_DiaChi.Size = new Size(216, 27);
            tbox_DiaChi.TabIndex = 8;
            // 
            // tbox_HoTen
            // 
            tbox_HoTen.BackColor = Color.WhiteSmoke;
            tbox_HoTen.Location = new Point(138, 26);
            tbox_HoTen.Name = "tbox_HoTen";
            tbox_HoTen.Size = new Size(216, 27);
            tbox_HoTen.TabIndex = 6;
            tbox_HoTen.TextChanged += tbox_TenThanhVien_TextChanged;
            // 
            // lb_Email
            // 
            lb_Email.AutoSize = true;
            lb_Email.Location = new Point(23, 292);
            lb_Email.Name = "lb_Email";
            lb_Email.Size = new Size(46, 20);
            lb_Email.TabIndex = 4;
            lb_Email.Text = "Email";
            lb_Email.Click += label6_Click;
            // 
            // lb_soDienThoai
            // 
            lb_soDienThoai.AutoSize = true;
            lb_soDienThoai.Location = new Point(23, 223);
            lb_soDienThoai.Name = "lb_soDienThoai";
            lb_soDienThoai.Size = new Size(39, 20);
            lb_soDienThoai.TabIndex = 3;
            lb_soDienThoai.Text = "SĐT:";
            // 
            // lb_DiaChi
            // 
            lb_DiaChi.AutoSize = true;
            lb_DiaChi.Location = new Point(23, 161);
            lb_DiaChi.Name = "lb_DiaChi";
            lb_DiaChi.Size = new Size(58, 20);
            lb_DiaChi.TabIndex = 2;
            lb_DiaChi.Text = "Địa chỉ:";
            // 
            // lb_Sdt
            // 
            lb_Sdt.AutoSize = true;
            lb_Sdt.Location = new Point(23, 93);
            lb_Sdt.Name = "lb_Sdt";
            lb_Sdt.Size = new Size(79, 20);
            lb_Sdt.TabIndex = 1;
            lb_Sdt.Text = "Ngày Sinh:";
            // 
            // lb_HoTen
            // 
            lb_HoTen.AutoSize = true;
            lb_HoTen.Location = new Point(23, 28);
            lb_HoTen.Name = "lb_HoTen";
            lb_HoTen.Size = new Size(59, 20);
            lb_HoTen.TabIndex = 0;
            lb_HoTen.Text = "Họ Tên:";
            lb_HoTen.Click += lb_TenThanhVien_Click;
            // 
            // pn_QLTV1
            // 
            pn_QLTV1.BackColor = Color.FromArgb(255, 192, 192);
            pn_QLTV1.Controls.Add(pn_TimKiem);
            pn_QLTV1.Controls.Add(data_Tb_QLTV);
            pn_QLTV1.Location = new Point(0, 77);
            pn_QLTV1.Name = "pn_QLTV1";
            pn_QLTV1.Size = new Size(884, 623);
            pn_QLTV1.TabIndex = 3;
            // 
            // pn_TimKiem
            // 
            pn_TimKiem.Controls.Add(tbox_TimKiem);
            pn_TimKiem.Controls.Add(lb_TimKiem);
            pn_TimKiem.Location = new Point(213, 54);
            pn_TimKiem.Name = "pn_TimKiem";
            pn_TimKiem.Size = new Size(407, 38);
            pn_TimKiem.TabIndex = 1;
            // 
            // tbox_TimKiem
            // 
            tbox_TimKiem.BackColor = SystemColors.ButtonFace;
            tbox_TimKiem.Location = new Point(91, 6);
            tbox_TimKiem.Name = "tbox_TimKiem";
            tbox_TimKiem.Size = new Size(313, 27);
            tbox_TimKiem.TabIndex = 1;
            tbox_TimKiem.TextChanged += tbox_TimKiem_TextChanged;
            // 
            // lb_TimKiem
            // 
            lb_TimKiem.AutoSize = true;
            lb_TimKiem.Location = new Point(12, 9);
            lb_TimKiem.Name = "lb_TimKiem";
            lb_TimKiem.Size = new Size(73, 20);
            lb_TimKiem.TabIndex = 0;
            lb_TimKiem.Text = "Tìm kiếm:";
            lb_TimKiem.Click += lb_TimKiem_Click;
            // 
            // data_Tb_QLTV
            // 
            data_Tb_QLTV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_Tb_QLTV.BackgroundColor = Color.FromArgb(255, 192, 192);
            data_Tb_QLTV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_Tb_QLTV.Columns.AddRange(new DataGridViewColumn[] { maThanhVien, hoTen, ngaySinh, diaChi, sdt, email, ngayDangKy });
            data_Tb_QLTV.GridColor = Color.FromArgb(255, 192, 192);
            data_Tb_QLTV.Location = new Point(0, 122);
            data_Tb_QLTV.Name = "data_Tb_QLTV";
            data_Tb_QLTV.ReadOnly = true;
            data_Tb_QLTV.RowHeadersWidth = 51;
            data_Tb_QLTV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data_Tb_QLTV.Size = new Size(884, 504);
            data_Tb_QLTV.TabIndex = 0;
            data_Tb_QLTV.CellContentClick += dataGridView1_CellContentClick;
            data_Tb_QLTV.SelectionChanged += data_Tb_QLTV_SelectionChanged;
            // 
            // maThanhVien
            // 
            maThanhVien.DataPropertyName = "maThanhVien";
            maThanhVien.HeaderText = "MTT";
            maThanhVien.MinimumWidth = 6;
            maThanhVien.Name = "maThanhVien";
            maThanhVien.ReadOnly = true;
            // 
            // hoTen
            // 
            hoTen.DataPropertyName = "hoTen";
            hoTen.HeaderText = "Họ Tên";
            hoTen.MinimumWidth = 6;
            hoTen.Name = "hoTen";
            hoTen.ReadOnly = true;
            // 
            // ngaySinh
            // 
            ngaySinh.DataPropertyName = "ngaySinh";
            ngaySinh.HeaderText = "Ngày Sinh";
            ngaySinh.MinimumWidth = 6;
            ngaySinh.Name = "ngaySinh";
            ngaySinh.ReadOnly = true;
            // 
            // diaChi
            // 
            diaChi.DataPropertyName = "diaChi";
            diaChi.HeaderText = "Địa Chỉ";
            diaChi.MinimumWidth = 6;
            diaChi.Name = "diaChi";
            diaChi.ReadOnly = true;
            // 
            // sdt
            // 
            sdt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            sdt.DataPropertyName = "sdt";
            sdt.HeaderText = "SĐT";
            sdt.MinimumWidth = 6;
            sdt.Name = "sdt";
            sdt.ReadOnly = true;
            sdt.Width = 101;
            // 
            // email
            // 
            email.DataPropertyName = "email";
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // ngayDangKy
            // 
            ngayDangKy.DataPropertyName = "ngayDangKy";
            ngayDangKy.HeaderText = "Ngày Đăng Ký";
            ngayDangKy.MinimumWidth = 6;
            ngayDangKy.Name = "ngayDangKy";
            ngayDangKy.ReadOnly = true;
            // 
            // QLThanhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QLThanhVien";
            Size = new Size(1282, 703);
            panel1.ResumeLayout(false);
            pn_QLTV.ResumeLayout(false);
            pn_QLTV.PerformLayout();
            pn_QLTV2.ResumeLayout(false);
            pn_ViPham_DatCho.ResumeLayout(false);
            pn_Button.ResumeLayout(false);
            pn_ThongTin.ResumeLayout(false);
            pn_ThongTin.PerformLayout();
            pn_QLTV1.ResumeLayout(false);
            pn_TimKiem.ResumeLayout(false);
            pn_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)data_Tb_QLTV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView data_Tb_QLTV;
        private Button btn_Xoa;
        private Button btn_Sua;
        private Panel pn_QLTV1;
        private Panel pn_TimKiem;
        private Label lb_TimKiem;
        private Panel pn_QLTV2;
        private TextBox tbox_TimKiem;
        private Panel pn_ThongTin;
        private Label lb_Sdt;
        private Label lb_HoTen;
        private Label lb_soDienThoai;
        private Label lb_DiaChi;
        private Label lb_Email;
        private TextBox tbox_Email;
        private TextBox tbox_SoDienThoai;
        private TextBox tbox_DiaChi;
        private TextBox tbox_HoTen;
        private Panel pn_Button;
        private DateTimePicker dateTime_NgaySinh;
        private Label lb_QuanLyThanhVien;
        private Panel pn_QLTV;
        private Panel pn_ViPham_DatCho;
        private Button btn_XemLichSu;
        private Button btn_DatCho;
        private Button btn_ViPham;
        private Button btn_NhapExcel;
        private DataGridViewTextBoxColumn maThanhVien;
        private DataGridViewTextBoxColumn hoTen;
        private DataGridViewTextBoxColumn ngaySinh;
        private DataGridViewTextBoxColumn diaChi;
        private DataGridViewTextBoxColumn sdt;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn ngayDangKy;
    }
}