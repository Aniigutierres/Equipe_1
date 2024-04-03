using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api.Repository
{
    public class MySqlConnectionFactory
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;port=3306;Database=bd_eventos_senailp;Uid=root;Pwd=senai2024;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}