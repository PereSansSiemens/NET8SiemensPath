using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class FindGreatestValueService : IFindGreatestValueService
    {
        private readonly HttpClient httpClient;

        public FindGreatestValueService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<int> FindGreatestValue(List<int> list)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Numbers/GreatestNumList", list);

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
