using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class PrimeNumber : IPrimeNumber
    {
        private readonly AppDbContext _dbContext;

        public PrimeNumber(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreatePrimeAsync(PrimeRequest num)
        {
            try
            {
                var completePalindrome = new PrimeEntity
                {
                    Number = num.Number,
                    IsPrime = IsPrimeNumber(num.Number),
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

        public async Task<bool> DeletePrimeAsync(int idIsPrime)
        {
            try
            {
                var num = await _dbContext.Primes.FindAsync(idIsPrime);

                if (num != null)
                {
                    _dbContext.Remove(num);
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

        public async Task<List<PrimeEntity>> GetPrimeAsync()
        {
            try
            {
                var nums = await _dbContext.Primes.ToListAsync();

                return nums;
            }
            catch
            {
                return new List<PrimeEntity>();
            }
        }

        public async Task<PrimeEntity> GetPrimeByIdAsync(int idIsPrime)
        {
            try
            {
                var num = await _dbContext.Primes.FindAsync(idIsPrime);

                if (num == null)
                {
                    return null;
                }

                return num;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsPrimeNumber(int num) 
        {
            if (num <= 1) { return false; } // A number equal to 1 or lower is not a prime number
            if (num <= 3) { return true; } // Numbers 2 and 3 are prime
            if (num % 2 == 0 || num % 3 == 0) { return false; } // Divisible by 2 or 3 numbers are not prime
            for (int i = 5; i * i < num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0) { return false; } // Divisible by i or i+2 are not prime numbers
            }
            return true; // By default the number is prime
        }

        public async Task<bool> UpdatePrimeAsync(PrimeRequest num, int idIsPrime)
        {
            try
            {
                var numberToChange = await _dbContext.Primes.FindAsync(idIsPrime);

                if (numberToChange != null)
                {
                    numberToChange.Number = num.Number;
                    numberToChange.IsPrime = IsPrimeNumber(num.Number);

                    _dbContext.Entry(numberToChange).State = EntityState.Modified;

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
