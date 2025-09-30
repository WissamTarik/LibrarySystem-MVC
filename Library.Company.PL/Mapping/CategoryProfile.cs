using AutoMapper;
using Library.Company.DAL.Models;
using Library.Company.PL.Dtos;

namespace Library.Company.PL.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
