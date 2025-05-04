using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.Repository;
using LibraryManager.Model;

namespace MinhViLap05
{
    public partial class FormThemPhieuNhap : Form
    {
        private PhieuNhapRepository Repository;
        private int maNCC = -1;
        private double tongGiaTri = 0;
        public FormThemPhieuNhap()
        {
            Repository = new PhieuNhapRepository();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadDataSanPham();
            LoadNhaCungCapData();
            SetupTableHeader();
            // Chặn ký tự không hợp lệ
            txtDonGia.KeyPress += new KeyPressEventHandler(HandleSoLuongDonGia);
            txtSoLuong.KeyPress += new KeyPressEventHandler(HandleSoLuongDonGia);

            // Tính toán khi giá trị thay đổi
            txtDonGia.TextChanged += new EventHandler(HandleSoLuongDonGia);
            txtSoLuong.TextChanged += new EventHandler(HandleSoLuongDonGia);
        }
        private void HandleSoLuongDonGia(object sender, EventArgs e)
        {
            // Xử lý nhập chỉ số (cho sự kiện KeyPress)
            if (e is KeyPressEventArgs ke)
            {
                if (!char.IsControl(ke.KeyChar) && !char.IsDigit(ke.KeyChar))
                {
                    ke.Handled = true;
                }
                return;
            }

            // Xử lý tính toán (cho sự kiện TextChanged)
            if (int.TryParse(txtDonGia.Text, out int donGia) &&
                int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                txtThanhTien.Text = (donGia * soLuong).ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "";
            }
        }

