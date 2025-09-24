using Library.Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Company.BLL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);

        int Add(Category model);
        int Update(Category model);
        int Delete(Category model);
    }
}
