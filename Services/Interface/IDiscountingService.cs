using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IDiscountingService
    {
        Task<Dictionary<string, IEnumerable<Discounting>>> GetDiscountingData(string? DealNo = "", string? DealNoTo = "", string? DealDate = "", string? DealDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? BrCode = "", string? Ccy = "", string? PortFolio = "", string? Broker = "", string? Trader = "", string? Customer = "", string? Ps = "", int? OrderBy = 0);
    }
}
