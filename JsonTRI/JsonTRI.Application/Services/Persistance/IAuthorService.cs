using JsonTRI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services.Persistance
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<IEnumerable<Author>> GetAuthorByOrderIdAsync(int AuthorId);
        Task AddAuthorAsync(Author Name);
        Task UpdateAuthorAsync(Author Name);
        Task DeleteAuthorAsync(int id);
    }
}