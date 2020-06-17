using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.DataModels
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public int CapitalCityId { get; set; }
        public CityDto Capital { get; set; }

        public float Area { get; set; }
        public long Population { get; set; }

        public int RegionId { get; set; }
        public RegionDto Region { get; set; }
    }
}
