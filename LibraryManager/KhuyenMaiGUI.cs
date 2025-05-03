using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryManager;
using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;

namespace ProjectLibraryManager
{
    public partial class KhuyenMaiGUI : UserControl
    {
        private string selectedMaKhuyenMai = null;
        private bool isEditing = false;
        public KhuyenMaiGUI()
        {
            InitializeComponent();
            richTextBox2.Enabled = false;
            richTextBox2.Text = GenerateNextMaKhuyenMai();

        }

        private void loadData(object sender, EventArgs e)
        {
            loadKhuyenMaiToTable();
        }

        private void loadKhuyenMaiToTable()
        {
            // 1. Lấy dữ liệu
            var sql = "SELECT * FROM khuyenmai";
            DataTable dt = DatabaseConnection.ExecuteSelectQuery(sql);

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;

            // 3. Thêm từng dòng dữ liệu
            int rowIndex = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

                int currentRow = rowIndex;

                var lblMa = new Label
                {
                    Text = dr["MaKhuyenMai"].ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                // gán sự kiện chọn dòng
                lblMa.Click += (s, e) =>
                {
                    selectedMaKhuyenMai = dr["MaKhuyenMai"].ToString();
                    HighlightSelectedRow(currentRow);
                };
                tableLayoutPanel1.Controls.Add(lblMa, 0, currentRow);

                // --- Cột 1: Tên ---
                var lblTen = new Label
                {
                    Text = dr["TenKhuyenMai"].ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblTen.Click += (s, e) =>
                {
                    selectedMaKhuyenMai = dr["MaKhuyenMai"].ToString();
                    HighlightSelectedRow(currentRow);
                };
                tableLayoutPanel1.Controls.Add(lblTen, 1, currentRow);

                // --- Cột 2: Ngày bắt đầu ---
                var lblNgayBD = new Label
                {
                    Text = Convert.ToDateTime(dr["NgayBatDau"])
                                     .ToString("yyyy-MM-dd"),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblNgayBD.Click += (s, e) =>
                {
                    selectedMaKhuyenMai = dr["MaKhuyenMai"].ToString();
                    HighlightSelectedRow(currentRow);
                };
                tableLayoutPanel1.Controls.Add(lblNgayBD, 2, currentRow);

                // --- Cột 3: Ngày kết thúc ---
                var lblNgayKT = new Label
                {
                    Text = Convert.ToDateTime(dr["NgayKetThuc"])
                                     .ToString("yyyy-MM-dd"),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                lblNgayKT.Click += (s, e) =>
                {
                    selectedMaKhuyenMai = dr["MaKhuyenMai"].ToString();
                    HighlightSelectedRow(currentRow);
                };
                tableLayoutPanel1.Controls.Add(lblNgayKT, 3, currentRow);

                // --- Cột 4: Xem thêm ---
                var btnXem = new Button
                {
                    Text = "Xem thêm",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 9F,
                                FontStyle.Underline | FontStyle.Bold),
                    ForeColor = Color.Green,
                    Tag = dr["MaKhuyenMai"]
                };
                btnXem.Click += button4_Click_1;
                tableLayoutPanel1.Controls.Add(btnXem, 4, currentRow);

                rowIndex++;
            }
        }

        private string GenerateNextMaKhuyenMai()
        {
            string sql = "SELECT MAX(CAST(MaKhuyenMai AS SIGNED)) FROM khuyenmai";
            // CAST để đảm bảo convert string thành số
            object result = null;
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                result = cmd.ExecuteScalar();
            }

            int next = 1;
            if (result != DBNull.Value && result != null)
                next = Convert.ToInt32(result) + 1;

            return next.ToString();
        }

        private void HighlightSelectedRow(int selectedRow)
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                int r = tableLayoutPanel1.GetRow(ctrl);
                ctrl.BackColor = (r == selectedRow) ? Color.LightBlue : Color.White;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var promoId = btn.Tag.ToString();

            // Mỗi lần bấm tạo một instance mới, truyền promoId vào
            using (var modal = new ModalKhuyenMai(promoId))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    // Nếu trong modal bạn đặt DialogResult = OK khi lưu,
                    // thì sau khi đóng bạn có thể reload bảng chính:
                    loadKhuyenMaiToTable();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đọc giá trị từ form
                string maCT = richTextBox2.Text.Trim();
                string tenCT = richTextBox3.Text.Trim();
                string ngayBD = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string ngayKT = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                // Kiểm tra không để trống
                if (string.IsNullOrEmpty(maCT) || string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Bạn phải nhập cả Mã chương trình và Tên chương trình!",
                                    "Thiếu dữ liệu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 2. Chèn vào database
                string sql = @"INSERT INTO khuyenmai (MaKhuyenMai, TenKhuyenMai, NgayBatDau, NgayKetThuc)
                               VALUES (@ma, @ten, @bd, @kt)";

                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maCT);
                    cmd.Parameters.AddWithValue("@ten", tenCT);
                    cmd.Parameters.AddWithValue("@bd", ngayBD);
                    cmd.Parameters.AddWithValue("@kt", ngayKT);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("Không có bản ghi nào được thêm.");
                }