        public void btnChon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && btn.Tag is SanPhamModel sp)
            {
                // Gán thông tin từ Model sang TextBox
                txtMaSP.Text = sp.MaSanPham.ToString();
                txtTenSP.Text = sp.TenSanPham;
                txtConLai.Text = sp.SoLuong.ToString();
                txtDonGia.Text = "";
                txtSoLuong.Text = "";
                txtThanhTien.Text = "";
            }
        }
        private void LoadDataSanPham()
        {
            // Tạm dừng layout để cải thiện hiệu suất khi thêm control
            tbDanhSachSP.SuspendLayout();

            // Xóa control và cấu hình lại bảng
            tbDanhSachSP.Controls.Clear();
            tbDanhSachSP.RowStyles.Clear();
            tbDanhSachSP.ColumnStyles.Clear();

            // Thiết lập số cột và tỉ lệ
            tbDanhSachSP.ColumnCount = 5;
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Mã sản phẩm
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Tên sản phẩm
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Số lượng
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Trạng thái
            tbDanhSachSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Thao tác

            // Dòng tiêu đề
            tbDanhSachSP.RowCount = 1;
            tbDanhSachSP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            int headerRow = 0;

            tbDanhSachSP.Controls.Add(new Label { Text = "Mã SP", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, headerRow);
            tbDanhSachSP.Controls.Add(new Label { Text = "Tên sản phẩm", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 1, headerRow);
            tbDanhSachSP.Controls.Add(new Label { Text = "Số lượng", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 2, headerRow);
            tbDanhSachSP.Controls.Add(new Label { Text = "Trạng thái", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 3, headerRow);
            tbDanhSachSP.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 4, headerRow);

            // Lấy danh sách sản phẩm từ Repository
            List<SanPhamModel> ds = Repository.GetAllSanPham();

            tbDanhSachSP.RowCount = ds.Count + 1;

            for (int i = 0; i < ds.Count; i++)
            {
                var sp = ds[i];
                int rowIndex = i + 1;

                tbDanhSachSP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                tbDanhSachSP.Controls.Add(new Label { Text = sp.MaSanPham.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);
                tbDanhSachSP.Controls.Add(new Label { Text = sp.TenSanPham, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft }, 1, rowIndex);
                tbDanhSachSP.Controls.Add(new Label { Text = sp.SoLuong.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, rowIndex);
                tbDanhSachSP.Controls.Add(new Label { Text = sp.TrangThai, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                // Nút "Chọn" gán Tag = sp
                Button btnChon = new Button
                {
                    Text = "Chọn",
                    Tag = sp,
                    AutoSize = true
                };
                btnChon.Click += btnChon_Click;

                tbDanhSachSP.Controls.Add(btnChon, 4, rowIndex);
            }

            // Resume layout
            tbDanhSachSP.ResumeLayout(true);
        }
        private void SetupTableHeader()
        {
            // Xóa các control hiện tại nếu có
            tbPhieuNhapTam.Controls.Clear();
            tbPhieuNhapTam.RowStyles.Clear();
            tbPhieuNhapTam.ColumnStyles.Clear();

            // Thiết lập số cột và kiểu cột
            tbPhieuNhapTam.ColumnCount = 6;  // 5 cột dữ liệu + 1 cột thao tác
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));  // Mã sản phẩm
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));  // Tên sản phẩm
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));  // Đơn giá
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));  // Số lượng
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));  // Thành tiền
            tbPhieuNhapTam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));  // Thao tác

            // Thiết lập dòng tiêu đề
            tbPhieuNhapTam.RowCount = 1;  // Chỉ có một dòng tiêu đề
            tbPhieuNhapTam.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Thêm các tiêu đề vào cột
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Mã sản phẩm", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Tên sản phẩm", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Đơn giá nhập", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Số lượng", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Thành tiền", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 4, 0);
            tbPhieuNhapTam.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 5, 0);
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string maSanPham = txtMaSP.Text;
            string tenSanPham = txtTenSP.Text;
            double donGia = 0;
            int soLuong = 0;

            // Parse donGia and soLuong
            if (double.TryParse(txtDonGia.Text, out donGia) && int.TryParse(txtSoLuong.Text, out soLuong))
            {
                // Calculate Thành Tiền
                double thanhTien = donGia * soLuong;
                AddProductToTable(maSanPham, tenSanPham, donGia, soLuong, thanhTien);

                tongGiaTri += thanhTien;

                txtTongGiaTri.Text = tongGiaTri.ToString("N0");
                btnXoaSP_Click(null, null);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đơn giá và Số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void AddProductToTable(string maSanPham, string tenSanPham, double donGia, int soLuong, double thanhTien)
        {
            // Tính toán lại số dòng của TableLayoutPanel
            int rowIndex = tbPhieuNhapTam.RowCount;
            tbPhieuNhapTam.RowCount = rowIndex + 1;  // Tăng số dòng lên 1

            // Thêm Mã Sản Phẩm
            tbPhieuNhapTam.Controls.Add(new Label { Text = maSanPham, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

            // Thêm Tên Sản Phẩm
            tbPhieuNhapTam.Controls.Add(new Label { Text = tenSanPham, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft }, 1, rowIndex);

            // Thêm Đơn Giá
            tbPhieuNhapTam.Controls.Add(new Label { Text = donGia.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleRight }, 2, rowIndex);

            // Thêm Số Lượng
            tbPhieuNhapTam.Controls.Add(new Label { Text = soLuong.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

            // Thêm Thành Tiền
            tbPhieuNhapTam.Controls.Add(new Label { Text = thanhTien.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleRight }, 4, rowIndex);

            // Thêm Thao Tác (Nút "Xóa")
            Button btnXoa = new Button { Text = "Xóa", AutoSize = true };
            btnXoa.Click += btnXoa_Click;
            tbPhieuNhapTam.Controls.Add(btnXoa, 5, rowIndex);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Button btnXoa = (Button)sender;

            // Lấy chỉ số dòng của nút "Xóa"
            int rowIndex = tbPhieuNhapTam.GetRow(btnXoa);

            // Kiểm tra nếu dòng là hợp lệ
            if (rowIndex >= 0)
            {
                // Lấy điều khiển trong cột 4 (thành tiền) và trừ giá trị
                var control = tbPhieuNhapTam.GetControlFromPosition(4, rowIndex);

                if (control is Label labelThanhTien) // Kiểm tra nếu điều khiển là Label
                {
                    double thanhTien = 0;
                    if (double.TryParse(labelThanhTien.Text, out thanhTien)) // Cột 4 là thành tiền
                    {
                        // Trừ giá trị thành tiền
                        tongGiaTri -= thanhTien;
                        txtTongGiaTri.Text = tongGiaTri.ToString("N0");
                    }
                }

                // Xóa tất cả các điều khiển trong dòng tương ứng
                for (int i = 0; i < tbPhieuNhapTam.ColumnCount; i++)
                {
                    Control ctrl = tbPhieuNhapTam.GetControlFromPosition(i, rowIndex);
                    if (ctrl != null)
                    {
                        tbPhieuNhapTam.Controls.Remove(ctrl); // Xóa điều khiển
                    }
                }
                // Di chuyển các dòng phía dưới lên
                for (int row = rowIndex + 1; row < tbPhieuNhapTam.RowCount; row++)
                {
                    for (int col = 0; col < tbPhieuNhapTam.ColumnCount; col++)
                    {
                        Control ctrl1 = tbPhieuNhapTam.GetControlFromPosition(col, row);
                        if (ctrl1 != null)
                        {
                            tbPhieuNhapTam.SetRow(ctrl1, row - 1);
                        }
                    }
                }
                // Cập nhật row count sau khi xóa
                tbPhieuNhapTam.RowCount--;
                tbPhieuNhapTam.Invalidate();  // Buộc phải vẽ lại
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtConLai.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
        private void LoadNhaCungCapData()
        {
            List<NhaCungCapModel> nhaCungCaps = Repository.GetAllNhaCungCap();

            // Xóa tất cả các item cũ trong ComboBox
            cbNhaCungCap.Items.Clear();

            // Thêm mục mặc định "Chọn nhà cung cấp" vào đầu ComboBox
            cbNhaCungCap.Items.Add(new { Text = "Chọn nhà cung cấp", Value = -1 });

            // Thêm các nhà cung cấp vào ComboBox
            foreach (var nhaCungCap in nhaCungCaps)
            {
                // Thêm tên nhà cung cấp vào ComboBox
                cbNhaCungCap.Items.Add(new { Text = nhaCungCap.TenNCC, Value = nhaCungCap.MaNCC });
            }

            // Đặt ComboBox hiển thị tên nhà cung cấp (Text)
            cbNhaCungCap.DisplayMember = "Text";
            cbNhaCungCap.ValueMember = "Value";
            // Đặt giá trị mặc định là "Chọn nhà cung cấp"
            cbNhaCungCap.SelectedIndex = 0;
        }
        private void cbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhaCungCap.SelectedItem != null)
            {
                // Lấy MaNCC từ giá trị của item được chọn
                maNCC = (int)((dynamic)cbNhaCungCap.SelectedItem).Value;

            }
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {

            if(maNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(tongGiaTri == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm phù hợp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ChiTietPhieuNhapModel> list = new List<ChiTietPhieuNhapModel>();

            for (int rowIndex = 1; rowIndex < tbPhieuNhapTam.RowCount; rowIndex++)
            {
                var maSPControl = tbPhieuNhapTam.GetControlFromPosition(0, rowIndex);
                var tenSPControl = tbPhieuNhapTam.GetControlFromPosition(1, rowIndex);
                var donGiaControl = tbPhieuNhapTam.GetControlFromPosition(2, rowIndex);
                var soLuongControl = tbPhieuNhapTam.GetControlFromPosition(3, rowIndex);

                if (maSPControl is Label maSPLabel &&
                    donGiaControl is Label donGiaLabel &&
                    soLuongControl is Label soLuongLabel)
                {
                    // Kiểm tra dữ liệu nhập vào
                    if (string.IsNullOrWhiteSpace(maSPLabel.Text) ||
                        string.IsNullOrWhiteSpace(donGiaLabel.Text) ||
                        string.IsNullOrWhiteSpace(soLuongLabel.Text))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ ở dòng " + rowIndex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (int.TryParse(maSPLabel.Text, out int maSP) &&
                        double.TryParse(donGiaLabel.Text, out double giaNhap) &&
                        int.TryParse(soLuongLabel.Text, out int soLuong))
                    {
                        if (list.Any(c => c.MaSanPham == maSP))  // Kiểm tra trùng MaSanPham
                        {
                            MessageBox.Show($"Sản phẩm mã {maSP} bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var chiTiet = new ChiTietPhieuNhapModel
                        {
                            MaSanPham = maSP,
                            GiaNhap = giaNhap,
                            SoLuong = soLuong
                        };

                        list.Add(chiTiet);
                    }
                    else
                    {
                        MessageBox.Show($"Dữ liệu không hợp lệ ở dòng {rowIndex}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }


            PhieuNhapModel phieuNhap = new PhieuNhapModel
            {
                MaNCC = maNCC,
                TongTien = tongGiaTri
            };

            if (Repository.Insert(phieuNhap, list))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
