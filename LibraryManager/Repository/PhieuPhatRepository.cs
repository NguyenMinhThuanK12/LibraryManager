using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.ConnectDatabase;
using LibraryManager.DTO;
using LibraryManager.Model;
using MySql.Data.MySqlClient;

namespace LibraryManager.Repository
{
    public class PhieuPhatRepository
    {
        public List<PhieuPhatModel> GetAllPhieuPhat()
        {
            List<PhieuPhatModel> list = new List<PhieuPhatModel>();
            string query = "SELECT * FROM phieuphat";
            DataTable dt = DatabaseConnection.ExecuteSelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhieuPhatModel
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    TongTienPhat = Convert.ToDouble(row["TongTienPhat"]),
                    NgayTao = Convert.ToDateTime(row["NgayTao"]),
                    TrangThaiThanhToan = Convert.ToString(row["TrangThaiThanhToan"])
                });
            }

            return list;
        }
        public ThanhVienDTO getThanhVienById(int maThanhVien)
        {
            ThanhVienDTO thanhVien = null;
            string query = "SELECT * FROM thanhvien WHERE MaThanhVien = @maThanhVien";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maThanhVien", maThanhVien);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            thanhVien = new ThanhVienDTO
                            {
                                maThanhVien = reader.GetInt32("MaThanhVien"),
                                hoTen = reader.GetString("HoTen"),
                                ngaySinh = reader.GetDateTime("NgaySinh"),
                                diaChi = reader.GetString("DiaChi"),
                                sdt = reader.GetString("SDT"),
                                email = reader.GetString("Email"),
                                ngayDangKy = reader.GetDateTime("NgayDangKy")
                            };
                        }
                    }
                }
            }

            return thanhVien;
        }
        public List<PhieuPhatModel> GetPhieuPhatByMaThanhVien(int maThanhVien)
        {
            List<PhieuPhatModel> list = new List<PhieuPhatModel>();
            string query = $"SELECT * FROM phieuphat WHERE MaThanhVien = {maThanhVien}";
            DataTable dt = DatabaseConnection.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhieuPhatModel
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    TongTienPhat = Convert.ToDouble(row["TongTienPhat"]),
                    NgayTao = Convert.ToDateTime(row["NgayTao"]),
                    TrangThaiThanhToan = Convert.ToString(row["TrangThaiThanhToan"])
                });
            }
            return list;
        }
        public List<ChiTietPhieuPhatModel> GetChiTietPhieuPhat(int maPhieuPhat)
        {
            List<ChiTietPhieuPhatModel> list = new List<ChiTietPhieuPhatModel>();
            string query = $"SELECT * FROM chitietphieuphat WHERE MaPhieuPhat = {maPhieuPhat}";
            DataTable dt = DatabaseConnection.ExecuteSelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietPhieuPhatModel
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaSanPham = Convert.ToInt32(row["MaSanPham"]),
                    TienPhat = Convert.ToDouble(row["TienPhat"]),
                    LoaiPhat = row["LoaiPhat"].ToString()
                });
            }

            return list;
        }
        public bool Insert(PhieuPhatModel p, List<ChiTietPhieuPhatModel> list)
        {
            try
            {
                int maPhieuPhat = InsertAndGetLastId(p);
                Console.WriteLine("Mã phiếu phạt mới: " + maPhieuPhat);

                foreach (var chiTiet in list)
                {
                    chiTiet.MaPhieuPhat = maPhieuPhat;
                    try
                    {
                        AddChiTietPhieuPhat(chiTiet);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm chi tiết (Mã SP: " + chiTiet.MaSanPham + "): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                //MessageBox.Show("Thêm phiếu phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PhieuPhatRepo: Lỗi khi thêm phiếu phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public int InsertAndGetLastId(PhieuPhatModel phieu)
        {
            string query = "INSERT INTO phieuphat (MaPhieuMuon, TongTienPhat, NgayTao) " +
               "VALUES (@MaPhieuMuon, @TongTienPhat, @NgayTao); " +
               "SELECT LAST_INSERT_ID();";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuMuon", phieu.MaPhieuMuon);
                    cmd.Parameters.AddWithValue("@TongTienPhat", phieu.TongTienPhat);
                    cmd.Parameters.AddWithValue("@NgayTao", phieu.NgayTao);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newId;
                }
            }

        }
        public int AddChiTietPhieuPhat(ChiTietPhieuPhatModel chitiet)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO chitietphieuphat (MaPhieuPhat, MaSanPham, TienPhat, LoaiPhat) " +
                               "VALUES (@MaPhieuPhat, @MaSanPham, @TienPhat, @LoaiPhat)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuPhat", chitiet.MaPhieuPhat);
                    cmd.Parameters.AddWithValue("@MaSanPham", chitiet.MaSanPham);
                    cmd.Parameters.AddWithValue("@TienPhat", chitiet.TienPhat);
                    cmd.Parameters.AddWithValue("@LoaiPhat", chitiet.LoaiPhat);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CapNhatTrangThaiPhieuPhat(int maPhieuPhat)
        {
            string trangThaiMoi = "Đã Thanh Toán";
            string query = @"
                UPDATE PhieuPhat
                SET TrangThaiThanhToan = @trangThaiMoi
                WHERE MaPhieuPhat = @maPhieuPhat
    ";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trangThaiMoi", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@maPhieuPhat", maPhieuPhat);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        //Other
        public string GetTenThanhVienByMaPhieuPhat(int maPhieuPhat)
        {
            string tenThanhVien = "";

            string query = @"
                SELECT tv.HoTen
                FROM phieuphat pp
                JOIN phieumuon pm ON pp.MaPhieuMuon = pm.MaPhieuMuon
                JOIN thanhvien tv ON pm.MaThanhVien = tv.MaThanhVien
                WHERE pp.MaPhieuPhat = @maPhieuPhat
    ";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhieuPhat", maPhieuPhat);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenThanhVien = reader.GetString("HoTen");
                        }
                    }
                }
            }

            return tenThanhVien;
        }
        public int GetMaThanhVienByMaPhieuPhat(int maPhieuPhat)
        {
            int maThanhVien = -1;

            string query = @"
                SELECT tv.MaThanhVien
                FROM phieuphat pp
                JOIN phieumuon pm ON pp.MaPhieuMuon = pm.MaPhieuMuon
                JOIN thanhvien tv ON pm.MaThanhVien = tv.MaThanhVien
                WHERE pp.MaPhieuPhat = @maPhieuPhat
    ";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhieuPhat", maPhieuPhat);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maThanhVien = reader.GetInt32("MaThanhVien");
                        }
                    }
                }
            }

            return maThanhVien;
        }
        public string GetTenSanPhamById(int maSanPham)
        {
            string query = @"
                SELECT TenSanPham
                FROM sanPham
                WHERE sanPham.MaSanPham = @maSanPham
    ";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSanPham", maSanPham);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString("TenSanPham");
                        }
                    }
                }
            }

            return null;
        }
        public double getGiaTriSanPhamByMaSanPham(int maSanPham)
        {
            string query = @"
                SELECT GiaTri
                FROM sanPham
                WHERE sanPham.MaSanPham = @maSanPham
    ";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSanPham", maSanPham);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDouble("GiaTri");
                        }
                    }
                }
            }

            return -1;
        }
    }
}
