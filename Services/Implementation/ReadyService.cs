using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static MudBlazor.CategoryTypes;

namespace OSR_APP.Services.Implementation
{
    public class ReadyService : IReadyService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        string baseApiURL = string.Empty;
        Dictionary<string, string> dictionary;
        public IEnumerable<Ready> ListMenuAddOns { get; set; }
        public ReadyService(HttpClient http, NavigationManager navigationManager, IConfiguration configuration)
        {
            _http = http;
            _navigationManager = navigationManager;
            baseApiURL = $"{configuration["BackendApi"]}Ready";
        }
        public async Task<Dictionary<string, IEnumerable<Ready>>> GetReadyData(string? DealNo = "", string? DealNoTo = "", string? DealDate = "", string? DealDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? BrCode = "", string? Ccy = "", string? PortFolio = "", string? Trader = "", string? Customer = "", string? Ps = "", int? OrderBy = 0)
        {
            var dictionary = new Dictionary<string, IEnumerable<Ready>> ();
            try
            {
                var requestBody = new Dictionary<string, object>()
                {
                    { "DealNo", DealNo },
                    { "DealNoTo", DealNoTo },
                    { "DealDate", DealDate },
                    { "DealDateTo", DealDateTo },
                    { "ValueDate", ValueDate },
                    { "ValueDateTo", ValueDateTo },
                    { "BrCode", BrCode },
                    { "Ccy", Ccy },
                    { "PortFolio", PortFolio },
                    { "Trader", Trader },
                    { "Customer", Customer },
                    { "Ps", Ps },
                    { "OrderBy", OrderBy }
                };

                var content = new StringContent(
                   JsonConvert.SerializeObject(requestBody),
                   Encoding.UTF8,
                   "application/json");

                var url = $"{baseApiURL}";

                HttpResponseMessage result = await _http.PostAsync(url, content);
                HttpResponseMessage result = await _http.GetAsync(baseApiURL);
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Ready>>>(response);
                    dictionary.Add("readyData", apiResponse.Data);
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
        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json"); 
        }
    }
}
