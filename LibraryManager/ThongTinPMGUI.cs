    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using muon.ConnectDatabase;
    using MySql.Data.MySqlClient;

    namespace muon
    {
        public partial class ThongTinPMGUI : Form
        {
            private readonly int _maPM;
            private string _trangThaiMuon;
        public ThongTinPMGUI(int maPhieuMuon, string trangThaiMuon)
        {
            InitializeComponent();
            _maPM = maPhieuMuon;
            _trangThaiMuon = trangThaiMuon;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void ThongTinPMGUI_Load(object sender, EventArgs e)
            {
                var dtInfo = DatabaseConnection.ExecuteSelectQuery($@"
                    SELECT p.MaPhieuMuon, t.HoTen, p.NgayMuon, p.HanTra, p.MaThanhVien
                    FROM phieumuon p
                    JOIN thanhvien t ON p.MaThanhVien = t.MaThanhVien
                    WHERE p.MaPhieuMuon = {_maPM}");
                if (dtInfo.Rows.Count > 0)
                {
                    var r = dtInfo.Rows[0];
                    tboxid.Text = r["MaThanhVien"].ToString();
                    tboxname.Text = r["HoTen"].ToString();
                    DateTime ngayBo = Convert.ToDateTime(r["NgayMuon"]);
                    DateTime hanTra = Convert.ToDateTime(r["HanTra"]);
                    tboxdaybor.Text = ngayBo.ToString("dd/MM/yyyy");

                    int daysLeft = (hanTra - DateTime.Now).Days;
                    tboxdayleft.Text = daysLeft >= 0
                        ? $"{daysLeft} ngày"
                        : $"Quá hạn {Math.Abs(daysLeft)} ngày";
                }

                // 2) Load chi tiết từ DB
                var dtCT = DatabaseConnection.ExecuteSelectQuery($@"
                    SELECT ct.MaPhieuMuon, ct.MaSanPham, sp.TenSanPham, ct.SoLuong, 
                    ct.TienCocMuon, ct.GiaMuon, ct.TrangThai, ct.SoLuongThietHai
                    FROM chitietphieumuon ct 
                    JOIN sanpham sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE ct.MaPhieuMuon = {_maPM}");

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaPhieuMuon",
                    HeaderText = "Mã Phiếu",
                    DataPropertyName = "MaPhieuMuon",
                    Visible = false
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaSanPham",
                    HeaderText = "Mã SP",
                    DataPropertyName = "MaSanPham"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenSanPham",
                    HeaderText = "Tên SP",
                    DataPropertyName = "TenSanPham"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoLuong",
                    HeaderText = "Số Lượng",
                    DataPropertyName = "SoLuong"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TienCocMuon",
                    HeaderText = "Tiền Cọc Mượn",
                    DataPropertyName = "TienCocMuon",
                    DefaultCellStyle = { Format = "N0" }
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "GiaMuon",
                    HeaderText = "Giá Mượn",
                    DataPropertyName = "GiaMuon",
                    DefaultCellStyle = { Format = "N0" }
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoLuongThietHai",
                    HeaderText = "Số Lượng Thiệt Hại",
                    DataPropertyName = "SoLuongThietHai" 
                });

                var comboCol = new DataGridViewComboBoxColumn
                {
                    Name = "TrangThai",
                    HeaderText = "Trạng Thái",
                    DataPropertyName = "TrangThai",
                    DataSource = new string[] { "Bình thường", "Hư hỏng/Mất" },
                    FlatStyle = FlatStyle.Flat
                };
                dataGridView1.Columns.Add(comboCol);

                dataGridView1.DataSource = dtCT;

                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                dataGridView1.CurrentCellDirtyStateChanged += (s, ev) =>
                {
                    if (dataGridView1.IsCurrentCellDirty)
                        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
            UpdateTotalPayable();
            }

        private void UpdateTotalPayable()
        {
            double total = 0;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                total += Convert.ToDouble(r.Cells["GiaMuon"].Value);
            }

            string[] parts = tboxdayleft.Text.Split(' ');
            int daysLate = 0;
            if (parts.Length >= 2 && int.TryParse(parts[0], out int x))
            {
                daysLate = tboxdayleft.Text.StartsWith("Quá hạn") ? x : 0;
            }

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                int sl = Convert.ToInt32(r.Cells["SoLuong"].Value);
                object raw = r.Cells["SoLuongThietHai"].Value;
                int slTH = (raw == null || raw == DBNull.Value) ? 0 : Convert.ToInt32(raw);
                double tienCoc = Convert.ToDouble(r.Cells["TienCocMuon"].Value);

                if (sl > 0)
                {
                    double unitDeposit = tienCoc / sl;

                    if (slTH > 0)
                        total += unitDeposit * slTH;

                    if (daysLate > 0)
                        total += daysLate * 0.5 * unitDeposit * sl;
                }
            }

            tboxtotal.Text = total.ToString("N0");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                var colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName == "SoLuongThietHai" || colName == "TrangThai")
                {
                    UpdateTotalPayable();
                }
            }

            private void btncancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnreturn_Click(object sender, EventArgs e)
            {
                if (_trangThaiMuon == "Đã trả")
                {
                    MessageBox.Show("Phiếu này đã được trả trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var conn = DatabaseConnection.GetConnection();
                if (conn == null) return;
                using var tran = conn.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        if (r.IsNewRow) continue;
                        int maSp = Convert.ToInt32(r.Cells["MaSanPham"].Value);
                        object rawSLTH = r.Cells["SoLuongThietHai"].Value;
                        int slTH = (rawSLTH == null || rawSLTH == DBNull.Value)
                                   ? 0
                                   : Convert.ToInt32(rawSLTH);

                        object rawSt = r.Cells["TrangThai"].Value;
                        string status = (rawSt == null || rawSt == DBNull.Value)
                                        ? "Bình thường"
                                        : rawSt.ToString();

                        var cmdCT = new MySqlCommand(@"
                    UPDATE chitietphieumuon
                    SET SoLuongThietHai = @slTH, TrangThai = @st
                    WHERE MaPhieuMuon = @pm AND MaSanPham = @sp;", conn, tran);
                        cmdCT.Parameters.AddWithValue("@slTH", slTH);
                        cmdCT.Parameters.AddWithValue("@st", status);
                        cmdCT.Parameters.AddWithValue("@pm", _maPM);
                        cmdCT.Parameters.AddWithValue("@sp", maSp);
                        cmdCT.ExecuteNonQuery();
                    }

                    double newTotal = double.Parse(tboxtotal.Text, NumberStyles.AllowThousands);

                    var cmdPM = new MySqlCommand(@"UPDATE phieumuon
                    SET TrangThaiMuon = 'Đã trả',
                    ThoiGianTraThucTe = @time,
                    TongTien = @tot
                    WHERE MaPhieuMuon = @pm;", conn, tran);
                    cmdPM.Parameters.AddWithValue("@time", DateTime.Now);
                    cmdPM.Parameters.AddWithValue("@tot", newTotal);
                    cmdPM.Parameters.AddWithValue("@pm", _maPM);
                    cmdPM.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Trả phiếu mượn thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi trả phiếu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

            private void tboxname_TextChanged(object sender, EventArgs e)
            {

            }
        }
    }
