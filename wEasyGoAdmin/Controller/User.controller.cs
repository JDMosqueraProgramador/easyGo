using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using wEasyGoAdmin.Model;

namespace wEasyGoAdmin.Controller
{
    class UserController
    {

        private IUser user;
        private UserModel userModel;
        private static UserModel model = new UserModel();


        public UserController(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, long intPhoneUser, string strEmailUser)
        {
            userModel = new UserModel(intIdCardPerson, strNamePerson, strLastNamePerson, dateOfBirthPerson, boolGenderPerson, intPhoneUser, strEmailUser, "Admin");
        }

        public UserController(long phone)
        {
            userModel = new UserModel();
            user = userModel.GetUserBy(phone);
        }

        public UserController(int id)
        {
            userModel = new UserModel();
            user = userModel.GetUserBy(id);
        }

        public UserController()
        {
            userModel = new UserModel();
        }

        public bool ExecuteLogin(long phone, string password)
        {
            return userModel.login(phone, password, "Admin");
        }

        public DataTable ExecuteSearchUser(string name)
        {
            return model.SearchDriver(name);
        }
    }
}
