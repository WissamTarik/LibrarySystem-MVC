using Library.Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Company.BLL.Interfaces
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        //IEnumerable<Book> GetAll();
        //Book? GetById(int id);
        //int Add(Book model);
        //int Update(Book model);
        //int Delete(Book model);
        IEnumerable<Book>? GetBookByName(string title);
    }
}
