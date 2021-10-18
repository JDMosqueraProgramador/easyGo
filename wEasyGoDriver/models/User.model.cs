using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;

namespace wEasyGoDriver.models
{
    class UserModel : User
    {

        public UserModel()
        {
        }

        public UserModel(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, long intPhoneUser, string strEmailUser, string strRolUser) : base(intIdCardPerson, strNamePerson, strLastNamePerson, dateOfBirthPerson, boolGenderPerson, intPhoneUser, strEmailUser, strRolUser)
        {
        }

        public UserModel(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, string city, int intIdUser, long intPhoneUser, string strEmailUser, DateTime dateCreateAd, string strRolUser, int intIdPerson) : base(intIdCardPerson, strNamePerson, strLastNamePerson, dateOfBirthPerson, boolGenderPerson, city, intIdUser, intPhoneUser, strEmailUser, dateCreateAd, strRolUser, intIdPerson)
        {
        }
    }
}
