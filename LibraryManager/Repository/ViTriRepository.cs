using LibraryManager.ConnectDatabase;
using LibraryManager.Model;
using LibraryManager.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LibraryManager.Repository
{
    public class ViTriRepository
    {
        public List<ViTriModel> GetAllViTri()
        {
            List<ViTriModel> list = new List<ViTriModel>();
            string query = "SELECT MaViTri, TenViTri FROM vitri";

            using (var conn = DatabaseConnection.GetConnection())
            {
                if (conn != null)
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ViTriModel
                            {
                                MaViTri = reader.GetInt32("MaViTri"),
                                TenViTri = reader.GetString("TenViTri")
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int GetIdByName(string tenViTri)
        {
            var list = GetAllViTri();
            var item = list.Find(x => x.TenViTri.Equals(tenViTri, StringComparison.OrdinalIgnoreCase));
            return item?.MaViTri ?? 0;
        }
    }
}