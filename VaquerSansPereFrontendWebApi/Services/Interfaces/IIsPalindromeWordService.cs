namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IIsPalindromeWordService
    {
        Task<bool> IsPalindrome(string word);
    }
}
