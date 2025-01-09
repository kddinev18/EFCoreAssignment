using JsonTRI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Domain.Interfaces
{
    public interface IBorrowRecordRepository
    {
        Task<IEnumerable<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord> GetByIdAsync(int id);
        Task<IEnumerable<BorrowRecord>> GetByBookIdAsync(int bookId);
        Task<IEnumerable<BorrowRecord>> GetByLibraryIdAsync(int libraryId);
        Task AddAsync(BorrowRecord borrowRecord);
        Task UpdateAsync(BorrowRecord borrowRecord);
        Task DeleteAsync(int id);
    }
}
