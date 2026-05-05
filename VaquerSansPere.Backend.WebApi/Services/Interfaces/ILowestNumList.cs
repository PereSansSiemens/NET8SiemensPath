using Shared.DTOs.Request;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface ILowestNumList
    {
        int LowestValueList(List<int> list);
        Task<bool> CreateLowestNumListAsync(LowestNumListRequest list);
        Task<bool> UpdateLowestNumListAsync(LowestNumListRequest list, int idList);
        Task<bool> DeleteLowestNumListAsync(int idList);
        Task<List<LowestNumListEntity>> GetLowestNumListAsync();
        Task<LowestNumListEntity> GetLowestNumListByIdAsync(int idList);
    }
}
