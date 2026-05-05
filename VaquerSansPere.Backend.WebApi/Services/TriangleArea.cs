using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.DTOs.Response;
using Shared.Models;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class TriangleArea : ITriangleArea
    {
        public float CalcTriangleArea(TriangleRequest triangle) 
        { 
            return triangle.Base * triangle.Height / 2; // Calculates the total area
             
        }

        private readonly AppDbContext _dbContext;

        public TriangleArea(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateTriangleAsync(TriangleRequest triangle)
        {
            try 
            {
                var completeTriangle = new TriangleEntity
                {
                    Base = triangle.Base,
                    Height = triangle.Height,
                    Area = CalcTriangleArea(triangle),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeTriangle);
                await _dbContext.SaveChangesAsync();
                return true;          
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTriangleAsync(int idTriangle)
        {
            try
            {
                var triangle = await _dbContext.Triangles.FindAsync(idTriangle);

                if (triangle != null) 
                {
                    _dbContext.Remove(triangle);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<TriangleEntity>> GetTriangleAsync()
        {
            try 
            {
                var triangles = await _dbContext.Triangles.ToListAsync();

                return triangles;
            } 
            catch
            {
                return new List<TriangleEntity>();
            }
        }

        public async Task<TriangleEntity> GetTriangleByIdAsync(int idtriangle)
        {
            try 
            {
                var triangle = await _dbContext.Triangles.FindAsync(idtriangle);

                if (triangle == null) 
                {
                    return null;
                }

                return triangle;

            } 
            catch(Exception) 
            {
                return null;
            }
        }

        public async Task<bool> UpdateTriangleAsync(TriangleRequest triangle, int idTriangle)
        {
            try
            {
                var triangleToChange = await _dbContext.Triangles.FindAsync(idTriangle);

                if (triangleToChange != null)
                {
                    triangleToChange.Base = triangle.Base;
                    triangleToChange.Height = triangle.Height;
                    triangleToChange.Area = CalcTriangleArea(triangle); 

                    _dbContext.Entry(triangleToChange).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;

            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
