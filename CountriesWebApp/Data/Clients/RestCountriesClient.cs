using CountriesWebApp.Data.ApiModels.RestCountriesApi;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Clients
{
    public class RestCountriesClient : ICountriesSearchClient<RestCountriesResultsModel>
    {
        private readonly string _apiUrlNameEndpoint = "https://restcountries.eu/rest/v2/name/";
        private readonly string _fulltNameOption = "?fullText=true";
        public async Task<RestCountriesResultsModel> SearchCountryByFullName(string phrase)
        {
            if (phrase != null)
            {
                string phraseForSearchUrl = phrase.Replace(" ", "+");

                StringBuilder searchUrl = new StringBuilder();
                searchUrl.Append(_apiUrlNameEndpoint);
                searchUrl.Append(phraseForSearchUrl);
                searchUrl.Append(_fulltNameOption);

                dynamic restCountriesSearchResultJson;
                var searchResults = new RestCountriesResultsModel();

                try
                {
                    restCountriesSearchResultJson = await searchUrl.ToString().GetJsonListAsync();

                    string serializedJson = JsonConvert.SerializeObject(restCountriesSearchResultJson, Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    searchResults.Results = JsonConvert.DeserializeObject<List<RestCountriesCountryResultModel>>(serializedJson);
                }
                catch (FlurlHttpException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                return searchResults;
            }

            else
            {
                return new RestCountriesResultsModel();
            }
        }
    }
}
