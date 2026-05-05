using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class FindLowestValueService : IFindLowestValueService
    {
        private readonly HttpClient httpClient;

        public FindLowestValueService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<int> FindLowestValue(List<int> list)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Numbers/LowestNumList", list);

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
