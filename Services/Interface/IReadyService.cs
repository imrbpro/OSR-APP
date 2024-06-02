using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IReadyService
    {
        Task<Dictionary<string, IEnumerable<Ready>>> GetReadyData(); 
    }
}
