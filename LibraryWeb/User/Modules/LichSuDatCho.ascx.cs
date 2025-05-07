using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User.Modules
{
    public partial class LichSuDatCho : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            LoadTrangThaiDropdown();
            LoadDanhSachPhieuDatCho();
            

            string eventTarget = Request["__EVENTTARGET"];
            string eventArgument = Request["__EVENTARGUMENT"];
            if (eventTarget == "SelectPhieuDatCho")
            {
                int maPhieu = Convert.ToInt32(eventArgument);
                LoadChiTietPhieuDatCho(maPhieu);
            }
        }

        private void LoadTrangThaiDropdown()
        {
            ddlTrangThaiDC.Items.Clear();
            ddlTrangThaiDC.Items.Add(new ListItem("Tất cả", ""));
            ddlTrangThaiDC.Items.Add(new ListItem("Đang xử lý", "Đang xử lý"));
            ddlTrangThaiDC.Items.Add(new ListItem("Đã xác nhận", "Đã xác nhận"));
            ddlTrangThaiDC.Items.Add(new ListItem("Đã huỷ", "Đã huỷ"));
        }

        private void LoadDanhSachPhieuDatCho()
        {
            int maTV = Convert.ToInt32(Session["MaThanhVien"]);
            string keyword = txtSearchDC.Text.Trim();
            string trangThai = ddlTrangThaiDC.SelectedValue;

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT MaPhieu, ThoiGianDat, ThoiGianMuonDuKien, TrangThaiDat
                    FROM phieudatcho
                    WHERE MaThanhVien = @maTV
                        AND (@keyword = '' OR MaPhieu LIKE CONCAT('%', @keyword, '%'))
                        AND (@trangThai = '' OR TrangThaiDat = @trangThai)
                    ORDER BY MaPhieu ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maTV", maTV);
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptPhieuDatCho.DataSource = dt;
                rptPhieuDatCho.DataBind();
            }
        }

        private void LoadChiTietPhieuDatCho(int maPhieu)
        {
            lblThoiGianDat.Text = "";
            lblThoiGianMuon.Text = "";
            lblTrangThaiDat.Text = "";

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();

                // Lấy thông tin tổng quan
                string queryInfo = @"
                    SELECT ThoiGianDat, ThoiGianMuonDuKien, TrangThaiDat
                    FROM phieudatcho
                    WHERE MaPhieu = @maPhieu";

                MySqlCommand cmdInfo = new MySqlCommand(queryInfo, conn);
                cmdInfo.Parameters.AddWithValue("@maPhieu", maPhieu);
                using (var reader = cmdInfo.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblThoiGianDat.Text = Convert.ToDateTime(reader["ThoiGianDat"]).ToString("dd/MM/yyyy HH:mm");
                        lblThoiGianMuon.Text = Convert.ToDateTime(reader["ThoiGianMuonDuKien"]).ToString("dd/MM/yyyy HH:mm");
                        lblTrangThaiDat.Text = reader["TrangThaiDat"].ToString();
                    }
                }

                // Lấy thông tin thiết bị từ phieudatcho join sanpham
                string queryDetail = @"
                    SELECT sp.TenSanPham, pdc.SoLuong
                    FROM phieudatcho pdc
                    JOIN sanpham sp ON sp.MaSanPham = pdc.MaSanPham
                    WHERE pdc.MaPhieu = @maPhieu";

                MySqlCommand cmdDetail = new MySqlCommand(queryDetail, conn);
                cmdDetail.Parameters.AddWithValue("@maPhieu", maPhieu);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDetail);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptChiTietPhieuDatCho.DataSource = dt;
                rptChiTietPhieuDatCho.DataBind();
            }
        }

        protected void ddlTrangThaiDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuDatCho();
        }

        protected void txtSearchDC_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuDatCho();
        }
    }
}
