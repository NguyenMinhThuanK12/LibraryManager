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
using LibraryManager.ConnectDatabase;
using LibraryManager.Model;
using LibraryManager.Repository;
using MySql.Data.MySqlClient;

namespace muon
{
    public partial class ThongTinPMGUI : Form
    {
        private readonly int _maPM;
        private string _trangThaiMuon;
        private PhieuPhatRepository phieuPhatRepo;
        public ThongTinPMGUI(int maPhieuMuon, string trangThaiMuon)
        {
            InitializeComponent();
            _maPM = maPhieuMuon;
            _trangThaiMuon = trangThaiMuon;
            phieuPhatRepo = new PhieuPhatRepository();
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
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var colName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Kiểm tra nếu cột "Trạng Thái" thay đổi
            if (colName == "TrangThai")
            {
                var statusCell = dataGridView1.Rows[e.RowIndex].Cells["TrangThai"];
                var damageQtyCell = dataGridView1.Rows[e.RowIndex].Cells["SoLuongThietHai"];

                // Kiểm tra nếu trạng thái là "Hư hỏng/Mất"
                if (statusCell.Value != null && statusCell.Value.ToString() == "Hư hỏng/Mất")
                {
                    damageQtyCell.ReadOnly = false;  // Cho phép nhập vào cột "Số Lượng Thiệt Hại"
                }
                else
                {
                    damageQtyCell.ReadOnly = true;   // Vô hiệu hóa nhập vào cột "Số Lượng Thiệt Hại"
                    damageQtyCell.Value = null;      // Xóa giá trị của cột "Số Lượng Thiệt Hại"
                }
            }

            // Cập nhật tổng tiền khi có thay đổi
            if (colName == "SoLuongThietHai" || colName == "TrangThai")
            {
                UpdateTotalPayable();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void UpdateTotalPayable()
        //{
        //    double total = 0;
        //    double tongTienPhat = 0;
        //    List<ChiTietPhieuPhatModel> listCTPP = new List<ChiTietPhieuPhatModel>();
        //    foreach (DataGridViewRow r in dataGridView1.Rows)
        //    {
        //        total += Convert.ToDouble(r.Cells["GiaMuon"].Value);
        //    }

        //    string[] parts = tboxdayleft.Text.Split(' ');
        //    int daysLate = 0;
        //    if (parts.Length >= 2 && int.TryParse(parts[0], out int x))
        //    {
        //        daysLate = tboxdayleft.Text.StartsWith("Quá hạn") ? x : 0;
        //    }

        //    foreach (DataGridViewRow r in dataGridView1.Rows)
        //    {
        //        double tienPhat = 0;
        //        ChiTietPhieuPhatModel ctpp = new ChiTietPhieuPhatModel();
        //        int maSP = Convert.ToInt32(r.Cells["MaSanPham"].Value);
        //        double giaTienSP = phieuPhatRepo.getGiaTriSanPhamByMaSanPham(maSP);


        //        int sl = Convert.ToInt32(r.Cells["SoLuong"].Value);
        //        object raw = r.Cells["SoLuongThietHai"].Value;
        //        int slTH = (raw == null || raw == DBNull.Value) ? 0 : Convert.ToInt32(raw);
        //        double tienCoc = Convert.ToDouble(r.Cells["TienCocMuon"].Value);

        //        if (sl > 0)
        //        {
        //            double unitDeposit = tienCoc / sl;

        //            if (slTH > 0)
        //            {
        //                total += unitDeposit * slTH;
        //                tienPhat += giaTienSP * slTH;
        //            }
        //            if (daysLate > 0)
        //            {
        //                total += daysLate * 0.5 * unitDeposit * sl;
        //                tienPhat += daysLate * 0.5 * giaTienSP;
        //            }
        //        }
        //        ctpp.MaSanPham = maSP;
        //        ctpp.TienPhat = tienPhat;
        //        ctpp.LoaiPhat = 
        //        listCTPP.Add(ctpp);
        //    }

        //    PhieuPhatModel ppModel = new PhieuPhatModel(-1, _maPM, tongTienPhat, "Đã Thanh Toán");

        //    tboxtotal.Text = total.ToString("N0");
        //}



        //    private void btnreturn_Click(object sender, EventArgs e)
        //    {
        //        if (_trangThaiMuon == "Đã trả")
        //        {
        //            MessageBox.Show("Phiếu này đã được trả trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        using var conn = DatabaseConnection.GetConnection();
        //        if (conn == null) return;
        //        using var tran = conn.BeginTransaction();
        //        try
        //        {
        //            foreach (DataGridViewRow r in dataGridView1.Rows)
        //            {
        //                if (r.IsNewRow) continue;
        //                int maSp = Convert.ToInt32(r.Cells["MaSanPham"].Value);
        //                object rawSLTH = r.Cells["SoLuongThietHai"].Value;
        //                int slTH = (rawSLTH == null || rawSLTH == DBNull.Value)
        //                           ? 0
        //                           : Convert.ToInt32(rawSLTH);

        //                object rawSt = r.Cells["TrangThai"].Value;
        //                string status = (rawSt == null || rawSt == DBNull.Value)
        //                                ? "Bình thường"
        //                                : rawSt.ToString();

        //                var cmdCT = new MySqlCommand(@"
        //            UPDATE chitietphieumuon
        //            SET SoLuongThietHai = @slTH, TrangThai = @st
        //            WHERE MaPhieuMuon = @pm AND MaSanPham = @sp;", conn, tran);
        //                cmdCT.Parameters.AddWithValue("@slTH", slTH);
        //                cmdCT.Parameters.AddWithValue("@st", status);
        //                cmdCT.Parameters.AddWithValue("@pm", _maPM);
        //                cmdCT.Parameters.AddWithValue("@sp", maSp);
        //                cmdCT.ExecuteNonQuery();
        //            }

        //            double newTotal = double.Parse(tboxtotal.Text, NumberStyles.AllowThousands);

        //            var cmdPM = new MySqlCommand(@"UPDATE phieumuon
        //            SET TrangThaiMuon = 'Đã trả',
        //            ThoiGianTraThucTe = @time,
        //            TongTien = @tot
        //            WHERE MaPhieuMuon = @pm;", conn, tran);
        //            cmdPM.Parameters.AddWithValue("@time", DateTime.Now);
        //            cmdPM.Parameters.AddWithValue("@tot", newTotal);
        //            cmdPM.Parameters.AddWithValue("@pm", _maPM);
        //            cmdPM.ExecuteNonQuery();

        //            tran.Commit();
        //            MessageBox.Show("Trả phiếu mượn thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            tran.Rollback();
        //            MessageBox.Show("Lỗi khi trả phiếu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //}

        private void tboxname_TextChanged(object sender, EventArgs e)
        {

        }
        //}
        private (PhieuPhatModel, List<ChiTietPhieuPhatModel>, double) TinhPhieuPhat()
        {
            double total = 0;
            double tongTienPhat = 0;
            List<ChiTietPhieuPhatModel> listCTPP = new List<ChiTietPhieuPhatModel>();

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                total += Convert.ToDouble(r.Cells["GiaMuon"].Value);
            }

            string[] parts = tboxdayleft.Text.Split(' ');
            int daysLate = 0;
            var txt = tboxdayleft.Text.Trim().Split(' ');
            if (txt.Length >= 3 && txt[0] == "Quá" && txt[1] == "hạn" && int.TryParse(txt[2], out int n))
                daysLate = n;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                double tienPhat = 0;
                ChiTietPhieuPhatModel ctpp = new ChiTietPhieuPhatModel();
                int maSP = Convert.ToInt32(r.Cells["MaSanPham"].Value);
                double giaTienSP = phieuPhatRepo.getGiaTriSanPhamByMaSanPham(maSP);

                int sl = Convert.ToInt32(r.Cells["SoLuong"].Value);
                object raw = r.Cells["SoLuongThietHai"].Value;
                int slTH = (raw == null || raw == DBNull.Value) ? 0 : Convert.ToInt32(raw);
                double tienCoc = Convert.ToDouble(r.Cells["TienCocMuon"].Value);

                string loaiPhat = "";

                if (sl > 0)
                {
                    double unitDeposit = tienCoc / sl;

                    if (slTH > 0)
                    {
                        total += unitDeposit * slTH;
                        tienPhat += giaTienSP * slTH;
                        loaiPhat += "Hư hỏng/Mất ";
                    }
                    if (daysLate > 0)
                    {
                        total += daysLate * 0.5 * unitDeposit * sl;
                        tienPhat += daysLate * 0.5 * giaTienSP;
                        loaiPhat += "Trễ hạn";
                    }
                }

                tongTienPhat += tienPhat;

                ctpp.MaSanPham = maSP;
                ctpp.TienPhat = tienPhat;
                ctpp.LoaiPhat = loaiPhat.Trim();
                if(ctpp.LoaiPhat != "") 
                    listCTPP.Add(ctpp);
            }

            PhieuPhatModel ppModel = new PhieuPhatModel(-1, _maPM, tongTienPhat, "Đã Thanh Toán");

            return (ppModel, listCTPP, total);
        }

