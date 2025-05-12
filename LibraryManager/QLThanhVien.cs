using LibraryManager.BUS;
using LibraryManager.DTO;
namespace LibraryManager
{
    public partial class QLThanhVien : UserControl
    {
        private ThanhVienBUS thanhVienBUS = new ThanhVienBUS();
        public QLThanhVien()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var thanhViens = thanhVienBUS.GetAllThanhVien();
            data_Tb_QLTV.DataSource = thanhViens;
            data_Tb_QLTV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            data_Tb_QLTV.ClearSelection();
            data_Tb_QLTV.CurrentCell = null;




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.data_Tb_QLTV.Rows[e.RowIndex];
                //tbox_MaThanhVien.Text = row.Cells["maThanhVien"].Value.ToString();
                tbox_HoTen.Text = row.Cells["hoTen"].Value.ToString();
                dateTime_NgaySinh.Text = row.Cells["ngaySinh"].Value.ToString();
                tbox_DiaChi.Text = row.Cells["diaChi"].Value.ToString();
                tbox_SoDienThoai.Text = row.Cells["sdt"].Value.ToString();
                tbox_Email.Text = row.Cells["email"].Value.ToString();
            }

        }

        private void data_Tb_QLTV_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra số lượng dòng được chọn
            int selectedRowCount = data_Tb_QLTV.SelectedRows.Count;

            if (selectedRowCount == 1)
            {
                btn_Sua.Enabled = true; // Bật nút "Sửa" nếu chỉ có 1 dòng được chọn
            }
            else
            {
                btn_Sua.Enabled = false; // Tắt nút "Sửa" nếu không phải 1 dòng
            }
        }



        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (!ValidateInputs())
            {
                return; // Nếu không hợp lệ, dừng xử lý
            }

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin thành viên này không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện cập nhật nếu người dùng chọn "Yes"
                ThanhVienDTO tv = new ThanhVienDTO
                {
                    maThanhVien = Convert.ToInt32(data_Tb_QLTV.CurrentRow.Cells["maThanhVien"].Value),
                    hoTen = tbox_HoTen.Text,
                    ngaySinh = dateTime_NgaySinh.Value,
                    diaChi = tbox_DiaChi.Text,
                    sdt = tbox_SoDienThoai.Text,
                    email = tbox_Email.Text
                };

                thanhVienBUS.UpdateThanhVien(tv);
                LoadData();
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                // Nếu người dùng chọn "No", không làm gì cả
                MessageBox.Show("Cập nhật đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (data_Tb_QLTV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thành viên để xóa.");
                return;
            }

            // Lấy danh sách các mã thành viên được chọn
            List<int> danhSachMaThanhVien = new List<int>();
            foreach (DataGridViewRow row in data_Tb_QLTV.SelectedRows)
            {
                int maThanhVien = Convert.ToInt32(row.Cells["maThanhVien"].Value);
                danhSachMaThanhVien.Add(maThanhVien);
            }

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các thành viên đã chọn không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Gọi hàm xóa nhiều thành viên trong BUS
                thanhVienBUS.DeleteNhieuThanhVien(danhSachMaThanhVien);

                // Tải lại dữ liệu
                LoadData();
                MessageBox.Show("Xóa thành công.");
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void ra_btn_MuonTra_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lb_TimKiem_Click(object sender, EventArgs e)
        {

        }

        private void tbox_TenThanhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbox_Sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_TenThanhVien_Click(object sender, EventArgs e)
        {

        }

        //// Kiểm tra đầu vào
        private bool ValidateInputs()
        {
            // Kiểm tra Họ Tên
            if (string.IsNullOrWhiteSpace(tbox_HoTen.Text))
            {
                MessageBox.Show("Họ Tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_HoTen.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbox_HoTen.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ Tên không được chứa số hoặc ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_HoTen.Focus();
                return false;
            }

            // Kiểm tra Ngày Sinh (phải trên 16 tuổi)
            DateTime ngaySinh = dateTime_NgaySinh.Value;
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--; // Điều chỉnh nếu chưa đến ngày sinh nhật
            if (tuoi < 16)
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Thành viên phải trên 16 tuổi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTime_NgaySinh.Focus();
                return false;
            }

            // Kiểm tra Địa Chỉ
            if (string.IsNullOrWhiteSpace(tbox_DiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_DiaChi.Focus();
                return false;
            }

            // Kiểm tra Số Điện Thoại
            if (string.IsNullOrWhiteSpace(tbox_SoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_SoDienThoai.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbox_SoDienThoai.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_SoDienThoai.Focus();
                return false;
            }

            // Kiểm tra Email
            if (string.IsNullOrWhiteSpace(tbox_Email.Text))
            {
                MessageBox.Show("Email không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_Email.Focus();
                return false;
            }
            if (!tbox_Email.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email phải chứa '@gmail.com'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbox_Email.Focus();
                return false;
            }

            return true; // Nếu tất cả hợp lệ
        }

        private void tbox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbox_TimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu thanh tìm kiếm trống, tải lại toàn bộ dữ liệu
                LoadData();
            }
            else
            {
                // Tìm kiếm theo họ tên
                var thanhViens = thanhVienBUS.SearchThanhVienByName(searchText);
                data_Tb_QLTV.DataSource = thanhViens;
            }
        }

        private void lb_QuanLyThanhVien_Click(object sender, EventArgs e)
        {

        }

        private void btn_DatCho_Click(object sender, EventArgs e)
        {

        }

        private void btn_XemLichSu_Click(object sender, EventArgs e)
        {
            if (data_Tb_QLTV.CurrentRow == null) return;

            int maTv = Convert.ToInt32(data_Tb_QLTV.CurrentRow.Cells["maThanhVien"].Value);
            var historyForm = new PhieuMuonTV(maTv);
            historyForm.ShowDialog();
        }

        private void btn_ViPham_Click(object sender, EventArgs e)
        {
            if (data_Tb_QLTV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thành viên để xem thông tin.");
                return;
            }
            // Lấy chỉ số hàng hiện tại
            int rowIndex = data_Tb_QLTV.CurrentRow.Index;

            // Lấy giá trị từ cột "maThanhVien" (giả sử cột có tên đó)
            int maThanhVien = Convert.ToInt32(data_Tb_QLTV.Rows[rowIndex].Cells["maThanhVien"].Value);

            FormXemDanhSachViPhamById form = new FormXemDanhSachViPhamById(maThanhVien);
            form.ShowDialog(); // hoặc .Show() nếu bạn muốn form không chặn
        }
        /// 
        /// Đọc dữ liệu từ file Excel và chuyển đổi thành danh sách đối tượng ThanhVienDTO
        /// 
        private List<ThanhVienDTO> DocDuLieuTuExcel(string filePath)
        {
            List<ThanhVienDTO> danhSachThanhVien = new List<ThanhVienDTO>();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(fileStream); // Đọc file .xlsx
                var sheet = workbook.GetSheetAt(0); // Lấy sheet đầu tiên

                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++) // Bỏ qua dòng tiêu đề
                {
                    var row = sheet.GetRow(rowIndex);
                    ThanhVienDTO thanhVien = new ThanhVienDTO
                    {
                        hoTen = row.GetCell(0).ToString(),
                        ngaySinh = ParseDate(row.GetCell(1).ToString()),
                        diaChi = row.GetCell(2).ToString(),
                        sdt = row.GetCell(3).ToString(),
                        email = row.GetCell(4).ToString(),
                        ngayDangKy = ParseDate(row.GetCell(5).ToString())
                    };

                    danhSachThanhVien.Add(thanhVien);
                }
            }

            return danhSachThanhVien;
        }

        // Hàm hỗ trợ chuyển đổi ngày tháng
        private DateTime ParseDate(string dateString)
        {
            string[] formats = { "dd/MM/yyyy", "MM/dd/yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "dd-MMM-yyyy" }; // Các định dạng có thể có
            if (DateTime.TryParseExact(dateString, formats, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                throw new FormatException($"Chuỗi ngày tháng '{dateString}' không hợp lệ.");
            }
        }




        private void btn_NhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Đọc dữ liệu từ file Excel
                    List<ThanhVienDTO> danhSachThanhVien = DocDuLieuTuExcel(filePath);

                    // Hiển thị dữ liệu lên DataGridView
                    //data_Tb_QLTV.DataSource = danhSachThanhVien;

                    // Thêm dữ liệu vào cơ sở dữ liệu
                    foreach (var thanhVien in danhSachThanhVien)
                    {
                        thanhVienBUS.ThemThanhVien(thanhVien);
                    }
                    LoadData();

                    MessageBox.Show("Nhập dữ liệu từ Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nhập dữ liệu từ Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pn_Button_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_ViPham_DatCho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
