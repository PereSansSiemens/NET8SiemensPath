using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Request;
using Shared.Models;
using Shared.Models.Entities;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Services
{
    public class BookData : IBookData
    {
        private readonly AppDbContext _dbContext;
        public BookData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {            
            return books.FirstOrDefault(x => x.Isbn == id);
        }

        public async Task<bool> CreateBookAsync(BookRequest book)
        {
            try
            {
                var completeBook = new BookEntity
                {
                    Title = book.Title,
                    Author = book.Author,
                    PageNum = book.PageNum,
                    Timestamp = DateTime.UtcNow
                };
                _dbContext.Add(completeBook);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBookAsync(BookRequest book, int idBook)
        {
            try
            {
                var bookToChange = await _dbContext.Books.FindAsync(idBook);

                if (bookToChange != null)
                {
                    bookToChange.Title = book.Title;
                    bookToChange.Author = book.Author;
                    bookToChange.PageNum = book.PageNum;

                    _dbContext.Entry(bookToChange).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookAsync(int idBook)
        {
            try
            {
                var book = await _dbContext.Books.FindAsync(idBook);

                if (book != null)
                {
                    _dbContext.Remove(book);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BookEntity>> GetBookAsync()
        {
            try
            {
                var books = await _dbContext.Books.ToListAsync();

                return books;
            }
            catch
            {
                return new List<BookEntity>();
            }
        }

        public async Task<BookEntity> GetBookByIdAsync(int idBook)
        {
            try
            {
                var circle = await _dbContext.Books.FindAsync(idBook);

                if (circle == null)
                {
                    return null;
                }

                return circle;

            }
            catch (Exception)
            {
                return null;
            }
        }

        List<Book> books = new List<Book>
        {
            new Book
            {
                Isbn = 1,
                Title = "The great Gatsby",
                Author = "F. Scott Fitzgerald",
                PageNum = 100,
            },
            new Book
            {
                Isbn = 2,
                 Title = "To kill a Mockingbird",
                Author = "Harper Lee",
                PageNum = 200,
            },
            new Book
            {
                Isbn = 3,
                Title = "1984",
                Author = "George Orwell",
                PageNum = 300,
            },
            new Book
            {
                Isbn = 4,
                Title = "Frankestein",
                Author = "Mary Shelley",
                PageNum = 400,
            }
        };
    }
}