        private void UpdateTotalPayable()
        {
            var (_, _, total) = TinhPhieuPhat();
            tboxtotal.Text = total.ToString("N0");
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
                    int sl = Convert.ToInt32(r.Cells["SoLuong"].Value);
                    object rawTH = r.Cells["SoLuongThietHai"].Value;
                    int slTH = (rawTH == null || rawTH == DBNull.Value)
                                ? 0
                                : Convert.ToInt32(rawTH);

                    string status = r.Cells["TrangThai"].Value?.ToString() ?? "Bình thường";
                    var cmdCT = new MySqlCommand(@"
                    UPDATE chitietphieumuon
                    SET SoLuongThietHai = @slTH,
                    TrangThai       = @st
                    WHERE MaPhieuMuon    = @pm
                    AND MaSanPham     = @sp;", conn, tran);
                    cmdCT.Parameters.AddWithValue("@slTH", slTH);
                    cmdCT.Parameters.AddWithValue("@st", status);
                    cmdCT.Parameters.AddWithValue("@pm", _maPM);
                    cmdCT.Parameters.AddWithValue("@sp", maSp);
                    cmdCT.ExecuteNonQuery();

                    int toReturn = sl - slTH;
                    if (toReturn > 0)
                    {
                        var cmdStock = new MySqlCommand(@"
                        UPDATE sanpham
                        SET SoLuong = SoLuong + @ret
                        WHERE MaSanPham = @sp;", conn, tran);
                        cmdStock.Parameters.AddWithValue("@ret", toReturn);
                        cmdStock.Parameters.AddWithValue("@sp", maSp);
                        cmdStock.ExecuteNonQuery();
                    }
                }

                double newTotal = double.Parse(tboxtotal.Text, NumberStyles.AllowThousands);
                var cmdPM = new MySqlCommand(@"
                UPDATE phieumuon
                SET TrangThaiMuon       = 'Đã trả',
                ThoiGianTraThucTe   = @time,
                TongTien            = @tot
                 WHERE MaPhieuMuon         = @pm;", conn, tran);
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

            // Tạo phiếu phạt và chi tiết
            var (ppModel, listCTPP, _) = TinhPhieuPhat();
            if(listCTPP.Count == 0)
            {
                return;
            }
            try
            {
                if (phieuPhatRepo.Insert(ppModel, listCTPP))
                {
                    MessageBox.Show("Thêm phiếu phạt thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm phiếu phạt (not Catch) ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu phạt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
    
