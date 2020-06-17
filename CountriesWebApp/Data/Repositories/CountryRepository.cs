using CountriesWebApp.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountriesDbContext _context;

        public CountryRepository(CountriesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds country to db if its code not exist and 
        /// updates if required country is found
        /// </summary>
        /// <param name="country">Country to add</param>
        /// <returns></returns>
        public async Task<int> AddCountryToDbIfNotExistAsync(CountryDto country)
        {
            var countryDto = await _context.Countries.FirstOrDefaultAsync(c => c.CountryCode == country.CountryCode);
            
            if (countryDto == null)
            {
                await _context.AddAsync(country);
                await SaveChangesAsync();
                return country.Id;
            }
            else
            {
                countryDto.CountryName = country.CountryName;
                countryDto.Capital = country.Capital;
                countryDto.Area = country.Area;
                countryDto.Population = country.Population;
                countryDto.Region = country.Region;

                await SaveChangesAsync();
                return countryDto.Id;
            }
        }

        public async Task<List<CountryDto>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
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
