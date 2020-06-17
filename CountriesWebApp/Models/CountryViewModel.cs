using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Models
{
    public class CountryViewModel
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CapitalName { get; set; }
        public float Area { get; set; }
        public long Population { get; set; }
        public string Region { get; set; }
    }
}
