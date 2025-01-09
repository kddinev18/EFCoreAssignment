using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreAssignment.Domain.Models;

namespace EFCoreAssignment.Domain.Interfaces
{
    public interface IBorrowRecordRepository
    {
        Task<IEnumerable<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord> GetByIdAsync(int id);
        Task AddAsync(BorrowRecord borrowRecord);
        Task UpdateAsync(BorrowRecord borrowRecord);
        Task DeleteAsync(int id);
    }
}