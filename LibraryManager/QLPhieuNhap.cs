using System.Windows.Forms;
using LibraryManager;
using LibraryManager.Repository;
using LibraryManager.Model;

namespace MinhViLap05
{
    public partial class QLPhieuNhap : UserControl
    {
        private PhieuNhapRepository Repository;
        public QLPhieuNhap()
        {

            InitializeComponent();
            Repository = new PhieuNhapRepository();
            LoadData();

            cbKieuTimKiem.Items.Clear(); // Xóa các mục cũ nếu có
            cbKieuTimKiem.Items.Add("Mã phiếu nhập");
            cbKieuTimKiem.Items.Add("Tên nhà cung cấp");
            cbKieuTimKiem.SelectedIndex = 0; // Mặc định là Mã phiếu nhập
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string kieuTim = cbKieuTimKiem.SelectedItem?.ToString();
            string tuKhoa = txtTimKiem.Text.ToLower();

            List<PhieuNhapModel> danhSachGoc = Repository.GetAll();

            List<PhieuNhapModel> ketQuaTimKiem = danhSachGoc.Where(pn =>
            {
                if (kieuTim == "Mã phiếu nhập")
                    return pn.MaPhieuNhap.ToString().Contains(tuKhoa);
                else if (kieuTim == "Tên nhà cung cấp")
                {
                    string tenNCC = Repository.GetTenNhaCungCapById(pn.MaNCC).ToLower();
                    return tenNCC.Contains(tuKhoa);
                }
                return false;
            }).ToList();

            HienThiDanhSach(ketQuaTimKiem);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

            using (FormThemPhieuNhap form = new FormThemPhieuNhap())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Gọi lại hàm cập nhật giao diện/dữ liệu của form cha
                    LoadData(); // Giả sử bạn có hàm này
                }
            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            PhieuNhapModel pn = btn.Tag as PhieuNhapModel;

            if (pn != null)
            {
                FormXemChiTietPhieuNhap form = new FormXemChiTietPhieuNhap(pn);  // Giả sử bạn có form này
                form.ShowDialog();
            }

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimKiemPhieuNhap()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string kieuTim = cbKieuTimKiem.SelectedItem?.ToString();

            var danhSachGoc = Repository.GetAll();

            var ketQua = danhSachGoc.Where(p =>
            {
                if (kieuTim == "Mã phiếu nhập")
                {
                    return p.MaPhieuNhap.ToString().Contains(tuKhoa);
                }
                else if (kieuTim == "Nhà cung cấp")
                {
                    string tenNCC = Repository.GetTenNhaCungCapById(p.MaNCC).ToLower();
                    return tenNCC.Contains(tuKhoa);
                }
                return false;
            }).ToList();

            HienThiDanhSach(ketQua);
        }
        private void HienThiDanhSach(List<PhieuNhapModel> ds)
        {
            tbDanhSachPhieuNhap.SuspendLayout();
            tbDanhSachPhieuNhap.Controls.Clear();
            tbDanhSachPhieuNhap.RowStyles.Clear();
            tbDanhSachPhieuNhap.ColumnStyles.Clear();

            tbDanhSachPhieuNhap.ColumnCount = 5;
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            tbDanhSachPhieuNhap.RowCount = 1;
            tbDanhSachPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Mã phiếu nhập", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, 0);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Ngày tạo", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 1, 0);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Tổng tiền", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 2, 0);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Nhà cung cấp", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 3, 0);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 4, 0);

            for (int i = 0; i < ds.Count; i++)
            {
                var pn = ds[i];
                int rowIndex = i + 1;

                tbDanhSachPhieuNhap.RowCount++;
                tbDanhSachPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.MaPhieuNhap.ToString(), AutoSize = true }, 0, rowIndex);
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.NgayTao.ToString("dd-MM-yyyy HH:mm:ss"), AutoSize = true }, 1, rowIndex);
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.TongTien.ToString("N0"), AutoSize = true }, 2, rowIndex);
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = Repository.GetTenNhaCungCapById(pn.MaNCC), AutoSize = true }, 3, rowIndex);

                Button btnXem = new Button { Text = "Xem", Tag = pn, AutoSize = true };
                btnXem.Click += btnXem_Click;
                tbDanhSachPhieuNhap.Controls.Add(btnXem, 4, rowIndex);
            }

            tbDanhSachPhieuNhap.ResumeLayout(true);
        }


        private void LoadData()
        {
            // Tạm dừng việc vẽ giao diện để tối ưu hiệu suất
            tbDanhSachPhieuNhap.SuspendLayout();

            // Xóa các control cũ
            tbDanhSachPhieuNhap.Controls.Clear();
            tbDanhSachPhieuNhap.RowStyles.Clear();
            tbDanhSachPhieuNhap.ColumnStyles.Clear();

            // Thiết lập số cột
            tbDanhSachPhieuNhap.ColumnCount = 5;
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));  // Mã phiếu nhập
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Ngày tạo
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Tổng tiền
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Mã NCC
            tbDanhSachPhieuNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));  // Thao tác

            // Thiết lập dòng tiêu đề
            tbDanhSachPhieuNhap.RowCount = 1;
            tbDanhSachPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Dòng tiêu đề auto size

            int headerRow = 0;

            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Mã phiếu nhập", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, headerRow);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Ngày tạo", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 1, headerRow);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Tổng tiền", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 2, headerRow);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Nhà cung cấp", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 3, headerRow);
            tbDanhSachPhieuNhap.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 4, headerRow);

            // Lấy danh sách phiếu nhập
            List<PhieuNhapModel> ds = Repository.GetAll();

            // Thiết lập số hàng cho bảng, thêm 1 cho dòng tiêu đề
            tbDanhSachPhieuNhap.RowCount = ds.Count + 1; // Dòng tiêu đề + số dòng dữ liệu

            // Thiết lập kiểu chiều cao cho các dòng dữ liệu (auto size)
            for (int i = 0; i < ds.Count; i++)
            {
                tbDanhSachPhieuNhap.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Dòng dữ liệu auto size
            }

            // Thêm các dòng dữ liệu vào bảng
            for (int i = 0; i < ds.Count; i++)
            {
                var pn = ds[i];

                // Tạo một dòng mới cho mỗi item
                int rowIndex = i + 1;  // Dòng bắt đầu từ 1

                // Cột 0: Mã phiếu nhập
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.MaPhieuNhap.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

                // Cột 1: Ngày tạo
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.NgayTao.ToString("dd-MM-yyyy HH:mm:ss"), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, rowIndex);

                // Cột 2: Tổng tiền
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = pn.TongTien.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, rowIndex);

                // Cột 3: Mã nhà cung cấp
                tbDanhSachPhieuNhap.Controls.Add(new Label { Text = Repository.GetTenNhaCungCapById(pn.MaNCC), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                // Cột 4: Nút Xem
                Button btnXem = new Button { Text = "Xem", Tag = pn, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                btnXem.Click += btnXem_Click;
                tbDanhSachPhieuNhap.Controls.Add(btnXem, 4, rowIndex);
            }

            // Kiểm tra và gán chiều cao nếu cần
            foreach (RowStyle rowStyle in tbDanhSachPhieuNhap.RowStyles)
            {
                if (rowStyle.SizeType != SizeType.AutoSize)
                {
                    rowStyle.SizeType = SizeType.AutoSize;
                }
            }

            // Hoàn tất vẽ giao diện
            tbDanhSachPhieuNhap.ResumeLayout(true);
        }

        private void tbDanhSachPhieuNhap_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
