// File: DangKy.aspx.cs
using System;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("DangNhap.aspx");
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string tenTaiKhoan = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            // 1. Kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(ngaySinhText) || string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi) ||
                string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                ShowAlert("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Kiểm tra định dạng email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowAlert("Email không hợp lệ!");
                return;
            }

            // 3. Chuyển đổi ngày sinh
            if (!DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
            {
                ShowAlert("Ngày sinh không hợp lệ!");
                return;
            }

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();

                // 4. Kiểm tra trùng tên tài khoản, email, số điện thoại
                string checkQuery = @"SELECT COUNT(*) FROM taikhoan tk
                              JOIN thanhvien tv ON tk.MaThanhVien = tv.MaThanhVien
                              WHERE tk.TenTaiKhoan = @tenTK OR tv.Email = @Email OR tv.SDT = @SDT";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@tenTK", tenTaiKhoan);
                checkCmd.Parameters.AddWithValue("@Email", email);
                checkCmd.Parameters.AddWithValue("@SDT", sdt);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    ShowAlert("Tên tài khoản, email hoặc số điện thoại đã được sử dụng!");
                    return;
                }

                // 5. Insert thành viên
                string insertTV = @"
            INSERT INTO thanhvien (HoTen, NgaySinh, SDT, Email, DiaChi, NgayDangKy)
            VALUES (@hoTen, @ngaySinh, @sdt, @email, @diaChi, @ngayDK);
            SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(insertTV, conn);
                cmd.Parameters.AddWithValue("@hoTen", hoTen);
                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@ngayDK", DateTime.Now);

                int maThanhVien = Convert.ToInt32(cmd.ExecuteScalar());

                //  Mã hoá mật khẩu
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);
                // 6. Insert tài khoản
                string insertTK = @"
            INSERT INTO taikhoan (TenTaiKhoan, MaThanhVien, MatKhau, VaiTro, TrangThai,
                                   ThoiGianDangKy_GiaHan, ThoiGianSuDungConLai, Phi_DangKy_GiaHan)
            VALUES (@tenTK, @maTV, @matKhau, 'user', 'active', @thoiGianDangKy, @thoiGianSuDung, @phiDangKy);";

                MySqlCommand cmd2 = new MySqlCommand(insertTK, conn);
                cmd2.Parameters.AddWithValue("@tenTK", tenTaiKhoan);
                cmd2.Parameters.AddWithValue("@maTV", maThanhVien);
                cmd2.Parameters.AddWithValue("@matKhau", hashedPassword);
                cmd2.Parameters.AddWithValue("@thoiGianDangKy", DateTime.Now);
                cmd2.Parameters.AddWithValue("@thoiGianSuDung", DateTime.Now.AddMonths(1));
                cmd2.Parameters.AddWithValue("@phiDangKy", 0);

                cmd2.ExecuteNonQuery();
            }

            // 7. Đăng ký thành công
            string script = @"
        <script>
            alert('Đăng ký thành công!');
            window.location.href='DangNhap.aspx';
        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "redirect", script);
        }

        // Hàm hiển thị thông báo lỗi
        private void ShowAlert(string message)
        {
            string script = $"<script>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
    }
}
