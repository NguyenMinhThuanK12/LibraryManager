using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class NhaCungCapModel
    {
        // Mã nhà cung cấp
        public int MaNCC { get; set; }

        // Tên nhà cung cấp
        public string TenNCC { get; set; }

        // Số điện thoại
        public string SDT { get; set; }

        // Email
        public string Email { get; set; }

        // Địa chỉ
        public string DiaChi { get; set; }

        // Trạng thái (ví dụ: 1 cho kích hoạt, 0 cho không kích hoạt)
        public string TrangThai { get; set; }

        // Constructor mặc định
        public NhaCungCapModel() { }

        // Constructor với các tham số
        public NhaCungCapModel(int maNCC, string tenNCC, string sdt, string email, string diaChi, string trangThai)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            Email = email;
            DiaChi = diaChi;
            TrangThai = trangThai;
        }
    }

}
