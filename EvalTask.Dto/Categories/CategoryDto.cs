using System;
using EvalTask.Dto.Accounts;

namespace EvalTask.Dto.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set;}
        
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public UserDto Creator { get; set; }
       
        public UserDto Changer { get; set; }
    }
}