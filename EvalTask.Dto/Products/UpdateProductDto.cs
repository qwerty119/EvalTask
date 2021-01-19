using System;

namespace EvalTask.Dto.Products
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set;}
        
        public string Description { get; set; }

        public string Specification { get; set; }

        public Guid CategoryId { get; set; }
    }
}