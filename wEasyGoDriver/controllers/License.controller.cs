using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wEasyGoDriver.models;

namespace wEasyGoDriver.controllers
{
    class LicenseController
    {
        LicenseModel license; 

        public LicenseController(int intNumLicense, DateTime dateValidityLicense, int intIdDriver, string strImageLicense)
        {
            int validateLicense = new DateTime().CompareTo(dateValidityLicense);
            bool boolValidLicense = (validateLicense == 1) ? true : false;

            license = new LicenseModel(intNumLicense, dateValidityLicense, intIdDriver, boolValidLicense, strImageLicense);
        }

        public LicenseController()
        {

        }

        public bool ExecuteInsertLicense()
        {
            return license.insertLicense();
        }
    }
}
