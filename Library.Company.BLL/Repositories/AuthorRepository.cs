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
    public class AuthorRepository : GenericRepository<Author>,IAuthorRepository
    {
        //private readonly LibraryDbContext _context;
        public AuthorRepository(LibraryDbContext libraryDbContext):base(libraryDbContext)
        {
            //_context = libraryDbContext;
            
        }
        //public IEnumerable<Author> GetAll()
        //{
        //    return _context.Authors.ToList();
        //}

        //public Author? GetById(int id)
        //{
        //    return _context.Authors.Find(id);
        //}

        //public int Add(Author model)
        //{
        //  _context.Add(model);
        //    return _context.SaveChanges();
        //}

        //public int Update(Author model)
        //{
        //    _context.Update(model);
        //    return _context.SaveChanges();
        //}
        //public int Delete(Author model)
        //{
        //    _context.Remove(model);
        //    return _context.SaveChanges();
        //}

      
       
    }
}
