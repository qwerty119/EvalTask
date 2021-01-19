using System;
using EvalTask.Domain.Entities;
using Spells.Domain;

namespace EvalTask.Domain.Specs
{
    public static class ProductSpec
    {
        public static Spec<Product> ById(Guid productId) 
            => new Spec<Product>(x => x.Id == productId);
        
        public static Spec<Product> NotDeleted() 
            => new Spec<Product>(x => !x.IsDeleted);

    }

}