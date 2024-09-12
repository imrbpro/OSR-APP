using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;

namespace OSR_APP.Services.Implementation
{
    public class FilterService : IFilterService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        string baseApiURL = string.Empty;
        Dictionary<string, string> dictionary;
        public FilterService(HttpClient http, NavigationManager navigationManager, IConfiguration configuration)
        {
            _http = http;
            _navigationManager = navigationManager;
            baseApiURL = $"{configuration["BackendApi"]}Filters";
        }

        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json");
        }
        public async Task<Dictionary<string, IEnumerable<string>>> GetBranchCode()
        {
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL+ "/GetBranchCode");
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<string>>>(response);
                    dictionary.Add("branchCodeData", apiResponse.Data);
                    return dictionary;
                }
                else
                {
                    errorMessage = await result.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Dictionary<string, IEnumerable<string>>> GetCurrency()
        {
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL+ "/GetCurrency");
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<string>>>(response);
                    dictionary.Add("currencyData", apiResponse.Data);
                    return dictionary;
                }
                else
                {
                    errorMessage = await result.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Dictionary<string, IEnumerable<string>>> GetPortfolio()
        {
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL+ "/GetPortfolio");
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<string>>>(response);
                    dictionary.Add("portfolioData", apiResponse.Data);
                    return dictionary;
                }
                else
                {
                    errorMessage = await result.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Dictionary<string, IEnumerable<string>>> GetTrader()
        {
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL+ "/GetTrader");
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<string>>>(response);
                    dictionary.Add("traderData", apiResponse.Data);
                    return dictionary;
                }
                else
                {
                    errorMessage = await result.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
