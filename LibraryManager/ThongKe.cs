﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            LoadDataToThanhVienGrid();
            LoadDataToThietBiMuonGrid();
            LoadDataToDangMuonGrid();


        }

        private void dgvThanhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            LoadDataToThanhVienGrid();
            LoadDataToThietBiMuonGrid();
            LoadDataToDangMuonGrid();
        }

        private void txtProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
