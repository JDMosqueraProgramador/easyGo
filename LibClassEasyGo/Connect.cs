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

        private static readonly string host = "easygo.postgres.database.azure.com";
        private static readonly string user = "alexadmin@easygo";
        private static readonly string dbname = "Easygo";
        private static readonly string password = "12345solobmx.";
        private static readonly string port = "5432";

        public NpgsqlConnection connection;

        public Connect()
        {
            string connectString = $"Server={host};Username={user};Database={dbname};Port={port};Password={password};SSL Mode=Require;Trust Server Certificate=true";

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
