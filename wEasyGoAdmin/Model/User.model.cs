using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using LibClassEasyGo;

namespace wEasyGoAdmin.Model
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
            string select = "SELECT intidcardperson as \"Documento\", strnameperson as \"Nombres\", strlastnameperson as \"Apellidos\", dateofbirthperson as \"Fecha nacimiento\", boolgenderperson as \"Género\", city as \"Ciudad\", intiduser as \"ID\", intphoneuser as \"Celular\", stremailuser as \"Email\", datecreatead as \"Fecha de registro\", strroluser as \"Rol\", intidperson as \"ID persona\" FROM sp_search_drivers(@namePerson);";

            NpgsqlCommand cmd = new NpgsqlCommand(select, this.conn);
            cmd.Parameters.AddWithValue("@namePerson", name);

            // NpgsqlDataReader data = cmd.ExecuteReader();
            DataTable table = new DataTable();
            NpgsqlDataAdapter drivers = new NpgsqlDataAdapter(cmd);
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(drivers);

            drivers.Fill(table);

            return table;

        }

        public DataTable SelectDriversDisabled()
        {
            string select = "SELECT intidcardperson as \"Documento\", strnameperson as \"Nombres\", strlastnameperson as \"Apellidos\", dateofbirthperson as \"Fecha nacimiento\", boolgenderperson as \"Género\", city as \"Ciudad\", intiduser as \"ID\", intphoneuser as \"Celular\", stremailuser as \"Email\", datecreatead as \"Fecha de registro\", strroluser as \"Rol\", intidperson as \"ID persona\" FROM sp_search_drivers(@namePerson);";

            NpgsqlCommand cmd = new NpgsqlCommand(select, this.conn);
            cmd.Parameters.AddWithValue("@namePerson", "A");

            // NpgsqlDataReader data = cmd.ExecuteReader();
            DataTable table = new DataTable();
            NpgsqlDataAdapter drivers = new NpgsqlDataAdapter(cmd);
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(drivers);

            drivers.Fill(table);

            return table;

        }







        /*protected DataTable selectDriver()
        {
            //Comando para seleciionar evento y conectarlo a la base de datos
            string select = "SELECT intCodigoEvento as 'Código', strNombreEvento as 'Nombre', strFormadorEvento as 'Formador', tblProcesoFormativo.strNombreProceso as 'Proceso formativo' FROM tblEvento inner join tblProcesoFormativo ON tblEvento.intCodigoProceso = tblProcesoFormativo.intCodigoProceso";
            NpgsqlCommand query = new SqlCommand(select, newConnection());

            //creacion de datatable
            DataTable table = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(query);

            data.Fill(table);
            return table;
        }*/


    }
}
