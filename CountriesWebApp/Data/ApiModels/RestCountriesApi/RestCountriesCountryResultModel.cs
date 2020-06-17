using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.ApiModels.RestCountriesApi
{
    public class RestCountriesCountryResultModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("topLevelDomain")]
        public string[] TopLevelDomain { get; set; }

        [JsonProperty("alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonProperty("alpha3Code")]
        public string Alpha3Code { get; set; }

        [JsonProperty("callingCodes")]
        public string[] CallingCodes { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("altSpellings")]
        public string[] AltSpellings { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("subregion")]
        public string Subregion { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("latlng")]
        public float[] Latlng { get; set; }

        [JsonProperty("demonym")]
        public string Demonym { get; set; }

        [JsonProperty("area")]
        public float Area { get; set; }

        [JsonProperty("gini")]
        public float Gini { get; set; }

        [JsonProperty("timezones")]
        public string[] Timezones { get; set; }

        [JsonProperty("borders")]
        public object[] Borders { get; set; }

        [JsonProperty("nativeName")]
        public string NativeName { get; set; }

        [JsonProperty("numericCode")]
        public int NumericCode { get; set; }

        [JsonProperty("currencies")]
        public RestCountriesCurrencyModel[] Currencies { get; set; }

        [JsonProperty("languages")]
        public RestCountriesLaunguageModel[] Languages { get; set; }

        [JsonProperty("translations")]
        public RestCountriesTranslationModel Translations { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("regionalBlocs")]
        public object[] RegionalBlocs { get; set; }

        [JsonProperty("cioc")]
        public string Cioc { get; set; }
    }
}
