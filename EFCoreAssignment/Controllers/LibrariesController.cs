using EFCoreAssignment.Domain.Interfaces;
using EFCoreAssignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibrariesController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibraries()
        {
            var libraries = await _libraryRepository.GetAllAsync();
            return Ok(libraries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            var library = await _libraryRepository.GetByIdAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            await _libraryRepository.AddAsync(library);
            return CreatedAtAction(nameof(GetLibrary), new { id = library.LibraryId }, library);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, Library library)
        {
            if (id != library.LibraryId)
            {
                return BadRequest();
            }

            await _libraryRepository.UpdateAsync(library);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            var library = await _libraryRepository.GetByIdAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            await _libraryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
