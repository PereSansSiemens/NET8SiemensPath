using Shared.DTOs.Request;
using Shared.DTOs.Response;
using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class AreaTrianguloService : IAreaTrianguloService
    {
        private readonly HttpClient httpClient;

        public AreaTrianguloService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<TriangleResponse> CalcAreaTriangulo(TriangleRequest request)
        {
            var response =  await httpClient.PostAsJsonAsync($"/api/Numbers/TriangleArea", request);

            return await response.Content.ReadFromJsonAsync<TriangleResponse>();

        }
    }
}