                // 3. Làm mới TableLayoutPanel
                loadKhuyenMaiToTable();

                MessageBox.Show("Thêm chương trình khuyến mãi thành công!",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:\n" + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            richTextBox2.Text = GenerateNextMaKhuyenMai();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1) Nếu chưa vào edit mode: load dữ liệu lên form
            if (!isEditing)
            {
                if (string.IsNullOrEmpty(selectedMaKhuyenMai))
                {
                    MessageBox.Show("Vui lòng chọn 1 dòng để sửa.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu chi tiết từ database
                string sql = "SELECT * FROM khuyenmai WHERE MaKhuyenMai = @ma";
                DataTable dt;
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", selectedMaKhuyenMai);
                    var adapter = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                if (dt.Rows.Count == 0) return;
                var dr = dt.Rows[0];

                // Đổ lên form
                richTextBox2.Text = dr["MaKhuyenMai"].ToString();
                richTextBox3.Text = dr["TenKhuyenMai"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["NgayBatDau"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["NgayKetThuc"]);

                // Vô hiệu hóa sửa mã
                richTextBox2.Enabled = false;

                // Chuyển sang chế độ “Lưu”
                isEditing = true;
                button2.Text = "Lưu";
            }
            else
            {
                // 2) Đang ở edit mode: thực hiện UPDATE
                string ten = richTextBox3.Text.Trim();
                string bd = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string kt = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Tên chương trình không được để trống.",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"UPDATE khuyenmai
                               SET TenKhuyenMai = @ten,
                                   NgayBatDau    = @bd,
                                   NgayKetThuc   = @kt
                               WHERE MaKhuyenMai = @ma";

                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@bd", bd);
                        cmd.Parameters.AddWithValue("@kt", kt);
                        cmd.Parameters.AddWithValue("@ma", selectedMaKhuyenMai);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form và reload bảng
                    richTextBox2.Enabled = false;
                    richTextBox2.Text = GenerateNextMaKhuyenMai();
                    richTextBox3.Clear();
                    isEditing = false;
                    button2.Text = "Sửa";
                    selectedMaKhuyenMai = null;
                    loadKhuyenMaiToTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaKhuyenMai))
            {
                MessageBox.Show("Vui lòng chọn chương trình để xóa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa chương trình {selectedMaKhuyenMai}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string delSql = "DELETE FROM khuyenmai WHERE MaKhuyenMai = @ma";
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new MySqlCommand(delSql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", selectedMaKhuyenMai);
                    cmd.ExecuteNonQuery();
                }

                // Làm mới lại bảng
                selectedMaKhuyenMai = null;
                loadKhuyenMaiToTable();
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
        }
    }
}
