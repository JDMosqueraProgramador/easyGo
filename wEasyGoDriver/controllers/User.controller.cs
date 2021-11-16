using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime;
using System.Drawing.Printing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using LibClassEasyGo;
using wEasyGoDriver.models;
using System.Data;


namespace wEasyGoDriver.controllers
{
    
    class UserController
    {

        private User user;
        private static UserModel model = new UserModel();

        public UserController(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, long intPhoneUser, string strEmailUser, string strRolUser)
        {
            user = new UserModel(intIdCardPerson, strNamePerson, strLastNamePerson, dateOfBirthPerson, boolGenderPerson, intPhoneUser, strEmailUser, strRolUser);
        }

        public UserController(long intPhoneUser)
        {
            user = model.GetUserBy(intPhoneUser);
        }

        public UserController()
        {

        }

        public int ExecuteSetUser(string password, int idCity)
        {
            return user.CreateUser(password, idCity);
        }

        public bool ExecuteLogin(long phone, string password)
        {
            return model.login(phone, password,"Driver");
        }

        public IUser getDataUser()
        {
            return user;
        }

        public DataTable ExecuteSearchUser(string name)
        {
            return model.SearchDriver(name);
        }

        public DataTable GetDriverHistory(string licensePlate)
        {
            return model.DriverHistory(licensePlate);
        }

        // ------------------------------------
        // ------------------------------------
        // ------------------------------------

    }

}
