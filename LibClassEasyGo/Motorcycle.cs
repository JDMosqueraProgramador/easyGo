using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LibClassEasyGo
{

    public class Motorcycle : IMotorcycle
    {
        private string strLicensePlateMoto;
        private string strStateMoto;
        private long intNumLicenseMoto;
        private string strMarkMoto;
        private int intCylinderMoto;
        private string strModelMoto;
        private string strFuelTypeMoto;
        private string strLinkPropertyCard;
        private IUser owner;
        private IUser driver;
        private string strColorMoto;

        public string StrLicensePlateMoto { get => strLicensePlateMoto; set => strLicensePlateMoto = value; }
        public string StrStateMoto { get => strStateMoto; set => strStateMoto = value; }
        public long IntNumLicenseMoto { get => intNumLicenseMoto; set => intNumLicenseMoto = value; }
        public string StrMarkMoto { get => strMarkMoto; set => strMarkMoto = value; }
        public int IntCylinderMoto { get => intCylinderMoto; set => intCylinderMoto = value; }
        public string StrModelMoto { get => strModelMoto; set => strModelMoto = value; }
        public string StrFuelTypeMoto { get => strFuelTypeMoto; set => strFuelTypeMoto = value; }
        public string StrLinkPropertyCard { get => strLinkPropertyCard; set => strLinkPropertyCard = value; }
        public IUser Owner { get => owner; set => owner = value; }
        public IUser Driver { get => driver; set => driver = value; }
        public string StrColorMoto { get => strColorMoto; set => strColorMoto = value; }


        protected NpgsqlConnection conn = new Connect().Conn();
        public Motorcycle()
        {

        }

        public Motorcycle(string strLicensePlateMoto, string strStateMoto, long intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, IUser owner, IUser driver, string strColorMoto)
        {
            StrLicensePlateMoto = strLicensePlateMoto;
            StrStateMoto = strStateMoto;
            IntNumLicenseMoto = intNumLicenseMoto;
            StrMarkMoto = strMarkMoto;
            IntCylinderMoto = intCylinderMoto;
            StrModelMoto = strModelMoto;
            StrFuelTypeMoto = strFuelTypeMoto;
            StrLinkPropertyCard = strLinkPropertyCard;
            Owner = owner;
            Driver = driver;
            StrColorMoto = strColorMoto;
        }

        public IMotorcycle SelectMoto(int idUser)
        {
            IMotorcycle moto = null;

            string select = "SELECT * FROM moto WHERE intiduser = @idUser";
            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if(data.HasRows)
            {
                while (data.Read())
                {
                    IUser user = new User(Convert.ToInt32(data[11]), data[12].ToString(), data[13].ToString(), Convert.ToDateTime(data[14]), Convert.ToBoolean(data[15]), data[16].ToString(), Convert.ToInt32(data[17]), Convert.ToInt64(data[18]), data[19].ToString(), Convert.ToDateTime(data[20]), data[21].ToString(), Convert.ToInt32(data[22]));
                    
                    moto = new Motorcycle(data[0].ToString(), data[1].ToString(), Convert.ToInt64(data[2]), data[3].ToString(), Convert.ToInt32(data[4]), data[5].ToString(), data[6].ToString(), data[7].ToString(), user, user, data[10].ToString());

                }
            }

            data.Close();

            return moto;
            
        }
    }
}
