using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class PhieuNhapModel
    {
        public int MaPhieuNhap { get; set; }
        public DateTime NgayTao { get; set; }
        public double TongTien { get; set; }
        public int MaNCC { get; set; }

        public PhieuNhapModel() { }

        public PhieuNhapModel(int maPhieuNhap, double tongTien, int maNCC)
        {
            MaPhieuNhap = maPhieuNhap;
            TongTien = tongTien;
            MaNCC = maNCC;
        }
    }
}
