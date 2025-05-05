using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model;
using MinhViLap05;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using LibraryManager.ConnectDatabase;
using System.Data;
using System.Windows.Forms;
namespace LibraryManager.Repository
{
    public class PhieuNhapRepository
    {

        public bool Insert(PhieuNhapModel p, List<ChiTietPhieuNhapModel> list)
        {
            try
            {
                int maPhieuNhap = InsertAndGetLastId(p);
                Console.WriteLine("Mã phiếu nhập mới: " + maPhieuNhap);

                foreach (var chiTiet in list)
                {
                    chiTiet.MaPhieuNhap = maPhieuNhap;
                    try
                    {
                        AddChiTietPhieuNhap(chiTiet);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm chi tiết (Mã SP: " + chiTiet.MaSanPham + "): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<PhieuNhapModel> GetAll()
        {
            
            List<PhieuNhapModel> list = new List<PhieuNhapModel>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM PhieuNhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PhieuNhapModel
                    {
                        MaPhieuNhap = reader.GetInt32("MaPhieuNhap"),
                        NgayTao = reader.GetDateTime("NgayTao"),
                        TongTien = reader.GetDouble("TongTien"),
                        MaNCC = reader.GetInt32("MaNCC")
                    });
                }
            }
            return list;
        }
        public PhieuNhapModel GetById(int maPhieuNhap)
        {

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                PhieuNhapModel pn = null;
                string query = "SELECT * FROM PhieuNhap WHERE PhieuNhap.MaPhieuNhap = " + maPhieuNhap;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     pn = new PhieuNhapModel(
                         reader.GetInt32("MaPhieuNhap"),
                         reader.GetDouble("TongTien"),
                         reader.GetInt32("MaNCC")
                    );
                }
                return pn;
            }
        }
        public String GetTenNhaCungCapById(int maNCC)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM NhaCungCap WHERE NhaCungCap.MaNCC = " + maNCC;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString("TenNCC");
                }
                return null;
            }
        }

        public int InsertAndGetLastId(PhieuNhapModel p)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO PhieuNhap (MaNCC, TongTien) VALUES (@MaNCC, @TongTien); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNCC", p.MaNCC);
                cmd.Parameters.AddWithValue("@TongTien", p.TongTien);

                // Thực hiện và trả về ID mới
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
        }

        public void Update(PhieuNhapModel p)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE PhieuNhap SET NgayTao = @NgayTao, TongTien = @TongTien, MaNCC = @MaNCC WHERE MaPhieuNhap = @MaPhieuNhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayTao", p.NgayTao);
                cmd.Parameters.AddWithValue("@TongTien", p.TongTien);
                cmd.Parameters.AddWithValue("@MaNCC", p.MaNCC);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", p.MaPhieuNhap);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int maPhieuNhap)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                cmd.ExecuteNonQuery();
            }
        }
        //Other
        public List<NhaCungCapModel> GetAllNhaCungCap()
        {
            List<NhaCungCapModel> list = new List<NhaCungCapModel>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM NhaCungCap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhaCungCapModel
                    {
                        // Gán giá trị cho các thuộc tính của NhaCungCapModel
                        MaNCC = reader.GetInt32("MaNCC"),
                        TenNCC = reader.GetString("TenNCC"),
                        SDT = reader.GetString("SDT"),
                        Email = reader.GetString("Email"),
                        DiaChi = reader.GetString("DiaChi"),
                        TrangThai = reader.GetString("TrangThai")
                    });
                }
            }
            return list;
        }
        public List<ChiTietPhieuNhapModel> GetAllChiTietPhieuNhapById(int maPhieuNhap)
        {
            List<ChiTietPhieuNhapModel> list = new List<ChiTietPhieuNhapModel>();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM chitietphieunhap WHERE MaPhieuNhap = @MaPhieuNhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietPhieuNhapModel chiTiet = new ChiTietPhieuNhapModel
                        {
                            MaPhieuNhap = reader.GetInt32("MaPhieuNhap"),
                            MaSanPham = reader.GetInt32("MaSanPham"),
                            SoLuong = reader.GetInt32("SoLuong"),
                            GiaNhap = reader.GetDouble("GiaNhap")
                        };
                        list.Add(chiTiet);
                    }
                }
            }
            return list;
        }
        public void AddChiTietPhieuNhap(ChiTietPhieuNhapModel chiTiet)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    // Bắt đầu transaction (đảm bảo an toàn dữ liệu)
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Thêm chi tiết phiếu nhập
                            string insertQuery = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, GiaNhap) " +
                                                 "VALUES (@MaPhieuNhap, @MaSanPham, @SoLuong, @GiaNhap)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@MaPhieuNhap", chiTiet.MaPhieuNhap);
                                insertCmd.Parameters.AddWithValue("@MaSanPham", chiTiet.MaSanPham);
                                insertCmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                                insertCmd.Parameters.AddWithValue("@GiaNhap", chiTiet.GiaNhap);
                                insertCmd.ExecuteNonQuery();
                            }

                            // 2. Cập nhật số lượng sản phẩm
                            string updateQuery = "UPDATE SanPham SET SoLuong = SoLuong + @SoLuong WHERE MaSanPham = @MaSanPham";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                                updateCmd.Parameters.AddWithValue("@MaSanPham", chiTiet.MaSanPham);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Commit nếu cả hai thành công
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback nếu có lỗi
                            Console.WriteLine("Lỗi trong transaction: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối hoặc lỗi khác: " + ex.Message);
            }
        }










        //Sản Phẩm DAO
        public List<SanPhamModel> GetAllSanPham()
        {
            List<SanPhamModel> sanPhams = new List<SanPhamModel>();
            string query = "SELECT * FROM SanPham";

            // Thực thi câu lệnh SELECT và lấy kết quả
            DataTable result = DatabaseConnection.ExecuteSelectQuery(query);

            // Duyệt qua DataTable và ánh xạ vào Model
            foreach (DataRow row in result.Rows)
            {
                SanPhamModel sanPham = new SanPhamModel
                (Convert.ToInt32(row["MaSanPham"]),
                     Convert.ToInt32(row["MaViTri"]),
                    Convert.ToInt32(row["MaTang"]),
                    row["TenSanPham"].ToString(),
                    Convert.ToInt32(row["SoLuong"]),
                    Convert.ToDouble(row["GiaTri"]),
                    row["TrangThai"].ToString()
                    );


                sanPhams.Add(sanPham);
            }

            return sanPhams;
        }
        public SanPhamModel GetSanPhamById(int maSanPham)
        {
            SanPhamModel sanPham = null;

            // Câu lệnh SQL để lấy thông tin sản phẩm theo maSanPham
            string query = "SELECT * FROM SanPham WHERE MaSanPham = @MaSanPham";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())  // Mở kết nối tới database
            {
                if (conn != null)
                {
                    try
                    {
                        // Thiết lập câu lệnh MySQL
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);

                        // Thực thi câu lệnh và lấy dữ liệu
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Kiểm tra nếu có dữ liệu trả về
                        if (reader.Read())
                        {
                            // Tạo đối tượng SanPhamModel và gán giá trị từ cơ sở dữ liệu
                            sanPham = new SanPhamModel(
                                reader.GetInt32("MaSanPham"),
                                reader.GetInt32("MaViTri"),
                                reader.GetInt32("MaTang"),
                                reader.GetString("TenSanPham"),
                                reader.GetInt32("SoLuong"),
                                reader.GetDouble("GiaTri"),
                                reader.GetString("TrangThai")
                            );
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
                    }
                }
            }

            return sanPham;  // Trả về đối tượng sản phẩm
        }
    }
}
