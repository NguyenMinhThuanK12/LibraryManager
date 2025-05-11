using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.ConnectDatabase;
using muon;
using MySql.Data.MySqlClient;
using OfficeOpenXml.LoadFunctions.Params;

namespace LibraryManager
{
    public partial class PhieuMuonTV : Form
    {
        private readonly int _maTv;
        private DataTable _dtPhieuMuonTv;

        public PhieuMuonTV(int maTv)
        {
            InitializeComponent();
            _maTv = maTv;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PhieuMuonTV_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string sql = @"
            SELECT MaPhieuMuon, NgayMuon, HanTra, ThoiGianTraThucTe,
                   TongTien, TrangThaiMuon
            FROM phieumuon
            WHERE MaThanhVien = @maTv";

            _dtPhieuMuonTv = DatabaseConnection.ExecuteSelectQuery(sql,
                new MySqlParameter("@maTv", _maTv));

            dataGridView1.DataSource = _dtPhieuMuonTv;
            dataGridView1.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu";
            dataGridView1.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dataGridView1.Columns["HanTra"].HeaderText = "Hạn Trả";
            dataGridView1.Columns["ThoiGianTraThucTe"].HeaderText = "Trả TT";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dataGridView1.Columns["TrangThaiMuon"].HeaderText = "Trạng Thái";
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maPM = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex].Cells["MaPhieuMuon"].Value);
            string trangThai = dataGridView1.Rows[e.RowIndex]
                                     .Cells["TrangThaiMuon"].Value.ToString();
            var detailForm = new ThongTinPMGUI(maPM, trangThai);
            detailForm.FormClosed += (s, args) => LoadData();
            detailForm.ShowDialog();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (_dtPhieuMuonTv == null) return;
            string kw = tboxsearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(kw))
            {
                _dtPhieuMuonTv.DefaultView.RowFilter = "";
            }
            else
            {
                var clauses = new List<string>
        {
            $"Convert(MaPhieuMuon, 'System.String') LIKE '%{kw}%'",
            $"Convert(NgayMuon, 'System.String') LIKE '%{kw}%'",
            $"Convert(HanTra, 'System.String') LIKE '%{kw}%'",
            $"Convert(ThoiGianTraThucTe, 'System.String') LIKE '%{kw}%'",
            $"Convert(TongTien, 'System.String') LIKE '%{kw}%'",
            $"Convert(TrangThaiMuon, 'System.String') LIKE '%{kw}%'"
        };
                _dtPhieuMuonTv.DefaultView.RowFilter = string.Join(" OR ", clauses);
            }

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            string statusCond = cboboxfilter.SelectedItem switch
            {
                "Chưa trả" => "TrangThaiMuon = 'Chưa trả'",
                "Đã trả" => "TrangThaiMuon = 'Đã trả'",
                "Quá hạn" => "TrangThaiMuon = 'Chưa trả' AND HanTra < NOW()",
                _ => "1=1"
            };

            var moneyConds = new List<string>();
            var parameters = new Dictionary<string, object>();

            if (double.TryParse(tboxfrom.Text, out double from) && from >= 0)
            {
                moneyConds.Add("TongTien >= @from");
                parameters["@from"] = from;
            }
            if (double.TryParse(tboxto.Text, out double to) && to >= 0)
            {
                moneyConds.Add("TongTien <= @to");
                parameters["@to"] = to;
            }

            var moneyCond = moneyConds.Count > 0
                ? string.Join(" AND ", moneyConds)
                : "1=1";

            string where = $"{statusCond} AND {moneyCond}";
            string sql = $@"
                SELECT MaPhieuMuon, NgayMuon, HanTra, ThoiGianTraThucTe, TongTien, TrangThaiMuon
                FROM phieumuon
                WHERE MaThanhVien = @_maTv AND {where}
                ORDER BY NgayMuon DESC";

            using var conn = DatabaseConnection.GetConnection();
            if (conn == null) return;
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@_maTv", _maTv);
            foreach (var kv in parameters)
                cmd.Parameters.AddWithValue(kv.Key, kv.Value);

            var dt = new DataTable();
            new MySqlDataAdapter(cmd).Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void PhieuMuonTV_Load_1(object sender, EventArgs e)
        {
            LoadData();
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

            // Hook sự kiện
            btnfilter.Click += btnfilter_Click;
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
    }
}