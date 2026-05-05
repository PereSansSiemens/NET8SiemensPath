using Shared;
using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System.Collections.Generic;
using VaquerSansPereFrontendWebApi.Services.Interfaces;

namespace VaquerSansPereFrontendWebApi.Services
{
    public class CircleAreaPerimeterService : ICircleAreaPerimeterService
    {
        private readonly HttpClient httpClient;
        public CircleAreaPerimeterService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<CircleResponse> CalcCircleAreaPerimeter(CircleRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Numbers/CircleAreaPerimeter", request);

            return await response.Content.ReadFromJsonAsync<CircleResponse>();
        }
    }
}
