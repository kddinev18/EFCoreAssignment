using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonTRI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Library>> GetAll()
        {
            return await _libraryService.GetAllLibrariesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetById(int id)
        {
            var library = await _libraryService.GetLibraryByIdAsync(id);
            if (library == null)
                return NotFound();
            return library;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Library library)
        {
            await _libraryService.AddLibraryAsync(library);
            return CreatedAtAction(nameof(GetById), new { id = library.LibraryId }, library);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Library library)
        {
            if (id != library.LibraryId)
                return BadRequest();

            await _libraryService.UpdateLibraryAsync(library);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libraryService.DeleteLibraryAsync(id);
            return NoContent();
        }
    }
}
