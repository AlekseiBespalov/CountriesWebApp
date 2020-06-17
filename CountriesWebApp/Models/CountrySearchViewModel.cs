using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Models
{
    public class CountrySearchViewModel
    {
        public string SearchString { get; set; }
        public List<CountryViewModel> CountrySearchResults { get; set; }
    }
}
