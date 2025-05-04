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
    public partial class QLPhieuPhat : UserControl
    {
        private PhieuPhatRepository Repository;
        public QLPhieuPhat()
        {
            Repository = new PhieuPhatRepository();
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            tbDanhSachPhieuPhat.SuspendLayout();

            // Xóa dữ liệu cũ
            tbDanhSachPhieuPhat.Controls.Clear();
            tbDanhSachPhieuPhat.RowStyles.Clear();
            tbDanhSachPhieuPhat.ColumnStyles.Clear();

            // Thiết lập cột
            tbDanhSachPhieuPhat.ColumnCount = 6;
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Mã phiếu phạt
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Mã phiếu mượn
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Ten thanh vien
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Tổng tiền phạt
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // TrangThai
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));  // Thao tác

            // Dòng tiêu đề
            tbDanhSachPhieuPhat.RowCount = 1;
            tbDanhSachPhieuPhat.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Mã phiếu phạt", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Mã phiếu mượn", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 1, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Tên thành viên", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 2, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Tổng tiền phạt", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 3, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Trạng Thái", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 4, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 5, 0);

            // Lấy dữ liệu phiếu phạt từ Repository
            List<PhieuPhatModel> danhSach = Repository.GetAllPhieuPhat(); // Hàm này bạn cần cài đặt trong Repository

            tbDanhSachPhieuPhat.RowCount = danhSach.Count + 1;

            for (int i = 0; i < danhSach.Count; i++)
            {
                var pp = danhSach[i];
                int rowIndex = i + 1;

                // Mã phiếu phạt
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.MaPhieuPhat.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

                // Mã phiếu mượn
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.MaPhieuMuon.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, rowIndex);
                // Mã phiếu mượn
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = Repository.GetTenThanhVienByMaPhieuPhat(pp.MaPhieuPhat), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, rowIndex);
                // Tổng tiền phạt
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TongTienPhat.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TrangThaiThanhToan, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 4, rowIndex);

                // Nút "Xem"
                Button btnXem = new Button { Text = "Xem", Tag = pp, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                btnXem.Click += btnXemPhieuPhat_Click;
                tbDanhSachPhieuPhat.Controls.Add(btnXem, 5, rowIndex);
            }

            // Đảm bảo tự động tính chiều cao dòng
            foreach (RowStyle rowStyle in tbDanhSachPhieuPhat.RowStyles)
            {
                if (rowStyle.SizeType != SizeType.AutoSize)
                    rowStyle.SizeType = SizeType.AutoSize;
            }

            tbDanhSachPhieuPhat.ResumeLayout(true);
        }
        private void btnXemPhieuPhat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is PhieuPhatModel pp)
            {
                var frm = new FormXemChiTietPhieuPhat(pp);
                frm.FormClosed += (s, args) => { LoadData(); }; // gán sự kiện khi form con tắ
                frm.ShowDialog(); // Hiển thị form xem chi tiết, chặn luồng
            }
        }

    }
}
