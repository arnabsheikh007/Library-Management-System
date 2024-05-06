using Library_Managemet_System_API.Models;

namespace Library_Managemet_System_API.Repositories
{
    public interface IBorrowedBookRepository
    {
        void AddBorrowedBook(BorrowedBook borrowedBook);
        void DeleteBorrowedBook(int borrowId);
        IEnumerable<BorrowedBook> GetAllBorrowedBooks();
        BorrowedBook GetBorrowedBookById(int borrowId);
        void UpdateBorrowedBook(BorrowedBook borrowedBook);
    }
}