using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MaTaiKhoan"] != null)
            {
                string maTK = Session["MaTaiKhoan"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = @"
                        SELECT tv.HoTen, t.VaiTro 
                        FROM taikhoan t 
                        JOIN thanhvien tv ON t.MaThanhVien = tv.MaThanhVien 
                        WHERE t.MaTaiKhoan = @MaTaiKhoan";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTK);

                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        litHoTen.Text = reader["HoTen"].ToString();
                        litVaiTro.Text = reader["VaiTro"].ToString() == "admin" ? "Admin" : "Thành viên";
                    }
                }
            }
            else
            {
                Response.Redirect("~/User/DangNhap.aspx");
            }
        }
    }
        protected void btnDatChoMuon_Click(object sender, EventArgs e)
        {
            // Xử lý chuyển trang hoặc load content
        }

        protected void btnLichSu_Click(object sender, EventArgs e)
        {
            // Xử lý chuyển trang hoặc load content
        }

        protected void btnCaNhan_Click(object sender, EventArgs e)
        {
            // Xử lý chuyển trang hoặc load content
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/User/DangNhap.aspx");
        }
    }
}
