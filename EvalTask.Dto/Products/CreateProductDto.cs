using System;

namespace EvalTask.Dto.Products
{
    public class CreateProductDto
    {
        public string Name { get; set;}
        
        public string Description { get; set; }

        public string Specification { get; set; }

        public Guid CategoryId { get; set; }
    }
}