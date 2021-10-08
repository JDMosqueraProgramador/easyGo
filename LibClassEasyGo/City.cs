using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibClassEasyGo
{
    public class City
    {
        private int intIdCity;
        private string strNameCity;

        public int IntIdCity { get => intIdCity; set => intIdCity = value; }
        public string StrNameCity { get => strNameCity; set => strNameCity = value; }

        public City(int intIdCity, string strNameCity)
        {
            IntIdCity = intIdCity;
            StrNameCity = strNameCity;
        }
    }
}