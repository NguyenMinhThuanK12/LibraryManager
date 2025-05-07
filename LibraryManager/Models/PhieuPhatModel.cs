using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class PhieuPhatModel
    {
        public int MaPhieuPhat { get; set; }
        public int MaPhieuMuon { get; set; }
        public double TongTienPhat { get; set; }
        public DateTime NgayTao { get; set; }

        public String TrangThaiThanhToan { get; set; }

        public PhieuPhatModel() { }
        public PhieuPhatModel(int maPhieuPhat, int maPhieuMuon, double tongTienPhat, DateTime ngayTao, string trangThaiThanhToan)
        {
            MaPhieuPhat = maPhieuPhat;
            MaPhieuMuon = maPhieuMuon;
            TongTienPhat = tongTienPhat;
            NgayTao = ngayTao;
            TrangThaiThanhToan = trangThaiThanhToan;
        }
        public PhieuPhatModel(int maPhieuPhat, int maPhieuMuon, double tongTienPhat, string trangThaiThanhToan)
        {
            MaPhieuPhat = maPhieuPhat;
            MaPhieuMuon = maPhieuMuon;
            TongTienPhat = tongTienPhat;
            TrangThaiThanhToan = trangThaiThanhToan;
        }
    }
}
