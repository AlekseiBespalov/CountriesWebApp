using CountriesWebApp.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<int> AddCountryToDbIfNotExistAsync(CountryDto country);
        Task<List<CountryDto>> GetAllCountriesAsync();

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
