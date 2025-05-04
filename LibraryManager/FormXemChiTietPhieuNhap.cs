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


namespace LibraryManager
{
    public partial class FormXemChiTietPhieuNhap : Form
    {
        private PhieuNhapModel phieuNhap;
        private PhieuNhapRepository Repository;
        public FormXemChiTietPhieuNhap(PhieuNhapModel pn)
        {
            InitializeComponent();
            phieuNhap = pn;
            Repository = new PhieuNhapRepository();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupTableHeader();
            LoadData();
        }
        private void SetupTableHeader()
        {
            // Xóa các control hiện tại nếu có
            tbChiTietPhieuNhap.Controls.Clear();
            tbChiTietPhieuNhap.RowStyles.Clear();
            tbChiTietPhieuNhap.ColumnStyles.Clear();

            // Thiết lập số cột và kiểu cột
            tbChiTietPhieuNhap.ColumnCount = 5;  // 5 cột dữ liệu
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));  // Mã sản phẩm
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));  // Tên sản phẩm
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));  // Đơn giá
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));  // Số lượng
            tbChiTietPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));  // Thành tiền

            // Thiết lập dòng tiêu đề
            tbChiTietPhieuNhap.RowCount = 1;  // Chỉ có một dòng tiêu đề
            tbChiTietPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Thêm các tiêu đề vào cột
            tbChiTietPhieuNhap.Controls.Add(new Label { Text = "Mã sản phẩm", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tbChiTietPhieuNhap.Controls.Add(new Label { Text = "Tên sản phẩm", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tbChiTietPhieuNhap.Controls.Add(new Label { Text = "Đơn giá nhập", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            tbChiTietPhieuNhap.Controls.Add(new Label { Text = "Số lượng", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
            tbChiTietPhieuNhap.Controls.Add(new Label { Text = "Thành tiền", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 4, 0);
        }
        public void LoadData()
        {
            List<ChiTietPhieuNhapModel> list = Repository.GetAllChiTietPhieuNhapById(phieuNhap.MaPhieuNhap);

            // Thiết lập lại header
            SetupTableHeader();

            // Bắt đầu từ dòng thứ 1 (vì dòng 0 là tiêu đề)
            int rowIndex = 1;

            foreach (ChiTietPhieuNhapModel ct in list)
            {
                // Tăng thêm một dòng
                tbChiTietPhieuNhap.RowCount++;
                tbChiTietPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Thêm Mã Sản Phẩm
                tbChiTietPhieuNhap.Controls.Add(new Label { Text = ct.MaSanPham.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

                // Thêm Tên Sản Phẩm
                tbChiTietPhieuNhap.Controls.Add(new Label { Text = Repository.GetSanPhamById(ct.MaSanPham).TenSanPham, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, rowIndex);

                // Thêm Đơn Giá
                tbChiTietPhieuNhap.Controls.Add(new Label { Text = ct.GiaNhap.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleRight }, 2, rowIndex);

                // Thêm Số Lượng
                tbChiTietPhieuNhap.Controls.Add(new Label { Text = ct.SoLuong.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                // Thêm Thành Tiền
                tbChiTietPhieuNhap.Controls.Add(new Label { Text = (ct.GiaNhap * ct.SoLuong).ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleRight }, 4, rowIndex);

                rowIndex++;  // Sang dòng tiếp theo
            }


            txtNhaCungCap.Text = Repository.GetTenNhaCungCapById(phieuNhap.MaNCC);
            txtTongGiaTri.Text = phieuNhap.TongTien.ToString("N0");
            lbThoiGian.Text = phieuNhap.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
