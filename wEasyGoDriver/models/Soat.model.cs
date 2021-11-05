using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LibClassEasyGo;
namespace wEasyGoDriver.models
{
    class SoatModel : Connect
    {
        private int intIdSoat;
        private DateTime dateValidUntilSoat;
        private string strURLSoat;
        private bool boolValidSoat;
        private string strLicensePlateMoto;

        public int IntIdSoat { get => intIdSoat; set => intIdSoat = value; }
        public DateTime DateValidUntilSoat { get => dateValidUntilSoat; set => dateValidUntilSoat = value; }
        public string StrURLSoat { get => strURLSoat; set => strURLSoat = value; }
        public bool BoolValidSoat { get => boolValidSoat; set => boolValidSoat = value; }
        public string StrLicensePlateMoto { get => strLicensePlateMoto; set => strLicensePlateMoto = value; }

        public SoatModel(int intIdSoat, DateTime dateValidUntilSoat, string strURLSoat, bool boolValidSoat, string strLicensePlateMoto)
        {
            IntIdSoat = intIdSoat;
            DateValidUntilSoat = dateValidUntilSoat;
            StrURLSoat = strURLSoat;
            BoolValidSoat = boolValidSoat;
            StrLicensePlateMoto = strLicensePlateMoto;
        }

        public bool InsertSoat()
        {
            string insert = "INSERT INTO tblsoat VALUES(@intIdSoat, @dateValidUntilSoat, @strURLSoat, @boolValidSoat, @strLicensePlateMoto)";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, Conn());

            cmd.Parameters.AddWithValue("@intIdSoat", this.IntIdSoat);
            cmd.Parameters.AddWithValue("@dateValidUntilSoat", this.DateValidUntilSoat);
            cmd.Parameters.AddWithValue("@strURLSoat", this.StrURLSoat);
            cmd.Parameters.AddWithValue("@boolValidSoat", this.BoolValidSoat);
            cmd.Parameters.AddWithValue("@strLicensePlateMoto", this.StrLicensePlateMoto);

            return (cmd.ExecuteNonQuery() == 1) ? true : false;

        }
    }
}
