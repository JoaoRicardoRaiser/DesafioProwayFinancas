using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Dados.Repositories.ContaRepository
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(DbContext dbContext): base(dbContext)
        {
        }

        public override Task<List<Conta>> ObterTodosAsync()
        {
            return _dbSet
                .AsNoTracking()
                .Include(x => x.Receitas)
                .Include(x => x.Despesas)
                .ToListAsync();
        }
    }
}
