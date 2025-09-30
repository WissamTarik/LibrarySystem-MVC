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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        //private readonly LibraryDbContext _context;
        public CategoryRepository(LibraryDbContext libraryDbContext):base(libraryDbContext)
        {
         //_context= libraryDbContext;   
        }
        //public IEnumerable<Category> GetAll()
        //{
        //    return _context.Categories.ToList();
        //}

        //public Category? GetById(int id)
        //{
        //    return _context.Categories.Find(id);
        //}

        //public int Add(Category model)
        //{
        //    _context.Categories.Add(model);
        //    return _context.SaveChanges();
        //}
        //public int Update(Category model)
        //{
        //    _context.Categories.Update(model);
        //    return _context.SaveChanges();
        //}
        //public int Delete(Category model)
        //{
        //    _context.Categories.Remove(model);
        //    return _context.SaveChanges();
        //}

     
        
    }
}
