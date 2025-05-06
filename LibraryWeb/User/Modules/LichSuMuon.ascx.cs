using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User.Modules
{
    public partial class LichSu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
            LoadTrangThaiDropdown();
            LoadDanhSachPhieuMuon();
            

            string eventTarget = Request["__EVENTTARGET"];
            string eventArgument = Request["__EVENTARGUMENT"];
            if (eventTarget == "SelectPhieuMuon")
            {
                int maPhieuMuon = Convert.ToInt32(eventArgument);
                LoadChiTietPhieuMuon(maPhieuMuon);
            }
        }

        private void LoadTrangThaiDropdown()
        {
            ddlTrangThaiPM.Items.Clear();
            ddlTrangThaiPM.Items.Add(new ListItem("Tất cả", ""));
            ddlTrangThaiPM.Items.Add(new ListItem("Đang mượn", "Đang mượn"));
            ddlTrangThaiPM.Items.Add(new ListItem("Đã trả", "Đã trả"));
            ddlTrangThaiPM.Items.Add(new ListItem("Quá hạn", "Quá hạn"));
        }

        private void LoadDanhSachPhieuMuon()
        {
            int maTV = Convert.ToInt32(Session["MaThanhVien"]);
            string keyword = txtSearchPM.Text.Trim();
            string trangThai = ddlTrangThaiPM.SelectedValue;

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT MaPhieuMuon, NgayMuon, HanTra, ThoiGianTraThucTe, TongTien, TrangThaiMuon
                    FROM phieumuon
                    WHERE MaThanhVien = @maTV
                        AND (@keyword = '' OR MaPhieuMuon LIKE CONCAT('%', @keyword, '%'))
                        AND (@trangThai = '' OR TrangThaiMuon = @trangThai)
                    ORDER BY NgayMuon DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maTV", maTV);
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptPhieuMuonList.DataSource = dt;
                rptPhieuMuonList.DataBind();
            }
        }

        private void LoadChiTietPhieuMuon(int maPhieuMuon)
        {
            lblNgayTao.Text = "";
            lblTongTienChiTiet.Text = "";

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();

                string query1 = "SELECT NgayMuon, TongTien FROM phieumuon WHERE MaPhieuMuon = @maPhieu";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@maPhieu", maPhieuMuon);

                using (var reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNgayTao.Text = Convert.ToDateTime(reader["NgayMuon"]).ToString("dd/MM/yyyy HH:mm");
                        lblTongTienChiTiet.Text = Convert.ToDouble(reader["TongTien"]).ToString("N0") + " đ";
                    }
                }

                string query2 = @"
                    SELECT sp.TenSanPham, ctm.SoLuong, ctm.GiaMuon
                    FROM chitietphieumuon ctm
                    JOIN sanpham sp ON sp.MaSanPham = ctm.MaSanPham
                    WHERE ctm.MaPhieuMuon = @maPhieu";

                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@maPhieu", maPhieuMuon);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptChiTietPhieuMuon.DataSource = dt;
                rptChiTietPhieuMuon.DataBind();
            }
        }

        // Tự động gọi lại khi người dùng đổi dropdown hoặc textbox
        protected void ddlTrangThaiPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuMuon();
        }

        protected void txtSearchPM_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuMuon();
        }
    }
}
