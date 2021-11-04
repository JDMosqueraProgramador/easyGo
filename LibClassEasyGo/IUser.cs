using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClassEasyGo
{
    public interface IUser
    {
        long IntIdCardPerson { get; set; }
        string StrNamePerson { get; set; }
        string StrLastNamePerson { get; set; }
        DateTime DateOfBirthPerson { get; set; }
        bool BoolGenderPerson { get; set; }
        string City { get; set; }
        int IntIdUser { get; set; }
        long IntPhoneUser { get; set; }
        string StrEmailUser { get; set; }
        DateTime DateCreateAd { get; set; }
        string StrRolUser { get; set; }
        int IntIdPerson { get; set; }
    }
}
