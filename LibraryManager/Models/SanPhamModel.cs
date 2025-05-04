using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }   // Mã sản phẩm
        public int MaViTri { get; set; }     // Mã vị trí
        public int MaTang { get; set; }      // Mã tầng
        public string TenSanPham { get; set; } // Tên sản phẩm
        public int SoLuong { get; set; }     // Số lượng
        public string TrangThai { get; set; }  // Trạng thái (ví dụ: "Còn hàng", "Hết hàng")


        // Constructor
        public SanPhamModel() { }
        public SanPhamModel(int maSanPham, int maViTri, int maTang, string tenSanPham, int soLuong, string trangThai)
        {
            MaSanPham = maSanPham;
            MaViTri = maViTri;
            MaTang = maTang;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            TrangThai = trangThai;
        }
    }

}
