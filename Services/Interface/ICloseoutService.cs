using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface ICloseoutService
    {

        Task<Dictionary<string, IEnumerable<Closeout>>> GetCloseoutData();
    }
}
