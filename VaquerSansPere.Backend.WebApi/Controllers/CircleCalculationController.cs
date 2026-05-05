using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CircleCalculationController : Controller
    {
        private readonly ICircleData _circleData;

        public CircleCalculationController(ICircleData circleData)
        {
            _circleData = circleData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        [HttpPost("CreateCircle")]
        public async Task<ActionResult<bool>> CreateCircle(CircleRequest circle)
        {

            var res = await _circleData.CreateCircleAsync(circle);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create Circle");
            }

            return CreatedAtAction(nameof(GetCircle), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCircles")]
        public async Task<ActionResult<IEnumerable<CircleRequest>>> GetAllCircles()
        {
            var res = await _circleData.GetCircleAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCircle"></param>
        /// <returns></returns>
        [HttpGet("GetCircleById")]
        public async Task<ActionResult<CircleRequest>> GetCircle(int idCircle)
        {
            var res = await _circleData.GetCircleByIdAsync(idCircle);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        /// <param name="idCircle"></param>
        /// <returns></returns>
        [HttpPut("ModifyCircle")]
        public async Task<IActionResult> UpdateCircle(CircleRequest circle, int idCircle)
        {
            var res = await _circleData.UpdateCircleAsync(circle, idCircle);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Circle");
            }

            return StatusCode(StatusCodes.Status200OK, "Circle updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCircle"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCircle")]
        public async Task<IActionResult> DeleteCircle(int idCircle)
        {
            var res = await _circleData.DeleteCircleAsync(idCircle);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Circle");
            }

            return StatusCode(StatusCodes.Status200OK, "Circle deleted successfully");
        }

    }
}
