using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryManager
{
    partial class ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox txtProductName; // Thay 'cboKhoa' thành 'cboThietBi'
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabThanhVien;
        private System.Windows.Forms.TabPage tabThietBiMuon;
        private System.Windows.Forms.TabPage tabDangMuon;
        private System.Windows.Forms.DataGridView dgvThanhVien;
        private System.Windows.Forms.DataGridView dgvThietBiMuon;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3; // Tên thiết bị
        private System.Windows.Forms.Label label4; // Tên thiết bị

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadDataToThanhVienGrid()
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

                    // Lấy giá trị ngày bắt đầu và kết thúc
                    string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
                    string endDate = dtpEnd.Value.ToString("yyyy-MM-dd");

                    // Thêm điều kiện lọc ngày đăng ký vào câu truy vấn SQL
                    string query = "SELECT * FROM thanhvien WHERE NgayDangKy BETWEEN @startDate AND @endDate";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    // Thêm tham số cho câu lệnh SQL
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvThanhVien.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu thành viên:\n" + ex.Message);
            }
        }

        private void LoadDataToThietBiMuonGrid()
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

                    // Lấy giá trị từ DateTimePicker
                    DateTime startDate = dtpStart.Value;
                    DateTime endDate = dtpEnd.Value;

                    // Lấy giá trị tên sản phẩm từ TextBox
                    string productName = txtProductName.Text.Trim(); // Loại bỏ khoảng trắng thừa

                    // Truy vấn SQL với JOIN giữa ba bảng PhieuMuon, ChiTietPhieuMuon và SanPham
                    string query = "SELECT pm.MaPhieuMuon, sp.TenSanPham, ctp.SoLuong, ctp.TienCocMuon, ctp.GiaMuon,pm.TrangThaiMuon " +
                                   "FROM ChiTietPhieuMuon ctp " +
                                   "JOIN PhieuMuon pm ON ctp.MaPhieuMuon = pm.MaPhieuMuon " +
                                   "JOIN SanPham sp ON ctp.MaSanPham = sp.MaSanPham " +
                                   "WHERE pm.TrangThaiMuon = 'Đang mượn' " +
                                   "AND pm.NgayMuon BETWEEN @startDate AND @endDate " +  // Lọc theo ngày mượn
                                   "AND sp.TenSanPham LIKE @productName";  // Lọc theo tên sản phẩm

                    // Tạo MySqlDataAdapter và thêm tham số
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@productName", "%" + productName + "%"); // Tên sản phẩm từ TextBox

                    // Tạo DataTable và điền dữ liệu từ câu lệnh SQL
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Gán dữ liệu vào DataGridView
                    dgvThietBiMuon.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu thiết bị mượn:\n" + ex.Message);
            }
        }


        private void LoadDataToDangMuonGrid()
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

                    // Lấy giá trị từ DateTimePicker
                    DateTime startDate = dtpStart.Value;
                    DateTime endDate = dtpEnd.Value;

                    // Lấy tên sản phẩm từ ComboBox
                    string productName = txtProductName.Text.Trim();

                    // Truy vấn dữ liệu các thiết bị đã trả
                    string query = "SELECT pm.MaPhieuMuon, sp.TenSanPham, ctp.SoLuong, ctp.TienCocMuon, ctp.GiaMuon,pm.TrangThaiMuon " +
                                   "FROM ChiTietPhieuMuon ctp " +
                                   "JOIN PhieuMuon pm ON ctp.MaPhieuMuon = pm.MaPhieuMuon " +
                                   "JOIN SanPham sp ON ctp.MaSanPham = sp.MaSanPham " +
                                   "WHERE pm.TrangThaiMuon = 'Đã trả' " +
                                   "AND pm.NgayMuon BETWEEN @startDate AND @endDate " +
                                   "AND sp.TenSanPham LIKE @productName";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@productName", "%" + productName + "%");

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvThietBiMuon.DataSource = table; // hoặc dgvDaTra nếu bạn dùng DataGridView riêng cho đã trả
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu thiết bị đã trả:\n" + ex.Message);
            }
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            LoadDataToThanhVienGrid();
            LoadDataToThietBiMuonGrid();
            LoadDataToDangMuonGrid();
        }
        private void LoadProductNamesToComboBox()
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

                    string query = "SELECT TenSanPham FROM SanPham";  // Truy vấn lấy tên sản phẩm

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Clear ComboBox trước khi thêm
                    txtProductName.Items.Clear();

                    // Thêm tên sản phẩm vào ComboBox
                    foreach (DataRow row in table.Rows)
                    {
                        txtProductName.Items.Add(row["TenSanPham"].ToString());
                    }

                    // Nếu có ít nhất một sản phẩm, chọn sản phẩm đầu tiên
                    if (txtProductName.Items.Count > 0)
                    {
                        txtProductName.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tên sản phẩm vào ComboBox:\n" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductNamesToComboBox();
        }


        private void InitializeComponent()
        {
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            txtProductName = new ComboBox();
            btnThongKe = new Button();
            tabControl = new TabControl();
            tabThanhVien = new TabPage();
            dgvThanhVien = new DataGridView();
            tabThietBiMuon = new TabPage();
            dgvThietBiMuon = new DataGridView();
            tabDangMuon = new TabPage();
            dgvDangMuon = new DataGridView();
            groupBoxFilter = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tabControl.SuspendLayout();
            tabThanhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThanhVien).BeginInit();
            tabThietBiMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThietBiMuon).BeginInit();
            tabDangMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDangMuon).BeginInit();
            groupBoxFilter.SuspendLayout();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(10, 50);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(204, 30);
            dtpStart.TabIndex = 0;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(220, 50);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(208, 30);
            dtpEnd.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(493, 49);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(121, 31);
            txtProductName.TabIndex = 2;
            txtProductName.SelectedIndexChanged += txtProductName_SelectedIndexChanged;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.FromArgb(0, 123, 255);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(786, 29);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(105, 33);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click_1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabThanhVien);
            tabControl.Controls.Add(tabThietBiMuon);
            tabControl.Controls.Add(tabDangMuon);
            tabControl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabControl.Location = new Point(20, 96);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(928, 463);
            tabControl.TabIndex = 1;
            // 
            // tabThanhVien
            // 
            tabThanhVien.Controls.Add(dgvThanhVien);
            tabThanhVien.Location = new Point(4, 29);
            tabThanhVien.Name = "tabThanhVien";
            tabThanhVien.Size = new Size(920, 430);
            tabThanhVien.TabIndex = 0;
            tabThanhVien.Text = "📚 Thành viên học tập";
            // 
            // dgvThanhVien
            // 
            dgvThanhVien.BackgroundColor = Color.WhiteSmoke;
            dgvThanhVien.BorderStyle = BorderStyle.Fixed3D;
            dgvThanhVien.ColumnHeadersHeight = 29;
            dgvThanhVien.Dock = DockStyle.Fill;
            dgvThanhVien.Location = new Point(0, 0);
            dgvThanhVien.Name = "dgvThanhVien";
            dgvThanhVien.RowHeadersWidth = 51;
            dgvThanhVien.Size = new Size(920, 430);
            dgvThanhVien.TabIndex = 0;
            dgvThanhVien.CellContentClick += dgvThanhVien_CellContentClick;
            // 
            // tabThietBiMuon
            // 
            tabThietBiMuon.Controls.Add(dgvThietBiMuon);
            tabThietBiMuon.Location = new Point(4, 29);
            tabThietBiMuon.Name = "tabThietBiMuon";
            tabThietBiMuon.Size = new Size(920, 430);
            tabThietBiMuon.TabIndex = 1;
            tabThietBiMuon.Text = "📦 Thiết bị đã mượn";
            // 
            // dgvThietBiMuon
            // 
            dgvThietBiMuon.BackgroundColor = Color.WhiteSmoke;
            dgvThietBiMuon.BorderStyle = BorderStyle.Fixed3D;
            dgvThietBiMuon.ColumnHeadersHeight = 29;
            dgvThietBiMuon.Dock = DockStyle.Fill;
            dgvThietBiMuon.Location = new Point(0, 0);
            dgvThietBiMuon.Name = "dgvThietBiMuon";
            dgvThietBiMuon.RowHeadersWidth = 51;
            dgvThietBiMuon.Size = new Size(920, 430);
            dgvThietBiMuon.TabIndex = 0;
            // 
            // tabDangMuon
            // 
            tabDangMuon.Controls.Add(dgvDangMuon);
            tabDangMuon.Location = new Point(4, 29);
            tabDangMuon.Name = "tabDangMuon";
            tabDangMuon.Size = new Size(920, 430);
            tabDangMuon.TabIndex = 2;
            tabDangMuon.Text = "🔄 Thiết bị đang mượn";
            // 
            // dgvDangMuon
            // 
            dgvDangMuon.BackgroundColor = Color.WhiteSmoke;
            dgvDangMuon.BorderStyle = BorderStyle.Fixed3D;
            dgvDangMuon.ColumnHeadersHeight = 29;
            dgvDangMuon.Dock = DockStyle.Fill;
            dgvDangMuon.Location = new Point(0, 0);
            dgvDangMuon.Name = "dgvDangMuon";
            dgvDangMuon.RowHeadersWidth = 51;
            dgvDangMuon.Size = new Size(920, 430);
            dgvDangMuon.TabIndex = 0;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(dtpStart);
            groupBoxFilter.Controls.Add(dtpEnd);
            groupBoxFilter.Controls.Add(txtProductName);
            groupBoxFilter.Controls.Add(btnThongKe);
            groupBoxFilter.Controls.Add(label1);
            groupBoxFilter.Controls.Add(label2);
            groupBoxFilter.Controls.Add(label3);
            groupBoxFilter.Controls.Add(label4);
            groupBoxFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilter.Location = new Point(20, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(940, 80);
            groupBoxFilter.TabIndex = 0;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Bộ lọc thống kê";
            // 
            // label1
            // 
            label1.Location = new Point(10, 24);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            label2.Location = new Point(220, 24);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "Đến ngày:";
            // 
            // label3
            // 
            label3.Location = new Point(493, 24);
            label3.Name = "label3";
            label3.Size = new Size(133, 23);
            label3.TabIndex = 7;
            label3.Text = "Tên thiết bị:";
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(10, 23);
            label4.TabIndex = 8;
            // 
            // ThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBoxFilter);
            Controls.Add(tabControl);
            Name = "ThongKe";
            Size = new Size(960, 575);
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabThanhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThanhVien).EndInit();
            tabThietBiMuon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThietBiMuon).EndInit();
            tabDangMuon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDangMuon).EndInit();
            groupBoxFilter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
