using CountriesWebApp.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CountriesDbContext _context;

        public CityRepository(CountriesDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds city to db if not exist and 
        /// updates if required city is found
        /// </summary>
        /// <param name="city">City to add</param>
        /// <returns></returns>
        public async Task<int> AddCityToDbIfNotExist(CityDto city)
        {
            var cityDto = await _context.Cities.FirstOrDefaultAsync(c => c.CityName == city.CityName);

            if(cityDto == null)
            {
                await _context.AddAsync(city);
                await SaveChangesAsync();
                return city.Id;
            }
            else
            {
                return cityDto.Id;
            }
        }

        public async Task<CityDto> GetCityById(int cityId)
        {
            return await _context.Cities.FindAsync(cityId);
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
