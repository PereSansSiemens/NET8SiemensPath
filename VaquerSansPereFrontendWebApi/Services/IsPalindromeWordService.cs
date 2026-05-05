using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class IsPalindromeWordService : IIsPalindromeWordService
    {
        private readonly HttpClient httpClient;
        public IsPalindromeWordService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<bool> IsPalindrome(string word)
        {
            return await httpClient.GetFromJsonAsync<bool>($"/api/Letters/IsPalindrome?word={word}");
        }
    }
}
