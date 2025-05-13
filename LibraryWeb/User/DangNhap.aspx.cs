using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using BCrypt.Net;
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
                string query = "SELECT * FROM taikhoan WHERE TenTaiKhoan = @user AND TrangThai = 'active'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string hashedPassword = reader["MatKhau"].ToString();

                    // So sánh mật khẩu người dùng nhập với mật khẩu đã mã hóa
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        string role = reader["VaiTro"].ToString();
                        if (!role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            int maThanhVien = Convert.ToInt32(reader["MaThanhVien"]);
                            Session["MaTaiKhoan"] = username;
                            Session["VaiTro"] = role;
                            Session["MaThanhVien"] = maThanhVien;

                            reader.Close(); // Đóng để chạy câu lệnh mới

                            string query2 = "SELECT MaThanhVien, HoTen FROM thanhvien WHERE MaThanhVien = @maTV";
                            using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                            {
                                cmd2.Parameters.AddWithValue("@maTV", maThanhVien);
                                using (var reader2 = cmd2.ExecuteReader())
                                {
                                    if (reader2.Read())
                                    {
                                        Session["TenThanhVien"] = reader2["HoTen"];
                                    }
                                }
                            }

                            Response.Redirect("TrangChu.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Không được phép đăng nhập với vai trò admin!');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu!');</script>");
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