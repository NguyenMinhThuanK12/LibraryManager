
using LibraryManager.ConnectDatabase;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using LibraryManager.Model;

namespace LibraryManager.Repository
{
    public class DeviceRepository
    {
        public List<DeviceModel> GetAllDevices()
        {
            List<DeviceModel> list = new List<DeviceModel>();

            string query = @"SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL,
                                v.TenViTri AS ViTri,
                   
             sp.SoLuong,sp.GiaTri, sp.TrangThai
                         FROM sanpham sp
                         JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
                         JOIN theloai tl ON tl.MaTL = lsp.MaTL
                         JOIN vitri v ON v.MaViTri = sp.MaViTri
                         JOIN tang t ON t.MaTang = sp.MaTang";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn == null) return list;

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DeviceModel
                            {
                                Id = reader.GetInt32("MaSanPham"),
                                TenThietBi = reader.GetString("TenSanPham"),
                                TheLoai = reader.GetString("TenTL"),
                                ViTri = reader.GetString("ViTri"),
                                SoLuong = reader.GetInt32("SoLuong"),
                                GiaTri = reader.GetDouble("GiaTri"),
                                TrangThai = reader.GetString("TrangThai")
                            });
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi truy vấn thiết bị: " + ex.Message);
                }
            }

            return list;
        }

        public List<DeviceModel> SearchDevices(string keyword)
        {
            List<DeviceModel> list = new List<DeviceModel>();
            string query = $@"
        SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL, 
               CONCAT(t.TenTang, ' - ', v.TenViTri) AS ViTri, 
               sp.SoLuong, sp.GiaTri, sp.TrangThai
        FROM sanpham sp
        JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
        JOIN theloai tl ON tl.MaTL = lsp.MaTL
        JOIN vitri v ON v.MaViTri = sp.MaViTri
        JOIN tang t ON t.MaTang = sp.MaTang
        WHERE sp.TenSanPham LIKE @kw OR sp.MaSanPham LIKE @kw
    ";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DeviceModel
                            {
                                Id = reader.GetInt32("MaSanPham"),
                                TenThietBi = reader.GetString("TenSanPham"),
                                TheLoai = reader.GetString("TenTL"),
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