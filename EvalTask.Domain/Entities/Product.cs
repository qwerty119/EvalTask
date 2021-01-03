using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvalTask.Domain.Interfaces;
using Spells.Domain.Contracts;

namespace EvalTask.Domain.Entities
{
    public class Product : HasId<Guid>, ISoftDeletable, IAuditable
    {
        protected Product()
        {
            
        }
        
        public Product(string name, Guid categoryId, string createdByUserId)
        {
            Name = name;
            CategoryId = categoryId;
            CreatedByUserId = createdByUserId;
            CreatedDate = DateTime.Now;
        }
        
        public string Name { get; protected set;}
        
        public string Description { get; set; }

        public string Specification { get; set; }
        
        public Guid CategoryId { get; protected set; }
        public Category Category { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public string CreatedByUserId { get; set; }
        public User Creator { get; set; }
       
        public string UpdatedByUserId { get; set; }
        public User Changer { get; set; }
    }
}