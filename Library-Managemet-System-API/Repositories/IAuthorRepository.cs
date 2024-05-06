using Library_Managemet_System_API.Models;

namespace Library_Managemet_System_API.Repositories
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        void DeleteAuthor(int id);
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthors();
        void UpdateAuthor(Author author);
    }
}