using System;
using EvalTask.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spells.Extensions;

namespace EvalTask.Data
{
    public class EvalTaskContext : IdentityDbContext<User>
    {
        public EvalTaskContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasIndex(x => x.Id)
                .IsUnique();

            // builder.Entity<Product>()
            //     .Property(x => x.CategoryId)
            //     .IsRequired();

            builder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
            
            builder.Entity<Category>()
                .HasIndex(x => x.Id)
                .IsUnique();
            
            builder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();
            
            builder.Entity<Category>()
                .Do(CategorySeed);
            
            builder.Entity<Product>()
                .Do(ProductSeed);
        }
        
        // "e0bc9e7a-67e1-4d46-9605-13daa1908a86"
        // "0ed6a80b-f50e-4a6e-8fe9-a7242f78cf1e" 
        protected void CategorySeed(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category("TestCat", "Foo Bar")
                {
                    Id = Guid.Parse("012ee0ef-e051-4e04-acc9-07ee03898f93")
                }
            );
        }
        
        protected void ProductSeed(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product("TestProd", new Guid("012ee0ef-e051-4e04-acc9-07ee03898f93"))
                {
                    Id = Guid.Parse("e0bc9e7a-67e1-4d46-9605-13daa1908a86"),
                    Description = "Foo Bar",
                    Specification = "{height: \"5\", width: \"10\"}"
                }
            );
        }
    }
}