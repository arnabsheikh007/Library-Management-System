using Library_Managemet_System_API.Data;
using Library_Managemet_System_API.Models;

namespace Library_Managemet_System_API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }
        public Author GetAuthor(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.AuthorId == id);
        }
        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
