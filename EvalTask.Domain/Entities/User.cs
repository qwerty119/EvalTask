using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EvalTask.Domain.Entities
{
    public class User : IdentityUser
    {
        public List<Product> CreatedProducts { get; set; } = new List<Product>();
        public List<Product> UpdatedProducts { get; set; } = new List<Product>();
        
        public List<Category> CreatedCategories { get; set; } = new List<Category>();
        public List<Category> UpdatedCategories { get; set; } = new List<Category>();
        
        
    }
}