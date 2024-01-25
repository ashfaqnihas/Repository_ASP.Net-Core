//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Shop.Domain.Models;

namespace T_Shop.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            public DbSet<Category> Category { get; set; }
        
    }
}