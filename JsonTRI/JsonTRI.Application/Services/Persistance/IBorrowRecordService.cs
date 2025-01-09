using JsonTRI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services.Persistance
{
    public interface IBorrowRecordService
    {
        Task<IEnumerable<BorrowRecord>> GetAllBorrowRecordsAsync();
        Task<BorrowRecord> GetBorrowRecordByIdAsync(int id);
        Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByBookIdAsync(int bookId);
        Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByLibraryIdAsync(int libraryId);
        Task AddBorrowRecordAsync(BorrowRecord borrowRecord);
        Task UpdateBorrowRecordAsync(BorrowRecord borrowRecord);
        Task DeleteBorrowRecordAsync(int id);
    }
}
