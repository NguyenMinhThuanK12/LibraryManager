using muon.ConnectDatabase;
using System.Data;
using MySql.Data.MySqlClient;

namespace muon
{
    public partial class QLMuonTraGUI : Form
    {
        private DataTable _dtPhieuMuon;
        public QLMuonTraGUI()
        {
            InitializeComponent();
        }

        private void LoadDataToGrid()
        {
            try
            {
                string query = @"
                SELECT MaPhieuMuon, MaThanhVien, NgayMuon, HanTra, 
                       ThoiGianTraThucTe, TongTien, TrangThaiMuon
                FROM phieumuon";

                _dtPhieuMuon = DatabaseConnection.ExecuteSelectQuery(query);

                dataGridView1.DataSource = _dtPhieuMuon;

                dataGridView1.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu";
                dataGridView1.Columns["MaThanhVien"].HeaderText = "Mã Thành Viên";
                dataGridView1.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                dataGridView1.Columns["HanTra"].HeaderText = "Hạn Trả";
                dataGridView1.Columns["ThoiGianTraThucTe"].HeaderText = "Trả Thực Tế";
                dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dataGridView1.Columns["TrangThaiMuon"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void QLMuonTraGUI_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
            cboboxfilter.Items.Clear();
            cboboxfilter.Items.AddRange(new string[]
            {
                "Tất cả",
                "Chưa trả",
                "Đã trả",
                "Quá hạn"
            });
            cboboxfilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboboxfilter.SelectedIndex = 0;

            btnsearch.Click += btnsearch_Click;
            tboxsearch.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    btnsearch_Click(s, EventArgs.Empty);
                    ev.SuppressKeyPress = true;
                }
            };
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var addForm = new ThemPhieuMuonGUI();
            addForm.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                this.LoadDataToGrid();
            };
            addForm.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maPM = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaPhieuMuon"].Value);
            string trangThai = dataGridView1.Rows[e.RowIndex].Cells["TrangThaiMuon"].Value.ToString();
            var detailForm = new ThongTinPMGUI(maPM, trangThai);
            detailForm.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                this.LoadDataToGrid();
            };
            detailForm.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            string statusCond = "";
            switch (cboboxfilter.SelectedItem?.ToString())
            {
                case "Chưa trả":
                    statusCond = "TrangThaiMuon = 'Chưa trả'";
                    break;
                case "Đã trả":
                    statusCond = "TrangThaiMuon = 'Đã trả'";
                    break;
                case "Quá hạn":
                    statusCond = "TrangThaiMuon = 'Chưa trả' AND HanTra < NOW()";
                    break;
                default:
                    statusCond = "1=1";  
                    break;
            }

            var moneyConds = new List<string>();
            var parameters = new Dictionary<string, object>();

            if (double.TryParse(tboxfrom.Text, out double from) && from >= 0)
            {
                moneyConds.Add("TongTien >= @from");
                parameters.Add("@from", from);
            }
            if (double.TryParse(tboxto.Text, out double to) && to >= 0)
            {
                moneyConds.Add("TongTien <= @to");
                parameters.Add("@to", to);
            }
            string moneyCond = moneyConds.Count > 0
                ? string.Join(" AND ", moneyConds)
                : "1=1";

            string where = $"{statusCond} AND {moneyCond}";

            string sql = $@"
                SELECT MaPhieuMuon, MaThanhVien, NgayMuon, HanTra, ThoiGianTraThucTe, TongTien, TrangThaiMuon
                FROM phieumuon
                WHERE {where}
                ORDER BY NgayMuon DESC";

            using var conn = DatabaseConnection.GetConnection();
            if (conn == null) return;
            using var cmd = new MySqlCommand(sql, conn);
            foreach (var kv in parameters)
                cmd.Parameters.AddWithValue(kv.Key, kv.Value);

            var dt = new DataTable();
            new MySqlDataAdapter(cmd).Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (_dtPhieuMuon == null) return;

            string kw = tboxsearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(kw))
            {
                _dtPhieuMuon.DefaultView.RowFilter = "";
            }
            else
            {
                var clauses = new List<string>
        {
            $"Convert(MaPhieuMuon, 'System.String') LIKE '%{kw}%'",
            $"Convert(MaThanhVien, 'System.String') LIKE '%{kw}%'",
            $"Convert(NgayMuon, 'System.String') LIKE '%{kw}%'",
            $"Convert(HanTra, 'System.String') LIKE '%{kw}%'",
            $"Convert(ThoiGianTraThucTe, 'System.String') LIKE '%{kw}%'",
            $"Convert(TongTien, 'System.String') LIKE '%{kw}%'",
            $"Convert(TrangThaiMuon, 'System.String') LIKE '%{kw}%'"
        };
                _dtPhieuMuon.DefaultView.RowFilter = string.Join(" OR ", clauses);
            }

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
        }
    }
}
