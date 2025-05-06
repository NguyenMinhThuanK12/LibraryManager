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
    public partial class FormXemChiTietPhieuPhat : Form
    {
        private PhieuPhatModel phieuPhat;
        private PhieuPhatRepository Repository;
        public FormXemChiTietPhieuPhat(PhieuPhatModel pp)
        {
            phieuPhat = pp;
            Repository = new PhieuPhatRepository();
            InitializeComponent();
            LoadThongTinPhieuPhat();
        }
        private void LoadThongTinPhieuPhat()
        {
            lbMaPhieuPhat.Text = phieuPhat.MaPhieuPhat.ToString();
            lbMaPhieuMuon.Text = phieuPhat.MaPhieuMuon.ToString();
            lbTongTienPhat.Text = phieuPhat.TongTienPhat.ToString("N0");


            lbMaThanhVien.Text = Repository.GetMaThanhVienByMaPhieuPhat(phieuPhat.MaPhieuPhat).ToString();
            lbTenThanhVien.Text = Repository.GetTenThanhVienByMaPhieuPhat(phieuPhat.MaPhieuPhat);


            // Xóa tất cả nội dung hiện tại
            tbChiTietPhieuPhat.Controls.Clear();
            tbChiTietPhieuPhat.RowStyles.Clear();
            tbChiTietPhieuPhat.RowCount = 0;
            tbChiTietPhieuPhat.ColumnCount = 4;
            tbChiTietPhieuPhat.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
            {
                tbChiTietPhieuPhat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            // Thêm tiêu đề cột
            tbChiTietPhieuPhat.RowCount++;
            tbChiTietPhieuPhat.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbChiTietPhieuPhat.Controls.Add(new Label() { Text = "Mã Sản Phẩm", Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true }, 0, 0);
            tbChiTietPhieuPhat.Controls.Add(new Label() { Text = "Tên Sản Phẩm", Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true }, 1, 0);
            tbChiTietPhieuPhat.Controls.Add(new Label() { Text = "Lý Do Phạt", Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true }, 2, 0);
            tbChiTietPhieuPhat.Controls.Add(new Label() { Text = "Tiền Phạt", Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true }, 3, 0);

            // Load danh sách chi tiết phiếu phạt
            var chiTietList = Repository.GetChiTietPhieuPhat(phieuPhat.MaPhieuPhat);
            int row = 1;
            foreach (var ct in chiTietList)
            {
                tbChiTietPhieuPhat.RowCount++;
                tbChiTietPhieuPhat.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                tbChiTietPhieuPhat.Controls.Add(new Label() { Text = ct.MaSanPham.ToString(), AutoSize = true }, 0, row);
                tbChiTietPhieuPhat.Controls.Add(new Label() { Text = Repository.GetTenSanPhamById(ct.MaSanPham), AutoSize = true }, 1, row);
                tbChiTietPhieuPhat.Controls.Add(new Label() { Text = ct.LoaiPhat, AutoSize = true }, 2, row);
                tbChiTietPhieuPhat.Controls.Add(new Label() { Text = ct.TienPhat.ToString("N0"), AutoSize = true }, 3, row);

                row++;
            }
            // Kiểm tra trạng thái
            if (phieuPhat.TrangThaiThanhToan == "Đã Thanh Toán")
            {
                btnXacNhanThanhToan.Enabled = false;
                btnXacNhanThanhToan.BackColor = Color.Gray; // tuỳ chọn để làm nút mờ đi
                btnXacNhanThanhToan.Text = "Đã Thanh Toán";
            }
            else
            {
                btnXacNhanThanhToan.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Nút xác nhận thanh toán
        private void button1_Click(object sender, EventArgs e)
        {
            if (phieuPhat == null)
            {
                MessageBox.Show("Không có phiếu phạt để cập nhật.");
                return;
            }

            DialogResult result = MessageBox.Show(
                        $"Bạn có chắc muốn xác nhận thanh toán phiếu phạt này ?",
                        "Xác nhận thanh toán",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

            if (result == DialogResult.Yes)
            {
                bool ketQua = Repository.CapNhatTrangThaiPhieuPhat(phieuPhat.MaPhieuPhat);

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!");
                    this.Close(); // hoặc: LoadDanhSachPhieuPhat();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
        }

        private void lbMaPhieuMuon_Click(object sender, EventArgs e)
        {

        }
    }
}
