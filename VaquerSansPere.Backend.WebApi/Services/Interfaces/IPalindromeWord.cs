using Shared.DTOs.Request;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface IPalindromeWord
    {
        bool IsPalindrome(string word);

        Task<bool> CreatePalindromeAsync(PalindromeRequest word);
        Task<bool> UpdatePalindromeAsync(PalindromeRequest word, int idIsPalindrome);
        Task<bool> DeletePalindromeAsync(int idIsPalindrome);
        Task<List<PalindromeEntity>> GetPalindromeAsync();
        Task<PalindromeEntity> GetPalindromeByIdAsync(int idIsPalindrome);
    }
}
