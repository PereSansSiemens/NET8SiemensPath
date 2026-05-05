using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;

namespace VaquerSansPere.Backend.WebApi.Services.Interfaces
{
    public interface IBookData
    {
        List<Book> GetAllBooks();
        Book GetBook(int Isbn);

        Task<bool> CreateBookAsync(BookRequest book);
        Task<bool> UpdateBookAsync(BookRequest book, int idBook);
        Task<bool> DeleteBookAsync(int idBook);
        Task<List<BookEntity>> GetBookAsync();
        Task<BookEntity> GetBookByIdAsync(int idBook);
    }
}
