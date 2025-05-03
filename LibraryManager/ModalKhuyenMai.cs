using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;

namespace LibraryManager
{
    public partial class ModalKhuyenMai : Form
    {
        private string selectedDetailId = null;
        private readonly string promoId;
        private bool isEditing = false;
        public ModalKhuyenMai(string promoId)
        {
            InitializeComponent();
            this.promoId = promoId;
            richTextBox3.Enabled = false;
            richTextBox3.Text = GenerateNextMaKhuyenMai();
            LoadProductCombo();
            this.Load += loadData;
        }

        private void loadData(object sender, EventArgs e)
        {
            ModalKhuyenMai_Load();

            loadDetailKhuyenMai();
        }

        private void LoadProductCombo()
        {
            // Lấy MaSanPham, TenSanPham từ bảng products
            var dt = DatabaseConnection.ExecuteSelectQuery(
                "SELECT MaSanPham, TenSanPham FROM sanpham");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "MaSanPham";
            comboBox1.DisplayMember = "TenSanPham";
            comboBox1.SelectedIndex = -1;
        }

        private void loadDetailKhuyenMai()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;

            // Query chi tiết cho promoId
            string sql = @"SELECT k.MaKhuyenMaiSanPham, 
                                  k.MaSanPham, 
                                  p.TenSanPham       AS TenSanPham, 
                                  k.PhanTramKhuyenMai
                           FROM khuyenmaisanpham k
                           JOIN sanpham p 
                           ON p.MaSanPham = k.MaSanPham
                           WHERE k.MaKhuyenMai = @mact";
            var dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@mact", promoId);
                new MySqlDataAdapter(cmd).Fill(dt);
            }

