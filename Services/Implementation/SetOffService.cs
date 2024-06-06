using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;

namespace OSR_APP.Services.Implementation
{
    public class SetOffService : ISetofffwService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        string baseApiURL = string.Empty;
        Dictionary<string, string> dictionary;
        public IEnumerable<SetOfffw> ListMenuAddOns { get; set; }
        public SetOffService(HttpClient http, NavigationManager navigationManager, IConfiguration configuration)
        {
            _http = http;
            _navigationManager = navigationManager;
            baseApiURL = $"{configuration["BackendApi"]}Setofffw";
        }

        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json");
        }
        public async Task<Dictionary<string, IEnumerable<SetOfffw>>> GetSetOffData()
        {
            var dictionary = new Dictionary<string, IEnumerable<SetOfffw>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL);
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<SetOfffw>>>(response);
                    dictionary.Add("setoffData", apiResponse.Data);
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
