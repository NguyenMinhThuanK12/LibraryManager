using System;
using System.Runtime.InteropServices; // thêm dòng này để dùng DllImport
using System.Windows.Forms;

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

            // 👇 Gọi hàm để bo góc form
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        // Sự kiện click nút đăng nhập...
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Logic đăng nhập
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
    }
}
