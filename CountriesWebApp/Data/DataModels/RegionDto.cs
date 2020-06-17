using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.DataModels
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string RegionName { get; set; }

        public List<CountryDto> Countries { get; set; }
    }
}
