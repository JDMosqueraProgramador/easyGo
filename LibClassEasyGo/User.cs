using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LibClassEasyGo
{
    abstract public class User
    {
        // Information to person
        private long intIdCardPerson;
        private string strNamePerson;
        private string strLastNamePerson;
        private DateTime dateOfBirthPerson;
        private string boolGenderPerson;
        private string city;

        // Information to user
        private int intIdUser;
        private long intPhoneUser;
        private string strEmailUser;
        private DateTime dateCreateAd;
        private string strRolUser;
        private int intIdPerson;

        public long IntIdCardPerson { get => intIdCardPerson; set => intIdCardPerson = value; }
        public string StrNamePerson { get => strNamePerson; set => strNamePerson = value; }
        public string StrLastNamePerson { get => strLastNamePerson; set => strLastNamePerson = value; }
        public DateTime DateOfBirthPerson { get => dateOfBirthPerson; set => dateOfBirthPerson = value; }
        public string BoolGenderPerson { get => boolGenderPerson; set => boolGenderPerson = value; }
        public string City { get => city; set => city = value; }
        public int IntIdUser { get => intIdUser; set => intIdUser = value; }
        public long IntPhoneUser { get => intPhoneUser; set => intPhoneUser = value; }
        public string StrEmailUser { get => strEmailUser; set => strEmailUser = value; }
        public DateTime DateCreateAd { get => dateCreateAd; set => dateCreateAd = value; }
        public string StrRolUser { get => strRolUser; set => strRolUser = value; }
        public int IntIdPerson { get => intIdPerson; set => intIdPerson = value; }

        public User()
        {

        }

        public User(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, string boolGenderPerson, int intIdUser, long intPhoneUser, string strEmailUser, string strRolUser)
        {
            IntIdCardPerson = intIdCardPerson;
            StrNamePerson = strNamePerson;
            StrLastNamePerson = strLastNamePerson;
            DateOfBirthPerson = dateOfBirthPerson;
            BoolGenderPerson = boolGenderPerson;
            IntIdUser = intIdUser;
            IntPhoneUser = intPhoneUser;
            StrEmailUser = strEmailUser;
            StrRolUser = strRolUser;
        }

        public User(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, string boolGenderPerson, string city, int intIdUser, long intPhoneUser, string strEmailUser, DateTime dateCreateAd, string strRolUser, int intIdPerson)
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


        //public abstract int CreateUser(string password, int idCity);

        // public abstract User getUserById();
        /* public abstract List<User> getUser(int id);
        public abstract List<User> getUser(long idCard); */

    }
}
