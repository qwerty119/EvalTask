using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Spells.Domain.Contracts;

namespace EvalTask.Domain.Entities
{
    public class Product : HasId<Guid>
    {
        protected Product()
        {
            
        }
        
        public Product(string name, Guid categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
        
        public string Name { get; protected set;}
        
        public string Description { get; set; }

        public string Specification { get; set; }
        
        public Guid CategoryId { get; protected set; }
        public Category Category { get; set; }
        
    }
}