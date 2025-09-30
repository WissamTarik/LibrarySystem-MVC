using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Company.PL.Dtos
{
    public class CategoryDto
    {
        [DisplayName("Category Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
