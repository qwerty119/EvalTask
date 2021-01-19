using System.ComponentModel.DataAnnotations;

namespace EvalTask.Dto.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set;}

        public string Description { get; set; }
    }
}