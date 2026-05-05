using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreatestNumListController : Controller
    {
        private readonly IGreatestNumList _greatestNumList;

        public GreatestNumListController(IGreatestNumList greatestNumList)
        {
            _greatestNumList = greatestNumList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("CreateGreatestNumList")]
        public async Task<ActionResult<bool>> CreateGreatestNumList(GreatestNumListRequest list)
        {

            var res = await _greatestNumList.CreateGreatestNumListAsync(list);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create the Greatest number list");
            }

            return CreatedAtAction(nameof(GetGreatestNumList), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllGreatestNumList")]
        public async Task<ActionResult<IEnumerable<GreatestNumListEntity>>> GetAllGreatestNumList()
        {
            var res = await _greatestNumList.GetGreatestNumListAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGreatestNumList"></param>
        /// <returns></returns>
        [HttpGet("GetGreatestNumListById")]
        public async Task<ActionResult<GreatestNumListEntity>> GetGreatestNumList(int idGreatestNumList)
        {
            var res = await _greatestNumList.GetGreatestNumListByIdAsync(idGreatestNumList);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="idGreatestNumList"></param>
        /// <returns></returns>
        [HttpPut("ModifyGreatestNumList")]
        public async Task<IActionResult> UpdateGreatestNumList(GreatestNumListRequest list, int idGreatestNumList)
        {
            var res = await _greatestNumList.UpdateGreatestNumListAsync(list, idGreatestNumList);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Greatest number list");
            }

            return StatusCode(StatusCodes.Status200OK, "Greatest number list updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGreatestNumList"></param>
        /// <returns></returns>
        [HttpDelete("DeleteGreatestNumList")]
        public async Task<IActionResult> DeleteGreatestNumList(int idGreatestNumList)
        {
            var res = await _greatestNumList.DeleteGreatestNumListAsync(idGreatestNumList);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Greatest number list");
            }

            return StatusCode(StatusCodes.Status200OK, "Greatest number list deleted successfully");
        }

    }
}
