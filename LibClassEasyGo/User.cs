using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LibClassEasyGo
{
    public class User : IUser
    {
        // Information to person
        private long intIdCardPerson;
        private string strNamePerson;
        private string strLastNamePerson;
        private DateTime dateOfBirthPerson;
        private bool boolGenderPerson;
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
        public bool BoolGenderPerson { get => boolGenderPerson; set => boolGenderPerson = value; }
        public string City { get => city; set => city = value; }
        public int IntIdUser { get => intIdUser; set => intIdUser = value; }
        public long IntPhoneUser { get => intPhoneUser; set => intPhoneUser = value; }
        public string StrEmailUser { get => strEmailUser; set => strEmailUser = value; }
        public DateTime DateCreateAd { get => dateCreateAd; set => dateCreateAd = value; }
        public string StrRolUser { get => strRolUser; set => strRolUser = value; }
        public int IntIdPerson { get => intIdPerson; set => intIdPerson = value; }

        protected NpgsqlConnection conn = new Connect().Conn();

        public User()
        {

        }

        public User(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, long intPhoneUser, string strEmailUser, string strRolUser)
        {
            IntIdCardPerson = intIdCardPerson;
            StrNamePerson = strNamePerson;
            StrLastNamePerson = strLastNamePerson;
            DateOfBirthPerson = dateOfBirthPerson;
            BoolGenderPerson = boolGenderPerson;
            IntPhoneUser = intPhoneUser;
            StrEmailUser = strEmailUser;
            StrRolUser = strRolUser;

        }

        public User(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, string city, int intIdUser, long intPhoneUser, string strEmailUser, DateTime dateCreateAd, string strRolUser, int intIdPerson)
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

        public int CreateUser(string password, int idCity)
        {
            string procedure = "SELECT * FROM set_user(@intIdCardPerson, @strNamePerson, @strLastNamePerson, @dateOfBirthPerson, @boolGenderPerson, @intIdCity, @intPhoneUser, @strEmailUser, @strPassword, @strRolUser)";
            NpgsqlCommand cmd = new NpgsqlCommand(procedure, conn);

            /* if(this.IntIdCardPerson == 0)
            {
                cmd.Parameters.AddWithValue("@intIdCardPerson", null);
            }
            else
            {
                cmd.Parameters.AddWithValue("@intIdCardPerson", NpgsqlTypes.NpgsqlDbType.Bigint, this.IntIdCardPerson);
            } */

            if(StrRolUser == "Customer")
            {
                cmd.Parameters.AddWithValue("@intIdCardPerson", null);
            } else
            {
                cmd.Parameters.AddWithValue("@intIdCardPerson", NpgsqlTypes.NpgsqlDbType.Bigint, this.IntIdCardPerson);
            }

            cmd.Parameters.AddWithValue("@strNamePerson", NpgsqlTypes.NpgsqlDbType.Varchar, this.StrNamePerson);
            cmd.Parameters.AddWithValue("@strLastNamePerson", NpgsqlTypes.NpgsqlDbType.Varchar, this.StrLastNamePerson);
            cmd.Parameters.AddWithValue("@dateOfBirthPerson", NpgsqlTypes.NpgsqlDbType.Date, this.DateOfBirthPerson);
            cmd.Parameters.AddWithValue("@boolGenderPerson", NpgsqlTypes.NpgsqlDbType.Boolean, this.BoolGenderPerson);
            cmd.Parameters.AddWithValue("@intIdCity", NpgsqlTypes.NpgsqlDbType.Integer, idCity);
            cmd.Parameters.AddWithValue("@intPhoneUser", NpgsqlTypes.NpgsqlDbType.Bigint, this.IntPhoneUser);
            cmd.Parameters.AddWithValue("@strEmailUser", NpgsqlTypes.NpgsqlDbType.Varchar, this.StrEmailUser);
            cmd.Parameters.AddWithValue("@strPassword", NpgsqlTypes.NpgsqlDbType.Varchar, password);
            cmd.Parameters.AddWithValue("@strRolUser", NpgsqlTypes.NpgsqlDbType.Varchar, this.StrRolUser);

            NpgsqlDataReader data = cmd.ExecuteReader();

            data.Read();

            return Convert.ToInt32(data["set_user"]);

        }

        public User GetUserBy(int idPerson)
        {
            User user = null;
            string select = "SELECT * FROM get_user(@intIdPerson)";
            dynamic value;

            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);

            cmd.Parameters.AddWithValue("@intIdPerson", NpgsqlTypes.NpgsqlDbType.Integer, idPerson);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    value = data[4];
                    user = new User((long)data[0], (string)data.GetString(1), data.GetString(2), (DateTime)data[3], (bool)data[4], data.GetString(5), (int)data[6], (long)data[7], data.GetString(8), (DateTime)data[9], data.GetString(10), (int)data[11]);
                }
            }

            return user;
        }

        public User GetUserBy(long phone)
        {
            User user = null;
            string select = "SELECT * FROM get_user(@intPhoneUser)";

            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);

            cmd.Parameters.AddWithValue("@intPhoneUser", NpgsqlTypes.NpgsqlDbType.Bigint, phone);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    user = new User(0, (string)data[1], data.GetString(2), (DateTime)data[3], (bool)data[4], data.GetString(5), (int)data[6], (long)data[7], data.GetString(8), (DateTime)data[9], data.GetString(10), (int)data[11]);
                }
            }

            return user;
        }

        public bool UpdateUser()
        {
            string update = "update tblUser set intPhoneUser = @intPhoneUser, strEmailUser = @strEmailUser WHERE intIdPerson = @intIdPerson";

            NpgsqlCommand cmd = new NpgsqlCommand(update, conn);

            cmd.Parameters.AddWithValue("@intIdPerson", this.IntIdPerson);
            cmd.Parameters.AddWithValue("@strEmailUser", this.StrEmailUser);
            cmd.Parameters.AddWithValue("@intPhoneUser", this.IntIdPerson);

            int numRows = cmd.ExecuteNonQuery();

            return (numRows > 0);

        }

        public bool UpdatePerson()
        {
            string update = "update tblPerson set strNamePerson = @strNamePerson, strLastNamePerson = @strLastNamePerson, dateOfBirthPerson = @dateOfBirthPerson WHERE intIdPerson = @intIdPerson";

            NpgsqlCommand cmd = new NpgsqlCommand(update, conn);

            cmd.Parameters.AddWithValue("@intIdPerson", this.IntIdPerson);
            cmd.Parameters.AddWithValue("@strNamePerson", this.StrNamePerson);
            cmd.Parameters.AddWithValue("@strLastNamePerson", this.StrLastNamePerson);
            cmd.Parameters.AddWithValue("@dateOfBirthPerson", this.DateOfBirthPerson);

            int numRows = cmd.ExecuteNonQuery();

            return (numRows > 0);

        }

        public bool login(long phone, string password)
        {
            string select = "SELECT * FROM tblUser WHERE intPhoneUser = @phone and strpassword = @password;";

            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);

            cmd.Parameters.AddWithValue("@phone", NpgsqlTypes.NpgsqlDbType.Bigint, phone);
            cmd.Parameters.AddWithValue("@password", NpgsqlTypes.NpgsqlDbType.Varchar, password);

            if (cmd.ExecuteReader().HasRows)
            {
                return true;

            }
            else
            {
                cmd.Cancel();
                return false;
            }
        }

        //public abstract int CreateUser(string password, int idCity);

        // public abstract User getUserById();
        /* public abstract List<User> getUser(int id);
        public abstract List<User> getUser(long idCard); */

    }
}
