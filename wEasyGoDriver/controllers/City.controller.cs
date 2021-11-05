using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassEasyGo;

namespace wEasyGoDriver.controllers
{
    class CityController
    {
        public List<City> getCities()
        {
            return new City().GetCities();
        }
    }
}
