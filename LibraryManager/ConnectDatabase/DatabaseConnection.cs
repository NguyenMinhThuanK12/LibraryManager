using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Thêm namespace này để dùng MessageBox

namespace LibraryManager.ConnectDatabase
{
    internal class DatabaseConnection
    {

        // Chuỗi kết nối MySQL (thay thế thông tin của bạn)
        private static string connectionString = "Server=localhost;Database=library_management;Uid=root;Pwd=123456;";

        // Hàm mở kết nối đến cơ sở dữ liệu MySQL
        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();  // Mở kết nối
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                return null;
            }
        }

        // Hàm thực thi câu lệnh SELECT và trả về DataTable
        public static DataTable ExecuteSelectQuery(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = GetConnection())
            {
                if (conn != null)
                {
                    try
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                        da.Fill(dt);  // Điền dữ liệu vào DataTable
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi thực thi câu lệnh: " + ex.Message);
                    }
                }
            }

            return dt;
        }

        // Hàm thực thi câu lệnh INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query)
        {
            int result = 0;

            using (MySqlConnection conn = GetConnection())
            {
                if (conn != null)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        result = cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT, UPDATE, DELETE
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi thực thi câu lệnh: " + ex.Message);
                    }
                }
            }

            return result;

        }
    }
}