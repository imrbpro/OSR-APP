using OSR_APP.Models;

namespace OSR_APP.Services.Interface
{
    public interface ISetofffwService
    {
        Task<Dictionary<string, IEnumerable<SetOfffw>>> GetSetOffData();
    }
}
