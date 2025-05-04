using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM taikhoan WHERE TenTaiKhoan = @user AND MatKhau = @pass  AND TrangThai = 'active'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string role = reader["VaiTro"].ToString();
                    if (!role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // Ghi nhận phiên đăng nhập 
                        Session["MaTaiKhoan"] = username;
                        Session["VaiTro"] = role;

                        Response.Redirect("TrangChu.aspx");
                    }
                    else
                    {
                        // Nếu là admin thì không được vào
                        Response.Write("<script>alert('Không được phép đăng nhập với vai trò admin!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu!');</script>");
                }
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //chuyển hướng sang trang Đăng ký
            Response.Redirect("~/User/DangKy.aspx");
        }
    }
}