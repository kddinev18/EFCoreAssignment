using EFCoreAssignment.Domain.Interfaces;
using EFCoreAssignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordsController : ControllerBase
    {
        private readonly IBorrowRecordRepository _borrowRecordRepository;

        public BorrowRecordsController(IBorrowRecordRepository borrowRecordRepository)
        {
            _borrowRecordRepository = borrowRecordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowRecord>>> GetBorrowRecords()
        {
            var borrowRecords = await _borrowRecordRepository.GetAllAsync();
            return Ok(borrowRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRecord>> GetBorrowRecord(int id)
        {
            var borrowRecord = await _borrowRecordRepository.GetByIdAsync(id);

            if (borrowRecord == null)
            {
                return NotFound();
            }

            return Ok(borrowRecord);
        }

        [HttpPost]
        public async Task<ActionResult<BorrowRecord>> PostBorrowRecord(BorrowRecord borrowRecord)
        {
            await _borrowRecordRepository.AddAsync(borrowRecord);
            return CreatedAtAction(nameof(GetBorrowRecord), new { id = borrowRecord.BorrowRecordId }, borrowRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowRecord(int id, BorrowRecord borrowRecord)
        {
            if (id != borrowRecord.BorrowRecordId)
            {
                return BadRequest();
            }

            await _borrowRecordRepository.UpdateAsync(borrowRecord);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRecord(int id)
        {
            var borrowRecord = await _borrowRecordRepository.GetByIdAsync(id);
            if (borrowRecord == null)
            {
                return NotFound();
            }

            await _borrowRecordRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
