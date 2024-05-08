using Library_Managemet_System_API.Models;
using Library_Managemet_System_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managemet_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowController : ControllerBase
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;

        public BookBorrowController(IBorrowedBookRepository borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        [HttpGet]
        public IEnumerable<BorrowedBook> GetHistory()
        {
            return _borrowedBookRepository.GetAllBorrowedBooks();
        }

        [HttpGet]
        [Route("{borrowId}")]
        public BorrowedBook GetHistoryById(int borrowId)
        {
            return _borrowedBookRepository.GetBorrowedBookById(borrowId);
        }

        [HttpPost]
        public IActionResult BorrowBook(BorrowedBook borrowedBook)
        {
            _borrowedBookRepository.AddBorrowedBook(borrowedBook);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        [Route("return/{borrowId}")]
        public IActionResult ReturnBook(int borrowId)
        {
            var borrowedBook = _borrowedBookRepository.GetBorrowedBookById(borrowId);

            if (borrowedBook == null)
            {
                return NotFound();
            }
            borrowedBook.Status = "returned";
            borrowedBook.ReturnDate = DateTime.Now;

            _borrowedBookRepository.UpdateBorrowedBook(borrowedBook);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
