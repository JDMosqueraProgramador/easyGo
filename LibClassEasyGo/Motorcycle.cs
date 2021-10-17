using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClassEasyGo
{
    public class Motorcycle
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
        private User owner;
        private User driver;

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
        public User Owner { get => owner; set => owner = value; }
        public User Driver { get => driver; set => driver = value; }
        public string StrColorMoto { get => strColorMoto; set => strColorMoto = value; }

        public Motorcycle()
        {

        }

        public Motorcycle(string strLicensePlateMoto, int intNumSerieMoto, int intNumChasisMoto, int intVimMoto, string strStateMoto, int intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, User owner, User driver, string strColorMoto)
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
    }
}
