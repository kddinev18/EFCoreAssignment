using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Application.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _BorrowRecordRepository;

        public BorrowRecordService(IBorrowRecordRepository BorrowRecordRepository)
        {
            _BorrowRecordRepository = BorrowRecordRepository;
        }

        public async Task<IEnumerable<BorrowRecord>> GetAllBorrowRecordsAsync()
        {
            return await _BorrowRecordRepository.GetAllAsync();
        }

        public async Task<BorrowRecord> GetBorrowRecordByIdAsync(int id)
        {
            return await _BorrowRecordRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByBookIdAsync(int bookId)
        {
            return await _BorrowRecordRepository.GetByBookIdAsync(bookId);
        }

        public async Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByLibraryIdAsync(int libraryId)
        {
            return await _BorrowRecordRepository.GetByLibraryIdAsync(libraryId);
        }

        public async Task AddBorrowRecordAsync(BorrowRecord borrowRecord)
        {
            await _BorrowRecordRepository.AddAsync(borrowRecord);
        }

        public async Task UpdateBorrowRecordAsync(BorrowRecord borrowRecord)
        {
            await _BorrowRecordRepository.UpdateAsync(borrowRecord);
        }

        public async Task DeleteBorrowRecordAsync(int id)
        {
            await _BorrowRecordRepository.DeleteAsync(id);
        }
    }
}
