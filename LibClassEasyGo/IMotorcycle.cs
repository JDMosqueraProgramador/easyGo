using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClassEasyGo
{
    public interface IMotorcycle
    {
        string StrLicensePlateMoto { get; set; }
        string StrStateMoto { get; set; }
        long IntNumLicenseMoto { get; set; }
        string StrMarkMoto { get; set; }
        int IntCylinderMoto { get; set; }
        string StrModelMoto { get; set; }
        string StrFuelTypeMoto { get; set; }
        string StrLinkPropertyCard { get; set; }
        IUser Owner { get; set; }
        IUser Driver { get; set; }
        string StrColorMoto { get; set; }
    }
}
