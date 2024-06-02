using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IDiscountingService
    {
        Task<Dictionary<string, IEnumerable<Discounting>>> GetDiscountingData();
    }
}
