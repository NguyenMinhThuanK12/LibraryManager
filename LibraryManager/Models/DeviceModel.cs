﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class DeviceModel
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public string TheLoai { get; set; }
        public int IDTheLoai { get; set; }
        public int IDViTri { get; set; }
        public int IDTang { get; set; }
        public string ViTri { get; set; }
        public int SoLuong { get; set; }
        public double GiaTri { get; set; }
        public string TrangThai { get; set; }
    }
}
