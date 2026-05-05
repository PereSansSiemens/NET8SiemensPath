using Shared.Models;

namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
