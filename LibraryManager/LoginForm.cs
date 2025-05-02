using System;
using System.Runtime.InteropServices; // thêm dòng này để dùng DllImport
using System.Windows.Forms;
using LibraryManager.ConnectDatabase;
using System.Data;
namespace LibraryManager
{
    public partial class LoginForm : Form
    {
        // 👇 Thêm đoạn này vào đầu class LoginForm

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // x góc trái
            int nTopRect,       // y góc trên
            int nRightRect,     // x góc phải
            int nBottomRect,    // y góc dưới
            int nWidthEllipse,  // độ cong ngang
            int nHeightEllipse  // độ cong dọc
        );

        public LoginForm()
        {
            InitializeComponent();

            // Gọi hàm để bo góc form
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        // Sự kiện click nút đăng nhập...
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Logic đăng nhập
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
                return;
            }

            // Viết truy vấn kiểm tra tài khoản trong bảng taikhoan
            string query = $"SELECT * FROM taikhoan WHERE VaiTro = '{username}' AND MatKhau = '{password}' AND TrangThai = 'active'";

            DataTable dt = DatabaseConnection.ExecuteSelectQuery(query);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản bị vô hiệu hóa.");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblRegisterPrompt_Click(object sender, EventArgs e)
        {
                    }
    }
}
