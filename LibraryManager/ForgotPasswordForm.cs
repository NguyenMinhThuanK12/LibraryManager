using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using BCrypt.Net;
using LibraryManager.ConnectDatabase;

namespace LibraryManager
{
    public class ForgotPasswordForm : Form
    {
        private TextBox txtEmail, txtOtp, txtNewPassword, txtConfirmPassword;
        private Button btnSendOtp, btnVerifyOtp, btnResetPassword;
        private Label lblMessage;
        private string generatedOtp;
        private string currentEmail;

        public ForgotPasswordForm()
        {
            this.Text = "Quên mật khẩu";
            this.Size = new Size(580, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 11F);
            this.BackColor = Color.White;

            Label lblEmail = new Label { Text = "Email:", Location = new Point(40, 30), AutoSize = true };
            txtEmail = new TextBox { Location = new Point(200, 25), Width = 250 };
            btnSendOtp = new Button
            {
                Text = "Gửi OTP",
                Location = new Point(200, 80),
                Width = 100,
                Height = 50,
                Cursor = Cursors.Hand
            };
            btnSendOtp.Click += BtnSendOtp_Click;

            Label lblOtp = new Label { Text = "Mã OTP:", Location = new Point(40, 160), AutoSize = true };
            txtOtp = new TextBox { Location = new Point(200, 155), Width = 250, Enabled = false };
            btnVerifyOtp = new Button
            {
                Text = "Xác minh OTP",
                Location = new Point(200, 210),
                Width = 140,
                Height = 50,
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnVerifyOtp.Click += BtnVerifyOtp_Click;

            Label lblNewPass = new Label { Text = "Mật khẩu mới:", Location = new Point(40, 280), AutoSize = true };
            txtNewPassword = new TextBox { Location = new Point(220, 280), Width = 250, UseSystemPasswordChar = true, Enabled = false };

            Label lblConfirmPass = new Label { Text = "Xác nhận mật khẩu:", Location = new Point(40, 330), AutoSize = true };
            txtConfirmPassword = new TextBox { Location = new Point(220, 330), Width = 250, UseSystemPasswordChar = true, Enabled = false };

            btnResetPassword = new Button
            {
                Text = "Đặt lại mật khẩu",
                Location = new Point(200, 380),
                Width = 180,
                Height = 50,
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnResetPassword.Click += BtnResetPassword_Click;

            lblMessage = new Label
            {
                Location = new Point(40, 390),
                AutoSize = true,
                ForeColor = Color.Red
            };

            Controls.AddRange(new Control[]
            {
            lblEmail, txtEmail, btnSendOtp,
            lblOtp, txtOtp, btnVerifyOtp,
            lblNewPass, txtNewPassword,
            lblConfirmPass, txtConfirmPassword,
            btnResetPassword, lblMessage
            });
        }

        private void BtnSendOtp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $@"SELECT * FROM thanhvien WHERE Email = '{email}'";
            DataTable dt = DatabaseConnection.ExecuteSelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                Random rand = new Random();
                generatedOtp = rand.Next(100000, 999999).ToString();
                currentEmail = email;

                SendEmailOTP(email, generatedOtp);

                MessageBox.Show("✅ Đã gửi OTP, vui lòng kiểm tra email.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOtp.Enabled = btnVerifyOtp.Enabled = true;
            }
            else
            {
                MessageBox.Show("❌ Email không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerifyOtp_Click(object sender, EventArgs e)
        {
            if (txtOtp.Text.Trim() == generatedOtp)
            {
                MessageBox.Show("✅ Mã OTP đúng, vui lòng nhập mật khẩu mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Enabled = txtConfirmPassword.Enabled = btnResetPassword.Enabled = true;
            }
            else
            {
                MessageBox.Show("❌ Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            string pass1 = txtNewPassword.Text.Trim();
            string pass2 = txtConfirmPassword.Text.Trim();

            if (pass1 != pass2)
            {
                MessageBox.Show("❌ Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashed = BCrypt.Net.BCrypt.HashPassword(pass1);

            string update = $@"UPDATE taikhoan SET MatKhau = '{hashed}' WHERE MaThanhVien = (SELECT MaThanhVien FROM thanhvien WHERE Email = '{currentEmail}')";
            DatabaseConnection.ExecuteNonQuery(update);

            MessageBox.Show("✅ Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void SendEmailOTP(string toEmail, string otp)
        {
            MailMessage mail = new MailMessage("thuanaz93@gmail.com", toEmail);
            mail.Subject = "Mã OTP khôi phục mật khẩu";
            mail.Body = $"Mã OTP của bạn là: {otp}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("thuanaz93@gmail.com", "qzcj pizy vslx wacy"),
                EnableSsl = true
            };
            smtp.Send(mail);
        }
    }
}
