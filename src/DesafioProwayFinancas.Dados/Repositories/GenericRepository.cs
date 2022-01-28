using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Dados.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntidadeBase
    {

        protected DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }
        
        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<T> ObterPorIdAsync(Guid id)
        {
            return _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> ObterTodosAsync()
        {
            return _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
