using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;
using System.Text;

namespace OSR_APP.Services.Implementation
{
    public class CloseoutService : ICloseoutService
    {
        private readonly HttpClient _http;
        string baseApiURL = string.Empty;
        public CloseoutService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            baseApiURL = $"{configuration["BackendApi"]}Closeout";
        }

        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json");
        }
        public async Task<Dictionary<string, IEnumerable<Closeout>>> GetCloseoutData(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy)
        {
            var dictionary = new Dictionary<string, IEnumerable<Closeout>>();
            try
            {
                var parameters = new Dictionary<string, object>()
                {
                  { "dealNo", dealNo },
                  { "dealNoTo", dealNoTo },
                  { "contractDate", contractDate },
                  { "contractDateTo", contractDateTo },
                  { "valueDate", valueDate },
                  { "valueDateTo", valueDateTo },
                  { "entryDate", entryDate },
                  { "entryDateTo", entryDateTo },
                  { "ccy", ccy },
                  { "portfolio", portfolio },
                  { "broker", broker },
                  { "customer", customer },
                  { "orderBy", orderBy }
                };

                // Build the query string from the parameters
                var queryString = BuildQueryString(parameters);

                var url = $"{baseApiURL}{queryString}";

                HttpResponseMessage result = await _http.GetAsync(url);
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Closeout>>>(response);
                    dictionary.Add("closeoutData", apiResponse.Data);
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

        public static string BuildQueryString(Dictionary<string, object> parameters)
        {
            var queryStringBuilder = new StringBuilder();

            foreach (var kvp in parameters)
            {
                if (queryStringBuilder.Length > 0)
                {
                    queryStringBuilder.Append('&');
                }
                
                if (kvp.Value is DateTime dateTime)
                {
                    queryStringBuilder.Append($"{kvp.Key}={dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
                }
                else if (kvp.Value is bool boolean)
                {
                    queryStringBuilder.Append($"{kvp.Key}={boolean.ToString().ToLowerInvariant()}");
                }
                else
                {
                    queryStringBuilder.Append($"{kvp.Key}={Uri.EscapeDataString(kvp.Value?.ToString() ?? string.Empty)}");
                }
            }

            return queryStringBuilder.ToString();
        }
    }
}
