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

        public TravelModel(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, string strRuteTravel, string strStateTravel, IUser customer, IMotorcycle moto) : base(strStartingPlaceTravel, strDestinationPlaceTravel, intTotalPriceTravel, numKMPriceTravel, dateRequestTravel, strRuteTravel, strStateTravel, customer, moto)
        {
        }

        public int InsertTravel()
        {
            int id = -1;

            string insert = "select * from register_travel(@strStartingPlaceTravel, @strDestinationPlaceTravel, @intTotalPriceTravel, @numKMPriceTravel, @dateRequestTravel, @strRuteTravel, @strStateTravel, @intIdPaymentMethod, @intIdCustomer, @strLicensePlateMoto);";

            NpgsqlCommand cmd = new NpgsqlCommand(insert, this.conn);

            cmd.Parameters.AddWithValue("@strStartingPlaceTravel", NpgsqlTypes.NpgsqlDbType.Varchar, StrStartingPlaceTravel);
            cmd.Parameters.AddWithValue("@strDestinationPlaceTravel", NpgsqlTypes.NpgsqlDbType.Varchar, StrDestinationPlaceTravel);
            cmd.Parameters.AddWithValue("@intTotalPriceTravel", NpgsqlTypes.NpgsqlDbType.Integer, IntTotalPriceTravel);
            cmd.Parameters.AddWithValue("@numKMPriceTravel", NpgsqlTypes.NpgsqlDbType.Integer, NumKMPriceTravel);
            cmd.Parameters.AddWithValue("@dateRequestTravel", NpgsqlTypes.NpgsqlDbType.Date, DateRequestTravel);
            cmd.Parameters.AddWithValue("@strRuteTravel", NpgsqlTypes.NpgsqlDbType.Text, StrRuteTravel);
            cmd.Parameters.AddWithValue("@strStateTravel", NpgsqlTypes.NpgsqlDbType.Varchar, StrStateTravel);
            cmd.Parameters.AddWithValue("@intIdPaymentMethod", 1);
            cmd.Parameters.AddWithValue("@intIdCustomer", Customer.IntIdUser);
            cmd.Parameters.AddWithValue("@strLicensePlateMoto", NpgsqlTypes.NpgsqlDbType.Varchar, Moto.StrLicensePlateMoto);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    id = Convert.ToInt32(data[0]);
                }
            }

            data.Close();

            return id;
        }

        public bool UpdateTravel()
        {
            string update = "SELECT update_travel(@date, @state ,@idTravel)";

            NpgsqlCommand cmd = new NpgsqlCommand(update, this.conn);

            switch (this.StrStateTravel)
            {
                case "traveling":
                    cmd.Parameters.AddWithValue("@date", this.DateStartTravel);
                    break;

                case "finalized":
                    cmd.Parameters.AddWithValue("@date", this.DateFinishTravel);
                    break;
            }

            cmd.Parameters.AddWithValue("@state", this.StrStateTravel);
            cmd.Parameters.AddWithValue("@idTravel", this.IntIdTravel);

            cmd.ExecuteNonQuery();

            return true;

        }
    }
}
