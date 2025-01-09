using JsonTRI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetByAuthorIdAsync(int BookId);
        Task AddAsync(Book author);
        Task UpdateAsync(Book author);
        Task DeleteAsync(int id);
    }
}
