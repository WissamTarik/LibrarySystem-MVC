using Library.Company.BLL.Interfaces;
using Library.Company.DAL.Data.Contexts;
using Library.Company.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Company.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private readonly LibraryDbContext _context;
        public GenericRepository(LibraryDbContext libraryDbContext)
        {
            _context=libraryDbContext;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Add(T model)
        {
            _context.Add(model);
            return _context.SaveChanges();
        }

        public int Update(T model)
        {
            _context.Update(model);
            return _context.SaveChanges();
        }
        public int Delete(T model)
        {
            _context.Remove(model);
            return _context.SaveChanges();
        }


    }
}
