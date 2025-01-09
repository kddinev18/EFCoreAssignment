using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _LibraryRepository;

        public LibraryService(ILibraryRepository LibraryRepository)
        {
            _LibraryRepository = LibraryRepository;
        }

        public async Task<IEnumerable<Library>> GetAllLibrariesAsync()
        {
            return await _LibraryRepository.GetAllAsync();
        }

        public async Task<Library> GetLibraryByIdAsync(int id)
        {
            return await _LibraryRepository.GetByIdAsync(id);
        }

        public async Task AddLibraryAsync(Library library)
        {
            await _LibraryRepository.AddAsync(library);
        }

        public async Task UpdateLibraryAsync(Library library)
        {
            await _LibraryRepository.UpdateAsync(library);
        }

        public async Task DeleteLibraryAsync(int id)
        {
            await _LibraryRepository.DeleteAsync(id);
        }
    }
}
