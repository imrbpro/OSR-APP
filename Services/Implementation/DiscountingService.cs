using OSR_APP.Models;
using OSR_APP.Services.Interface;

namespace OSR_APP.Services.Implementation
{
    public class DiscountingService : IDiscountingService
    {
        public Task<Dictionary<string, IEnumerable<Discounting>>> GetDiscountingData()
        {
            throw new NotImplementedException();
        }
    }
}
