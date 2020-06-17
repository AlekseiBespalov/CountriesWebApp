using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.ApiModels.RestCountriesApi
{
    public class RestCountriesResultsModel
    {
        public List<RestCountriesCountryResultModel> Results { get; set; }
    }
}
