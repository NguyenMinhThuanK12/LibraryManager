namespace giaodien_nhacungcap_quanlythanhvien
{
    partial class QuanLyNhaCungCap
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
            btn_Xoa = new Button();
            btn_Sua = new Button();
            btn_Them = new Button();
            dataGridView1 = new DataGridView();
            maNCC = new DataGridViewTextBoxColumn();
            tenNCC = new DataGridViewTextBoxColumn();
            diaChi = new DataGridViewTextBoxColumn();
            soDienThoai = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            linhVucCungCap = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Xoa);
            panel1.Controls.Add(btn_Sua);
            panel1.Controls.Add(btn_Them);
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 703);
            panel1.TabIndex = 0;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(1148, 645);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 29);
            btn_Xoa.TabIndex = 3;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.Location = new Point(1018, 645);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(94, 29);
            btn_Sua.TabIndex = 2;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_Them
            // 
            btn_Them.Location = new Point(891, 645);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(94, 29);
            btn_Them.TabIndex = 1;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            btn_Them.Click += btn_Them_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { maNCC, tenNCC, diaChi, soDienThoai, email, linhVucCungCap });
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1282, 616);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // maNCC
            // 
            maNCC.HeaderText = "Mã nhà cung cấp";
            maNCC.MinimumWidth = 6;
            maNCC.Name = "maNCC";
            // 
            // tenNCC
            // 
            tenNCC.HeaderText = "Tên Nhà Cung Cấp";
            tenNCC.MinimumWidth = 6;
            tenNCC.Name = "tenNCC";
            // 
            // diaChi
            // 
            diaChi.HeaderText = "Địa Chỉ";
            diaChi.MinimumWidth = 6;
            diaChi.Name = "diaChi";
            // 
            // soDienThoai
            // 
            soDienThoai.HeaderText = "Số Điện Thoại";
            soDienThoai.MinimumWidth = 6;
            soDienThoai.Name = "soDienThoai";
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            // 
            // linhVucCungCap
            // 
            linhVucCungCap.HeaderText = "Lĩnh Vực Cung Cấp";
            linhVucCungCap.MinimumWidth = 6;
            linhVucCungCap.Name = "linhVucCungCap";
            // 
            // QuanLyNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 703);
            Controls.Add(panel1);
            Name = "QuanLyNhaCungCap";
            Text = "QuanLyNhaCungCap";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn maNCC;
        private DataGridViewTextBoxColumn tenNCC;
        private DataGridViewTextBoxColumn diaChi;
        private DataGridViewTextBoxColumn soDienThoai;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn linhVucCungCap;
        private Button btn_Xoa;
        private Button btn_Sua;
        private Button btn_Them;
    }
}
