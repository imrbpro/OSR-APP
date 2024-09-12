using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface ICloseoutService
    {
        Task<Dictionary<string, IEnumerable<Closeout>>> GetCloseoutData(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy);
    }
}
