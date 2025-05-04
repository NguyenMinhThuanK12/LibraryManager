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
    }
}
