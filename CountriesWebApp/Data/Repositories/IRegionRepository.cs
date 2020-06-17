using CountriesWebApp.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public interface IRegionRepository
    {
        Task<int> AddRegionToDbIfNotExist(RegionDto region);
        Task<RegionDto> GetRegionById(int regionId);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
