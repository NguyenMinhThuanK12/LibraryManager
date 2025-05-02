using LibraryManager.ConnectDatabase;
using LibraryManager.Model;
using LibraryManager.Models;
using MySql.Data.MySqlClient;

namespace LibraryManager.Repository
{
    public class TheLoaiRepository
    {
        public List<TheLoaiModel> GetAllTheLoai()
        {
            List<TheLoaiModel> list = new List<TheLoaiModel>();
            string query = "SELECT MaTL, TenTL FROM theloai";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TheLoaiModel
                            {
                                MaTL = reader.GetInt32("MaTL"),
                                TenTL = reader.GetString("TenTL")
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<DeviceModel> SearchDevicesByTheLoai(int maTL)
        {
            var list = new List<DeviceModel>();
            string query = @"
        SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL, tl.MaTL, t.MaTang, v.MaViTri,
               CONCAT(t.TenTang, ' - ', v.TenViTri) AS ViTri,
               sp.SoLuong, sp.GiaTri, sp.TrangThai
        FROM sanpham sp
        JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
        JOIN theloai tl ON tl.MaTL = lsp.MaTL
        JOIN vitri v ON v.MaViTri = sp.MaViTri
        JOIN tang t ON t.MaTang = sp.MaTang
        WHERE sp.TrangThai != 'Unactive' AND tl.MaTL = @maTL
        ORDER BY sp.MaSanPham ASC";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maTL", maTL);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DeviceModel
                            {
                                Id = reader.GetInt32("MaSanPham"),
                                TenThietBi = reader.GetString("TenSanPham"),
                                TheLoai = reader.GetString("TenTL"),
                                IDTheLoai = reader.GetInt32("MaTL"),
                                IDTang = reader.GetInt32("MaTang"),
                                IDViTri = reader.GetInt32("MaViTri"),
                                ViTri = reader.GetString("ViTri"),
                                SoLuong = reader.GetInt32("SoLuong"),
                                GiaTri = reader.GetDouble("GiaTri"),
                                TrangThai = reader.GetString("TrangThai")
                            });
                        }
                    }
                }
            }
            return list;
        }
    }


}
