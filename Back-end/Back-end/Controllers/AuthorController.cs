using Back_end.Models.DTO;
using Back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorDBService _authorDBService;

        public AuthorController(IAuthorDBService authorDBService)
        {
            _authorDBService = authorDBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorList()
        {
            IList<AuthorDTO> authors = await _authorDBService.GetAuthorList();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            AuthorDTO author = await _authorDBService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            return Ok(await _authorDBService.DeleteAuthor(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthor(AuthorDTO author)
        {
            return Ok(await _authorDBService.PostAuthor(author));
        }

        [HttpPut]
        public async Task<IActionResult> PutAuthor(AuthorDTO author)
        {
            return Ok(await _authorDBService.PutAuthor(author));
        }
    }
}
