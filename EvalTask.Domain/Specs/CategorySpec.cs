using System;
using EvalTask.Domain.Entities;
using Spells.Domain;

namespace EvalTask.Domain.Specs
{
    public static class CategorySpec
    {
        public static Spec<Category> ById(Guid categoryId) 
            => new Spec<Category>(x => x.Id == categoryId);
        
        public static Spec<Category> NotDeleted() 
            => new Spec<Category>(x => !x.IsDeleted);
    }
}