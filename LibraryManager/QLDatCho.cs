using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class QLDatCho : UserControl
    {
        public QLDatCho()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ktketnoi_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối thành công!");
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại.");
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tableDatCho.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tableDatCho.SelectedRows[0];
                string trangThai = selectedRow.Cells["TrangThaiDat"].Value.ToString();

                if (trangThai == "Đang xử lý")
                {
                    int maPhieu = Convert.ToInt32(selectedRow.Cells["MaPhieu"].Value);

                    // Hiển thị hộp thoại xác nhận trước khi hủy
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (MySqlConnection conn = DatabaseConnection.GetConnection())
                        {
                            string query = "UPDATE PhieuDatCho SET TrangThaiDat = 'Đã hủy' WHERE MaPhieu = @MaPhieu";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Đã hủy phiếu đặt chỗ.");
                        LoadDataToGrid(); // Hàm load lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Hủy thao tác.");
                    }
                }
                else
                {
                    MessageBox.Show("Chỉ được hủy phiếu ở trạng thái 'Đang xử lý'.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu để hủy.");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string giaTriTimKiem = search.Text.Trim(); // Lấy giá trị từ TextBox tên là 'search'

            string query = "SELECT * FROM PhieuDatCho";

            if (!string.IsNullOrEmpty(giaTriTimKiem))
            {
                query += " WHERE MaPhieu = @GiaTri OR MaThanhVien = @GiaTri";
            }

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(giaTriTimKiem))
                    {
                        if (int.TryParse(giaTriTimKiem, out int maSo))
                        {
                            cmd.Parameters.AddWithValue("@GiaTri", maSo);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số hợp lệ.");
                            return;
                        }
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tableDatCho.DataSource = dt;
                }
            }
        }

        private void tableDatCho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableDatCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo không chọn tiêu đề
            {
                DataGridViewRow row = tableDatCho.Rows[e.RowIndex];

                // Truyền dữ liệu từ hàng đang chọn vào các control
                txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
                txtMaThanhVien.Text = row.Cells["MaThanhVien"].Value.ToString();

                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();


                // Truyền giá trị thời gian mượn vào DateTimePicker
                if (DateTime.TryParse(row.Cells["ThoiGianMuonDuKien"].Value.ToString(), out DateTime thoiGian))
                {
                    dtpThoiGian.Value = thoiGian;
                }

                // Truyền trạng thái vào ComboBox
                cbTrangThai.SelectedItem = row.Cells["TrangThaiDat"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) || cbTrangThai.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtMaThanhVien.Text)
                || string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
                int soluong = Convert.ToInt32(txtSoLuong.Text);
                DateTime thoiGianMuon = dtpThoiGian.Value;
                string trangThai = cbTrangThai.SelectedItem.ToString();

                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE PhieuDatCho 
                             SET soluong = @soluong,
                                 ThoiGianMuonDuKien = @ThoiGianMuonDuKien,
                                 TrangThaiDat = @TrangThaiDat
                             WHERE MaPhieu = @maphieu";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maphieu", maPhieu);
                        cmd.Parameters.AddWithValue("@soLuong", soluong);
                        cmd.Parameters.AddWithValue("@ThoiGianMuonDuKien", thoiGianMuon);
                        cmd.Parameters.AddWithValue("@TrangThaiDat", trangThai);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataToGrid();   // Load lại bảng
                                                // Reset form về chế độ mặc định
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy phiếu để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


        
