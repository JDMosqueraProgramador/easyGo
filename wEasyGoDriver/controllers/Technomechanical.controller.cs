using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wEasyGoDriver.models;

namespace wEasyGoDriver.controllers
{
    class TechnomechanicalController
    {
        private TechnomechanicalModel Technomechanical;

        public TechnomechanicalController(DateTime dateValidUntilTechnomechanical, string strURLTechnomechanical, string strLicensePlateMoto)
        {
            bool boolValidTechnomechanical = (new DateTime().CompareTo(dateValidUntilTechnomechanical) >= 0) ? true : false;
            Technomechanical = new TechnomechanicalModel(dateValidUntilTechnomechanical, boolValidTechnomechanical, strURLTechnomechanical, strLicensePlateMoto);
        }

        public bool ExecuteInsertTechnomechanical()
        {
            return Technomechanical.InsertTechnomechanical();
        }
    }
}
