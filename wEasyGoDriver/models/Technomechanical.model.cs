using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LibClassEasyGo;

namespace wEasyGoDriver.models
{
    class TechnomechanicalModel : Connect
    {
        private int intIdTechnomechanical;
        private DateTime dateValidUntilTechnomechanical;
        private bool boolValidTechnomechanical;
        private string strURLTechnomechanical;
        private string strLicensePlateMoto;

        public int IntIdTechnomechanical { get => intIdTechnomechanical; set => intIdTechnomechanical = value; }
        public DateTime DateValidUntilTechnomechanical { get => dateValidUntilTechnomechanical; set => dateValidUntilTechnomechanical = value; }
        public bool BoolValidTechnomechanical { get => boolValidTechnomechanical; set => boolValidTechnomechanical = value; }
        public string StrURLTechnomechanical { get => strURLTechnomechanical; set => strURLTechnomechanical = value; }
        public string StrLicensePlateMoto { get => strLicensePlateMoto; set => strLicensePlateMoto = value; }

        public TechnomechanicalModel(DateTime dateValidUntilTechnomechanical, bool boolValidTechnomechanical, string strURLTechnomechanical, string strLicensePlateMoto)
        {
            DateValidUntilTechnomechanical = dateValidUntilTechnomechanical;
            BoolValidTechnomechanical = boolValidTechnomechanical;
            StrURLTechnomechanical = strURLTechnomechanical;
            StrLicensePlateMoto = strLicensePlateMoto;
        }

        public bool InsertTechnomechanical()
        {
            string insert = "INSERT INTO tblTechnomechanical (dateValidUntilTechnomechanical, boolValidTechnomechanical, strURLTechnomechanical, strLicensePlateMoto) VALUES (@dateValidUntilTechnomechanical, @boolValidTechnomechanical, @strURLTechnomechanical, @strLicensePlateMoto)";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, Conn());

            cmd.Parameters.AddWithValue("@dateValidUntilTechnomechanical", this.DateValidUntilTechnomechanical);
            cmd.Parameters.AddWithValue("@boolValidTechnomechanical", this.BoolValidTechnomechanical);
            cmd.Parameters.AddWithValue("@strURLTechnomechanical", this.StrURLTechnomechanical);
            cmd.Parameters.AddWithValue("@strLicensePlateMoto", this.StrLicensePlateMoto);

            return (cmd.ExecuteNonQuery() == 1) ? true : false;
        }

    }
}
