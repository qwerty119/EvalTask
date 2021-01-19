using System;
using EvalTask.Dto.Accounts;
using EvalTask.Dto.Categories;

namespace EvalTask.Dto.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set;}
        
        public string Description { get; set; }

        public string Specification { get; set; }
        
        public CategoryDto Category { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public UserDto Creator { get; set; }
       
        public UserDto Changer { get; set; }
    }
}