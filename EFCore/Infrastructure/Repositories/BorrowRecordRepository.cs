using EFCoreAssignment.Domain.Interfaces;
using EFCoreAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace EFCoreAssignment.Infrastructure.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly AppDbContext _dbContext;

        public BorrowRecordRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BorrowRecord>> GetAllAsync()
        {
            return await _dbContext.BorrowRecords.ToListAsync();
        }

        public async Task<BorrowRecord> GetByIdAsync(int id)
        {
            return await _dbContext.BorrowRecords.FindAsync(id);
        }

        public async Task AddAsync(BorrowRecord borrowRecord)
        {
            await _dbContext.BorrowRecords.AddAsync(borrowRecord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowRecord borrowRecord)
        {
            _dbContext.BorrowRecords.Update(borrowRecord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var borrowRecord = await _dbContext.BorrowRecords.FindAsync(id);
            if (borrowRecord != null)
            {
                _dbContext.BorrowRecords.Remove(borrowRecord);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}