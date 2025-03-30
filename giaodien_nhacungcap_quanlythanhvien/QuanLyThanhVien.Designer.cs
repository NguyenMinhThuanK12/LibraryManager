namespace giaodien_nhacungcap_quanlythanhvien
{
    partial class QuanLyThanhVien
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
            dataGridView1 = new DataGridView();
            stt = new DataGridViewTextBoxColumn();
            tenThanhVien = new DataGridViewTextBoxColumn();
            sdt = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            tenTaiKhoan = new DataGridViewTextBoxColumn();
            viPham = new DataGridViewTextBoxColumn();
            trangThai = new DataGridViewTextBoxColumn();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Xoa);
            panel1.Controls.Add(btn_Sua);
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 703);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { stt, tenThanhVien, sdt, email, tenTaiKhoan, viPham, trangThai });
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1282, 597);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // stt
            // 
            stt.HeaderText = "STT";
            stt.MinimumWidth = 6;
            stt.Name = "stt";
            // 
            // tenThanhVien
            // 
            tenThanhVien.HeaderText = "Tên Thành Viên";
            tenThanhVien.MinimumWidth = 6;
            tenThanhVien.Name = "tenThanhVien";
            // 
            // sdt
            // 
            sdt.HeaderText = "Số Điện Thoại";
            sdt.MinimumWidth = 6;
            sdt.Name = "sdt";
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            // 
            // tenTaiKhoan
            // 
            tenTaiKhoan.HeaderText = "Tên Tài Khoản";
            tenTaiKhoan.MinimumWidth = 6;
            tenTaiKhoan.Name = "tenTaiKhoan";
            // 
            // viPham
            // 
            viPham.HeaderText = "Vi Phạm";
            viPham.MinimumWidth = 6;
            viPham.Name = "viPham";
            // 
            // trangThai
            // 
            trangThai.HeaderText = "Trạng Thái";
            trangThai.MinimumWidth = 6;
            trangThai.Name = "trangThai";
            // 
            // btn_Sua
            // 
            btn_Sua.Location = new Point(971, 636);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(94, 29);
            btn_Sua.TabIndex = 1;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(1117, 636);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 29);
            btn_Xoa.TabIndex = 2;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // QuanLyThanhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 703);
            Controls.Add(panel1);
            Name = "QuanLyThanhVien";
            Text = "QuanLyThanhVien";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn tenThanhVien;
        private DataGridViewTextBoxColumn sdt;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn tenTaiKhoan;
        private DataGridViewTextBoxColumn viPham;
        private DataGridViewTextBoxColumn trangThai;
        private Button btn_Xoa;
        private Button btn_Sua;
    }
}