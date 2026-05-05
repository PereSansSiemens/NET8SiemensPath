using Shared;
using Shared.DTOs.Request;
using Shared.DTOs.Response;

namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface ICircleAreaPerimeterService
    {
        Task<CircleResponse> CalcCircleAreaPerimeter(CircleRequest request);
    }
}
