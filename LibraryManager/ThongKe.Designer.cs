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
        private System.Windows.Forms.DataGridView dgvDaTra;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3; // Tên thiết bị
        private System.Windows.Forms.Label label4; // Tên thiết bị
        private Label lblSoLuotVao; 
        private Label lblSoThanhVien;
        private Label lblSoLuongDaMuon;
        private Label lblSoLuongDangMuon;
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
    string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
    string endDate = dtpEnd.Value.ToString("yyyy-MM-dd");

    try
    {
        // ✅ PHẦN 1: Load dữ liệu chi tiết vào bảng
        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        {
            string query = @"
                SELECT tv.MaThanhVien, tv.HoTen, tv.NgaySinh, tv.DiaChi, tv.SDT, tv.Email, ck.thoiGianVao 
                FROM checkin ck
                JOIN thanhvien tv ON ck.MaThanhVien = tv.MaThanhVien
                WHERE DATE(ck.thoiGianVao) BETWEEN @startDate AND @endDate
                ORDER BY ck.thoiGianVao DESC
            ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
            adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvThanhVien.DataSource = table;
            dgvThanhVien.Columns["MaThanhVien"].HeaderText = "Mã thành viên";
            dgvThanhVien.Columns["HoTen"].HeaderText = "Họ tên";
            dgvThanhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvThanhVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvThanhVien.Columns["SDT"].HeaderText = "SĐT";
            dgvThanhVien.Columns["Email"].HeaderText = "Email";
            dgvThanhVien.Columns["thoiGianVao"].HeaderText = "Thời gian vào";
        }

                int tongLuotVao = 0;
                HashSet<string> maTVSet = new HashSet<string>();

                foreach (DataGridViewRow row in dgvThanhVien.Rows)
                {
                    // Chỉ tính dòng nếu có dữ liệu
                    if (row.Cells["MaThanhVien"].Value != null && !row.IsNewRow)
                    {
                        tongLuotVao++; // Đếm dòng thực
                        string maTV = row.Cells["MaThanhVien"].Value.ToString();
                        maTVSet.Add(maTV);
                    }
                }

                int tongThanhVien = maTVSet.Count;
                lblSoLuotVao.Text = $"Tổng số lượt vào: {tongLuotVao}";
                lblSoThanhVien.Text = $"Tổng số thành viên: {tongThanhVien}";
            }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi khi load dữ liệu thành viên:\n" + ex.Message);
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

                    DateTime startDate = dtpStart.Value;
                    DateTime endDate = dtpEnd.Value;
                    string productName = txtProductName.Text.Trim();

                    // Câu truy vấn có thêm điều kiện sp.TrangThai = 'active'
                    string query = "SELECT pm.MaPhieuMuon, sp.TenSanPham, ctp.SoLuong, ctp.TienCocMuon, ctp.GiaMuon, pm.TrangThaiMuon " +
                                   "FROM ChiTietPhieuMuon ctp " +
                                   "JOIN PhieuMuon pm ON ctp.MaPhieuMuon = pm.MaPhieuMuon " +
                                   "JOIN SanPham sp ON ctp.MaSanPham = sp.MaSanPham " +
                                   "WHERE pm.TrangThaiMuon = 'Chưa Trả' " +
                                   "AND pm.NgayMuon BETWEEN @startDate AND @endDate " +
                                   "AND sp.TrangThai = 'active' ";

                    if (productName != "Tất cả")
                    {
                        query += "AND sp.TenSanPham LIKE @productName ";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    if (productName != "Tất cả")
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@productName", "%" + productName + "%");
                    }

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvDangMuon.DataSource = table;
                    //  Tính tổng số lượng
                    int tongSoLuong = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        if (int.TryParse(row["SoLuong"].ToString(), out int sl))
                        {
                            tongSoLuong += sl;
                        }
                    }

                    lblSoLuongDangMuon.Text = $"Tổng số thiết bị đang mượn: {tongSoLuong}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu thiết bị đang mượn:\n" + ex.Message);
            }
        }



        private void LoadDataToDaTraGrid()
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

                    DateTime startDate = dtpStart.Value;
                    DateTime endDate = dtpEnd.Value;
                    string productName = txtProductName.Text.Trim();

                    string query = "SELECT pm.MaPhieuMuon, sp.TenSanPham, ctp.SoLuong, ctp.TienCocMuon, ctp.GiaMuon, pm.TrangThaiMuon " +
                       "FROM ChiTietPhieuMuon ctp " +
                       "JOIN PhieuMuon pm ON ctp.MaPhieuMuon = pm.MaPhieuMuon " +
                       "JOIN SanPham sp ON ctp.MaSanPham = sp.MaSanPham " +
                       "WHERE pm.TrangThaiMuon = 'Đã trả' " +
                       "AND pm.NgayMuon BETWEEN @startDate AND @endDate " +
                       "AND sp.TrangThai = 'active'";

                    //  Nếu KHÔNG chọn "Tất cả", thêm điều kiện lọc theo tên sản phẩm
                    if (productName != "Tất cả")
                    {
                        query += "AND sp.TenSanPham LIKE @productName";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    if (productName != "Tất cả")
                        adapter.SelectCommand.Parameters.AddWithValue("@productName", "%" + productName + "%");

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvDaTra.DataSource = table;

                    //  Tính tổng số lượng
                    int tongSoLuong = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        if (int.TryParse(row["SoLuong"].ToString(), out int sl))
                        {
                            tongSoLuong += sl;
                        }
                    }

                    lblSoLuongDaMuon.Text = $"Tổng số thiết bị đã mượn: {tongSoLuong}";
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
            LoadDataToDaTraGrid();
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

                    string query = "SELECT TenSanPham FROM SanPham WHERE TrangThai = 'active'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    txtProductName.Items.Clear();

                    //  Thêm mục "Tất cả" lên đầu
                    txtProductName.Items.Add("Tất cả");

                    foreach (DataRow row in table.Rows)
                    {
                        txtProductName.Items.Add(row["TenSanPham"].ToString());
                    }

                    // Chọn "Tất cả" làm mặc định
                    txtProductName.SelectedIndex = 0;
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
            dgvDaTra = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dgvDaTra).BeginInit();
            tabDangMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDangMuon).BeginInit();
            groupBoxFilter.SuspendLayout();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(10, 50);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(258, 30);
            dtpStart.TabIndex = 0;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(299, 53);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(264, 30);
            dtpEnd.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(654, 53);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(281, 31);
            txtProductName.TabIndex = 2;
            txtProductName.SelectedIndexChanged += txtProductName_SelectedIndexChanged;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.FromArgb(0, 123, 255);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(1003, 53);
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
            tabControl.Location = new Point(20, 123);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1261, 620);
            tabControl.TabIndex = 1;
            // 
            // tabThanhVien
            // 
            Panel panelThanhVien = new Panel();
            panelThanhVien.Dock = DockStyle.Fill;
            tabThanhVien.Controls.Add(panelThanhVien);

        
            tabThanhVien.Location = new Point(4, 29);
            tabThanhVien.Name = "tabThanhVien";
            tabThanhVien.Size = new Size(1253, 700);
            tabThanhVien.TabIndex = 0;
            tabThanhVien.Text = "📚 Thành viên học tập";
            // 
            // dgvThanhVien
            // 
            dgvThanhVien.Dock = DockStyle.Top;
            dgvThanhVien.Height = 550; // Giảm chiều cao để chừa chỗ cho label 
            dgvThanhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThanhVien.BackgroundColor = Color.WhiteSmoke;
            dgvThanhVien.BorderStyle = BorderStyle.Fixed3D;
            dgvThanhVien.ColumnHeadersHeight = 29;
            dgvThanhVien.Location = new Point(0, 0);
            dgvThanhVien.Name = "dgvThanhVien";
            dgvThanhVien.RowHeadersWidth = 51;
            dgvThanhVien.Size = new Size(1253, 550);
            dgvThanhVien.TabIndex = 0;
            dgvThanhVien.CellContentClick += dgvThanhVien_CellContentClick;
            panelThanhVien.Controls.Add(dgvThanhVien);

            lblSoLuotVao = new Label();
            lblSoLuotVao.Text = "Tổng số lượt vào: ";
            lblSoLuotVao.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSoLuotVao.Location = new Point(10, 560); // Ngay dưới bảng
            lblSoLuotVao.AutoSize = true;

            lblSoThanhVien = new Label();
            lblSoThanhVien.Text = "Tổng số thành viên: ";
            lblSoThanhVien.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSoThanhVien.Location = new Point(320, 560);
            lblSoThanhVien.AutoSize = true;

            panelThanhVien.Controls.Add(lblSoLuotVao);
            panelThanhVien.Controls.Add(lblSoThanhVien);
            // 
            // tabThietBiMuon
            // 

            Panel panelThietBiDaMuon = new Panel();
            panelThietBiDaMuon.Dock = DockStyle.Fill;

            tabThietBiMuon.Controls.Add(panelThietBiDaMuon);
           
            tabThietBiMuon.Location = new Point(4, 29);
            tabThietBiMuon.Name = "tabThietBiMuon";
            tabThietBiMuon.Size = new Size(1253, 700);
            tabThietBiMuon.TabIndex = 1;
            tabThietBiMuon.Text = "📦 Thiết bị đã mượn";
            // 
            // dgvThietBiMuon
            // 
            dgvDaTra.BackgroundColor = Color.WhiteSmoke;
            dgvDaTra.BorderStyle = BorderStyle.Fixed3D;
            dgvDaTra.ColumnHeadersHeight = 29;
            dgvThanhVien.Dock = DockStyle.Top;
            dgvThanhVien.Height = 550;
            dgvDaTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDaTra.Location = new Point(0, 0);
            dgvDaTra.Name = "dgvThietBiMuon";
            dgvDaTra.RowHeadersWidth = 51;
            dgvDaTra.Size = new Size(1253, 550);
            dgvDaTra.TabIndex = 0;


            lblSoLuongDaMuon = new Label();
            lblSoLuongDaMuon.Text = "Tổng số thiết bị đã mượn: ";
            lblSoLuongDaMuon.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSoLuongDaMuon.Location = new Point(10, 560); // Ngay dưới bảng
            lblSoLuongDaMuon.AutoSize = true;

            panelThietBiDaMuon.Controls.Add(dgvDaTra);
            panelThietBiDaMuon.Controls.Add(lblSoLuongDaMuon);
            // 
            // tabDangMuon
            // 
            Panel panelThietBiDangMuon = new Panel();
            panelThietBiDangMuon.Dock = DockStyle.Fill;

            tabDangMuon.Controls.Add(panelThietBiDangMuon);
            
            tabDangMuon.Location = new Point(4, 29);
            tabDangMuon.Name = "tabDangMuon";
            tabDangMuon.Size = new Size(1253, 700);
            tabDangMuon.TabIndex = 2;
            tabDangMuon.Text = "🔄 Thiết bị đang mượn";
            // 
            // dgvDangMuon
            // 
            dgvDangMuon.BackgroundColor = Color.WhiteSmoke;
            dgvDangMuon.BorderStyle = BorderStyle.Fixed3D;
            dgvDangMuon.ColumnHeadersHeight = 29;
            dgvThanhVien.Dock = DockStyle.Top;
            dgvThanhVien.Height = 550; // Giảm chiều cao để chừa chỗ cho label 
            dgvDangMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDangMuon.Location = new Point(0, 0);
            dgvDangMuon.Name = "dgvDangMuon";
            dgvDangMuon.RowHeadersWidth = 51;
            dgvDangMuon.Size = new Size(1253, 550);
            dgvDangMuon.TabIndex = 0;

            lblSoLuongDangMuon = new Label();
            lblSoLuongDangMuon.Text = "Tổng số thiết bị đang mượn: ";
            lblSoLuongDangMuon.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSoLuongDangMuon.Location = new Point(10, 560); // Ngay dưới bảng
            lblSoLuongDangMuon.AutoSize = true;

            panelThietBiDangMuon.Controls.Add(dgvDangMuon);
            panelThietBiDangMuon.Controls.Add(lblSoLuongDangMuon);
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
            groupBoxFilter.Size = new Size(1261, 107);
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
            label2.Location = new Point(299, 24);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "Đến ngày:";
            // 
            // label3
            // 
            label3.Location = new Point(654, 24);
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
            Size = new Size(1299, 750);
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabThanhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThanhVien).EndInit();
            tabThietBiMuon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDaTra).EndInit();
            tabDangMuon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDangMuon).EndInit();
            groupBoxFilter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
