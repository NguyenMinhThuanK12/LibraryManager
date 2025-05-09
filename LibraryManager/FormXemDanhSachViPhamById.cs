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
using LibraryManager.DTO;

namespace LibraryManager
{
    public partial class FormXemDanhSachViPhamById : Form
    {
        private PhieuPhatRepository phieuPhatRepository;
        private ThanhVienDTO thanhVien;
        private List<PhieuPhatModel> danhSachPhieuPhat;
        public FormXemDanhSachViPhamById(int maThanhVien)
        {
            InitializeComponent();
            phieuPhatRepository = new PhieuPhatRepository();
            this.thanhVien = phieuPhatRepository.getThanhVienById(maThanhVien);
            this.danhSachPhieuPhat = phieuPhatRepository.GetPhieuPhatByMaThanhVien(this.thanhVien.maThanhVien);
            loadData();
        }

        public void loadData()
        {
            lbMaThanhVien.Text = thanhVien.maThanhVien.ToString();
            lbTenThanhVien.Text = thanhVien.hoTen;
            lbDiaChi.Text = thanhVien.diaChi;
            lbSoDienThoai.Text = thanhVien.sdt;
            lbTongViPham.Text = danhSachPhieuPhat.Count().ToString();

            HienThiPhieuPhat(danhSachPhieuPhat);
        }
        private void HienThiPhieuPhat(List<PhieuPhatModel> danhSach)
        {
            tbDanhSachPhieuPhat.SuspendLayout();
            tbDanhSachPhieuPhat.Controls.Clear();
            tbDanhSachPhieuPhat.RowStyles.Clear();
            tbDanhSachPhieuPhat.ColumnStyles.Clear();

            tbDanhSachPhieuPhat.ColumnCount = 6;
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbDanhSachPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            tbDanhSachPhieuPhat.RowCount = 1;
            tbDanhSachPhieuPhat.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Mã phiếu phạt", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Mã phiếu mượn", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 1, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Tên thành viên", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 2, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Tổng tiền phạt", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 3, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Trạng Thái", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 4, 0);
            tbDanhSachPhieuPhat.Controls.Add(new Label { Text = "Thao tác", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 5, 0);

            tbDanhSachPhieuPhat.RowCount = danhSach.Count + 1;

            for (int i = 0; i < danhSach.Count; i++)
            {
                var pp = danhSach[i];
                int rowIndex = i + 1;

                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.MaPhieuPhat.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.MaPhieuMuon.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = phieuPhatRepository.GetTenThanhVienByMaPhieuPhat(pp.MaPhieuPhat), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TongTienPhat.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TrangThaiThanhToan, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 4, rowIndex);

                Button btnXem = new Button { Text = "Xem", Tag = pp, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                btnXem.Click += btnXemPhieuPhat_Click;
                tbDanhSachPhieuPhat.Controls.Add(btnXem, 5, rowIndex);
            }

            tbDanhSachPhieuPhat.ResumeLayout(true);
        }
        public void btnXemPhieuPhat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is PhieuPhatModel pp)
            {
                var frm = new FormXemChiTietPhieuPhat(pp);
                frm.ShowDialog(); // Hiển thị form xem chi tiết, chặn luồng
            }
        }
        public void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
