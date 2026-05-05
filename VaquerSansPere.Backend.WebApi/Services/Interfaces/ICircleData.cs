using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface ICircleData
    {
        double CalcCirclePerimeter(CircleRequest circle);
        double CalcCircleArea(CircleRequest circle);
        Task<bool> CreateCircleAsync(CircleRequest circle);
        Task<bool> UpdateCircleAsync(CircleRequest circle, int idCircle);
        Task<bool> DeleteCircleAsync(int idCircle);
        Task<List<CircleEntity>> GetCircleAsync();
        Task<CircleEntity> GetCircleByIdAsync(int idCircle);
    }
}
