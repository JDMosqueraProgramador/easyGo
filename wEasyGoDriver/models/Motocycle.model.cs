using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using Npgsql;
namespace wEasyGoDriver.models
{
    class MotorcycleModel : Motorcycle
    {
        public MotorcycleModel()
        {
        }

        private NpgsqlConnection conn = new Connect().Conn();

        public MotorcycleModel(string strLicensePlateMoto, int intNumSerieMoto, int intNumChasisMoto, int intVimMoto, string strStateMoto, int intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, User owner, User driver, string strColorMoto) : base(strLicensePlateMoto, intNumSerieMoto, intNumChasisMoto, intVimMoto, strStateMoto, intNumLicenseMoto, strMarkMoto, intCylinderMoto, strModelMoto, strFuelTypeMoto, strLinkPropertyCard, owner, driver, strColorMoto)
        {
        }

        public bool InsertMotorcycle()
        {
            string insert = "CALL sp_insert_moto(@strLicensePlateMoto, @intNumSerieMoto, @intNumChasisMoto, @intVimMoto, @strStateMoto, @intNumLicenseMoto, @strMarkMoto, @intCylinderMoto, @strModelMoto, @strFuelTypeMoto, @strLinkPropertyCard, @intIdOwner, @intIdDriver, @strColorMoto)";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, conn);

            cmd.Parameters.AddWithValue("@strLicensePlateMoto", StrLicensePlateMoto);
            cmd.Parameters.AddWithValue("@intNumSerieMoto", IntNumSerieMoto);
            cmd.Parameters.AddWithValue("@intNumChasisMoto", IntNumChasisMoto);
            cmd.Parameters.AddWithValue("@intVimMoto", IntVimMoto);
            cmd.Parameters.AddWithValue("@strStateMoto", StrStateMoto);
            cmd.Parameters.AddWithValue("@intNumLicenseMoto", IntNumLicenseMoto);
            cmd.Parameters.AddWithValue("@strMarkMoto", StrMarkMoto);
            cmd.Parameters.AddWithValue("@intCylinderMoto", IntCylinderMoto);
            cmd.Parameters.AddWithValue("@strModelMoto", StrModelMoto);
            cmd.Parameters.AddWithValue("@strFuelTypeMoto", StrFuelTypeMoto);
            cmd.Parameters.AddWithValue("@strLinkPropertyCard", StrLinkPropertyCard);
            cmd.Parameters.AddWithValue("@intIdOwner", Owner.IntIdUser);
            cmd.Parameters.AddWithValue("@intIdDriver", Driver.IntIdUser);
            cmd.Parameters.AddWithValue("@strColorMoto", StrColorMoto);

            cmd.ExecuteNonQuery();

            return true;
        }


        public bool ChangeState(string state, string licensePlate)
        {
            string update = "CALL sp_set_motorcycle_state(@state, @licensePlate)";

            NpgsqlCommand cmd = new NpgsqlCommand(update, conn);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@licensePlate", licensePlate);

            int res = cmd.ExecuteNonQuery();

            return true;

        }
    }
}
