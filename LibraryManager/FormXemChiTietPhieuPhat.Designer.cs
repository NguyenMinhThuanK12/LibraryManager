namespace LibraryManager
{
    partial class FormXemChiTietPhieuPhat
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
            btnXacNhanThanhToan = new Button();
            btnHuy = new Button();
            tbChiTietPhieuPhat = new TableLayoutPanel();
            label2 = new Label();
            lbTongTienPhat = new Label();
            lbMaPhieuPhat = new Label();
            label4 = new Label();
            lbMaPhieuMuon = new Label();
            label6 = new Label();
            lbTenThanhVien = new Label();
            label5 = new Label();
            lbMaThanhVien = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 38);
            label1.TabIndex = 0;
            label1.Text = "Chi Tiết Phiếu Phạt";
            // 
            // btnXacNhanThanhToan
            // 
            btnXacNhanThanhToan.BackColor = Color.Lime;
            btnXacNhanThanhToan.Cursor = Cursors.Hand;
            btnXacNhanThanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhanThanhToan.Location = new Point(590, 462);
            btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            btnXacNhanThanhToan.Size = new Size(223, 50);
            btnXacNhanThanhToan.TabIndex = 11;
            btnXacNhanThanhToan.Text = "Xác Nhận Thanh Toán";
            btnXacNhanThanhToan.UseVisualStyleBackColor = false;
            btnXacNhanThanhToan.Click += button1_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(410, 462);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(174, 50);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Trờ Về";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += button3_Click;
            // 
            // tbChiTietPhieuPhat
            // 
            tbChiTietPhieuPhat.AutoScroll = true;
            tbChiTietPhieuPhat.ColumnCount = 2;
            tbChiTietPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbChiTietPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbChiTietPhieuPhat.Location = new Point(12, 128);
            tbChiTietPhieuPhat.Name = "tbChiTietPhieuPhat";
            tbChiTietPhieuPhat.RowCount = 2;
            tbChiTietPhieuPhat.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbChiTietPhieuPhat.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbChiTietPhieuPhat.Size = new Size(801, 280);
            tbChiTietPhieuPhat.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(547, 426);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 15;
            label2.Text = "Tổng Tiền Phạt :";
            // 
            // lbTongTienPhat
            // 
            lbTongTienPhat.AutoSize = true;
            lbTongTienPhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTongTienPhat.Location = new Point(677, 426);
            lbTongTienPhat.Name = "lbTongTienPhat";
            lbTongTienPhat.Size = new Size(119, 20);
            lbTongTienPhat.TabIndex = 16;
            lbTongTienPhat.Text = "lbTongTienPhat";
            // 
            // lbMaPhieuPhat
            // 
            lbMaPhieuPhat.AutoSize = true;
            lbMaPhieuPhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaPhieuPhat.Location = new Point(424, 94);
            lbMaPhieuPhat.Name = "lbMaPhieuPhat";
            lbMaPhieuPhat.Size = new Size(115, 20);
            lbMaPhieuPhat.TabIndex = 18;
            lbMaPhieuPhat.Text = "lbMaPhieuPhat";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(290, 94);
            label4.Name = "label4";
            label4.Size = new Size(118, 20);
            label4.TabIndex = 17;
            label4.Text = "Mã Phiếu Phạt :";
            // 
            // lbMaPhieuMuon
            // 
            lbMaPhieuMuon.AutoSize = true;
            lbMaPhieuMuon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaPhieuMuon.Location = new Point(424, 61);
            lbMaPhieuMuon.Name = "lbMaPhieuMuon";
            lbMaPhieuMuon.Size = new Size(124, 20);
            lbMaPhieuMuon.TabIndex = 20;
            lbMaPhieuMuon.Text = "lbMaPhieuMuon";
            lbMaPhieuMuon.Click += lbMaPhieuMuon_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(290, 61);
            label6.Name = "label6";
            label6.Size = new Size(128, 20);
            label6.TabIndex = 19;
            label6.Text = "Mã Phiếu Mượn :";
            // 
            // lbTenThanhVien
            // 
            lbTenThanhVien.AutoSize = true;
            lbTenThanhVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTenThanhVien.Location = new Point(146, 94);
            lbTenThanhVien.Name = "lbTenThanhVien";
            lbTenThanhVien.Size = new Size(122, 20);
            lbTenThanhVien.TabIndex = 22;
            lbTenThanhVien.Text = "lbTenThanhVien";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 94);
            label5.Name = "label5";
            label5.Size = new Size(125, 20);
            label5.TabIndex = 21;
            label5.Text = "Tên Thành Viên :";
            // 
            // lbMaThanhVien
            // 
            lbMaThanhVien.AutoSize = true;
            lbMaThanhVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaThanhVien.Location = new Point(146, 61);
            lbMaThanhVien.Name = "lbMaThanhVien";
            lbMaThanhVien.Size = new Size(119, 20);
            lbMaThanhVien.TabIndex = 24;
            lbMaThanhVien.Text = "lbMaThanhVien";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 61);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 23;
            label7.Text = "Mã Thành Viên :";
            // 
            // FormXemChiTietPhieuPhat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 536);
            Controls.Add(lbMaThanhVien);
            Controls.Add(label7);
            Controls.Add(lbTenThanhVien);
            Controls.Add(label5);
            Controls.Add(lbMaPhieuMuon);
            Controls.Add(label6);
            Controls.Add(lbMaPhieuPhat);
            Controls.Add(label4);
            Controls.Add(lbTongTienPhat);
            Controls.Add(label2);
            Controls.Add(tbChiTietPhieuPhat);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhanThanhToan);
            Controls.Add(label1);
            Name = "FormXemChiTietPhieuPhat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Vi Phạm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnXacNhanThanhToan;
        private Button btnHuy;
        private TableLayoutPanel tbChiTietPhieuPhat;
        private Label label2;
        private Label lbTongTienPhat;
        private Label lbMaPhieuPhat;
        private Label label4;
        private Label lbMaPhieuMuon;
        private Label label6;
        private Label lbTenThanhVien;
        private Label label5;
        private Label lbMaThanhVien;
        private Label label7;
    }
}