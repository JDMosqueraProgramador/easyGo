using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using wEasyGoDriver.models;
namespace wEasyGoDriver.controllers
{
    class TravelController
    {
         TravelModel travelModel;

        public TravelController()
        {

        }

        public TravelController(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, IUser customer, IMotorcycle moto)
        {
            travelModel = new TravelModel( strStartingPlaceTravel, strDestinationPlaceTravel, intTotalPriceTravel, numKMPriceTravel, dateRequestTravel, customer, moto);
        }

        public bool ExecuteCreateTravel()
        {
            return this.travelModel.InsertTravel();
        }

        public static int CalculePriceTravel(int distance)
        {
            return (distance * 200);
        }

    }
}
