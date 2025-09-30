using AutoMapper;
using Library.Company.BLL.Interfaces;
using Library.Company.DAL.Models;
using Library.Company.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Company.PL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository,IMapper mapper)
        {
           _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public IActionResult Index(string? SearchName)
        {
            List<Book> Books;
            if (string.IsNullOrEmpty(SearchName))
            {

             Books = _bookRepository.GetAll().ToList();
            }
            else
            {

            Books=_bookRepository.GetBookByName(SearchName).ToList();
            }
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
           
                var Book=_mapper.Map<Book>(model);
               int Count= _bookRepository.Add(Book);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int ? id,string ViewName="Details")
        {
            if (id is null) return BadRequest("Invalid id");
            var Book = _bookRepository.GetById(id.Value);
            if (Book != null) {
            
                if(ViewName=="Details")
                return View(ViewName,Book);
                else
                {
                    var bookDtos=_mapper.Map<BookDto>(Book);
                    return View(ViewName,bookDtos);
                }
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
                return Details(id, "Edit");
             
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
