using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Clients
{
    interface ICountriesSearchClient<T> where T : class
    {
        Task<T> SearchCountryByFullName(string phrase);
    }
}
