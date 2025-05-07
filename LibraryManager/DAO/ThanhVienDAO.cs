using LibraryManager.DTO;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LibraryManager.ConnectDatabase;

namespace LibraryManager.DAO
{
    public class ThanhVienDAO
    {
        public List<ThanhVienDTO> GetAllThanhVien()
        {
            List<ThanhVienDTO> list = new List<ThanhVienDTO>();
            MySqlConnection conn = DatabaseConnection.GetConnection();

            if (conn == null)
            {
                return list;
            }

            try
            {
                string query = "SELECT * FROM thanhvien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThanhVienDTO tv = new ThanhVienDTO
                    {
                        maThanhVien = reader.GetInt32("maThanhVien"),
                        hoTen = reader["hoTen"]?.ToString(),
                        ngaySinh = reader.GetDateTime("ngaySinh"),
                        diaChi = reader["diaChi"]?.ToString(),
                        sdt = reader["sdt"]?.ToString(),
                        email = reader["email"]?.ToString(),
                        ngayDangKy = reader.GetDateTime("ngayDangKy")
                    };
                    list.Add(tv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAllThanhVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public void UpdateThanhVien(ThanhVienDTO tv)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            if (conn == null) return;

            try
            {
                string query = "UPDATE thanhvien SET hoTen=@hoTen, ngaySinh=@ngaySinh, diaChi=@diaChi, sdt=@sdt, email=@email WHERE maThanhVien=@maThanhVien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maThanhVien", tv.maThanhVien);
                cmd.Parameters.AddWithValue("@hoTen", tv.hoTen);
                cmd.Parameters.AddWithValue("@ngaySinh", tv.ngaySinh);
                cmd.Parameters.AddWithValue("@diaChi", tv.diaChi);
                cmd.Parameters.AddWithValue("@sdt", tv.sdt);
                cmd.Parameters.AddWithValue("@email", tv.email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UpdateThanhVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteThanhVien(int maThanhVien)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            if (conn == null) return;

            try
            {
                string query = "DELETE FROM thanhvien WHERE maThanhVien=@maThanhVien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maThanhVien", maThanhVien);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DeleteThanhVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteNhieuThanhVien(List<int> danhSachMaThanhVien)
        {
            if (danhSachMaThanhVien == null || danhSachMaThanhVien.Count == 0)
                return;

            MySqlConnection conn = DatabaseConnection.GetConnection();
            if (conn == null) return;

            try
            {
                string query = "DELETE FROM thanhvien WHERE maThanhVien IN (" + string.Join(",", danhSachMaThanhVien) + ")";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DeleteNhieuThanhVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<ThanhVienDTO> SearchThanhVienByName(string hoTen)
        {
            List<ThanhVienDTO> list = new List<ThanhVienDTO>();
            MySqlConnection conn = DatabaseConnection.GetConnection();
            if (conn == null) return list;

            try
            {
                string query = "SELECT * FROM thanhvien WHERE hoTen LIKE @hoTen";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hoTen", "%" + hoTen + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThanhVienDTO tv = new ThanhVienDTO
                    {
                        maThanhVien = reader.GetInt32("maThanhVien"),
                        hoTen = reader["hoTen"]?.ToString(),
                        ngaySinh = reader.GetDateTime("ngaySinh"),
                        diaChi = reader["diaChi"]?.ToString(),
                        sdt = reader["sdt"]?.ToString(),
                        email = reader["email"]?.ToString(),
                        ngayDangKy = reader.GetDateTime("ngayDangKy")
                    };
                    list.Add(tv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi SearchThanhVienByName: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public void ThemThanhVien(ThanhVienDTO thanhVien)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            if (conn == null) return;

            try
            {
                string query = "INSERT INTO thanhvien (maThanhVien, hoTen, ngaySinh, diaChi, sdt, email, ngayDangKy) " +
                               "VALUES (@maThanhVien, @hoTen, @ngaySinh, @diaChi, @sdt, @email, @ngayDangKy)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maThanhVien", thanhVien.maThanhVien);
                cmd.Parameters.AddWithValue("@hoTen", thanhVien.hoTen);
                cmd.Parameters.AddWithValue("@ngaySinh", thanhVien.ngaySinh);
                cmd.Parameters.AddWithValue("@diaChi", thanhVien.diaChi);
                cmd.Parameters.AddWithValue("@sdt", thanhVien.sdt);
                cmd.Parameters.AddWithValue("@email", thanhVien.email);
                cmd.Parameters.AddWithValue("@ngayDangKy", thanhVien.ngayDangKy);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ThemThanhVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
