using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using BCrypt.Net; // ✅ THÊM using

namespace LibraryWeb.User.Modules
{
    public partial class CaNhan : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
        }

        private void LoadThongTinCaNhan()
        {
            if (Session["MaThanhVien"] == null)
            {
                lblThongBao.Text = "❌ Phiên đăng nhập không tồn tại.";
                return;
            }

            int maTV = Convert.ToInt32(Session["MaThanhVien"]);
            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT tv.MaThanhVien, tv.HoTen, tv.NgaySinh, tv.SDT, tv.Email, tv.DiaChi,
                           tk.TenTaiKhoan, tk.MatKhau
                    FROM thanhvien tv
                    JOIN taikhoan tk ON tv.MaThanhVien = tk.MaThanhVien
                    WHERE tv.MaThanhVien = @maTV";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maTV", maTV);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMaThanhVien.Text = reader["MaThanhVien"].ToString();
                        txtHoTen.Text = reader["HoTen"].ToString();
                        object ngaySinhObj = reader["NgaySinh"];
                        txtNgaySinh.Text = (ngaySinhObj != DBNull.Value && DateTime.TryParse(ngaySinhObj.ToString(), out DateTime ngaySinh))
                            ? ngaySinh.ToString("dd/MM/yyyy")
                            : "";

                        txtEmail.Text = reader["Email"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                        txtUsername.Text = reader["TenTaiKhoan"].ToString();

                        //  Lưu hash mật khẩu
                        hdnMatKhau.Value = reader["MatKhau"].ToString();
                    }
                    else
                    {
                        lblThongBao.Text = "❌ Không tìm thấy thông tin thành viên!";
                    }
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            int maTV = Convert.ToInt32(Session["MaThanhVien"]);

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string update = @"
                    UPDATE thanhvien 
                    SET Email = @Email, SDT = @SDT, DiaChi = @DiaChi 
                    WHERE MaThanhVien = @maTV";

                MySqlCommand cmd = new MySqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@maTV", maTV);

                cmd.ExecuteNonQuery();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alertUpdateSuccess",
                "alert('✅ Cập nhật thông tin thành công!');", true);
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string matKhauXacNhan = txtXacNhanMatKhau.Text.Trim();

            // Kiểm tra trống
            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(matKhauXacNhan))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertEmpty", "alert('❌ Vui lòng điền đầy đủ thông tin!');", true);
                return;
            }

            // So sánh mật khẩu cũ với hash lưu trong DB
            string hashedOldPass = hdnMatKhau.Value;
            if (!BCrypt.Net.BCrypt.Verify(matKhauCu, hashedOldPass))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertWrongOld", "alert('❌ Mật khẩu cũ không chính xác!');", true);
                return;
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (matKhauMoi != matKhauXacNhan)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMismatch", "alert('❌ Mật khẩu mới không khớp!');", true);
                return;
            }

            // Hash mật khẩu mới
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
            int maTV = Convert.ToInt32(Session["MaThanhVien"]);

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string update = "UPDATE taikhoan SET MatKhau = @MatKhau WHERE MaThanhVien = @maTV";

                MySqlCommand cmd = new MySqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@MatKhau", hashedNewPassword);
                cmd.Parameters.AddWithValue("@maTV", maTV);

                cmd.ExecuteNonQuery();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('✅ Đổi mật khẩu thành công!');", true);
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhanMatKhau.Text = "";
        }
    }
}
