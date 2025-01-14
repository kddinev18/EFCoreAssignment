using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Infrastructure.Service;
using Task.Domain.DTO;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var assignments = await _assignmentService.GetAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }
        
        [HttpPost]
        public async Task<ActionResult<AssignmentDto>> CreateAssignment([FromBody] AssignmentDto assignmentDto)
        {
            var createdAssignment = await _assignmentService.CreateAssignmentAsync(assignmentDto);
            return CreatedAtAction(nameof(GetAssignment), new { id = createdAssignment.AssignmentId }, createdAssignment);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AssignmentDto assignmentDto)
        {
            if (id != assignmentDto.AssignmentId)
            {
                return BadRequest();
            }

            await _assignmentService.UpdateAssignmentAsync(id, assignmentDto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            await _assignmentService.DeleteAssignmentAsync(id);
            return NoContent();
        }
    }
}
