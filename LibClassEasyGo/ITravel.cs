using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClassEasyGo
{
    public interface ITravel
    {
        int IntIdTravel { get; set; }
        string StrStartingPlaceTravel { get; set; }
        string StrDestinationPlaceTravel { get; set; }
        int IntTotalPriceTravel { get; set; }
        int NumKMPriceTravel { get; set; }
        DateTime DateStartTravel { get; set; }
        DateTime DateFinishTravel { get; set; }
        DateTime DateRequestTravel { get; set; }
        string StrRuteTravel { get; set; }
        int IntCalificationTravel { get; set; }
        string StrStateTravel { get; set; }
        string StrCommentaryTravel { get; set; }
        string PaymentMethod { get; set; }
        IUser Customer { get; set; }
        IMotorcycle Moto { get; set; }

    }
}
