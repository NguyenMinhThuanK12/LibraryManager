using LibraryManager.Model;
using LibraryManager.Models;
using LibraryManager.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibraryManager.UI
{
    public class ThemThietBi : Form
    {
        private TextBox txtId, txtTen, txtSoLuong, txtGiaTri;
        private ComboBox cbTheLoai, cbViTri, cbTang;
        private Button btnHuy, btnThem;
        private PictureBox btnClose, picAddTheLoai, picAddViTri, picAddTang;

        public event Action? OnDeviceAdded;

        public ThemThietBi()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadNextDeviceId();
        }

        private void InitializeComponent()
        {
            Text = "Thêm thiết bị";
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

            Controls.Add(CreateLabel("📖 Thêm thiết bị", 25, 40, bold: true, size: 16));
            Controls.Add(CreateLine(70));

            int y = 90;
            Controls.Add(CreateLabel("ID", y));
            txtId = CreateTextBox(y += 30, Enabled : false);

            Controls.Add(CreateLabel("Tên thiết bị", y += 50));
            txtTen = CreateTextBox(y += 30);

            Controls.Add(CreateLabel("Thể loại", y += 50));
            cbTheLoai = CreateComboBox(y += 30);
            picAddTheLoai = CreatePlusIcon(cbTheLoai.Right + 5, cbTheLoai.Top);

            Controls.Add(CreateLabel("Vị trí", y += 50));
            cbViTri = CreateComboBox(y += 30);
            picAddViTri = CreatePlusIcon(cbViTri.Right + 5, cbViTri.Top);

            Controls.Add(CreateLabel("Tầng", y += 50));
            cbTang = CreateComboBox(y += 30);
            picAddTang = CreatePlusIcon(cbTang.Right + 5, cbTang.Top);

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
            btnHuy.Click += (s, e) => Close();

            btnThem = new Button
            {
                Text = "Thêm",
                Size = new Size(200, 50),
                Location = new Point(340, y),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThem.Click += BtnThem_Click;

            Controls.AddRange(new Control[]
            {
                btnClose, txtId, txtTen, cbTheLoai, cbViTri, cbTang,
                txtSoLuong, txtGiaTri, btnHuy, btnThem,
                picAddTheLoai, picAddViTri, picAddTang
            });
        }

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

        private void LoadNextDeviceId()
        {
            int nextId = new DeviceRepository().GetNextDeviceId();
            txtId.Text = nextId.ToString();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !double.TryParse(txtGiaTri.Text, out double giaTri))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var repo = new DeviceRepository();
            if (repo.IsDeviceNameExists(txtTen.Text, -1))
            {
                MessageBox.Show("Tên thiết bị đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var device = new DeviceModel
            {
                TenThietBi = txtTen.Text,
                SoLuong = soLuong,
                GiaTri = giaTri,
                IDTheLoai = (int)cbTheLoai.SelectedValue,
                IDViTri = (int)cbViTri.SelectedValue,
                IDTang = (int)cbTang.SelectedValue
            };

            bool success = repo.InsertDevice(device);
            if (success)    
            {
                MessageBox.Show("Thêm thiết bị thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDeviceAdded?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label CreateLabel(string text, int top, int left = 70, bool bold = false, int size = 10)
        {
            return new Label
            {
                Text = text,
                Location = new Point(left, top),
                Font = new Font("Segoe UI", size,  FontStyle.Bold ),
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

        private PictureBox CreatePlusIcon(int x, int y)
        {
            var pic = new PictureBox
            {
                Image = Properties.Resources.plus,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(24, 24),
                Location = new Point(x, y + 3),
                Cursor = Cursors.Hand
            };
            pic.Click += (s, e) => MessageBox.Show("Chức năng thêm mới chưa được triển khai.");
            return pic;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
