using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wEasyGoDriver.models;
namespace wEasyGoDriver.controllers
{
    class SoatController
    {
        private SoatModel soat;

        public SoatController(int intIdSoat, DateTime dateValidUntilSoat, string strURLSoat, string strLicensePlateMoto)
        {

            bool boolValidSoat = (new DateTime().CompareTo(dateValidUntilSoat) >= 0) ? true : false; 
            soat = new SoatModel(intIdSoat, dateValidUntilSoat, strURLSoat, boolValidSoat, strLicensePlateMoto);
        }

        public SoatController()
        {

        }

        public bool ExecuteinsertSoat()
        {
            return soat.InsertSoat();
        }
    }
}
