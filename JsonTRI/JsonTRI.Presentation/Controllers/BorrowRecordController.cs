using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowRecordController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService;

        public BorrowRecordController(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }

        [HttpGet]
        public async Task<IEnumerable<BorrowRecord>> GetAll()
        {
            return await _borrowRecordService.GetAllBorrowRecordsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRecord>> GetById(int id)
        {
            var borrowRecord = await _borrowRecordService.GetBorrowRecordByIdAsync(id);
            if (borrowRecord == null)
                return NotFound();
            return borrowRecord;
        }

        [HttpPost]
        public async Task<ActionResult> Add(BorrowRecord borrowRecord)
        {
            await _borrowRecordService.AddBorrowRecordAsync(borrowRecord);
            return CreatedAtAction(nameof(GetById), new { id = borrowRecord.BorrowRecordId }, borrowRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BorrowRecord borrowRecord)
        {
            if (id != borrowRecord.BorrowRecordId)
                return BadRequest();

            await _borrowRecordService.UpdateBorrowRecordAsync(borrowRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _borrowRecordService.DeleteBorrowRecordAsync(id);
            return NoContent();
        }
    }
}
