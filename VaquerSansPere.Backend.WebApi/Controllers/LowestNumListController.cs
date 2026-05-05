using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LowestNumListController : Controller
    {
        private readonly ILowestNumList _lowestNumList;

        public LowestNumListController(ILowestNumList lowestNumList)
        {
            _lowestNumList = lowestNumList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("CreateLowestNumList")]
        public async Task<ActionResult<bool>> CreateLowestNumList(LowestNumListRequest list)
        {

            var res = await _lowestNumList.CreateLowestNumListAsync(list);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create the Lowest number list");
            }

            return CreatedAtAction(nameof(GetLowestNumList), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLowestNumList")]
        public async Task<ActionResult<IEnumerable<LowestNumListEntity>>> GetAllLowestNumList()
        {
            var res = await _lowestNumList.GetLowestNumListAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idLowestNumList"></param>
        /// <returns></returns>
        [HttpGet("GetLowestNumListById")]
        public async Task<ActionResult<LowestNumListEntity>> GetLowestNumList(int idLowestNumList)
        {
            var res = await _lowestNumList.GetLowestNumListByIdAsync(idLowestNumList);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="idLowestNumList"></param>
        /// <returns></returns>
        [HttpPut("ModifyLowestNumList")]
        public async Task<IActionResult> UpdateLowestNumList(LowestNumListRequest list, int idLowestNumList)
        {
            var res = await _lowestNumList.UpdateLowestNumListAsync(list, idLowestNumList);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Lowest number list");
            }

            return StatusCode(StatusCodes.Status200OK, "Lowest number list updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idLowestNumList"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLowestNumList")]
        public async Task<IActionResult> DeleteLowestNumList(int idLowestNumList)
        {
            var res = await _lowestNumList.DeleteLowestNumListAsync(idLowestNumList);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Lowest number list");
            }

            return StatusCode(StatusCodes.Status200OK, "Lowest number list deleted successfully");
        }

    }
}
