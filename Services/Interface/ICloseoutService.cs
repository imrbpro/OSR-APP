using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface ICloseoutService
    {
        Task<Dictionary<string?, IEnumerable<Closeout>>> GetCloseoutData(string? dealNo, string? dealNoTo, DateTime? contractDate, DateTime? contractDateTo, DateTime? valueDate, DateTime? valueDateTo, DateTime? entryDate, DateTime? entryDateTo, string? ccy, string? portfolio, string? broker, string? customer, int? orderBy);
    }
}
