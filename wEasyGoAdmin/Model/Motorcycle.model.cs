using System;
using System.Collections.Generic;
using System.Data;
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
                    papers = new Papers((int)data[0], (DateTime)data[1], data[2].ToString(), (int)data[3], (DateTime)data[4], data[5].ToString(), (DateTime)data[6], (string)data[7], (string)data[8]);
                }
            }

            return papers;

        }

        public DataTable getDriversDisabled()
        {
            string select = "SELECT * FROM sp_get_drivers_disabled()";

            //NpgsqlCommand cmd = new NpgsqlCommand(select, this.conn);

            DataTable table = new DataTable();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(select, this.conn);
            //NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapter);

            adapter.Fill(table);
             
            return table;

        }

    }
}
