using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class GreatestNumList : IGreatestNumList
    {

        private readonly AppDbContext _dbContext;

        public GreatestNumList(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateGreatestNumListAsync(GreatestNumListRequest list)
        {
            try
            {
                var completeGreatestNumList = new GreatestNumListEntity
                {
                    OriginalList = list.OriginalList,
                    GreatestNumber = GreatestValueList(list.OriginalList),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeGreatestNumList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGreatestNumListAsync(int idList)
        {
            try
            {
                var list = await _dbContext.GreatestNumLists.FindAsync(idList);

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

        public async Task<List<GreatestNumListEntity>> GetGreatestNumListAsync()
        {
            try
            {
                var lists = await _dbContext.GreatestNumLists.ToListAsync();

                return lists;
            }
            catch
            {
                return new List<GreatestNumListEntity>();
            }
        }

        public async Task<GreatestNumListEntity> GetGreatestNumListByIdAsync(int idList)
        {
            try
            {
                var list = await _dbContext.GreatestNumLists.FindAsync(idList);

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

        public int GreatestValueList(List<int> list) { List<int> copy = new List<int>(list);  copy.Sort(); copy.Reverse(); return copy[0]; }

        public async Task<bool> UpdateGreatestNumListAsync(GreatestNumListRequest list, int idList)
        {
            try
            {
                var greatestNumListToChange = await _dbContext.GreatestNumLists.FindAsync(idList);

                if (greatestNumListToChange != null)
                {
                    greatestNumListToChange.OriginalList = list.OriginalList;
                    greatestNumListToChange.GreatestNumber = GreatestValueList(list.OriginalList);

                    _dbContext.Entry(greatestNumListToChange).State = EntityState.Modified;

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
