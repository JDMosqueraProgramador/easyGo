using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wEasyGoAdmin.Model;
using LibClassEasyGo;

namespace wEasyGoAdmin.Controller
{
    internal class MotorcycleController
    {
        MotorcycleModel motoModel;

        public static IMotorcycle GetMoto(int idUser)
        {
            return new MotorcycleModel().SelectMoto(idUser);
        }

        public static Papers GetPapers(string licensePlate)
        {
            return new MotorcycleModel().SelectPapers(licensePlate);
        }

    }
}
