using Library.Company.BLL.Interfaces;
using Library.Company.DAL.Models;
using Library.Company.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Company.PL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
           _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var Books = _bookRepository.GetAll();
            return View(Books);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookDto model)
        {
            if (ModelState.IsValid)
            {
                var Book = new Book()
                {
                    ISBN = model.ISBN,
                    Title = model.Title,
                    PublishedYear = model.PublishedYear
                };
               int Count= _bookRepository.Add(Book);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int ? id)
        {
            if (id is null) return BadRequest("Invalid id");
            var Book = _bookRepository.GetById(id.Value);
            if (Book != null) {
                //var bookDto = new BookDto()
                //{
                //    ISBN = Book.ISBN,
                //    Title = Book.Title,
                //    PublishedYear = Book.PublishedYear
                //};
                return View(Book);
             
            }
            return NotFound(new
            {
                StatusCode=404,
                Message=$"Book with id {id} is not found"
            });

        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            if (id is null) return BadRequest("Invalid id");
            var Book = _bookRepository.GetById(id.Value);
            if (Book != null)
            {

                var bookDtos = new BookDto()
                {
                    ISBN = Book.ISBN,
                    Title = Book.Title,
                    PublishedYear = Book.PublishedYear
                };
                return View(bookDtos);
            }
            return NotFound(new
            {
                StatusCode = 404,
                message = "Not found"
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int ?id,BookDto bookDto)
        {
            if (id is null) return BadRequest("Invalid id");
            if (ModelState.IsValid)
            {
                var Book = new Book()
                {
                    Id = id.Value,
                    ISBN = bookDto.ISBN,
                    Title = bookDto.Title,
                    PublishedYear = bookDto.PublishedYear

                };
                int Count=_bookRepository.Update(Book);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(bookDto);
        }
    
       public IActionResult Delete([FromRoute] int ? id )
        {
            if (id is null) return BadRequest("Invalid id");

            var Book = _bookRepository.GetById(id.Value);
            if(Book is not null)
            {
              int Count=  _bookRepository.Delete(Book);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
