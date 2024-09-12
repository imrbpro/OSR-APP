using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface ISetofffwService
    {
        Task<Dictionary<string, IEnumerable<SetOfffw>>> GetSetOffData(string? DealNo = "", string? DealNoTo = "", string? ContractDate = "", string? ContractDateTo = "", string? ValueDate = "", string? ValueDateTo = "", string? EntryDate = "", string? EntryDateTo = "", string? Ccy = "", string? Portfolio = "", string? Trad = "", string? Customer = "", int? OrderBy = 0);
    }
}
