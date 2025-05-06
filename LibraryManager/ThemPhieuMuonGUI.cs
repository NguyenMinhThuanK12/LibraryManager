using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using muon.ConnectDatabase;
using MySql.Data.MySqlClient;

namespace muon
{
    public partial class ThemPhieuMuonGUI : Form
    {
        public ThemPhieuMuonGUI()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("MaSanPham", "Mã sản phẩm");
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            dataGridView1.Columns.Add("TienCocMuon", "Tiền cọc");
            dataGridView1.Columns.Add("GiaMuon", "Giá mượn");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private DataTable _dtItems;

        private void ThemPhieuMuonGUI_Load(object sender, EventArgs e)
        {
            var dtUsers = DatabaseConnection.ExecuteSelectQuery(
                "SELECT MaThanhVien, HoTen FROM thanhvien");
            dtUsers.Columns.Add("Full", typeof(string), "MaThanhVien + ' - ' + HoTen");
            cboboxuser.DataSource = dtUsers;
            cboboxuser.ValueMember = "MaThanhVien";
            cboboxuser.DisplayMember = "Full";

            _dtItems = DatabaseConnection.ExecuteSelectQuery(
                 "SELECT MaSanPham, TenSanPham, SoLuong, GiaTri FROM sanpham");
            _dtItems.PrimaryKey = new[] { _dtItems.Columns["MaSanPham"] };
            _dtItems.Columns.Add("Full", typeof(string), "MaSanPham + ' - ' + TenSanPham");
            cboboxitem.DataSource = _dtItems;
            cboboxitem.ValueMember = "MaSanPham";
            cboboxitem.DisplayMember = "MaSanPham + ' - ' + TenSanPham";
            cboboxitem.DisplayMember = "Full";


            if (cboboxitem.Items.Count > 0)
                cboboxitem.SelectedIndex = 0;
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(tboxquantity.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Nhập số lượng hợp lệ (≥1).", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSp = (int)cboboxitem.SelectedValue;
            DataRow dr = ((DataTable)cboboxitem.DataSource).Rows.Find(maSp);    // nếu dt có PrimaryKey = MaSanPham

            int available = (int)dr["SoLuong"];
            if (qty > available)
            {
                MessageBox.Show("Không đủ tồn kho!");
                return;
            }

            double giaTri = Convert.ToDouble(dr["GiaTri"]);
            double tienCoc = giaTri * qty;            
            double giaMuon = 15000 * qty;            

            dataGridView1.Rows.Add(maSp, qty, tienCoc, giaMuon);
            UpdateTotalMoney();
        }

        private void UpdateTotalMoney()
        {
            double sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sum += Convert.ToDouble(row.Cells["GiaMuon"].Value);
            }
            tboxmoney.Text = sum.ToString("N0");
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong phiếu.");
                return;
            }

            using var conn = DatabaseConnection.GetConnection();
            if (conn == null) return;

            using var tran = conn.BeginTransaction();
            try
            {
                var cmd1 = new MySqlCommand(@"INSERT INTO phieumuon (MaThanhVien, NgayMuon, HanTra, TongTien, TrangThaiMuon)
                    VALUES (@MaTV, @NgayMuon, @HanTra, @TongTien, @TrangThai);
                    SELECT LAST_INSERT_ID();", conn, tran);
                cmd1.Parameters.AddWithValue("@MaTV", cboboxuser.SelectedValue);
                cmd1.Parameters.AddWithValue("@NgayMuon", DateTime.Now);
                cmd1.Parameters.AddWithValue("@HanTra", DateTime.Now.AddDays(15));
                cmd1.Parameters.AddWithValue("@TongTien", Convert.ToDouble(tboxmoney.Text));
                cmd1.Parameters.AddWithValue("@TrangThai", "Chưa trả");

                long newId = Convert.ToInt64(cmd1.ExecuteScalar()!);

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    int maSp = Convert.ToInt32(r.Cells["MaSanPham"].Value);
                    int soLuongMuon = Convert.ToInt32(r.Cells["SoLuong"].Value);
                    double tienCoc = Convert.ToDouble(r.Cells["TienCocMuon"].Value);
                    double giaMuon = Convert.ToDouble(r.Cells["GiaMuon"].Value);

                    var cmd2 = new MySqlCommand(@"INSERT INTO chitietphieumuon(MaPhieuMuon, MaSanPham, SoLuong, TienCocMuon, GiaMuon)
                        VALUES (@pm, @sp, @sl, @coc, @muon);", conn, tran);
                    cmd2.Parameters.AddWithValue("@pm", newId);
                    cmd2.Parameters.AddWithValue("@sp", maSp);
                    cmd2.Parameters.AddWithValue("@sl", soLuongMuon);
                    cmd2.Parameters.AddWithValue("@coc", tienCoc);
                    cmd2.Parameters.AddWithValue("@muon", giaMuon);
                    cmd2.ExecuteNonQuery();

                    var cmd3 = new MySqlCommand(@"UPDATE sanpham SET SoLuong = SoLuong - @sl
                        WHERE MaSanPham = @sp;", conn, tran);
                    cmd3.Parameters.AddWithValue("@sl", soLuongMuon);
                    cmd3.Parameters.AddWithValue("@sp", maSp);
                    cmd3.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Thêm phiếu mượn thành công!", "OK", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi thêm phiếu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
