using Shared.DTOs.Request;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface IPrimeNumber
    {
        bool IsPrimeNumber(int num);
        Task<bool> CreatePrimeAsync(PrimeRequest word);
        Task<bool> UpdatePrimeAsync(PrimeRequest word, int idIsPrime);
        Task<bool> DeletePrimeAsync(int idIsPrime);
        Task<List<PrimeEntity>> GetPrimeAsync();
        Task<PrimeEntity> GetPrimeByIdAsync(int idIsPrime);
    }
}
