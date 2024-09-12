using Newtonsoft.Json;
using OSR_APP.Models;
using OSR_APP.Services.Interface;
using System.Net;
using System.Text;

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
        public async Task<Dictionary<string, IEnumerable<OutstandingFWD>>> GetOutstandingFWDData(string? DealNo = "", string? DealNoTo = "", string? ContractDate = "", string? ContractDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? EntryDate = "", string? EntryDateTo = "", string? Ccy = "", string? PortFolio = "", string? BranchCode = "", string? Trader = "", string? Customer = "", int? OrderBy = 0)
        {
            var dictionary = new Dictionary<string, IEnumerable<OutstandingFWD>>();
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
                    { "PortFolio", PortFolio },
                    { "BranchCode", BranchCode },
                    { "Trader", Trader },
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
