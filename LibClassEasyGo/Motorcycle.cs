using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LibClassEasyGo
{

    public interface IMotorcycle
    {
        string StrLicensePlateMoto { get; set; }
        int IntNumSerieMoto { get; set; }
        int IntNumChasisMoto { get; set; }
        int IntVimMoto { get; set; }
        string StrStateMoto { get; set; }
        int IntNumLicenseMoto { get; set; }
        string StrMarkMoto { get; set; }
        int IntCylinderMoto { get; set; }
        string StrModelMoto { get; set; }
        string StrFuelTypeMoto { get; set; }
        string StrLinkPropertyCard { get; set; }
        IUser Owner { get; set; }
        IUser Driver { get; set; }
        string StrColorMoto { get; set; }
    }

    public class Motorcycle : IMotorcycle
    {
        private string strLicensePlateMoto;
        private int intNumSerieMoto;
        private int intNumChasisMoto;
        private int intVimMoto;
        private string strStateMoto;
        private int intNumLicenseMoto;
        private string strMarkMoto;
        private int intCylinderMoto;
        private string strModelMoto;
        private string strFuelTypeMoto;
        private string strLinkPropertyCard;
        private IUser owner;
        private IUser driver;
        private string strColorMoto;

        public string StrLicensePlateMoto { get => strLicensePlateMoto; set => strLicensePlateMoto = value; }
        public int IntNumSerieMoto { get => intNumSerieMoto; set => intNumSerieMoto = value; }
        public int IntNumChasisMoto { get => intNumChasisMoto; set => intNumChasisMoto = value; }
        public int IntVimMoto { get => intVimMoto; set => intVimMoto = value; }
        public string StrStateMoto { get => strStateMoto; set => strStateMoto = value; }
        public int IntNumLicenseMoto { get => intNumLicenseMoto; set => intNumLicenseMoto = value; }
        public string StrMarkMoto { get => strMarkMoto; set => strMarkMoto = value; }
        public int IntCylinderMoto { get => intCylinderMoto; set => intCylinderMoto = value; }
        public string StrModelMoto { get => strModelMoto; set => strModelMoto = value; }
        public string StrFuelTypeMoto { get => strFuelTypeMoto; set => strFuelTypeMoto = value; }
        public string StrLinkPropertyCard { get => strLinkPropertyCard; set => strLinkPropertyCard = value; }
        public IUser Owner { get => owner; set => owner = value; }
        public IUser Driver { get => driver; set => driver = value; }
        public string StrColorMoto { get => strColorMoto; set => strColorMoto = value; }


        private NpgsqlConnection conn = new Connect().Conn();
        public Motorcycle()
        {

        }

        public Motorcycle(string strLicensePlateMoto, int intNumSerieMoto, int intNumChasisMoto, int intVimMoto, string strStateMoto, int intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, IUser owner, IUser driver, string strColorMoto)
        {
            StrLicensePlateMoto = strLicensePlateMoto;
            IntNumSerieMoto = intNumSerieMoto;
            IntNumChasisMoto = intNumChasisMoto;
            IntVimMoto = intVimMoto;
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
                    IUser user = new User(Convert.ToInt32(data[14]), data[15].ToString(), data[16].ToString(), Convert.ToDateTime(data[17]), Convert.ToBoolean(data[18]), data[19].ToString(), Convert.ToInt32(data[20]), Convert.ToInt64(data[21]), data[22].ToString(), Convert.ToDateTime(data[23]), data[24].ToString(), Convert.ToInt32(data[25]));
                    
                    moto = new Motorcycle(data[0].ToString(), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), data[4].ToString(), Convert.ToInt32(data[5]), data[6].ToString(), Convert.ToInt32(data[7]), data[8].ToString(), data[9].ToString(), data[10].ToString(), user, user, data[13].ToString());

                }
            }

            return moto;
            
        }
    }
}
