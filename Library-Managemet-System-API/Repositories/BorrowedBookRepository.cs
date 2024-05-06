using System;
using System.Collections.Generic;
using System.Linq;
using Library_Managemet_System_API.Data;
using Library_Managemet_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Managemet_System_API.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly DataContext _context;

        public BorrowedBookRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<BorrowedBook> GetAllBorrowedBooks()
        {
            return _context.BorrowedBooks.Include(b => b.Member).Include(b => b.Book).ToList();
        }

        public BorrowedBook GetBorrowedBookById(int borrowId)
        {
            return _context.BorrowedBooks.Include(b => b.Member).Include(b => b.Book)
                                         .FirstOrDefault(b => b.BorrowID == borrowId);
        }

        public void AddBorrowedBook(BorrowedBook borrowedBook)
        {
            if (borrowedBook == null)
            {
                throw new ArgumentNullException(nameof(borrowedBook));
            }

            _context.BorrowedBooks.Add(borrowedBook);
            _context.SaveChanges();
        }

        public void UpdateBorrowedBook(BorrowedBook borrowedBook)
        {
            if (borrowedBook == null)
            {
                throw new ArgumentNullException(nameof(borrowedBook));
            }

            _context.Entry(borrowedBook).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBorrowedBook(int borrowId)
        {
            var borrowedBookToDelete = _context.BorrowedBooks.FirstOrDefault(b => b.BorrowID == borrowId);
            if (borrowedBookToDelete != null)
            {
                _context.BorrowedBooks.Remove(borrowedBookToDelete);
                _context.SaveChanges();
            }
        }
    }
}
