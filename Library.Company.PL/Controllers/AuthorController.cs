using Library.Company.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Company.PL.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository=authorRepository;
        }
        public IActionResult Index()
        {
            var Authors=_authorRepository.GetAll();
            return View(Authors);
        }
    }
}
