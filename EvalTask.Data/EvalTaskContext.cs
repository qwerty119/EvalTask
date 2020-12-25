using System;
using EvalTask.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Data
{
    public class EvalTaskContext : IdentityDbContext<User>
    {
        public EvalTaskContext(DbContextOptions<EvalTaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}