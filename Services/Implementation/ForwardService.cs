using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;

namespace OSR_APP.Services.Implementation
{
    public class ForwardService : IForwardService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        string baseApiURL = string.Empty;
        Dictionary<string, string> dictionary;
        public IEnumerable<Forward> ListMenuAddOns { get; set; }
        public ForwardService(HttpClient http, NavigationManager navigationManager, IConfiguration configuration)
        {
            _http = http;
            _navigationManager = navigationManager;
            baseApiURL = $"{configuration["BackendApi"]}Forward";
        }

        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json");
        }
        public async Task<Dictionary<string, IEnumerable<Forward>>> GetForwardData()
        {
            var dictionary = new Dictionary<string, IEnumerable<Forward>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL);
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Forward>>>(response);
                    dictionary.Add("forwardData", apiResponse.Data);
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
