using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;
using System.Text;

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
        public async Task<Dictionary<string, IEnumerable<SetOfffw>>> GetSetOffData(string? DealNo = "", string? DealNoTo = "", string? ContractDate = "", string? ContractDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? EntryDate = "", string? EntryDateTo = "", string? Ccy = "", string? Portfolio = "", string? Trad = "", string? Customer = "", int? OrderBy = 0)
        {
            var dictionary = new Dictionary<string, IEnumerable<SetOfffw>>();
            try
            {
                var requestBody = new Dictionary<string, object>()
                {
                    { "DealNo", DealNo },
                    { "DealNoTo", DealNoTo },
                    { "ContractDate", ContractDate },
                    { "ContractDateTo", ContractDateTo },
                    { "ValueDate", ValueDate },
                    { "ValueDateTo", ValueDateTo },
                    { "EntryDate", EntryDate },
                    { "EntryDateTo", EntryDateTo },
                    { "Ccy", Ccy },
                    { "Portfolio", Portfolio },
                    { "Trad", Trad },
                    { "Customer", Customer },
                    { "OrderBy", OrderBy }
                };

                var content = new StringContent(
                   JsonConvert.SerializeObject(requestBody),
                   Encoding.UTF8,
                   "application/json");

                var url = $"{baseApiURL}";

                HttpResponseMessage result = await _http.PostAsync(url, content);
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
