using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace LibraryManager
{
    partial class QLmotTv
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


        private void LoadDataToGrid()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.");
                        return;
                    }



                    string query = "SELECT b1.HoTen, b2.MaPhieu, b2.MaThanhVien, b2.MaSanPham, b2.SoLuong, " +
                   "b2.ThoiGianDat, b2.ThoiGianMuonDuKien, b2.TrangThaiDat " +
                   "FROM thanhvien b1 " +
                   "JOIN phieudatcho b2 ON b1.MaThanhVien = b2.MaThanhVien ";

                    if (!string.IsNullOrEmpty(hoTen1))
                    {
                        query += "WHERE b1.HoTen = @HoTen1";
                    }

                   
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Dùng để chuẩn bị và thực thi câu SQL
                        {
                            if (!string.IsNullOrEmpty(hoTen1))
                            {
                                cmd.Parameters.AddWithValue("@HoTen1", hoTen1);// Truyền giá trị vào biến trong SQL
                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); // là cầu nối giữa cơ sở dữ liệu và chương trình của bạn.
                            DataTable dt = new DataTable();// tạo bảng chứa csdl 
                            adapter.Fill(dt); //Dòng này thực thi câu lệnh SQL (qua cmd)
                            tableDatCho.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chi tiết lỗi:\n" + ex.ToString());
            }
        }



        private void QLDatCho_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            dtpThoiGian = new DateTimePicker();
            cbTrangThai = new ComboBox();
            txtSoLuong = new TextBox();
            txtMaThanhVien = new TextBox();
            txtMaPhieu = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            tableDatCho = new DataGridView();
            panel4 = new Panel();
            button5 = new Button();
            search = new TextBox();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableDatCho).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.IndianRed;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1210, 73);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 15);
            label1.Name = "label1";
            label1.Size = new Size(123, 38);
            label1.TabIndex = 0;
            label1.Text = "Đặt Chỗ";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(dtpThoiGian);
            panel2.Controls.Add(cbTrangThai);
            panel2.Controls.Add(txtSoLuong);
            panel2.Controls.Add(txtMaThanhVien);
            panel2.Controls.Add(txtMaPhieu);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 573);
            panel2.TabIndex = 1;
            // 
            // dtpThoiGian
            // 
            dtpThoiGian.Location = new Point(53, 276);
            dtpThoiGian.Name = "dtpThoiGian";
            dtpThoiGian.Size = new Size(239, 27);
            dtpThoiGian.TabIndex = 12;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Đang xử lý", "Đã xác nhận", "Đã hủy" });
            cbTrangThai.Location = new Point(104, 337);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(151, 28);
            cbTrangThai.TabIndex = 11;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(96, 184);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(196, 27);
            txtSoLuong.TabIndex = 8;
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Location = new Point(96, 131);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.ReadOnly = true;
            txtMaThanhVien.Size = new Size(196, 27);
            txtMaThanhVien.TabIndex = 7;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Location = new Point(96, 75);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.ReadOnly = true;
            txtMaPhieu.Size = new Size(196, 27);
            txtMaPhieu.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 336);
            label7.Name = "label7";
            label7.Size = new Size(98, 25);
            label7.TabIndex = 5;
            label7.Text = "Trạng Thái";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(-3, 237);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 4;
            label6.Text = "TG dự kiến";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 186);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 2;
            label4.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 131);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 1;
            label3.Text = "Ma Tv";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 80);
            label2.Name = "label2";
            label2.Size = new Size(71, 22);
            label2.TabIndex = 0;
            label2.Text = "MaPhieu";
            // 
            // panel3
            // 
            panel3.Controls.Add(tableDatCho);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(300, 73);
            panel3.Name = "panel3";
            panel3.Size = new Size(910, 573);
            panel3.TabIndex = 2;
            // 
            // tableDatCho
            // 
            tableDatCho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableDatCho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableDatCho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableDatCho.Location = new Point(0, 3);
            tableDatCho.Name = "tableDatCho";
            tableDatCho.RowHeadersWidth = 51;
            tableDatCho.Size = new Size(892, 427);
            tableDatCho.TabIndex = 4;
            tableDatCho.CellClick += tableDatCho_CellContentClick;
            tableDatCho.CellContentClick += tableDatCho_CellContentClick;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel4.Controls.Add(button5);
            panel4.Controls.Add(search);
            panel4.Controls.Add(button4);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Location = new Point(-18, 433);
            panel4.Name = "panel4";
            panel4.Size = new Size(928, 140);
            panel4.TabIndex = 3;
            // 
            // button5
            // 
            button5.AccessibleRole = AccessibleRole.Grip;
            button5.BackColor = Color.Cyan;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(343, 72);
            button5.Name = "button5";
            button5.Size = new Size(109, 39);
            button5.TabIndex = 5;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // search
            // 
            search.Location = new Point(458, 78);
            search.Name = "search";
            search.Size = new Size(144, 27);
            search.TabIndex = 4;
            // 
            // button4
            // 
            button4.BackColor = Color.Cyan;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(625, 72);
            button4.Name = "button4";
            button4.Size = new Size(114, 37);
            button4.TabIndex = 3;
            button4.Text = "Cập Nhật";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Cyan;
            button2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(195, 74);
            button2.Name = "button2";
            button2.Size = new Size(128, 37);
            button2.TabIndex = 1;
            button2.Text = "Hủy Đặt Chỗ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Cyan;
            button1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(32, 72);
            button1.Name = "button1";
            button1.Size = new Size(147, 37);
            button1.TabIndex = 0;
            button1.Text = "Xem Danh Sách";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // QLmotTv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 646);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "QLmotTv";
            Load += QLDatCho_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableDatCho).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView tableDatCho;
        private Panel panel4;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtSoLuong;
        private TextBox txtMaThanhVien;
        private TextBox txtMaPhieu;
        private Button button4;
        private Button button2;
        private Button button1;
        private Button button5;
        private TextBox search;
        private DateTimePicker dtpThoiGian;
        private ComboBox cbTrangThai;

    }
}
