using LibraryManager.BUS;
using LibraryManager.DAO;
using LibraryManager.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

public class CheckIn : UserControl
{
    private TextBox txtSDT;
    private Button btnCheck;
    private Label lblStatus;
    private TableLayoutPanel infoPanel;
    private ThanhVienBUS tvBus = new ThanhVienBUS();
    private CheckInDAO checkInDAO = new CheckInDAO();

    public CheckIn()
    {
        Text = "Quản lý vào khu học tập";
        Size = new Size(1400, 750);
       
        BackColor = Color.White;

        Label lblInput = new Label
        {
            Text = "Nhập số điện thoại thành viên:",
            Location = new Point(50, 30),
            Font = new Font("Segoe UI", 12),
            AutoSize = true
        };
        Controls.Add(lblInput);

        txtSDT = new TextBox
        {
            Location = new Point(340, 25),
            Size = new Size(300, 30),
            Font = new Font("Segoe UI", 12)
        };
        Controls.Add(txtSDT);

        btnCheck = new Button
        {
            Text = "Check-in",
            Location = new Point(680, 25),
            Size = new Size(140, 35),
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            BackColor = Color.LightGreen,
            Cursor = Cursors.Hand,
        };
        btnCheck.Click += BtnCheck_Click;
        Controls.Add(btnCheck);

        lblStatus = new Label
        {
            Text = "",
            Location = new Point(50, 80),
            Size = new Size(1300, 40),
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.Green
        };
        Controls.Add(lblStatus);

        infoPanel = new TableLayoutPanel
        {
            Location = new Point(50, 130),
            Size = new Size(1000, 500), // Giảm kích thước để vừa khung
            ColumnCount = 2,
            RowCount = 8,
            AutoSize = false,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };

        infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Cột trái: nhãn cố định
        infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // Cột phải: chiếm phần còn lại

        for (int i = 0; i < 8; i++)
        {
            infoPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            infoPanel.Controls.Add(CreateLabel(""), 0, i);
            infoPanel.Controls.Add(CreateLabel(""), 1, i);
        }

        Controls.Add(infoPanel);
    }

    private void BtnCheck_Click(object sender, EventArgs e)
    {
        string sdt = txtSDT.Text.Trim();

        if (string.IsNullOrEmpty(sdt))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var danhSach = tvBus.GetAllThanhVien();
        var tv = danhSach.Find(t => t.sdt == sdt);

        if (tv != null)
        {
            checkInDAO.InsertCheckIn(tv.maThanhVien);
            lblStatus.Text = "✔ ĐÃ CHECK-IN THÀNH CÔNG!";
            lblStatus.ForeColor = Color.Green;

            UpdateInfoPanel(tv);
        }
        else
        {
            lblStatus.Text = "❌ KHÔNG TÌM THẤY THÀNH VIÊN!";
            lblStatus.ForeColor = Color.Red;
            ClearInfoPanel();
        }
    }

    private Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Segoe UI", 11),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            Padding = new Padding(5, 0, 5, 0), // Thêm padding để văn bản không dính sát
            MaximumSize = new Size(0, 30) // Giới hạn chiều cao
        };
    }

    private void UpdateInfoPanel(ThanhVienDTO tv)
    {
        string[] labels =
        {
            "Mã thành viên:", "Họ tên:", "Ngày sinh:", "Địa chỉ:", "Số điện thoại:", "Email:", "Ngày đăng ký:", "Giờ vào:"
        };

        string[] values =
        {
            tv.maThanhVien.ToString(),
            tv.hoTen,
            tv.ngaySinh.ToString("dd/MM/yyyy"),
            tv.diaChi,
            tv.sdt,
            tv.email,
            tv.ngayDangKy.ToString("dd/MM/yyyy HH:mm:ss"),
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        };

        for (int i = 0; i < labels.Length; i++)
        {
            infoPanel.GetControlFromPosition(0, i).Text = labels[i];
            infoPanel.GetControlFromPosition(1, i).Text = values[i];
        }
    }

    private void ClearInfoPanel()
    {
        for (int i = 0; i < 8; i++)
        {
            infoPanel.GetControlFromPosition(0, i).Text = "";
            infoPanel.GetControlFromPosition(1, i).Text = "";
        }
    }
}