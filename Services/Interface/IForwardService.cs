using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IForwardService
    {
        Task<Dictionary<string, IEnumerable<Forward>>> GetForwardData(string? DealNo = "", string? DealNoTo = "", string? DealDate = "", string? DealDateTo = "", string? ODate = "", string? ODateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? Ccy = "", string? PortFolio = "", string? Broker = "", string? Trader = "", string? Customer = "", int? OrderBy = 0);
    }
}
