using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;
using Npgsql;
using System.Data;

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

        public DataTable SearchDriver(string name)
        {
            string select = "SELECT * FROM search_user_by_name(@namePerson, @rol)";

            NpgsqlCommand cmd = new NpgsqlCommand(select, this.conn);
            cmd.Parameters.AddWithValue("@namePerson", name);
            cmd.Parameters.AddWithValue("@rol", "Driver");

            // NpgsqlDataReader data = cmd.ExecuteReader();
            DataTable table = new DataTable();
            NpgsqlDataAdapter drivers = new NpgsqlDataAdapter(cmd);
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(drivers);

            drivers.Fill(table);

            return table; 

        }
    }
}
