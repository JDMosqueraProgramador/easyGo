using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibEasyGo
{
    abstract class User
    {
        // Information to person
        private int intIdCardPerson;
        private string strNamePerson;
        private string strLastNamePerson;
        private DateTime dateOfBirthPerson;
        private string boolGenderPerson;
        private string city;

        // Information to user
        private int intIdUser;
        private int intPhoneUser;
        private string strEmailUser;
        private string dateCreateAd;
        private string strRolUser;
        private int intIdPerson;

        public int IntIdCardPerson { get => intIdCardPerson; set => intIdCardPerson = value; }
        public string StrNamePerson { get => strNamePerson; set => strNamePerson = value; }
        public string StrLastNamePerson { get => strLastNamePerson; set => strLastNamePerson = value; }
        public DateTime DateOfBirthPerson { get => dateOfBirthPerson; set => dateOfBirthPerson = value; }
        public string BoolGenderPerson { get => boolGenderPerson; set => boolGenderPerson = value; }
        public string City { get => city; set => city = value; }
        public int IntIdUser { get => intIdUser; set => intIdUser = value; }
        public int IntPhoneUser { get => intPhoneUser; set => intPhoneUser = value; }
        public string StrEmailUser { get => strEmailUser; set => strEmailUser = value; }
        public string DateCreateAd { get => dateCreateAd; set => dateCreateAd = value; }
        public string StrRolUser { get => strRolUser; set => strRolUser = value; }
        public int IntIdPerson { get => intIdPerson; set => intIdPerson = value; }

        protected User(int intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, string boolGenderPerson, string city, int intIdUser, int intPhoneUser, string strEmailUser, string dateCreateAd, string strRolUser, int intIdPerson)
        {
            IntIdCardPerson = intIdCardPerson;
            StrNamePerson = strNamePerson;
            StrLastNamePerson = strLastNamePerson;
            DateOfBirthPerson = dateOfBirthPerson;
            BoolGenderPerson = boolGenderPerson;
            City = city;
            IntIdUser = intIdUser;
            IntPhoneUser = intPhoneUser;
            StrEmailUser = strEmailUser;
            DateCreateAd = dateCreateAd;
            StrRolUser = strRolUser;
            IntIdPerson = intIdPerson;
        }
    }
}
