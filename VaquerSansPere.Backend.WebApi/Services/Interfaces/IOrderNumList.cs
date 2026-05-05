using Shared.DTOs.Request;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface IOrderNumList
    {
        List<int> OrderedNumList(List<int> list);
        Task<bool> CreateListToOrderAsync(OrderListRequest list);
        Task<bool> UpdateListToOrderAsync(OrderListRequest list, int idListToOrder);
        Task<bool> DeleteListToOrderAsync(int idListToOrder);
        Task<List<ListToOrderEntity>> GetListToOrderAsync();
        Task<ListToOrderEntity> GetListToOrderByIdAsync(int idListToOrder);
    }
}
