using System.Configuration;
using MySql.Data.MySqlClient;

public class MySqlHelper
{
    public static MySqlConnection GetConnection()
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        return new MySqlConnection(connStr);
    }
}