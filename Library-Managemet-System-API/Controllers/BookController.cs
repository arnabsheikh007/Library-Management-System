using Library_Managemet_System_API.Models;
using Library_Managemet_System_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managemet_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPut("{id}")]
        public IActionResult EditBook(int id, Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            _bookRepository.UpdateBook(book);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            _bookRepository.AddBook(book);

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);

            return NoContent();
        }
    }
}
