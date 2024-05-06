using Library_Managemet_System_API.Models;

namespace Library_Managemet_System_API.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();
        void UpdateBook(Book book);
    }
}