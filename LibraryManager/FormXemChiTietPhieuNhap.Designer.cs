namespace LibraryManager
{
    partial class FormXemChiTietPhieuNhap
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
            panel3 = new Panel();
            lbThoiGian = new Label();
            label2 = new Label();
            txtNhaCungCap = new TextBox();
            label1 = new Label();
            label14 = new Label();
            txtTongGiaTri = new TextBox();
            label13 = new Label();
            btnXacNhan = new Button();
            tbChiTietPhieuNhap = new TableLayoutPanel();
            label11 = new Label();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(lbThoiGian);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtNhaCungCap);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(txtTongGiaTri);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(btnXacNhan);
            panel3.Controls.Add(tbChiTietPhieuNhap);
            panel3.Controls.Add(label11);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(890, 458);
            panel3.TabIndex = 4;
            panel3.Paint += panel3_Paint;
            // 
            // lbThoiGian
            // 
            lbThoiGian.AutoSize = true;
            lbThoiGian.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThoiGian.Location = new Point(259, 39);
            lbThoiGian.Name = "lbThoiGian";
            lbThoiGian.Size = new Size(0, 23);
            lbThoiGian.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 39);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 19;
            label2.Text = "Thời Gian :";
            // 
            // txtNhaCungCap
            // 
            txtNhaCungCap.Location = new Point(143, 373);
            txtNhaCungCap.Name = "txtNhaCungCap";
            txtNhaCungCap.ReadOnly = true;
            txtNhaCungCap.Size = new Size(279, 27);
            txtNhaCungCap.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 71);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 17;
            label1.Text = "Sản Phẩm :";
            label1.Click += label1_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(21, 373);
            label14.Name = "label14";
            label14.Size = new Size(116, 20);
            label14.TabIndex = 16;
            label14.Text = "Nhà Cung Cấp :";
            // 
            // txtTongGiaTri
            // 
            txtTongGiaTri.Location = new Point(142, 414);
            txtTongGiaTri.Name = "txtTongGiaTri";
            txtTongGiaTri.ReadOnly = true;
            txtTongGiaTri.Size = new Size(279, 27);
            txtTongGiaTri.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(21, 417);
            label13.Name = "label13";
            label13.Size = new Size(102, 20);
            label13.TabIndex = 14;
            label13.Text = "Tổng Giá Trị :";
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Lime;
            btnXacNhan.Cursor = Cursors.Hand;
            btnXacNhan.Location = new Point(719, 395);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(133, 42);
            btnXacNhan.TabIndex = 12;
            btnXacNhan.Text = "Trở Về";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // tbChiTietPhieuNhap
            // 
            tbChiTietPhieuNhap.AutoScroll = true;
            tbChiTietPhieuNhap.ColumnCount = 2;
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbChiTietPhieuNhap.Location = new Point(11, 94);
            tbChiTietPhieuNhap.Name = "tbChiTietPhieuNhap";
            tbChiTietPhieuNhap.RowCount = 2;
            tbChiTietPhieuNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbChiTietPhieuNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbChiTietPhieuNhap.Size = new Size(872, 260);
            tbChiTietPhieuNhap.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(391, 0);
            label11.Name = "label11";
            label11.Size = new Size(139, 31);
            label11.TabIndex = 1;
            label11.Text = "Phiếu Nhập";
            // 
            // FormXemChiTietPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 482);
            Controls.Add(panel3);
            Name = "FormXemChiTietPhieuNhap";
            Text = "Chi Tiết Phiếu Nhập";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private Panel panel3;
        private Button btnHuy;
        private Button btnXacNhan;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label11;
        private TextBox textBox1;
        private Label label1;
        private Label label14;
        private TextBox txtTongGiaTri;
        private Label label13;
        private TableLayoutPanel tbPhieuNhapTam;
        private TextBox txtNhaCungCap;
        private TableLayoutPanel tbChiTietPhieuNhap;
        private Label lbThoiGian;
        private Label label2;
    }
}