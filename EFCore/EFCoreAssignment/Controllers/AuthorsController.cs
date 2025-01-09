using EFCoreAssignment.Domain.Models;
using EFCoreAssignment.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Author author)
        {
            await _authorRepository.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = author.AuthorId }, author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Author author)
        {
            if (id != author.AuthorId) return BadRequest();
            await _authorRepository.UpdateAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}