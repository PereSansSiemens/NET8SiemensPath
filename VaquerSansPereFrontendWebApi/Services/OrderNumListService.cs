using System.Threading.Tasks;
using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class OrderNumListService : IOrderNumListService
    {
        private readonly HttpClient httpClient;

        public OrderNumListService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<int>> OrderedNumList(List<int> list)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Numbers/OrderNumList", list);
            
            return await response.Content.ReadFromJsonAsync<List<int>>();
        }
    }
}
