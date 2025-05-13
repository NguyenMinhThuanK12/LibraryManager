using System;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using MySql.Data.MySqlClient;



namespace LibraryWeb.User
{
    public partial class QuenMatKhau : Page
    {
        private string otpSessionKey = "OTP";
        private string emailSessionKey = "Email";

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM taikhoan WHERE EXISTS (SELECT 1 FROM thanhvien WHERE taikhoan.MaThanhVien = thanhvien.MaThanhVien AND email = @Email)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Tạo mã OTP
                    Random rand = new Random();
                    string otp = rand.Next(100000, 999999).ToString();
                    Session[otpSessionKey] = otp;
                    Session[emailSessionKey] = email;

                    SendEmailOTP(email, otp);

                    lblMessage.Text = "Đã gửi mã OTP đến email của bạn.";
                    step1.Visible = false;
                    step2.Visible = true;
                    lblStep.Text = "Bước 2: Nhập mã OTP";
                }
                else
                {
                    lblMessage.Text = "Email không tồn tại trong hệ thống.";
                }
            }
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string otp = txtOTP.Text.Trim();
            if (Session[otpSessionKey]?.ToString() == otp)
            {
                lblMessage.Text = "Mã OTP hợp lệ, mời đặt lại mật khẩu.";
                step2.Visible = false;
                step3.Visible = true;
                lblStep.Text = "Bước 3: Đặt lại mật khẩu";
            }
            else
            {
                lblMessage.Text = "Mã OTP không đúng.";
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (newPass != confirmPass)
            {
                lblMessage.Text = "Mật khẩu xác nhận không khớp.";
                return;
            }

            string email = Session[emailSessionKey]?.ToString();
            using (MySqlConnection conn = MySqlHelper.GetConnection())
            {
                conn.Open();

                // Mã hóa mật khẩu trước khi lưu
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPass);

                string update = @"
            UPDATE taikhoan 
            SET MatKhau = @NewPassword
            WHERE MaThanhVien = (SELECT MaThanhVien FROM thanhvien WHERE email = @Email)";

                var cmd = new MySqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@NewPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "✅ Cập nhật mật khẩu thành công! Bạn có thể đăng nhập lại.";

                lnkBackToLogin.Visible = true;

                Session.Remove(otpSessionKey);
                Session.Remove(emailSessionKey);
            }
        }


        private void SendEmailOTP(string toEmail, string otp)
        {
            MailMessage mail = new MailMessage("minhthuan040903@gmail.com", toEmail);
            mail.Subject = "Mã OTP đặt lại mật khẩu";
            mail.Body = $"Mã OTP của bạn là: {otp}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("minhthuan040903@gmail.com", "tnzr oway wofo bknr");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
