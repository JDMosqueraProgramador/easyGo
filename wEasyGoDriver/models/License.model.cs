using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using Npgsql;


namespace wEasyGoDriver.models
{
    class LicenseModel : Connect
    {
        private int intNumLicense;
        private DateTime dateValidityLicense;
        private int intIdDriver;
        private bool boolValidLicense;
        private string strImageLicense;

        public int IntNumLicense { get => intNumLicense; set => intNumLicense = value; }
        public DateTime DateValidityLicense { get => dateValidityLicense; set => dateValidityLicense = value; }
        public int IntIdDriver { get => intIdDriver; set => intIdDriver = value; }
        public bool BoolValidLicense { get => boolValidLicense; set => boolValidLicense = value; }
        public string StrImageLicense { get => strImageLicense; set => strImageLicense = value; }

        public LicenseModel(int intNumLicense, DateTime dateValidityLicense, int intIdDriver, bool boolValidLicense, string strImageLicense)
        {
            IntNumLicense = intNumLicense;
            DateValidityLicense = dateValidityLicense;
            IntIdDriver = intIdDriver;
            BoolValidLicense = boolValidLicense;
            StrImageLicense = strImageLicense;
        }

        public bool insertLicense()
        {
            string insert = "INSERT INTO tblLicense VALUES(@intNumLicense, @dateValidityLicense, @intIdDriver, @boolValidLicense, @strImageLicense)";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, Conn());

            cmd.Parameters.AddWithValue("@intNumLicense", this.IntNumLicense);
            cmd.Parameters.AddWithValue("@dateValidityLicense", this.DateValidityLicense);
            cmd.Parameters.AddWithValue("@intIdDriver", this.IntIdDriver);
            cmd.Parameters.AddWithValue("@boolValidLicense", this.BoolValidLicense);
            cmd.Parameters.AddWithValue("@strImageLicense", this.StrImageLicense);

            return (cmd.ExecuteNonQuery() == 1) ? true : false;
           
        }

    }
}
