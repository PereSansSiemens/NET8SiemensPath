using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;
using System.Drawing;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class CircleData : ICircleData
    {
        private readonly AppDbContext _dbContext;
        public CircleData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public double CalcCirclePerimeter(CircleRequest circle) { return 2 * Math.PI * circle.Radius; }

        public double CalcCircleArea(CircleRequest circle) { return Math.PI * circle.Radius * circle.Radius; }

        public async Task<bool> CreateCircleAsync(CircleRequest circle)
        {
            try
            {
                var completeCircle = new CircleEntity
                {
                    Radius = circle.Radius,
                    Color = circle.Color,
                    Perimeter = CalcCirclePerimeter(circle),
                    Area = CalcCircleArea(circle),
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeCircle);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCircleAsync(CircleRequest circle, int idCircle)
        {
            try
            {
                var circleToChange = await _dbContext.Circles.FindAsync(idCircle);

                if (circleToChange != null)
                {
                    circleToChange.Radius = circle.Radius;
                    circleToChange.Color = circle.Color;
                    circleToChange.Perimeter = CalcCirclePerimeter(circle);
                    circleToChange.Area = CalcCircleArea(circle);

                    _dbContext.Entry(circleToChange).State = EntityState.Modified;

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

        public async Task<bool> DeleteCircleAsync(int idCircle)
        {
            try
            {
                var circle = await _dbContext.Circles.FindAsync(idCircle);

                if (circle != null)
                {
                    _dbContext.Remove(circle);
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

        public async Task<List<CircleEntity>> GetCircleAsync()
        {
            try
            {
                var circles = await _dbContext.Circles.ToListAsync();

                return circles;
            }
            catch
            {
                return new List<CircleEntity>();
            }
        }

        public async Task<CircleEntity> GetCircleByIdAsync(int idCircle)
        {
            try
            {
                var circle = await _dbContext.Circles.FindAsync(idCircle);

                if (circle == null)
                {
                    return null;
                }

                return circle;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
