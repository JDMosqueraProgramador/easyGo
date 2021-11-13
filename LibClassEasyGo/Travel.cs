using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LibClassEasyGo
{
    public class Travel : ITravel
    {

        protected NpgsqlConnection conn;

        private int intIdTravel;
        private string strStartingPlaceTravel;
        private string strDestinationPlaceTravel;
        private int intTotalPriceTravel;
        private int numKMPriceTravel;
        private DateTime dateStartTravel;
        private DateTime dateFinishTravel;
        private DateTime dateRequestTravel;
        private string strRuteTravel;
        private int intCalificationTravel;
        private string strStateTravel;
        private string strCommentaryTravel;
        private string paymentMethod;
        private IUser customer;
        private IMotorcycle moto;

        public int IntIdTravel { get => intIdTravel; set => intIdTravel = value; }
        public string StrStartingPlaceTravel { get => strStartingPlaceTravel; set => strStartingPlaceTravel = value; }
        public string StrDestinationPlaceTravel { get => strDestinationPlaceTravel; set => strDestinationPlaceTravel = value; }
        public int IntTotalPriceTravel { get => intTotalPriceTravel; set => intTotalPriceTravel = value; }
        public int NumKMPriceTravel { get => numKMPriceTravel; set => numKMPriceTravel = value; }
        public DateTime DateStartTravel { get => dateStartTravel; set => dateStartTravel = value; }
        public DateTime DateFinishTravel { get => dateFinishTravel; set => dateFinishTravel = value; }
        public DateTime DateRequestTravel { get => dateRequestTravel; set => dateRequestTravel = value; }
        public string StrRuteTravel { get => strRuteTravel; set => strRuteTravel = value; }
        public int IntCalificationTravel { get => intCalificationTravel; set => intCalificationTravel = value; }
        public string StrStateTravel { get => strStateTravel; set => strStateTravel = value; }
        public string StrCommentaryTravel { get => strCommentaryTravel; set => strCommentaryTravel = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public IUser Customer { get => customer; set => customer = value; }
        public IMotorcycle Moto { get => moto; set => moto = value; }

        public Travel()
        {

        }

        public Travel(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, IUser customer)
        {
            StrStartingPlaceTravel = strStartingPlaceTravel;
            StrDestinationPlaceTravel = strDestinationPlaceTravel;
            IntTotalPriceTravel = intTotalPriceTravel;
            NumKMPriceTravel = numKMPriceTravel;
            DateRequestTravel = dateRequestTravel;
            Customer = customer;
        }

        
        public Travel(string strStartingPlaceTravel, string strDestinationPlaceTravel, int intTotalPriceTravel, int numKMPriceTravel, DateTime dateRequestTravel, IUser customer, IMotorcycle moto)
        {
            StrStartingPlaceTravel = strStartingPlaceTravel;
            StrDestinationPlaceTravel = strDestinationPlaceTravel;
            IntTotalPriceTravel = intTotalPriceTravel;
            NumKMPriceTravel = numKMPriceTravel;
            DateRequestTravel = dateRequestTravel;
            Customer = customer;
            Moto = moto;
        }
    }
}
