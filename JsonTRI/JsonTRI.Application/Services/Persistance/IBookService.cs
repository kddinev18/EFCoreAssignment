using JsonTRI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services.Persistance
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
