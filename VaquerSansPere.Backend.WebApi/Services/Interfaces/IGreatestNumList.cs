using Shared.DTOs.Request;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface IGreatestNumList
    {
        int GreatestValueList(List<int> list);
        Task<bool> CreateGreatestNumListAsync(GreatestNumListRequest list);
        Task<bool> UpdateGreatestNumListAsync(GreatestNumListRequest list, int idList);
        Task<bool> DeleteGreatestNumListAsync(int idList);
        Task<List<GreatestNumListEntity>> GetGreatestNumListAsync();
        Task<GreatestNumListEntity> GetGreatestNumListByIdAsync(int idList);
    }
}
