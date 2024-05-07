using Library_Managemet_System_API.Models;
using Library_Managemet_System_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managemet_System_API.Controllers
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
        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAuthors();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _authorRepository.UpdateAuthor(author);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Author> PostAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);

            return NoContent();
        }   
    }
}
