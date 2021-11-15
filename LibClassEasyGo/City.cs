using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Npgsql;
namespace LibClassEasyGo
{

    public interface IDepartment
    {
        string strNameDepartment { get; set; }
        string intIdDepartment { get; set; }
        int intIdCountry { get; set; }
    }
    public class City
    {
        private int intIdCity;
        private string strNameCity;
        private NpgsqlConnection conn = new Connect().Conn();

        public int IntIdCity { get => intIdCity; set => intIdCity = value; }
        public string StrNameCity { get => strNameCity; set => strNameCity = value; }

        public City(int intIdCity, string strNameCity)
        {
            IntIdCity = intIdCity;
            StrNameCity = strNameCity;
        }

        public City()
        {

        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            string select = "SELECT * FROM sp_get_cities()";

            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    cities.Add(new City((int)(data["intIdCity"]), data["strNameCity"].ToString()));
                }
            }

            data.Close();

            return cities;
        }

        public List<Object> getDepartments()
        {
            List<Object> departments = new List<Object>();
            string select = "SELECT * FROM tblDepartment";

            NpgsqlCommand cmd = new NpgsqlCommand(select, conn);

            NpgsqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Object department = new {

                        intIdDepartment = Convert.ToInt32(data[0]),
                        strNameDepartment = data[1].ToString(),
                        intIdCountry = Convert.ToInt32(data[3]),

                    };

                    departments.Add(department);
                }
            }

            data.Close();

            return departments;
        }

        //public bool SetCity()

    }


}