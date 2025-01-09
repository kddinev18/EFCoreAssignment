using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorService(IAuthorRepository AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _AuthorRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAuthorByOrderIdAsync(int AuthorId)
        {
            return await _AuthorRepository.GetByAuthorIdAsync(AuthorId);
        }

        public async Task AddAuthorAsync(Author Author)
        {
            _AuthorRepository.AddAsync(Author);
        }

        public async Task UpdateAuthorAsync(Author Author)
        {
            await _AuthorRepository.UpdateAsync(Author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _AuthorRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Author>> GetAllAuthorAsync()
        {
            throw new NotImplementedException();
        }
    }

}