using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListToOrderController : Controller
    {
        private readonly IOrderNumList _orderNumList;

        public ListToOrderController(IOrderNumList orderNumList)
        {
            _orderNumList = orderNumList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("CreateListToOrder")]
        public async Task<ActionResult<bool>> CreateListToOrder(OrderListRequest list)
        {

            var res = await _orderNumList.CreateListToOrderAsync(list);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create the Ordered list");
            }

            return CreatedAtAction(nameof(GetListToOrder), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllListToOrder")]
        public async Task<ActionResult<IEnumerable<ListToOrderEntity>>> GetAllListToOrder()
        {
            var res = await _orderNumList.GetListToOrderAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idListToOrder"></param>
        /// <returns></returns>
        [HttpGet("GetListToOrderById")]
        public async Task<ActionResult<ListToOrderEntity>> GetListToOrder(int idListToOrder)
        {
            var res = await _orderNumList.GetListToOrderByIdAsync(idListToOrder);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="idListToOrder"></param>
        /// <returns></returns>
        [HttpPut("ModifyListToOrder")]
        public async Task<IActionResult> UpdateListToOrder(OrderListRequest list, int idListToOrder)
        {
            var res = await _orderNumList.UpdateListToOrderAsync(list, idListToOrder);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Ordered list");
            }

            return StatusCode(StatusCodes.Status200OK, "Ordered list updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idListToOrder"></param>
        /// <returns></returns>
        [HttpDelete("DeleteListToOrder")]
        public async Task<IActionResult> DeleteListToOrder(int idListToOrder)
        {
            var res = await _orderNumList.DeleteListToOrderAsync(idListToOrder);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Ordered list");
            }

            return StatusCode(StatusCodes.Status200OK, "Ordered list deleted successfully");
        }

    }
}
