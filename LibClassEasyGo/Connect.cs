using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql; 

namespace LibClassEasyGo
{
    public class Connect
    {

        private static readonly string host = "localhost";
        private static readonly string user = "postgres";
        private static readonly string dbname = "EasyGo";
        private static readonly string password = "0308";
        private static readonly string port = "5432";

        public NpgsqlConnection connection;

        public Connect()
        {
            string connectString = $"Server={host};Username={user};Database={dbname};Port={port};Password={password};SSLMode=Prefer";

            try
            {
                connection = new NpgsqlConnection(connectString);
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public NpgsqlConnection Conn()
        {
            connection.Open();
            return connection;
        }
    }
}
