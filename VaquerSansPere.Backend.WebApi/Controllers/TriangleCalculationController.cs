using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriangleCalculationController : Controller
    {
        private readonly ITriangleArea _triangleArea;

        public TriangleCalculationController(ITriangleArea triangleArea)
        {
            _triangleArea = triangleArea;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        [HttpPost("CreateTriangle")]
        public async Task<ActionResult<bool>> CreateTriangle(TriangleRequest triangle)
        {

            var res = await _triangleArea.CreateTriangleAsync(triangle);

            if (res == false) 
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create Triangle");
            }

            return CreatedAtAction(nameof(GetTriangle), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTriangles")]
        public async Task<ActionResult<IEnumerable<TriangleEntity>>> GetAllTriangles()
        {
            var res = await _triangleArea.GetTriangleAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTriangle"></param>
        /// <returns></returns>
        [HttpGet("GetTriangleById")]
        public async Task<ActionResult<TriangleEntity>> GetTriangle(int idTriangle)
        {
            var res = await _triangleArea.GetTriangleByIdAsync(idTriangle);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="idTriangle"></param>
        /// <returns></returns>
        [HttpPut("ModifyTriangle")]
        public async Task<IActionResult> UpdateTriangle(TriangleRequest triangle, int idTriangle) 
        {
            var res = await _triangleArea.UpdateTriangleAsync(triangle, idTriangle);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Triangle");
            }

            return StatusCode(StatusCodes.Status200OK, "Triangle updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTriangle"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTriangle")]
        public async Task<IActionResult> DeleteTriangle(int idTriangle) 
        {
            var res = await _triangleArea.DeleteTriangleAsync(idTriangle);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Triangle");
            }

            return StatusCode(StatusCodes.Status200OK, "Triangle deleted successfully");
        }

    }
}