            int rowIndex = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, 40));

                int currentRow = rowIndex;
                string detailId = dr["MaKhuyenMaiSanPham"].ToString();

                // Cột 0: Mã khuyến mãi sản phẩm
                var lblId = new Label
                {
                    Text = detailId,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblId.Click += (s, e) => HighlightDetailRow(currentRow, detailId);
                tableLayoutPanel1.Controls.Add(lblId, 0, currentRow);

                // Cột 1: Mã Khuyến mãi
                var lblProd = new Label
                {
                    Text = promoId,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblProd.Click += (s, e) => HighlightDetailRow(currentRow, detailId);
                tableLayoutPanel1.Controls.Add(lblProd, 1, currentRow);

                // Cột 2: Tên sản phẩm
                var lblTenSP = new Label
                {
                    Text = dr["TenSanPham"].ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblTenSP.Click += (s, e) => HighlightDetailRow(currentRow, detailId);
                tableLayoutPanel1.Controls.Add(lblTenSP, 2, currentRow);

                // Cột 3: Phần trăm khuyến mãi
                var lblSel = new Label
                {
                    Text = dr["PhanTramKhuyenMai"].ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblSel.Click += (s, e) => HighlightDetailRow(currentRow, detailId);
                tableLayoutPanel1.Controls.Add(lblSel, 3, currentRow);

                rowIndex++;
            }
        }

        private string GenerateNextMaKhuyenMai()
        {
            // Lấy max sequence đã sinh trong cùng promo
            string sql = @"SELECT IFNULL(MAX(MaKhuyenMaiSanPham), 0)
                           FROM khuyenmaisanpham
                           WHERE MaKhuyenMai = @mact";
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@mact", promoId);
            var r = cmd.ExecuteScalar();

            int next = 1;
            if (r != DBNull.Value && r != null)
                next = Convert.ToInt32(r) + 1;

            return next.ToString();
        }

        private void HighlightDetailRow(int rowIndex, string detailId)
        {
            selectedDetailId = detailId;
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                ctrl.BackColor =
                  (tableLayoutPanel1.GetRow(ctrl) == rowIndex)
                  ? Color.LightBlue
                  : Color.White;
            }
            // Hiển thị mã chi tiết lên ô để người dùng biết
            richTextBox3.Text = detailId;
        }

        private void ModalKhuyenMai_Load()
        {
            // 1) Query database lấy thông tin của promoId
            string sql = "SELECT * FROM khuyenmai WHERE MaKhuyenMai = @ma";
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", promoId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Đổ lên các control trong modal
                        richTextBox2.Text = reader["MaKhuyenMai"].ToString();
                    }
                }
            }
            richTextBox2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedDetailId))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm khuyễn mãi để xóa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm khuyến mãi {selectedDetailId}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string delSql = "DELETE FROM khuyenmaisanpham WHERE MaKhuyenMaiSanPham = @msp";
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new MySqlCommand(delSql, conn))
                {
                    cmd.Parameters.AddWithValue("@msp", selectedDetailId);
                    cmd.ExecuteNonQuery();
                }

                // Làm mới lại bảng
                selectedDetailId = null;
                loadDetailKhuyenMai();
                MessageBox.Show("Đã xóa thành công!", "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            loadDetailKhuyenMai();
            richTextBox3.Text = GenerateNextMaKhuyenMai();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Nếu đang không trong chế độ chỉnh sửa
            if (!isEditing)
            {
                // Kiểm tra đã chọn dòng chưa
                if (string.IsNullOrEmpty(selectedDetailId))
                {
                    MessageBox.Show("Vui lòng chọn 1 dòng để sửa.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu từ database
                string sql = @"SELECT MaSanPham, PhanTramKhuyenMai 
                               FROM khuyenmaisanpham 
                               WHERE MaKhuyenMaiSanPham = @msp";
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@msp", selectedDetailId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Đổ dữ liệu lên form
                            comboBox1.SelectedValue = reader["MaSanPham"].ToString();
                            richTextBox4.Text = reader["PhanTramKhuyenMai"].ToString();
                        }
                    }
                }

                // Chuyển sang chế độ chỉnh sửa
                isEditing = true;
                button2.Text = "Lưu";
                comboBox1.Enabled = false; // Khóa comboBox để không đổi sản phẩm
            }
            else // Đang trong chế độ chỉnh sửa - thực hiện lưu
            {
                // Validate dữ liệu
                if (!decimal.TryParse(richTextBox4.Text.Trim(), out decimal pct))
                {
                    MessageBox.Show("Nhập phần trăm giảm hợp lệ.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện cập nhật
                string updateSql = @"UPDATE khuyenmaisanpham 
                                     SET PhanTramKhuyenMai = @pt 
                                     WHERE MaKhuyenMaiSanPham = @msp";
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    using (var cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pt", pct);
                        cmd.Parameters.AddWithValue("@msp", selectedDetailId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset trạng thái
                    isEditing = false;
                    button2.Text = "Sửa";
                    comboBox1.Enabled = true;
                    selectedDetailId = null;

                    // Làm mới dữ liệu
                    loadDetailKhuyenMai();
                    LoadProductCombo();
                    richTextBox4.Clear();
                    comboBox1.SelectedIndex = -1;
                    richTextBox3.Text = GenerateNextMaKhuyenMai();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra chọn sản phẩm
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra phần trăm
            if (!decimal.TryParse(richTextBox4.Text.Trim(), out decimal pct))
            {
                MessageBox.Show("Nhập phần trăm giảm hợp lệ.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm record mới
            string seq = GenerateNextMaKhuyenMai();
            string insertSql = @"INSERT INTO khuyenmaisanpham (MaKhuyenMai, MaKhuyenMaiSanPham, MaSanPham, PhanTramKhuyenMai)
                                 VALUES (@mact, @seq, @prod, @pt)";
            try { 
                using var conn = DatabaseConnection.GetConnection();
                using var cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@mact", promoId);
                cmd.Parameters.AddWithValue("@seq", seq);
                cmd.Parameters.AddWithValue("@prod", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@pt", pct);
                cmd.ExecuteNonQuery();


                loadDetailKhuyenMai();
                richTextBox3.Text = GenerateNextMaKhuyenMai();
                LoadProductCombo();
                richTextBox4.Clear();

                MessageBox.Show("Thêm thành công.", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

