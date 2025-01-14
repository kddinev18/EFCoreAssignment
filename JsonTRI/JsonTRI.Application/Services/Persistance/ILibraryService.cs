using JsonTRI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services.Persistance
{
    public interface ILibraryService
    {
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task<Library> GetLibraryByIdAsync(int id);
        Task AddLibraryAsync(Library library);
        Task UpdateLibraryAsync(Library library);
        Task DeleteLibraryAsync(int id);
    }
}
