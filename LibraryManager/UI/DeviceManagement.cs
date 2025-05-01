// ===========================
// File: UI/DeviceManagementPanel.cs
// ===========================
using LibraryManager.Model;
using LibraryManager.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibraryManager.UI
{
    public class DeviceManagementPanel : UserControl
    {
        private Panel headerPanel;
        private FlowLayoutPanel contentTable; // Bảng hiển thị danh sách thiết bị
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnAddDevice, btnRefresh;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // Cấu hình bảng
        private readonly int[] columnWidths = { 60, 250, 200, 200, 100, 150, 150, 200 }; // Thêm "Giá trị"
        private readonly string[] columnHeaders = { "ID", "Tên thiết bị", "Thể loại", "Vị trí", "Số lượng", "Giá trị", "Trạng thái", "Action" };

        private List<DeviceModel> allDevices; // Danh sách toàn bộ thiết bị (phục vụ lọc)

        public DeviceManagementPanel()
        {
            InitializeComponent();
            LoadDevices(); // Tải danh sách thiết bị ban đầu
        }

        private void InitializeComponent()
        {
            Size = new Size(1400, 750);
            BackColor = Color.White;

            // 1. Tạo bảng hiển thị dữ liệu (FlowLayoutPanel)
            contentTable = new FlowLayoutPanel
            {
                Location = new Point(0, 70),
                Size = new Size(1400, 680),
                BackColor = Color.White,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            Controls.Add(contentTable);

            // 2. Header tìm kiếm và nút chức năng
            InitializeHeader();
        }

        private void InitializeHeader()
        {
            headerPanel = new Panel
            {
                Size = new Size(1400, 70),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            lblTitle = new Label
            {
                Text = "Quản lý thiết bị",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(15, 20),
                AutoSize = true
            };

            Panel searchPanel = new Panel
            {
                Size = new Size(420, 40),
                BackColor = Color.White,
                Location = new Point(420, 15),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10, 5, 5, 5),
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 420, 40, 15, 15))
            };

            PictureBox searchIcon = new PictureBox
            {
                Image = Properties.Resources.search,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(20, 20),
                Location = new Point(5, 7)
            };

            txtSearch = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(30, 7),
                Width = 380,
                Text = "Tìm kiếm theo id hoặc tên thiết bị"
            };
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Tìm kiếm theo id hoặc tên thiết bị")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Tìm kiếm theo id hoặc tên thiết bị";
                    txtSearch.ForeColor = Color.Gray;
                }
            };
            txtSearch.TextChanged += (s, e) => FilterDevices(txtSearch.Text);

            btnRefresh = new Button
            {
                Text = "  Làm mới",
                Image = new Bitmap(Properties.Resources.refresh, new Size(24, 24)),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10),
                Size = new Size(180, 40),
                Location = new Point(900, 15),
                BackColor = Color.Gainsboro,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Padding = new Padding(5, 0, 5, 0),
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 180, 40, 10, 10))
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.DarkGray;
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = Color.Gainsboro;
            btnRefresh.Click += (s, e) => LoadDevices();

            btnAddDevice = new Button
            {
                Text = "  Thêm thiết bị",
                Size = new Size(180, 40),
                Location = new Point(1110, 15),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.add,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(8, 0, 8, 0),
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 180, 40, 10, 10))
            };
            btnAddDevice.FlatAppearance.BorderSize = 0;

            searchPanel.Controls.Add(searchIcon);
            searchPanel.Controls.Add(txtSearch);
            headerPanel.Controls.Add(searchPanel);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(btnRefresh);
            headerPanel.Controls.Add(btnAddDevice);
            Controls.Add(headerPanel);
        }

        private void LoadDevices()
        {
            var repo = new DeviceRepository();
            allDevices = repo.GetAllDevices();
            DisplayDevices(allDevices);
        }

        private void FilterDevices(string keyword)
        {
            var repo = new DeviceRepository();
            var filteredDevices = repo.SearchDevices(keyword);
            DisplayDevices(filteredDevices);
        }
        private void DisplayDevices(List<DeviceModel> devices)
        {
            contentTable.Controls.Clear();

            // Vẽ lại dòng tiêu đề bảng
            Panel headerRow = new Panel { Size = new Size(1380, 40), BackColor = Color.White };
            for (int i = 0, x = 50; i < columnHeaders.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = columnHeaders[i],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(x, 10),
                    Size = new Size(columnWidths[i], 20),
                    ForeColor = Color.Black
                };
                headerRow.Controls.Add(lbl);
                x += columnWidths[i];
            }
            contentTable.Controls.Add(headerRow);
            contentTable.Controls.Add(new Panel { BackColor = Color.LightGray, Size = new Size(1380, 1) });

            // Hiển thị từng dòng dữ liệu
            foreach (var device in devices)
            {
                contentTable.Controls.Add(CreateDeviceRow(device));
            }
        }

        private Panel CreateDeviceRow(DeviceModel device)
        {
            Panel dataRow = new Panel { Size = new Size(1380, 40), BackColor = Color.White };
            dataRow.MouseEnter += (s, e) => dataRow.BackColor = Color.FromArgb(240, 240, 240);
            dataRow.MouseLeave += (s, e) => dataRow.BackColor = Color.White;

            string[] data = {
                device.Id.ToString(), device.TenThietBi, device.TheLoai,
                device.ViTri, device.SoLuong.ToString(), device.GiaTri.ToString(), device.TrangThai
            };

            int x = 50;
            for (int i = 0; i < data.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = data[i],
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(x, 10),
                    Size = new Size(columnWidths[i], 20),
                    ForeColor = Color.Black
                };
                dataRow.Controls.Add(lbl);
                x += columnWidths[i];
            }

            PictureBox picEdit = CreateIconButton(Properties.Resources.edit, x);
            PictureBox picDelete = CreateIconButton(Properties.Resources.delete, x + 30);
            PictureBox picDetail = CreateIconButton(Properties.Resources.view, x + 60);
            dataRow.Controls.AddRange(new Control[] { picEdit, picDelete, picDetail });

            return dataRow;
        }

        private PictureBox CreateIconButton(Image icon, int x)
        {
            return new PictureBox
            {
                Image = new Bitmap(icon, new Size(24, 24)),
                Size = new Size(24, 24),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Location = new Point(x, 8)
            };
        }
    }
}
