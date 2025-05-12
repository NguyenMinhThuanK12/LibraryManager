using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.DAO
{
    using MySql.Data.MySqlClient;
    using LibraryManager.ConnectDatabase;
    using LibraryManager.DTO;
    using System;

    public class CheckInDAO
    {
        public void InsertCheckIn(int maThanhVien)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = "INSERT INTO checkin (maThanhVien, thoiGianVao) VALUES (@maTV, NOW())";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@maTV", maThanhVien);
            cmd.ExecuteNonQuery();
        }
    }

}
