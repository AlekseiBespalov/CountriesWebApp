using CountriesWebApp.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public interface ICityRepository
    {
        Task<int> AddCityToDbIfNotExist(CityDto city);
        Task<CityDto> GetCityById(int cityId);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
