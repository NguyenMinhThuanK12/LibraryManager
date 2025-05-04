using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class ChiTietPhieuNhapModel
    {
        public int MaPhieuNhap { get; set; }  // Mã phiếu nhập
        public int MaSanPham { get; set; }    // Mã sản phẩm
        public int SoLuong { get; set; }      // Số lượng sản phẩm
        public double GiaNhap { get; set; }  // Giá nhập của sản phẩm

        // Constructor mặc định
        public ChiTietPhieuNhapModel() { }

        // Constructor để khởi tạo giá trị
        public ChiTietPhieuNhapModel(int maSanPham, int soLuong, double giaNhap)
        {
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
        }

        // Phương thức để tính tổng tiền cho một chi tiết phiếu nhập
        public double TinhTongTien()
        {
            return SoLuong * GiaNhap;
        }
    }
}
