using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace LibraryManager.Components
{
    public class DeviceManagementPanel : UserControl
    {
        private Panel headerPanel;
        private Label lblTitle;
     
        private PictureBox picSearchIcon;
        private TextBox txtSearch;
        private Button btnAddDevice;
        private DataGridView dgv;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,     // x đầu
        int nTopRect,      // y đầu
        int nRightRect,    // x cuối
        int nBottomRect,   // y cuối
        int nWidthEllipse, // độ bo theo chiều ngang
        int nHeightEllipse // độ bo theo chiều dọc
    );
        public DeviceManagementPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(1300, 750);
            this.BackColor = Color.White;

            // Header tổng
            headerPanel = new Panel
            {
                Size = new Size(1300, 70),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(245, 245, 245) // màu nền xám nhạt
            };

            // Label tiêu đề "Quản lý thiết bị"
            lblTitle = new Label
            {
                Text = "Quản lý thiết bị",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(15, 20),
                AutoSize = true
            };

            // Panel bao ngoài để bo góc
            Panel searchPanel = new Panel
            {
                Size = new Size(420, 40),
                BackColor = Color.White,
                Location = new Point(420, 15), // tuỳ chỉnh vị trí
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10, 5, 5, 5)
            };
            searchPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, searchPanel.Width, searchPanel.Height, 15, 15));
            PictureBox searchIcon = new PictureBox
            {
                Image = Properties.Resources.search, 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(20, 20),
                Location = new Point(5, 7)
            };

            TextBox txtSearch = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(30, 7),
                Width = 380,
                Text = "Tìm kiếm theo id hoặc tên thiết bị"
            };

            // Placeholder xử lý khi focus
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

            Button btnRefresh = new Button
            {
                Text = "  Làm mới",
                Image = new Bitmap(Properties.Resources.refresh, new Size(24, 24)),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Size = new Size(180, 40),
                Location = new Point(870, 15),
                BackColor = Color.Gainsboro,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Padding = new Padding(5, 0, 5, 0)
            };

            // Bo góc
            btnRefresh.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRefresh.Width, btnRefresh.Height, 10, 10));

            // Hover hiệu ứng
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.DarkGray; ;
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = Color.Gainsboro;
            btnRefresh.Click += (s, e) =>
            {
                // TODO: Gọi hàm làm mới dữ liệu tại đây
              
            };

            // Nút "+ Thêm thiết bị"
            btnAddDevice = new Button
            {
                Text = "  Thêm thiết bị",
                Size = new Size(180, 40),
                Location = new Point(1090, 15),
                BackColor = Color.FromArgb(76, 175, 80), // xanh lá
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,

                // Icon add bên trái
                Image = Properties.Resources.add, 
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(8, 0, 8, 0)
            };

            btnAddDevice.FlatAppearance.BorderSize = 0;
            btnAddDevice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddDevice.Width, btnAddDevice.Height, 10, 10));

            // Thêm các control con
            searchPanel.Controls.Add(searchIcon);
            searchPanel.Controls.Add(txtSearch);
            headerPanel.Controls.Add(searchPanel);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(btnRefresh);
            headerPanel.Controls.Add(btnAddDevice);

            // Thêm headerPanel vào content panel
            this.Controls.Add(headerPanel);

            // Container cho bảng dữ liệu
            FlowLayoutPanel contentTable = new FlowLayoutPanel
            {
                Location = new Point(0, 70),
                Size = new Size(1300, 680),
                BackColor = Color.White,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            // === Header Row ===
            Panel headerRow = new Panel
            {
                Size = new Size(1280, 40),
                BackColor = Color.White
            };

            string[] headers = { "ID", "Tên thiết bị", "Thể loại", "Vị trí", "Số lượng","Trạng thái", "Action" };
            int[] widths = { 60, 300, 200, 200,100, 150, 250 };

            for (int i = 0, x = 50; i < headers.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = headers[i],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(x, 10),
                    Size = new Size(widths[i], 20),
                    ForeColor = Color.Black
                };
                headerRow.Controls.Add(lbl);
                x += widths[i];
            }
            contentTable.Controls.Add(headerRow);
            // === Separator line dưới header ===
            Panel separatorLine = new Panel
            {
                BackColor = Color.LightGray,
                Size = new Size(1280, 1),
                Margin = new Padding(0, 0, 0, 0)
            };
            contentTable.Controls.Add(separatorLine);
            // === Dữ liệu giả lập (3 dòng) ===
            for (int row = 0; row < 3; row++)
            {
                Panel dataRow = new Panel
                {
                    Size = new Size(1280, 40),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None
                };
                //  hiệu ứng hover:
                dataRow.MouseEnter += (s, e) => ((Panel)s).BackColor = Color.FromArgb(240, 240, 240); // xám nhạt
                dataRow.MouseLeave += (s, e) => ((Panel)s).BackColor = Color.White;

             
                string[] data = {
        (row + 1).ToString(),
        row == 0 ? "Truyện CoNan" : row == 1 ? "Sách giáo dục" : "Sách giáo khoa",
        "Giáo dục",
        $"Tầng 1 - A{row + 1}",
        "10",
        row == 1 ? "Đang mượn" : "Có sẵn"
    };

                int x = 50;
                for (int i = 0; i < data.Length; i++)
                {
                    Label lbl = new Label
                    {
                        Text = data[i],
                        Font = new Font("Segoe UI", 9),
                        Location = new Point(x, 10),
                        Size = new Size(widths[i], 20),
                        ForeColor = Color.Black
                    };
                    dataRow.Controls.Add(lbl);
                    x += widths[i];
                }

                // === Action Icons ===
                PictureBox picEdit = CreateIconButton(Properties.Resources.edit);
                picEdit.Location = new Point(x, 8);
                picEdit.Click += (s, e) => MessageBox.Show("Sửa");

                PictureBox picDelete = CreateIconButton(Properties.Resources.delete);
                picDelete.Location = new Point(x + 30, 8);
                picDelete.Click += (s, e) => MessageBox.Show("Xoá");

                PictureBox picDetail = CreateIconButton(Properties.Resources.view);
                picDetail.Location = new Point(x + 60, 8);
                picDetail.Click += (s, e) => MessageBox.Show("Chi tiết");

                dataRow.Controls.AddRange(new Control[] { picEdit, picDelete, picDetail });

                contentTable.Controls.Add(dataRow);
            }

           

            // Thêm content vào panel chính
            this.Controls.Add(contentTable);
           

        }
        private PictureBox CreateIconButton(Image icon)
        {
            return new PictureBox
            {
                Image = new Bitmap(icon, new Size(24, 24)),
                Size = new Size(24, 24),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };
        }
    }
}
