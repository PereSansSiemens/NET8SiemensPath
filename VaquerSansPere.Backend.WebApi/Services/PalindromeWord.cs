using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using System.Collections.Generic;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class PalindromeWord : IPalindromeWord
    {
        private readonly AppDbContext _dbContext;

        public PalindromeWord(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreatePalindromeAsync(PalindromeRequest word)
        {
            try
            {
                var completePalindrome = new PalindromeEntity
                {
                    Word = word.Word,
                    IsPalindrome = IsPalindrome(word.Word),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completePalindrome);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePalindromeAsync(int idIsPalindrome)
        {
            try
            {
                var word = await _dbContext.Palindromes.FindAsync(idIsPalindrome);

                if (word != null)
                {
                    _dbContext.Remove(word);
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

        public async Task<List<PalindromeEntity>> GetPalindromeAsync()
        {
            try
            {
                var words = await _dbContext.Palindromes.ToListAsync();

                return words;
            }
            catch
            {
                return new List<PalindromeEntity>();
            }
        }

        public async Task<PalindromeEntity> GetPalindromeByIdAsync(int idIsPalindrome)
        {
            try
            {
                var word = await _dbContext.Palindromes.FindAsync(idIsPalindrome);

                if (word == null)
                {
                    return null;
                }

                return word;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsPalindrome(string word) 
        {
            int RightPointer = word.Length - 1;
            int LeftPointer = 0;
            while (RightPointer > LeftPointer) 
            {
                if (word[RightPointer] != word[LeftPointer]) { return false; }
                LeftPointer++;
                RightPointer--;
            }
            return true;
        }

        public async Task<bool> UpdatePalindromeAsync(PalindromeRequest word, int idIsPalindrome)
        {
            try
            {
                var wordToChange = await _dbContext.Palindromes.FindAsync(idIsPalindrome);

                if (wordToChange != null)
                {
                    wordToChange.Word = word.Word;
                    wordToChange.IsPalindrome = IsPalindrome(word.Word);

                    _dbContext.Entry(wordToChange).State = EntityState.Modified;

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
