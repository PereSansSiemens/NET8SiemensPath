using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimeNumberController : Controller
    {
        private readonly IPrimeNumber _primeNumber;

        public PrimeNumberController(IPrimeNumber primeNumber)
        {
            _primeNumber = primeNumber;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpPost("CreatePrimeNumber")]
        public async Task<ActionResult<bool>> CreatePrimeNumber(PrimeRequest num)
        {

            var res = await _primeNumber.CreatePrimeAsync(num);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create the Prime number");
            }

            return CreatedAtAction(nameof(GetPrimeNumber), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPrimeNumber")]
        public async Task<ActionResult<IEnumerable<PrimeEntity>>> GetAllPrimeNumber()
        {
            var res = await _primeNumber.GetPrimeAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idIsPrime"></param>
        /// <returns></returns>
        [HttpGet("GetPrimeNumberById")]
        public async Task<ActionResult<PrimeEntity>> GetPrimeNumber(int idIsPrime)
        {
            var res = await _primeNumber.GetPrimeByIdAsync(idIsPrime);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="idIsPrime"></param>
        /// <returns></returns>
        [HttpPut("ModifyPrimeNumber")]
        public async Task<IActionResult> UpdatePrimeNumber(PrimeRequest num, int idIsPrime)
        {
            var res = await _primeNumber.UpdatePrimeAsync(num, idIsPrime);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Prime number");
            }

            return StatusCode(StatusCodes.Status200OK, "Prime number updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idIsPalindrome"></param>
        /// <returns></returns>
        [HttpDelete("DeletePrimeNumber")]
        public async Task<IActionResult> DeletePrimeNumber(int idIsPalindrome)
        {
            var res = await _primeNumber.DeletePrimeAsync(idIsPalindrome);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Prime number");
            }

            return StatusCode(StatusCodes.Status200OK, "Prime number deleted successfully");
        }

    }
}
