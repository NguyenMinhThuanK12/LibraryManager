using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.DTO
{
    public class ThanhVienDTO
    {
        public int maThanhVien { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public DateTime ngayDangKy { get; set; }
    }
}
