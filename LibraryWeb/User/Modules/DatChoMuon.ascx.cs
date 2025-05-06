using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User.Modules
{
    public partial class DatChoMuon : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTheLoai();
            if (!IsPostBack)
                LoadTheLoai();

            LoadThietBi();
            BindDanhSachDatCho();
        }

        public class ThietBiMuon
        {
            public int MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; } = 1;
        }

        private List<ThietBiMuon> DanhSachThietBiDatCho
        {
            get => (List<ThietBiMuon>)Session["DanhSachDatCho"] ?? new List<ThietBiMuon>();
            set => Session["DanhSachDatCho"] = value;
        }

        private void LoadTheLoai()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT MaTL, TenTL FROM theloai WHERE TrangThai = 'active'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlTheLoai.Items.Clear();
                        ddlTheLoai.Items.Add(new ListItem("Tất cả", ""));
                        while (reader.Read())
                            ddlTheLoai.Items.Add(new ListItem(reader["TenTL"].ToString(), reader["MaTL"].ToString()));
                    }
                }
            }
        }

        private void LoadThietBi()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    StringBuilder query = new StringBuilder(@"
                        SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL,
                        CONCAT(tg.TenTang, ' - ', vt.TenViTri) AS ViTri
                        FROM sanpham sp
                        LEFT JOIN vitri vt ON sp.MaViTri = vt.MaViTri
                        LEFT JOIN tang tg ON sp.MaTang = tg.MaTang
                        LEFT JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
                        LEFT JOIN theloai tl ON lsp.MaTL = tl.MaTL
                        WHERE sp.TrangThai = 'active'");

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        if (!string.IsNullOrEmpty(ddlTheLoai.SelectedValue))
                        {
                            query.Append(" AND tl.MaTL = @maTL");
                            cmd.Parameters.AddWithValue("@maTL", ddlTheLoai.SelectedValue);
                        }
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            query.Append(" AND (sp.TenSanPham COLLATE utf8mb4_general_ci LIKE @keyword COLLATE utf8mb4_general_ci OR sp.MaSanPham LIKE @keyword)");
                            cmd.Parameters.AddWithValue("@keyword", "%" + txtSearch.Text.Trim() + "%");
                        }
                        cmd.CommandText = query.ToString();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            rptThietBi.DataSource = dt;
                            rptThietBi.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<div style='color:red;'>Lỗi SQL: " + ex.Message + "</div>");
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadThietBi();
        }

        protected void ddlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = ""; // Reset tìm kiếm khi chọn thể loại
            LoadThietBi();
        }

        protected void btnChon_Command(object sender, CommandEventArgs e)
        {
            string[] parts = e.CommandArgument.ToString().Split('|');
            int maSP = int.Parse(parts[0]);
            string tenSP = parts[1];

            var danhSach = DanhSachThietBiDatCho;
            if (!danhSach.Any(x => x.MaSanPham == maSP))
            {
                danhSach.Add(new ThietBiMuon { MaSanPham = maSP, TenSanPham = tenSP });
                DanhSachThietBiDatCho = danhSach;
            }

            BindDanhSachDatCho();
        }

        private void BindDanhSachDatCho()
        {
            rptDatCho.DataSource = DanhSachThietBiDatCho;
            rptDatCho.DataBind();
        }

        protected void rptDatCho_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                int maSP = int.Parse(e.CommandArgument.ToString());
                var danhSach = DanhSachThietBiDatCho;
                danhSach.RemoveAll(x => x.MaSanPham == maSP);
                DanhSachThietBiDatCho = danhSach;
                BindDanhSachDatCho();
            }
        }

        protected void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var danhSach = DanhSachThietBiDatCho;
            if (!danhSach.Any())
            {
                Response.Write("<script>alert('Vui lòng chọn ít nhất 1 thiết bị');</script>");
                return;
            }

            if (!DateTime.TryParse(txtNgayMuon.Text, out DateTime ngayMuon))
            {
                Response.Write("<script>alert('Vui lòng chọn ngày mượn hợp lệ');</script>");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                int maTV = (int)Session["MaThanhVien"];

                for (int i = 0; i < rptDatCho.Items.Count; i++)
                {
                    RepeaterItem item = rptDatCho.Items[i];

                    HiddenField hidMaSP = (HiddenField)item.FindControl("hidMaSP");
                    TextBox txtSoLuong = (TextBox)item.FindControl("txtSoLuong");

                    int maSP = int.Parse(hidMaSP.Value);
                    int soLuong = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 1;

                    using (MySqlCommand cmd = new MySqlCommand(@"
                INSERT INTO phieudatcho (MaThanhVien, MaSanPham, SoLuong, ThoiGianDat, ThoiGianMuonDuKien, TrangThaiDat)
                VALUES (@maTV, @maSP, @soLuong, @now, @ngayMuon, 'Chờ duyệt')", conn))
                    {
                        cmd.Parameters.AddWithValue("@maTV", maTV);
                        cmd.Parameters.AddWithValue("@maSP", maSP);
                        cmd.Parameters.AddWithValue("@soLuong", soLuong);
                        cmd.Parameters.AddWithValue("@now", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ngayMuon", ngayMuon);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            DanhSachThietBiDatCho = new List<ThietBiMuon>();
            txtNgayMuon.Text = "";
            BindDanhSachDatCho();
            Response.Write("<script>alert('Đã tạo phiếu thành công');</script>");
        }
    }
}
