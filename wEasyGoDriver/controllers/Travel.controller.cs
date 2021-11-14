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
            travelModel = new TravelModel();
        }

        public TravelController(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, string strRouteTravel, string strStateTravel, IUser customer, IMotorcycle moto)
        {
            travelModel = new TravelModel(strStartingPlaceTravel, strDestinationPlaceTravel, intTotalPriceTravel, numKMPriceTravel, dateRequestTravel, strRouteTravel, strStateTravel, customer, moto);
        }

        public bool ExecuteCreateTravel()
        {
            travelModel.IntIdTravel = this.travelModel.InsertTravel();
            if(travelModel.IntIdTravel > 0)
            {
                return true;
            } else
            {
                travelModel.IntIdTravel = 0;
                return false;
            }
        }

        public bool StartTravel()
        {
            this.travelModel.DateStartTravel = DateTime.Now;
            this.travelModel.StrStateTravel = "traveling";
            return this.travelModel.UpdateTravel();
        }

        public bool FinishTravel()
        {
            this.travelModel.DateFinishTravel = DateTime.Now;
            this.travelModel.StrStateTravel = "finalized";
            return this.travelModel.UpdateTravel();
        }

        public bool ExecuteCancelTravel()
        {
            return this.travelModel.CancelTravel();
        }

        public static int CalculePriceTravel(int distance)
        {
            return 3000 + (int)(distance * 0.500);
        }

        public ITravel GetTravel()
        {
            return travelModel;
        }

    }
}
