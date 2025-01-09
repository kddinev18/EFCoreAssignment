using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _BookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _BookRepository.GetByAuthorIdAsync(authorId);
        }

        public async Task AddBookAsync(Book book)
        {
            await _BookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _BookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _BookRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
