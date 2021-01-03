using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Spells.Domain.Contracts;

namespace EvalTask.Domain.Entities
{
    public class Category : HasId<Guid>
    {
        protected Category()
        {

        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; protected set;}

        public string Description { get; protected set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}