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

    }
}
