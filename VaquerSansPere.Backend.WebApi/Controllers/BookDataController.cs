using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookDataController : Controller
    {
        private readonly IBookData _bookData;

        public BookDataController(IBookData bookData)
        {
            _bookData = bookData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("CreateBook")]
        public async Task<ActionResult<bool>> CreateBook(BookRequest book)
        {

            var res = await _bookData.CreateBookAsync(book);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to create Book");
            }

            return CreatedAtAction(nameof(GetBook), res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<IEnumerable<BookRequest>>> GetAllCircles()
        {
            var res = await _bookData.GetBookAsync();

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        [HttpGet("GetBookById")]
        public async Task<ActionResult<BookRequest>> GetBook(int idBook)
        {
            var res = await _bookData.GetBookByIdAsync(idBook);

            return StatusCode(StatusCodes.Status200OK, res);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="idBook"></param>
        /// <returns></returns>
        [HttpPut("ModifyBook")]
        public async Task<IActionResult> UpdateCircle(BookRequest book, int idBook)
        {
            var res = await _bookData.UpdateBookAsync(book, idBook);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to update the Book");
            }

            return StatusCode(StatusCodes.Status200OK, "Book updated successfully");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int idBook)
        {
            var res = await _bookData.DeleteBookAsync(idBook);

            if (res == false)
            {
                return StatusCode(StatusCodes.Status424FailedDependency, "Failed to delete the Book");
            }

            return StatusCode(StatusCodes.Status200OK, "Book deleted successfully");
        }

    }
}
