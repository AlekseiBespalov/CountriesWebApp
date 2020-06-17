using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CountriesWebApp.Models;
using CountriesWebApp.Services;

namespace CountriesWebApp.Controllers
{
    public class CountrySearchController : Controller
    {
        private readonly CountrySearchService _countrySearchService;

        public CountrySearchController(CountrySearchService countrySearchService)
        {
            _countrySearchService = countrySearchService;
        }

        [HttpGet]
        public IActionResult CountrySearch()
        {
            var countrySearchViewModel = new CountrySearchViewModel
            {
                SearchString = string.Empty,
                CountrySearchResults = new List<CountryViewModel>(),
            };

            return View(countrySearchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CountrySearch(CountrySearchViewModel countrySearchViewModel)
        {
            if(!string.IsNullOrEmpty(countrySearchViewModel.SearchString))
            {
                countrySearchViewModel.CountrySearchResults = await _countrySearchService.SearchCountryNameInApi(countrySearchViewModel.SearchString);
                return View(countrySearchViewModel);
            }

            else
            {
                return View(new CountrySearchViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCountryToDb(CountryViewModel countryViewModel)
        {
            if(countryViewModel != null)
            {
                await _countrySearchService.AddCountryToDb(countryViewModel);
                return View(countryViewModel);
            }
            else
            {
                return View(countryViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesFromDb()
        {
            var countries = await _countrySearchService.GetAllCountriesFromDb();

            var countryListViewModel = new CountryListViewModel
            {
                Countries = countries
            };

            return View(countryListViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
