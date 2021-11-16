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

        public MotorcycleControlller(string strLicensePlateMoto, long intNumLicenseMoto, string strMarkMoto, int intCylinderMoto, string strModelMoto, string strFuelTypeMoto, string strLinkPropertyCard, int owner, int driver, string strColorMoto)
        {
            string strStateMoto = "disabled";

            UserModel ownerClass = new UserModel();
            ownerClass.IntIdUser = owner;
            UserModel driverClass = new UserModel();
            driverClass.IntIdUser = driver;

            moto = new MotorcycleModel(strLicensePlateMoto, strStateMoto, intNumLicenseMoto, strMarkMoto, intCylinderMoto, strModelMoto, strFuelTypeMoto, strLinkPropertyCard, ownerClass, driverClass, strColorMoto);
        }

        public MotorcycleControlller()
        {
            moto = new MotorcycleModel();
        }


        public bool ExecuteInsertMoto()
        {
            return moto.InsertMotorcycle();
        }

        public IMotorcycle ExecuteGetMotorcycle(int idUser)
        {
            return moto.SelectMoto(idUser);
        }

        public bool ExecuteChangeState(string state, string licensePlate)
        {
            return this.moto.ChangeState(state, licensePlate);
        }

    }
}
