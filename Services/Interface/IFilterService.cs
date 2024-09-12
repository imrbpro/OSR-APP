namespace OSR_APP.Services.Interface
{
    public interface IFilterService
    {
        Task<Dictionary<string, IEnumerable<string>>> GetBranchCode();
        Task<Dictionary<string, IEnumerable<string>>> GetCurrency();
        Task<Dictionary<string, IEnumerable<string>>> GetPortfolio();
        Task<Dictionary<string, IEnumerable<string>>> GetTrader();
    }
}
