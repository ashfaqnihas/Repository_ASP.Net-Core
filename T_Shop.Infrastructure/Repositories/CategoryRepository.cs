using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Shop.Domain.Contracts;
using T_Shop.Domain.Models;
using T_Shop.Infrastructure.DbContexts;

namespace T_Shop.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)  
        {
            
        }
        public async Task UpdateAsync(Category category)
        {
            _dbcontext.Update(category);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
