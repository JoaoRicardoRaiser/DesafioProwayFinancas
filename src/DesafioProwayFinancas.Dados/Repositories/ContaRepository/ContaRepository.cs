using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DesafioProwayFinancas.Dados.Repositories.ContaRepository
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(DbContext dbContext): base(dbContext)
        {
        }
    }
}
