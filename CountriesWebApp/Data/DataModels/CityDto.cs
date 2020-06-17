using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.DataModels
{
    /// <summary>
    /// Only for capitals
    /// </summary>
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public CountryDto Country { get; set; }
    }
}
