using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using Npgsql;

namespace wEasyGoAdmin.Model
{
    internal class MotorcycleModel : Motorcycle
    {
        public MotorcycleModel()
        {
        }

        public MotorcycleModel(string strLicensePlateMoto, string strStateMoto, long intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, IUser owner, IUser driver, string strColorMoto) : base(strLicensePlateMoto, strStateMoto, intNumLicenseMoto, strMarkMoto, intCylinderMoto, strModelMoto, strFuelTypeMoto, strLinkPropertyCard, owner, driver, strColorMoto)
        {
        }

        public Papers SelectPapers(string licensePlate)
        {

            Papers papers = null;

            string select = "SELECT * FROM sp_get_papers(@licenseplate)";
            NpgsqlCommand cmd = new NpgsqlCommand(select, this.conn);

            cmd.Parameters.AddWithValue("@licenseplate", licensePlate);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    papers = new Papers((DateTime)data[0], data[1].ToString(), (int)data[2], (DateTime)data[3], data[4].ToString(), (DateTime)data[5], (string)data[6], (string)data[7]);
                }
            }

            return papers;


        }

    }
}
