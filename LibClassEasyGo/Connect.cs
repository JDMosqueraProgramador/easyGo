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

        private static readonly string host = "ec2-54-208-104-27.compute-1.amazonaws.com";
        private static readonly string user = "qbrayutdtstfye";
        private static readonly string dbname = "d4jjomqb2tmlrh";
        private static readonly string password = "0e0e2e832c95c651bacc28a3d3274f89515dd766516ade44715fe30061957430";
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
