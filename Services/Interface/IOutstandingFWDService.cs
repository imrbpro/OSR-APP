using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface IOutstandingFWDService
    {
        Task<Dictionary<string, IEnumerable<OutstandingFWD>>> GetOutstandingFWDData();
    }
}
