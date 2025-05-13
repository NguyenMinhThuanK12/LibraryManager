using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.DTO
{
    internal class QLmotTv
    {
        public string HoTen { get; set; } // Thuộc tính HoTen

        // Constructor để nhận tham số HoTen
        public QLmotTv(string hoTen)
        {
            HoTen = hoTen; // Gán giá trị hoTen cho thuộc tính HoTen
        }
    }
}
