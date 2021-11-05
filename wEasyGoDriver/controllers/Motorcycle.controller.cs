using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LibClassEasyGo;
using wEasyGoDriver.models;

namespace wEasyGoDriver.controllers
{
    class MotorcycleControlller
    {
        MotorcycleModel moto;

        public MotorcycleControlller(string strLicensePlateMoto, int intNumSerieMoto, int intNumChasisMoto, int intVimMoto, int intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, int owner, int driver, string strColorMoto)
        {
            string strStateMoto = "Default";

            UserModel ownerClass = new UserModel();
            ownerClass.IntIdUser = owner;
            UserModel driverClass = new UserModel();
            driverClass.IntIdUser = driver;

            moto = new MotorcycleModel(strLicensePlateMoto, intNumSerieMoto, intNumChasisMoto, intVimMoto, strStateMoto, intNumLicenseMoto, strMarkMoto, intCylinderMoto, strModelMoto, strFuelTypeMoto, strLinkPropertyCard, ownerClass, driverClass, strColorMoto);
        }

        public bool ExecuteInsertMoto()
        {
            return moto.InsertMotorcycle();
        }
    }
}
