
using LibraryManager.Model;
using LibraryManager.Models;
using LibraryManager.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManager.UI
{
    public class CapNhat : Form
    {
        private TextBox txtId, txtTen, txtSoLuong, txtGiaTri;
        private ComboBox cbTheLoai, cbViTri, cbTang;
        private Button btnHuy, btnCapNhat;
        private PictureBox btnClose, picAddTheLoai, picAddViTri, picAddTang;
        private DeviceModel device;
        private DeviceModel originalDevice; // lưu bản sao ban đầu
        public event Action? OnDeviceUpdated;
        public CapNhat(DeviceModel selectedDevice)
        {
            device = new DeviceModel
            {
                Id = selectedDevice.Id,
                TenThietBi = selectedDevice.TenThietBi,
                SoLuong = selectedDevice.SoLuong,
                GiaTri = selectedDevice.GiaTri,
                IDTheLoai = selectedDevice.IDTheLoai,
                IDViTri = selectedDevice.IDViTri,
                IDTang = selectedDevice.IDTang,
            };
            originalDevice = selectedDevice; // dùng cho nút Hủy
            InitializeComponent();
            LoadComboBoxes();
            LoadDeviceInfo();
        }

        private void InitializeComponent()
        {
            Text = "Cập nhật thiết bị";
            Size = new Size(640, 720);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(255, 248, 220);

            btnClose = new PictureBox
            {
                Image = SystemIcons.Error.ToBitmap(),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(32, 32),
                Location = new Point(580, 20),
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => Close();

            Controls.Add(CreateLabel("\ud83d\udcd6  Cập nhật thiết bị", 25, 40, bold: true, size: 16));
            Controls.Add(CreateLine(70));

            int y = 90;
            Controls.Add(CreateLabel("ID", y));
            txtId = CreateTextBox(y += 30, Enabled: false);

            Controls.Add(CreateLabel("Tên thiết bị", y += 50));
            txtTen = CreateTextBox(y += 30);

            Controls.Add(CreateLabel("Thể loại", y += 50));
            cbTheLoai = CreateComboBox(y += 30);
            picAddTheLoai = CreatePlusIcon(cbTheLoai.Right + 5, cbTheLoai.Top, () => MessageBox.Show("Chức năng thêm thể loại chưa được triển khai."));

            Controls.Add(CreateLabel("Vị trí", y += 50));
            cbViTri = CreateComboBox(y += 30);
            picAddViTri = CreatePlusIcon(cbViTri.Right + 5, cbViTri.Top, () => MessageBox.Show("Chức năng thêm vị trí chưa được triển khai."));

            Controls.Add(CreateLabel("Tầng", y += 50));
            cbTang = CreateComboBox(y += 30);
            picAddTang = CreatePlusIcon(cbTang.Right + 5, cbTang.Top, () => MessageBox.Show("Chức năng thêm tầng chưa được triển khai."));

            Controls.Add(CreateLabel("Số lượng", y += 50));
            txtSoLuong = CreateTextBox(y += 30);

            Controls.Add(CreateLabel("Giá trị", y += 50));
            txtGiaTri = CreateTextBox(y += 30);

            btnHuy = new Button
            {
                Text = "Hủy",
                Size = new Size(200, 50),
                Location = new Point(70, y += 60),
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnHuy.Click += (s, e) => LoadDeviceInfo();

            btnCapNhat = new Button
            {
                Text = "Cập nhật",
                Size = new Size(200, 50),
                Location = new Point(340, y),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCapNhat.Click += BtnCapNhat_Click;

            Controls.AddRange(new Control[]
            {
                btnClose, txtId, txtTen, cbTheLoai, cbViTri, cbTang,
                txtSoLuong, txtGiaTri, btnHuy, btnCapNhat,
                picAddTheLoai, picAddViTri, picAddTang
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

        private Control CreateLine(int y) => new Panel { BackColor = Color.Gray, Location = new Point(40, y), Size = new Size(540, 1) };

        private TextBox CreateTextBox(int top, int left = 70, bool Enabled = true)
        {
            var tb = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                Size = new Size(500, 40),
                Location = new Point(left, top),
                Enabled = Enabled,
            };
            tb.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, tb.Width, tb.Height, 20, 20));
            return tb;
        }

        private ComboBox CreateComboBox(int top, int left = 70)
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 12),
                Size = new Size(500, 40),
                Location = new Point(left, top)
            };
        }

        private PictureBox CreatePlusIcon(int x, int y, Action onClick)
        {
            var pic = new PictureBox
            {
                Image = Properties.Resources.plus,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(24, 24),
                Location = new Point(x, y + 3),
                Cursor = Cursors.Hand
            };
            pic.Click += (s, e) => onClick();
            return pic;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void LoadComboBoxes()
        {
            cbTheLoai.DataSource = new TheLoaiRepository().GetAllTheLoai();
            cbTheLoai.DisplayMember = "TenTL";
            cbTheLoai.ValueMember = "MaTL";

            cbViTri.DataSource = new ViTriRepository().GetAllViTri();
            cbViTri.DisplayMember = "TenViTri";
            cbViTri.ValueMember = "MaViTri";

            cbTang.DataSource = new TangRepository().GetAllTang();
            cbTang.DisplayMember = "TenTang";
            cbTang.ValueMember = "MaTang";
        }

        private void LoadDeviceInfo()
        {
            txtId.Text = originalDevice.Id.ToString();
            txtTen.Text = originalDevice.TenThietBi;
            txtSoLuong.Text = originalDevice.SoLuong.ToString();
            txtGiaTri.Text = originalDevice.GiaTri.ToString();

            cbTheLoai.SelectedValue = originalDevice.IDTheLoai;
            cbViTri.SelectedValue = originalDevice.IDViTri;
            cbTang.SelectedValue = originalDevice.IDTang;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên thiết bị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtGiaTri.Text, out double giaTri))
            {
                MessageBox.Show("Giá trị không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tên đã tồn tại (trừ thiết bị hiện tại)
            var repo = new DeviceRepository();
            if (repo.IsDeviceNameExists(txtTen.Text, device.Id))
            {
                MessageBox.Show("Tên thiết bị đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            device.TenThietBi = txtTen.Text;
            device.SoLuong = soLuong;
            device.GiaTri = giaTri;
            device.IDTheLoai = (int)cbTheLoai.SelectedValue;
            device.IDViTri = (int)cbViTri.SelectedValue;
            device.IDTang = (int)cbTang.SelectedValue;

            bool success = repo.UpdateDevice(device);
            if (success)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDeviceUpdated?.Invoke(); // gọi sự kiện load lại
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
