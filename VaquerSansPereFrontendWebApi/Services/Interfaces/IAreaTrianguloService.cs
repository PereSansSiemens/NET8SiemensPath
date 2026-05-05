using Shared.DTOs.Request;
using Shared.DTOs.Response;

namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IAreaTrianguloService
    {
        Task<TriangleResponse> CalcAreaTriangulo(TriangleRequest request);
    }
}
