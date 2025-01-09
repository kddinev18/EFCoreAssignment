using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreAssignment.Domain.Models;

namespace EFCoreAssignment.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllAsync();
        Task<Library> GetByIdAsync(int id);
        Task AddAsync(Library library);
        Task UpdateAsync(Library library);
        Task DeleteAsync(int id);
    }
}