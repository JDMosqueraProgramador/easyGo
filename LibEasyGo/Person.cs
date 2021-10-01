using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibEasyGo
{
    abstract class Person
    {
        private int id;
        private string names;
        private string last_names;
        private int phone;
        private string email;
        private string create_ad;
        private string dateAge;
        private string gender;
        private string city;

        public int ID { get => id; set => id = value; }
        public string Names { get => names; set => names = value; }
        public string Last_names { get => last_names; set => last_names = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Create_ad { get => create_ad; set => create_ad = value; }
        public string DateAge { get => dateAge; set => dateAge = value; }
        public string Gender { get => gender; set => gender = value; }
        public string City { get => city; set => city = value; }

    }
}
