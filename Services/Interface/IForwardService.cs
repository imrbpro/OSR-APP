using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IForwardService
    {
        Task<Dictionary<string, IEnumerable<Forward>>> GetForwardData();
    }
}
