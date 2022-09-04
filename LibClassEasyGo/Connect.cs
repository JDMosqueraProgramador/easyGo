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
        //----
        private static readonly string host = "ec2-54-159-175-38.compute-1.amazonaws.com";
        private static readonly string user = "ikjldkchmscihd";
        private static readonly string dbname = "degedi2n7nu60o";
        private static readonly string password = "530c77e05a644bcb42c332b3eeb7ba8acec2e16db37eff03cfdefb6f3efc34df";
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
