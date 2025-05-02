
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

                    string query = @"
            SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL, tl.MaTL, t.MaTang, v.MaViTri,
                   CONCAT(t.TenTang, ' - ', v.TenViTri) AS ViTri, 
                   sp.SoLuong, sp.GiaTri, sp.TrangThai
            FROM sanpham sp
            JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
            JOIN theloai tl ON tl.MaTL = lsp.MaTL
            JOIN vitri v ON v.MaViTri = sp.MaViTri
            JOIN tang t ON t.MaTang = sp.MaTang
            WHERE sp.TrangThai != 'Unactive'
            ORDER BY sp.MaSanPham ASC";


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
                                IDTheLoai = reader.GetInt32("MaTL"),
                                IDViTri = reader.GetInt32("MaViTri"),
                                IDTang = reader.GetInt32("MaTang"),
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
    SELECT sp.MaSanPham, sp.TenSanPham, tl.TenTL,tl.MaTL,t.MaTang,v.MaViTri,
           CONCAT(t.TenTang, ' - ', v.TenViTri) AS ViTri, 
           sp.SoLuong, sp.GiaTri, sp.TrangThai
    FROM sanpham sp
    JOIN loaisp_sp lsp ON sp.MaSanPham = lsp.MaSP
    JOIN theloai tl ON tl.MaTL = lsp.MaTL
    JOIN vitri v ON v.MaViTri = sp.MaViTri
    JOIN tang t ON t.MaTang = sp.MaTang
    WHERE (sp.TenSanPham LIKE @kw OR sp.MaSanPham LIKE @kw)
      AND sp.TrangThai != 'Unactive'
        ORDER BY sp.MaSanPham ASC
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
                                IDTheLoai = reader.GetInt32("MaTL"),
                                IDViTri = reader.GetInt32("MaViTri"),
                                IDTang = reader.GetInt32("MaTang"),
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
        public bool InsertDevice(DeviceModel device)
        {
            string query = @"
        INSERT INTO sanpham (TenSanPham, SoLuong, GiaTri, MaViTri, MaTang, TrangThai)
        VALUES (@Ten, @SoLuong, @GiaTri, @ViTri, @Tang, 'active');
        SET @MaSP = LAST_INSERT_ID();

        INSERT INTO loaisp_sp (MaSP, MaTL) VALUES (@MaSP, @TheLoai);
    ";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@Ten", device.TenThietBi);
                            cmd.Parameters.AddWithValue("@SoLuong", device.SoLuong);
                            cmd.Parameters.AddWithValue("@GiaTri", device.GiaTri);
                            cmd.Parameters.AddWithValue("@ViTri", device.IDViTri);
                            cmd.Parameters.AddWithValue("@Tang", device.IDTang);
                            cmd.Parameters.AddWithValue("@TheLoai", device.IDTheLoai);

                            cmd.Parameters.Add(new MySqlParameter("@MaSP", MySqlDbType.Int32) { Direction = System.Data.ParameterDirection.Output });

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm thiết bị: " + ex.Message);
                        }
                    }
                }
            }

            return false;
        }

        public bool UpdateDevice(DeviceModel device)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    try
                    {
                        string query = @"
                    UPDATE sanpham 
                    SET TenSanPham = @Ten, SoLuong = @SoLuong, GiaTri = @GiaTri, MaViTri = @ViTri, MaTang = @Tang
                    WHERE MaSanPham = @Id;

                    UPDATE loaisp_sp 
                    SET MaTL = @TheLoai
                    WHERE MaSP = @Id;
                ";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", device.Id);
                        cmd.Parameters.AddWithValue("@Ten", device.TenThietBi);
                        cmd.Parameters.AddWithValue("@SoLuong", device.SoLuong);
                        cmd.Parameters.AddWithValue("@GiaTri", device.GiaTri);
                        cmd.Parameters.AddWithValue("@ViTri", device.IDViTri);
                        cmd.Parameters.AddWithValue("@Tang", device.IDTang);
                        cmd.Parameters.AddWithValue("@TheLoai", device.IDTheLoai);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật thiết bị: " + ex.Message);
                    }
                }
            }
            return false;
        }


        public bool DeleteDevice(int id)
        {
            string query = "UPDATE sanpham SET TrangThai = 'Unactive' WHERE MaSanPham = @id";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn == null) return false;

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    int affectedRows = cmd.ExecuteNonQuery();

                    return affectedRows > 0; // trả về true nếu có ít nhất 1 dòng được cập nhật
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật trạng thái thiết bị: " + ex.Message);
                    return false;
                }
            }
        }

        public int GetNextDeviceId()
        {
            string query = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'library_management' AND TABLE_NAME = 'sanpham'";
            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lấy ID tiếp theo: " + ex.Message);
                    }
                }
            }
            return -1; // lỗi
        }

        public bool IsDeviceNameExists(string ten, int excludeId)
        {
            string query = "SELECT COUNT(*) FROM sanpham WHERE TenSanPham = @Ten AND MaSanPham != @Id AND TrangThai != 'Unactive'";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ten", ten);
                            cmd.Parameters.AddWithValue("@Id", excludeId);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            return count > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kiểm tra tên thiết bị: " + ex.Message);
                    }
                }
            }

            return false;
        }

    }
}