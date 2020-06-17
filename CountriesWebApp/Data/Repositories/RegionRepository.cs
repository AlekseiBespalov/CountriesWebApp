using CountriesWebApp.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CountriesDbContext _context;

        public RegionRepository(CountriesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds region to db if not exist and 
        /// updates if required region is found
        /// </summary>
        /// <param name="region">Region to add</param>
        /// <returns></returns>
        public async Task<int> AddRegionToDbIfNotExist(RegionDto region)
        {
            var regionDto = await _context.Regions.FirstOrDefaultAsync(r => r.RegionName == region.RegionName);

            if (regionDto == null)
            {
                await _context.AddAsync(region);
                await SaveChangesAsync();
                return region.Id;
            }
            else
            {
                return regionDto.Id;
            }
        }

        public async Task<RegionDto> GetRegionById(int regionId)
        {
            return await _context.Regions.FindAsync(regionId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
