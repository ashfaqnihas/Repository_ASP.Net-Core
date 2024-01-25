using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using T_Shop.Domain.Common;
using T_Shop.Domain.Contracts;
using T_Shop.Infrastructure.DbContexts;

namespace T_Shop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbcontext;

        public GenericRepository(ApplicationDbContext context)
        {

            _dbcontext = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
          var createEntity = await _dbcontext.Set<T>().AddAsync(entity);
           await _dbcontext.SaveChangesAsync();
            return createEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condtion)
        {
            return await _dbcontext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condtion);
        }
    }

}
