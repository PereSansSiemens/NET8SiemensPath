using Shared.DTOs.Request;
using Shared.DTOs.Response;
using Shared.Models;
using Shared.Models.Entities;
namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface ITriangleArea
    {
        float CalcTriangleArea(TriangleRequest triangle);
        Task<bool> CreateTriangleAsync(TriangleRequest triangle);
        Task<bool> UpdateTriangleAsync(TriangleRequest triangle, int idTriangle);
        Task<bool> DeleteTriangleAsync(int idTriangle);
        Task<List<TriangleEntity>> GetTriangleAsync();
        Task<TriangleEntity> GetTriangleByIdAsync(int idtriangle);

    }
}
