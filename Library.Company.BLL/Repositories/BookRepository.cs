using Library.Company.BLL.Interfaces;
using Library.Company.DAL.Data.Contexts;
using Library.Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Company.BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }
        public IEnumerable<Book> GetAll()
        {
           return _context.Books.ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public int Add(Book model)
        {
             _context.Books.Add(model);
            return _context.SaveChanges();
        }
        public int Update(Book model)
        {
            _context.Books.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Book model)
        {
            _context.Books.Remove(model);
            return _context.SaveChanges();
        }

      
    }
}
