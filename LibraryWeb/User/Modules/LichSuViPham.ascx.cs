using System;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User.Modules
{
    public partial class LichSuViPham : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            LoadTrangThaiDropdown();
            LoadDanhSachPhieuPhat();
           

            string eventTarget = Request["__EVENTTARGET"];
            string eventArgument = Request["__EVENTARGUMENT"];
            if (eventTarget == "SelectPhieuPhat")
            {
                int maPhieuPhat = Convert.ToInt32(eventArgument);
                LoadChiTietPhieuPhat(maPhieuPhat);
            }
        }

        private void LoadTrangThaiDropdown()
        {
            ddlTrangThaiPhat.Items.Clear();
            ddlTrangThaiPhat.Items.Add(new ListItem("Tất cả", ""));
            ddlTrangThaiPhat.Items.Add(new ListItem("Đã xử lý", "Đã xử lý"));
            ddlTrangThaiPhat.Items.Add(new ListItem("Chưa xử lý", "Chưa xử lý"));
        }

        private void LoadDanhSachPhieuPhat()
        {
            int maTV = Convert.ToInt32(Session["MaThanhVien"]);
            string keyword = txtSearchPhat.Text.Trim();
            string trangThai = ddlTrangThaiPhat.SelectedValue;

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT MaPhieuPhat, MaPhieuMuon, NgayTao, TrangThai
                    FROM phieuphat
                    WHERE MaPhieuMuon IN (
                        SELECT MaPhieuMuon FROM phieumuon WHERE MaThanhVien = @maTV
                    )
                    AND (@keyword = '' OR MaPhieuPhat LIKE CONCAT('%', @keyword, '%'))
                    AND (@trangThai = '' OR TrangThai = @trangThai)
                    ORDER BY NgayTao DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maTV", maTV);
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptPhieuPhat.DataSource = dt;
                rptPhieuPhat.DataBind();
            }
        }

        private void LoadChiTietPhieuPhat(int maPhieuPhat)
        {
            lblNgayTaoPhat.Text = "";
            lblTrangThaiPhat.Text = "";

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();

                string query1 = "SELECT NgayTao, TrangThai FROM phieuphat WHERE MaPhieuPhat = @maPhieu";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@maPhieu", maPhieuPhat);
                using (var reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNgayTaoPhat.Text = Convert.ToDateTime(reader["NgayTao"]).ToString("dd/MM/yyyy HH:mm");
                        lblTrangThaiPhat.Text = reader["TrangThai"].ToString();
                    }
                }

                string query2 = @"
                    SELECT sp.TenSanPham, ctp.TienPhat, ctp.LoaiPhat
                    FROM chitietphieuphat ctp
                    JOIN sanpham sp ON sp.MaSanPham = ctp.MaSanPham
                    WHERE ctp.MaPhieuPhat = @maPhieu";

                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@maPhieu", maPhieuPhat);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptChiTietPhieuPhat.DataSource = dt;
                rptChiTietPhieuPhat.DataBind();
            }
        }

        protected void txtSearchPhat_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuPhat();
        }

        protected void ddlTrangThaiPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuPhat();
        }
    }
}
