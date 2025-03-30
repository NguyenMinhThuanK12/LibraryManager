namespace giaodien_nhacungcap_quanlythanhvien
{
    partial class ChiTietNCC
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
            tenNCC = new DataGridViewTextBoxColumn();
            loai = new DataGridViewTextBoxColumn();
            soLuong = new DataGridViewTextBoxColumn();
            donGia = new DataGridViewTextBoxColumn();
            tongTien = new DataGridViewTextBoxColumn();
            ngayNhap = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenNCC, loai, soLuong, donGia, tongTien, ngayNhap });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1282, 703);
            dataGridView1.TabIndex = 0;
            // 
            // tenNCC
            // 
            tenNCC.HeaderText = "Tên Nhà Cung Cấp";
            tenNCC.MinimumWidth = 6;
            tenNCC.Name = "tenNCC";
            // 
            // loai
            // 
            loai.HeaderText = "Loại";
            loai.MinimumWidth = 6;
            loai.Name = "loai";
            // 
            // soLuong
            // 
            soLuong.HeaderText = "Số Lượng";
            soLuong.MinimumWidth = 6;
            soLuong.Name = "soLuong";
            // 
            // donGia
            // 
            donGia.HeaderText = "Đơn Giá";
            donGia.MinimumWidth = 6;
            donGia.Name = "donGia";
            // 
            // tongTien
            // 
            tongTien.HeaderText = "Tổng Tiền";
            tongTien.MinimumWidth = 6;
            tongTien.Name = "tongTien";
            // 
            // ngayNhap
            // 
            ngayNhap.HeaderText = "Ngày Nhập";
            ngayNhap.MinimumWidth = 6;
            ngayNhap.Name = "ngayNhap";
            // 
            // ChiTietNCC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 703);
            Controls.Add(panel1);
            Name = "ChiTietNCC";
            Text = "ChiTietNCC";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tenNCC;
        private DataGridViewTextBoxColumn loai;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn donGia;
        private DataGridViewTextBoxColumn tongTien;
        private DataGridViewTextBoxColumn ngayNhap;
    }
}