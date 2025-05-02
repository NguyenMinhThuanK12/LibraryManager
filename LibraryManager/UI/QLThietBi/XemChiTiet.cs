using LibraryManager.Model;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibraryManager.UI.QLThietBi
{
    public class XemChiTiet : Form
    {
        private TextBox txtId, txtTen, txtTheLoai, txtViTri, txtTang, txtSoLuong, txtGiaTri;
        private Button btnDong;
        private DeviceModel device;

        public XemChiTiet(DeviceModel selectedDevice)
        {
            device = selectedDevice;
            InitializeComponent();
            LoadDeviceInfo();
        }

        private void InitializeComponent()
        {
            Text = "Chi tiết thiết bị";
            Size = new Size(640, 750);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(255, 248, 220);

            Controls.Add(CreateLabel("📖 Chi tiết thiết bị", 25, 40, bold: true, size: 16));
            Controls.Add(CreateLine(70));

            int y = 90;
            Controls.Add(CreateLabel("ID", y));
            txtId = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Tên thiết bị", y += 50));
            txtTen = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Thể loại", y += 50));
            txtTheLoai = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Vị trí", y += 50));
            txtViTri = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Tầng", y += 50));
            txtTang = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Số lượng", y += 50));
            txtSoLuong = CreateTextBox(y += 30, readOnly: true);

            Controls.Add(CreateLabel("Giá trị", y += 50));
            txtGiaTri = CreateTextBox(y += 30, readOnly: true);

            // Nút Đóng ở giữa
            btnDong = new Button
            {
                Text = "Đóng",
                Size = new Size(200, 50),
                Location = new Point((Width - 200) / 2, y += 70),
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDong.Click += (s, e) => Close();

            Controls.AddRange(new Control[] {
                txtId, txtTen, txtTheLoai, txtViTri, txtTang,
                txtSoLuong, txtGiaTri, btnDong
            });
        }

        private Label CreateLabel(string text, int top, int left = 70, bool bold = false, int size = 10)
        {
            return new Label
            {
                Text = text,
                Location = new Point(left, top),
                Font = new Font("Segoe UI", size, FontStyle.Bold),
                AutoSize = true
            };
        }

        private Control CreateLine(int y) =>
            new Panel { BackColor = Color.Gray, Location = new Point(40, y), Size = new Size(540, 1) };

        private TextBox CreateTextBox(int top, int left = 70, bool readOnly = false)
        {
            var tb = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                Size = new Size(500, 40),
                Location = new Point(left, top),
                ReadOnly = readOnly,
                Enabled = false,
                BackColor = Color.White,

            };
            tb.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, tb.Width, tb.Height, 20, 20));
            return tb;
        }

        private void LoadDeviceInfo()
        {
            txtId.Text = device.Id.ToString();
            txtTen.Text = device.TenThietBi;
            txtTheLoai.Text = device.TheLoai;
            txtViTri.Text = device.ViTri.Split('-')[1].Trim(); // ví dụ "A1"
            txtTang.Text = device.ViTri.Split('-')[0].Replace("Tầng", "").Trim(); // ví dụ "1"
            txtSoLuong.Text = device.SoLuong.ToString();
            txtGiaTri.Text = device.GiaTri.ToString("N0");
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
