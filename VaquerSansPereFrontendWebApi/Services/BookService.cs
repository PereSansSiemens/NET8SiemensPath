using Shared.Models;
using VaquerSansPereFrontendWebApi.Services.Interfaces;
namespace VaquerSansPereFrontendWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await httpClient.GetFromJsonAsync<Book[]>("/api/Letters/ShowAllBooks");
        }
    }
}
