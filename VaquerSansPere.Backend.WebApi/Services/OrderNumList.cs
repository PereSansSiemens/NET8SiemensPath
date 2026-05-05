using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class OrderNumList : IOrderNumList
    {
        private readonly AppDbContext _dbContext;

        public OrderNumList(AppDbContext dbContext)
        {
         _dbContext = dbContext;   
        }
        public async Task<bool> CreateListToOrderAsync(OrderListRequest list)
        {
            try
            {
                var completeListToOrder = new ListToOrderEntity { 
                    OriginalList = list.OriginalList,
                    OrderedList = OrderedNumList(list.OriginalList),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeListToOrder);
                await _dbContext.SaveChangesAsync();
                return true;
            } 
            catch(Exception) 
            {
                return false;  
            }
        }

        public async Task<bool> DeleteListToOrderAsync(int idListToOrder)
        {
            try
            {
                var list = await _dbContext.ListToOrders.FindAsync(idListToOrder);

                if (list != null)
                {
                    _dbContext.Remove(list);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ListToOrderEntity>> GetListToOrderAsync()
        {
            try
            {
                var lists = await _dbContext.ListToOrders.ToListAsync();

                return lists;
            }
            catch
            {
                return new List<ListToOrderEntity>();
            }
        }

        public async Task<ListToOrderEntity> GetListToOrderByIdAsync(int idListToOrder)
        {
            try
            {
                var list = await _dbContext.ListToOrders.FindAsync(idListToOrder);

                if (list == null)
                {
                    return null;
                }

                return list;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<int> OrderedNumList(List<int> list){ List<int> copy = new List<int>(list); copy.Sort(); return copy; }

        public async Task<bool> UpdateListToOrderAsync(OrderListRequest list, int idListToOrder)
        {
            try
            {
                var listToChange = await _dbContext.ListToOrders.FindAsync(idListToOrder);

                if (listToChange != null)
                {
                    listToChange.OriginalList = list.OriginalList;
                    listToChange.OrderedList = OrderedNumList(list.OriginalList);

                    _dbContext.Entry(listToChange).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
