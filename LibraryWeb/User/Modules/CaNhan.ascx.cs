using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

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
                        if (ngaySinhObj != DBNull.Value && DateTime.TryParse(ngaySinhObj.ToString(), out DateTime ngaySinh))
                        {
                            txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txtNgaySinh.Text = ""; 
                        }
                        txtEmail.Text = reader["Email"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                        txtUsername.Text = reader["TenTaiKhoan"].ToString();
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

            // Hiển thị thông báo thành công bằng alert
            ScriptManager.RegisterStartupScript(this, GetType(), "alertUpdateSuccess",
                "alert('✅ Cập nhật thông tin thành viên thành công!');", true);
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string matKhauXacNhan = txtXacNhanMatKhau.Text.Trim();

            // Check ô trống
            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(matKhauXacNhan))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertEmpty", "alert('❌ Vui lòng điền đầy đủ tất cả các trường!');", true);
                return;
            }

            // Kiểm tra mật khẩu cũ đúng không
            if (matKhauCu != hdnMatKhau.Value)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertWrongOld", "alert('❌ Mật khẩu cũ không chính xác!');", true);
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (matKhauMoi != matKhauXacNhan)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMismatch", "alert('❌ Mật khẩu mới không khớp!');", true);
                return;
            }

            int maTV = Convert.ToInt32(Session["MaThanhVien"]);

            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string update = "UPDATE taikhoan SET MatKhau = @MatKhau WHERE MaThanhVien = @maTV";

                MySqlCommand cmd = new MySqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@MatKhau", matKhauMoi);
                cmd.Parameters.AddWithValue("@maTV", maTV);

                cmd.ExecuteNonQuery();
            }

            // Hiển thị thành công
            ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('✅ Đổi mật khẩu thành công!');", true);

            // Reset các trường
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhanMatKhau.Text = "";
        }
    }
}
