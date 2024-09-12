using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IReadyService
    {
        Task<Dictionary<string, IEnumerable<Ready>>> GetReadyData(string? DealNo = "", string? DealNoTo = "", string? DealDate = "", string? DealDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? BrCode = "", string? Ccy = "", string? PortFolio = "", string? Trader = "", string? Customer = "", string? Ps = "", int? OrderBy = 0); 
    }
}
