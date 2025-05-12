using LibraryManager.ConnectDatabase;
using LibraryManager.Model;
using LibraryManager.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LibraryManager.Repository
{
    public class TangRepository
    {
        public List<TangModel> GetAllTang()
        {
            List<TangModel> list = new List<TangModel>();
            string query = "SELECT MaTang, TenTang FROM tang";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TangModel
                            {
                                MaTang = reader.GetInt32("MaTang"),
                                TenTang = reader.GetString("TenTang")
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int GetIdByName(string tenTang)
        {
            var list = GetAllTang();
            var item = list.Find(x => x.TenTang.Equals(tenTang, StringComparison.OrdinalIgnoreCase));
            return item?.MaTang ?? 0;
        }
    }
}