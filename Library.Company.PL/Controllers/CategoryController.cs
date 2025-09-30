using AutoMapper;
using Library.Company.BLL.Interfaces;
using Library.Company.DAL.Data.Contexts;
using Library.Company.DAL.Models;
using Library.Company.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Company.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var Categories = _categoryRepository.GetAll();
            return View(Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDto model)
        {
            if (ModelState.IsValid)
            {

                var Category = _mapper.Map<Category>(model);
                int Count = _categoryRepository.Add(Category);
                if (Count > 0) return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpGet]
        public IActionResult Details([FromRoute] int? id, string ViewName = "Details")
        {
            if (id is null) return BadRequest("Invalid id");


            Category? Category = _categoryRepository.GetById(id.Value);
            if (Category is null) return NotFound(new
            {
                StatusCode = 404,
                message = $"There is no department with id :{id}"
            });
            if (ViewName == "Details" || ViewName=="Delete")
                return View(ViewName, Category);
            var model = _mapper.Map<CategoryDto>(Category);
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, CategoryDto model)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                var Category = new Category()
                {
                    Id = id.Value,
                    Name = model.Name
                };
                int count = _categoryRepository.Update(Category);
                if (count > 0) return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {

            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, Category model)
        {
            if (id is null) return BadRequest("Invalid id");
            if (ModelState.IsValid)
            {
                var Category = new Category()
                {
                    Name = model.Name,
                    Id = id.Value
                };
              
                int count = _categoryRepository.Delete(Category);
                if (count > 0) return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}
