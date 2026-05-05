using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using VaquerSansPere.Backend.WebApi.Services;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LettersController : ControllerBase
    {

        private readonly IPalindromeWord _palindromeWord;
        private readonly IBookData _bookData;

        public LettersController
            (
            IPalindromeWord palindromeWord, 
            IBookData bookData
            ) 
        {
            _palindromeWord = palindromeWord;
            _bookData = bookData;
        }

        /// <summary>
        /// Shows all Books available with their data
        /// </summary>
        /// <returns></returns>
        [HttpGet("ShowAllBooks")]
        public IActionResult ShowAllBooks() 
        {
            var AllBooks = _bookData.GetAllBooks();
            return Ok(AllBooks);
        }

        /// <summary>
        /// Show a specific book
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpGet("ShowBookByIsbn")]
        public IActionResult ShowBookByIsbn(int isbn) 
        {
            var Book = _bookData.GetBook(isbn);
            return Ok(new { BookData = Book });
        }

        /// <summary>
        /// Tells if a word is palindrome (true) or not (false)
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet("IsPalindrome")]
        public IActionResult IsPalindrome(string word) 
        {
            var res = _palindromeWord.IsPalindrome(word);
            return Ok(res);
        }
    }
}
