using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class IsPrimeNumberService : IIsPrimeNumberService
    {
        private readonly HttpClient httpClient;
        public IsPrimeNumberService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient; 
        }
        public async Task<bool> IsPrime(int num)
        {
            return await httpClient.GetFromJsonAsync<bool>($"/api/Numbers/IsPrime?num={num}");
        }
    }
}
