using CountriesWebApp.Data.ApiModels.RestCountriesApi;
using CountriesWebApp.Data.Clients;
using CountriesWebApp.Data.DataModels;
using CountriesWebApp.Data.Repositories;
using CountriesWebApp.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Services
{
    public class CountrySearchService
    {
        private readonly IServiceProvider _serviceProvider;

        public CountrySearchService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<CountryViewModel>> SearchCountryNameInApi(string phraseForSearch)
        {
            using var scope = _serviceProvider.CreateScope();

            var countryApiSearchClient = scope.ServiceProvider.GetRequiredService<ICountriesSearchClient<RestCountriesResultsModel>>();

            if (!string.IsNullOrEmpty(phraseForSearch))
            {
                var countrySearchResult = await countryApiSearchClient.SearchCountryByFullName(phraseForSearch);

                if (countrySearchResult.Results == null)
                {
                    return new List<CountryViewModel>();
                }
                else
                {
                    var convertedSearchResult = ConvertSearchResultToResultViewModel(countrySearchResult);

                    return convertedSearchResult;
                }
            }
            else
            {
                return new List<CountryViewModel>();
            }
        }

        public async Task AddCountryToDb(CountryViewModel countryViewModel)
        {
            using var scope = _serviceProvider.CreateScope();

            var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
            var cityRepository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
            var regionRepository = scope.ServiceProvider.GetRequiredService<IRegionRepository>();

            if (countryViewModel != null)
            {
                var city = new CityDto { CityName = countryViewModel.CapitalName }; // map to dto
                var cityId = await cityRepository.AddCityToDbIfNotExist(city);
                city = await cityRepository.GetCityById(cityId);

                var region = new RegionDto { RegionName = countryViewModel.Region };
                var regionId = await regionRepository.AddRegionToDbIfNotExist(region);
                region = await regionRepository.GetRegionById(regionId);

                var country = ConvertCountryViewModelToDto(countryViewModel, city, region);
                await countryRepository.AddCountryToDbIfNotExistAsync(country);
            }
        }

        public async Task<List<CountryViewModel>> GetAllCountriesFromDb()
        {
            List<CountryViewModel> countries = new List<CountryViewModel>();

            using var scope = _serviceProvider.CreateScope();

            var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
            var cityRepository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
            var regionRepository = scope.ServiceProvider.GetRequiredService<IRegionRepository>();

            foreach (CountryDto countryDto in await countryRepository.GetAllCountriesAsync())
            {
                var cityDto = await cityRepository.GetCityById(countryDto.CapitalCityId);
                var regionDto = await regionRepository.GetRegionById(countryDto.RegionId);

                countries.Add(new CountryViewModel
                {
                    CountryName = countryDto.CountryName,
                    CountryCode = countryDto.CountryCode,
                    CapitalName = cityDto.CityName,
                    Area = countryDto.Area,
                    Population = countryDto.Population,
                    Region = regionDto.RegionName
                });
            }

            return countries;
        }

        #region mappings
        private CountryDto ConvertCountryViewModelToDto(CountryViewModel countryViewModel, CityDto city, RegionDto region)
        {
            var countryDto = new CountryDto
            {
                CountryName = countryViewModel.CountryName,
                CountryCode = countryViewModel.CountryCode,
                CapitalCityId = city.Id,
                Capital = city,
                Area = countryViewModel.Area,
                Population = (long)countryViewModel.Population,
                RegionId = region.Id,
                Region = region
            };

            return countryDto;
        }

        private List<CountryViewModel> ConvertSearchResultToResultViewModel(RestCountriesResultsModel results)
        {
            List<CountryViewModel> countryViewModels = new List<CountryViewModel>();
            foreach(RestCountriesCountryResultModel result in results.Results)
            {
                countryViewModels.Add(new CountryViewModel 
                {
                    CountryName = result.Name,
                    CountryCode = result.Alpha3Code,
                    CapitalName = result.Capital,
                    Area = result.Area,
                    Population = result.Population,
                    Region = result.Region
                });
            }

            return countryViewModels;
        }
        #endregion
    }
}
