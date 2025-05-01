using LibraryManager.Model;
using LibraryManager.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LibraryManager.Data
{
    public class DeviceRepository
    {
        private readonly string connectionString = "server=localhost;database=library_management;uid=root;pwd=123456;";

        public List<DeviceModel> GetAllDevices()
        {
            var list = new List<DeviceModel>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL,
                                        CONCAT(t.TenTang, ' - ', v.TenViTri) AS ViTri,
                                        sp.SoLuong, sp.TrangThai
                                 FROM sanpham sp
                                 JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
                                 JOIN theloai tl ON tl.MaTL = lsp.MaTL
                                 JOIN vitri v ON v.MaViTri = sp.MaViTri
                                 JOIN tang t ON t.MaTang = sp.MaTang";

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DeviceModel
                    {
                        Id = reader.GetInt32("MaSanPham"),
                        TenThietBi = reader.GetString("TenSanPham"),
                        TheLoai = reader.GetString("TenTL"),
                        ViTri = reader.GetString("ViTri"),
                        SoLuong = reader.GetInt32("SoLuong"),
                        TrangThai = reader.GetString("TrangThai")
                    });
                }
            }

            return list;
        }
    }
}