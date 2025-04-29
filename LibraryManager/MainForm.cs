using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LibraryManager
{
    public class MainForm : Form
    {
        private Panel sidebar;
        private Panel topbar;
        private Panel contentPanel;
        private Panel separatorVertical;   // đường kẻ chia sidebar-content
        private Panel separatorHorizontal; // đường kẻ chia topbar-content
        private Label lblLogo, lblUser, lblTime;
        private PictureBox picLogo, picUser;
        private Button btnOverview, btnMember, btnBorrow, btnDevice, btnReservation, btnViolation, btnDiscount, btnReceipt, btnLogout;
        private Button currentSelectedButton;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
         int nLeftRect, int nTopRect,
         int nRightRect, int nBottomRect,
         int nWidthEllipse, int nHeightEllipse
        );
        public MainForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
        }

        private void InitializeComponent()
        {
            this.Text = "Library Dashboard";
            this.ClientSize = new Size(1510, 810);
            this.FormBorderStyle = FormBorderStyle.None; // bỏ viền cứng Windows
            this.BackColor = Color.WhiteSmoke; // màu nền tổng thể
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            topbar = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 60
            };

            picLogo = new PictureBox
            {
                Image = Properties.Resources.LogoApp,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                Size = new Size(40, 40)
            };

            lblLogo = new Label
            {
                Text = "Library App",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(60, 18),
                AutoSize = true
            };

            picUser = new PictureBox
            {
                Image = Properties.Resources.user,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(220, 15),
                Size = new Size(30, 30)
            };

            lblUser = new Label
            {
                Text = "Nguyễn Minh Thuận\nAdmin",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(260, 12),
                AutoSize = true
            };

            lblTime = new Label
            {
                Text = $"{DateTime.Now:hh:mm tt}\n{DateTime.Now:MMM dd, yyyy}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.TopRight,
                AutoSize = true,
                Location = new Point(1350, 10)
            };

            topbar.Controls.AddRange(new Control[] { picLogo, lblLogo, picUser, lblUser, lblTime });

            sidebar = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Left,
                Width = 210
            };

            btnOverview = CreateSidebarButton("Tổng quan", Properties.Resources.dashboard, 20);
            btnMember = CreateSidebarButton("Thành viên", Properties.Resources.user, 80);
            btnBorrow = CreateSidebarButton("Phiếu mượn", Properties.Resources.note, 140);
            btnDevice = CreateSidebarButton("Thiết bị", Properties.Resources.book, 200);
            btnReservation = CreateSidebarButton("Đặt chỗ", Properties.Resources.calendar, 260);
            btnViolation = CreateSidebarButton("Vi phạm", Properties.Resources.cancel, 320);
            btnDiscount = CreateSidebarButton("Giảm giá", Properties.Resources.Tag, 380);
            btnReceipt = CreateSidebarButton("Phiếu nhập", Properties.Resources.Download, 440);
            btnLogout = CreateSidebarButton("Đăng xuất", Properties.Resources.Logout, 680, true);

            sidebar.Controls.AddRange(new Control[]
            {
                btnOverview, btnMember, btnBorrow, btnDevice,
                btnReservation, btnViolation, btnDiscount, btnReceipt,
                btnLogout
            });

            contentPanel = new Panel
            {
                Location = new Point(210, 60),
                Size = new Size(1300, 750),
                BackColor = Color.White
            };
            separatorVertical = new Panel
            {
                BackColor = Color.LightGray,
                Location = new Point(210, 0),
                Width = 1,
                Height = 810
            };

            // Separator horizontal (giữa topbar và content)
            separatorHorizontal = new Panel
            {
                BackColor = Color.LightGray,
                Location = new Point(0, 60),
                Width = 1510,
                Height = 1
            };

            this.Controls.Add(separatorVertical);
            this.Controls.Add(separatorHorizontal);
            this.Controls.Add(sidebar);
            this.Controls.Add(topbar);
            this.Controls.Add(contentPanel);

        }

        private Button CreateSidebarButton(string text, Image icon, int top, bool isLogout = false)
        {
            Button btn = new Button
            {
                Text = "       " + text,
                Image = new Bitmap(icon, new Size(22, 22)),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(160, 45),
                Location = new Point(20, top),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.White,
                ForeColor = isLogout ? Color.Red : Color.Black,
                Cursor = Cursors.Hand,
                Padding = new Padding(5, 5, 5,5)
            };
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 15, 15));
            if (!isLogout)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn.BackColor == Color.White)
                        btn.BackColor = Color.FromArgb(245, 245, 245);
                };
                btn.MouseLeave += (s, e) =>
                {
                    if (btn.BackColor == Color.FromArgb(245, 245, 245))
                        btn.BackColor = Color.White;
                };
            }
            btn.Click += (s, e) => SelectSidebarButton(btn);
            return btn;
        }

        private void SelectSidebarButton(Button btn)
        {
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.White;
                currentSelectedButton.ForeColor = Color.Black;
            }

            btn.BackColor = Color.FromArgb(52, 168, 83); // xanh lá
            btn.ForeColor = Color.White;

            currentSelectedButton = btn;
            LoadContent(btn.Text.Trim());

        }

        private void LoadContent(string module)
        {
            contentPanel.Controls.Clear();
            UserControl control = null;
            if (string.Equals(module, "Tổng quan", StringComparison.OrdinalIgnoreCase))
            {
                //  mở giao diện Tổng quan
            }
            else if (string.Equals(module, "Thành viên", StringComparison.OrdinalIgnoreCase))
            {
                // mở giao diện Thành viên
            }
            else if (string.Equals(module, "Phiếu mượn", StringComparison.OrdinalIgnoreCase))
            {
                //  mở giao diện Phiếu mượn
            }
            else if (string.Equals(module, "Thiết bị", StringComparison.OrdinalIgnoreCase))
            {
                // mở giao diện Thiết bị
            }
            else if (string.Equals(module, "Đặt chỗ", StringComparison.OrdinalIgnoreCase))
            {
                // mở giao diện Đặt chỗ
            }
            else if (string.Equals(module, "Vi phạm", StringComparison.OrdinalIgnoreCase))
            {
                // mở giao diện Vi phạm
            }
            else if (string.Equals(module, "Giảm giá", StringComparison.OrdinalIgnoreCase))
            {
                //  mở giao diện Giảm giá
            }
            else if (string.Equals(module, "Phiếu nhập", StringComparison.OrdinalIgnoreCase))
            {
                //  mở giao diện Phiếu nhập
              
            }
            else if (string.Equals(module, "Đăng xuất", StringComparison.OrdinalIgnoreCase))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    var loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
            else
            {
                // Nếu không match module nào thì mặc định
                Label lbl = new Label();
                lbl.Text = $"[ {module} module hiển thị ở đây ]";
                lbl.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lbl.ForeColor = Color.Gray;
                lbl.AutoSize = true;
                lbl.Location = new Point(100, 100);
                contentPanel.Controls.Add(lbl);
            }
            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(control);
            }
        }
        private void ApplyRoundedCorners()
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
        }
    }
}
