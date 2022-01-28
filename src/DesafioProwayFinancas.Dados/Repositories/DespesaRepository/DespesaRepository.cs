using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DesafioProwayFinancas.Dados.Repositories.DespesaRepository
{
    public class DespesaRepository: GenericRepository<Despesa>, IDespesaRepository
    {
        public DespesaRepository(DbContext dbContext): base(dbContext)
        {
        }
    }
}
