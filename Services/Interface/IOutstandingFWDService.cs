using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IOutstandingFWDService
    {
        Task<Dictionary<string, IEnumerable<OutstandingFWD>>> GetOutstandingFWDData(string? DealNo = "", string? DealNoTo = "", string? ContractDate = "", string? ContractDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? EntryDate = "", string? EntryDateTo = "", string? Ccy = "", string? PortFolio = "", string? BranchCode = "", string? Trader = "", string? Customer = "", int? OrderBy = 0);
    }
}
