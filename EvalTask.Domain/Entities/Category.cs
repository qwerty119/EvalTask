using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvalTask.Domain.Interfaces;
using Spells.Domain.Contracts;

namespace EvalTask.Domain.Entities
{
    public class Category : HasId<Guid>, ISoftDeletable, IAuditable
    {
        protected Category()
        {

        }

        public Category(string name, string description, string createdByUserId)
        {
            Name = name;
            Description = description;
            CreatedByUserId = createdByUserId;
            CreatedDate = DateTime.Now;
        }

        public string Name { get; protected set;}

        public string Description { get; protected set; }

        public List<Product> Products { get; set; } = new List<Product>();
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public string CreatedByUserId { get; set; }
        public User Creator { get; set; }
       
        public string UpdatedByUserId { get; set; }
        public User Changer { get; set; }
    }
}