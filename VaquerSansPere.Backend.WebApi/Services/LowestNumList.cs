using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class LowestNumList : ILowestNumList
    {
        private readonly AppDbContext _dbContext;

        public LowestNumList(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateLowestNumListAsync(LowestNumListRequest list)
        {
            try
            {
                var completeLowestNumList = new LowestNumListEntity
                {
                    OriginalList = list.OriginalList,
                    LowestNumber = LowestValueList(list.OriginalList),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeLowestNumList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteLowestNumListAsync(int idList)
        {
            try
            {
                var list = await _dbContext.LowestNumLists.FindAsync(idList);

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

        public async Task<List<LowestNumListEntity>> GetLowestNumListAsync()
        {
            try
            {
                var lists = await _dbContext.LowestNumLists.ToListAsync();

                return lists;
            }
            catch
            {
                return new List<LowestNumListEntity>();
            }
        }

        public async Task<LowestNumListEntity> GetLowestNumListByIdAsync(int idList)
        {
            try
            {
                var list = await _dbContext.LowestNumLists.FindAsync(idList);

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

        public int LowestValueList(List<int> list) { List<int> copy = new List<int>(list); copy.Sort(); return copy[0]; }

        public async Task<bool> UpdateLowestNumListAsync(LowestNumListRequest list, int idList)
        {
            try
            {
                var lowestNumListToChange = await _dbContext.LowestNumLists.FindAsync(idList);

                if (lowestNumListToChange != null)
                {
                    lowestNumListToChange.OriginalList = list.OriginalList;
                    lowestNumListToChange.LowestNumber = LowestValueList(list.OriginalList);

                    _dbContext.Entry(lowestNumListToChange).State = EntityState.Modified;

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
