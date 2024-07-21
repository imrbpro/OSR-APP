using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;

namespace OSR_APP.Services.Implementation
{
    public class OutstandingFWDService : IOutstandingFWDService
    {
        private readonly HttpClient _http;
        private string baseApiURL = string.Empty;
        public OutstandingFWDService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            baseApiURL = $"{configuration["BackendApi"]}OutstandingFWD";
        }
        private void SetDefaultHeaders(HttpRequestMessage request)
        {
            //request.Headers.Add("Authorization", ""); 
            request.Headers.Add("Content-Type", "application/json");
        }
        public async Task<Dictionary<string, IEnumerable<OutstandingFWD>>> GetOutstandingFWDData()
        {
            var dictionary = new Dictionary<string, IEnumerable<OutstandingFWD>>();
            try
            {
                HttpResponseMessage result = await _http.GetAsync(baseApiURL);
                var errorMessage = "";
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<OutstandingFWD>>>(response);
                    dictionary.Add("outstandingfwdData", apiResponse.Data);
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
