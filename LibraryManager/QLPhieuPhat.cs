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
            cbKieuTimKiem.Items.Clear();
            cbKieuTimKiem.Items.AddRange(new string[] { "Mã phiếu phạt", "Tên thành viên" });
            cbKieuTimKiem.SelectedIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string kieuTim = cbKieuTimKiem.SelectedItem?.ToString();

            var danhSach = Repository.GetAllPhieuPhat();

            var ketQua = danhSach.Where(pp =>
            {
                if (kieuTim == "Mã phiếu phạt")
                    return pp.MaPhieuPhat.ToString().Contains(tuKhoa);
                else if (kieuTim == "Tên thành viên")
                {
                    string tenTV = Repository.GetTenThanhVienByMaPhieuPhat(pp.MaPhieuPhat).ToLower();
                    return tenTV.Contains(tuKhoa);
                }
                return false;
            }).ToList();

            HienThiPhieuPhat(ketQua);
        }

        private void LoadData()
        {
            var danhSach = Repository.GetAllPhieuPhat();
            HienThiPhieuPhat(danhSach);
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
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = Repository.GetTenThanhVienByMaPhieuPhat(pp.MaPhieuPhat), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TongTienPhat.ToString("N0"), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);
                tbDanhSachPhieuPhat.Controls.Add(new Label { Text = pp.TrangThaiThanhToan, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 4, rowIndex);

                Button btnXem = new Button { Text = "Xem", Tag = pp, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                btnXem.Click += btnXemPhieuPhat_Click;
                tbDanhSachPhieuPhat.Controls.Add(btnXem, 5, rowIndex);
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
