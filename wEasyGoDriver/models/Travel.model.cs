using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using Npgsql;

namespace wEasyGoDriver.models
{
    class TravelModel : Travel
    {

        public TravelModel()
        {

        }

        public TravelModel(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, IUser customer) : base(strStartingPlaceTravel, strDestinationPlaceTravel, intTotalPriceTravel, numKMPriceTravel, dateRequestTravel, customer)
        {
        }

        public TravelModel(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, IUser customer, IMotorcycle moto) : base(strStartingPlaceTravel, strDestinationPlaceTravel, intTotalPriceTravel, numKMPriceTravel, dateRequestTravel, customer, moto)
        {
        }

        public bool InsertTravel()
        {
            string insert = "CALL sp_register_trip(@strStartingPlaceTravel,@strDestinationPlaceTravel,@intTotalPriceTravel,@numKMPriceTravel,@dateStartTravel,@dateRequestTravel,@strRuteTravel,@strStateTravel,@intIdPaymentMethod,@intIdCustomer,@strLicensePlateMoto)";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, this.conn);

            cmd.Parameters.AddWithValue("@strStartingPlaceTravel", StrStartingPlaceTravel);
            cmd.Parameters.AddWithValue("@strDestinationPlaceTravel", StrDestinationPlaceTravel);
            cmd.Parameters.AddWithValue("@intTotalPriceTravel", IntTotalPriceTravel);
            cmd.Parameters.AddWithValue("@numKMPriceTravel", NumKMPriceTravel);
            cmd.Parameters.AddWithValue("@dateStartTravel", DateStartTravel);
            cmd.Parameters.AddWithValue("@dateRequestTravel", DateRequestTravel);
            cmd.Parameters.AddWithValue("@strRuteTravel", StrRuteTravel);
            cmd.Parameters.AddWithValue("@strStateTravel", StrStateTravel);
            cmd.Parameters.AddWithValue("@intIdPaymentMethod",PaymentMethod);
            cmd.Parameters.AddWithValue("@intIdCustomer", Customer.IntIdUser);
            cmd.Parameters.AddWithValue("@strLicensePlateMoto", Moto.StrLicensePlateMoto);

            cmd.ExecuteNonQuery();

            return true;
        }

    }
}
