using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalindromeWordController : Controller
    {
        private readonly IPalindromeWord _palindromeWord;

        public PalindromeWordController(IPalindromeWord palindromeWord)
        {
            _palindromeWord = palindromeWord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpPost("CreatePalindromeWord")]
        public async Task<ActionResult<bool>> CreatePalindromeWord(PalindromeRequest word)
        {

            var res = await _palindromeWord.CreatePalindromeAsync(word);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create the Palindrome word");
            }

            return CreatedAtAction(nameof(GetPalindromeWord), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPalindromeWord")]
        public async Task<ActionResult<IEnumerable<PalindromeEntity>>> GetAllPalindromeWord()
        {
            var res = await _palindromeWord.GetPalindromeAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idIsPalindrome"></param>
        /// <returns></returns>
        [HttpGet("GetPalindromeWordById")]
        public async Task<ActionResult<PalindromeEntity>> GetPalindromeWord(int idIsPalindrome)
        {
            var res = await _palindromeWord.GetPalindromeByIdAsync(idIsPalindrome);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="idIsPalindrome"></param>
        /// <returns></returns>
        [HttpPut("ModifyPalindromeWord")]
        public async Task<IActionResult> UpdatePalindromeWord(PalindromeRequest word, int idIsPalindrome)
        {
            var res = await _palindromeWord.UpdatePalindromeAsync(word, idIsPalindrome);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Palindrome word");
            }

            return StatusCode(StatusCodes.Status200OK, "Palindrome word updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idIsPalindrome"></param>
        /// <returns></returns>
        [HttpDelete("DeletePalindromeWord")]
        public async Task<IActionResult> DeletePalindromeWord(int idIsPalindrome)
        {
            var res = await _palindromeWord.DeletePalindromeAsync(idIsPalindrome);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Palindrome word");
            }

            return StatusCode(StatusCodes.Status200OK, "Palindrome word deleted successfully");
        }

    }
}
