using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DesafioProwayFinancas.Dados.Repositories.ReceitaRepository
{
    public class ReceitaRepository: GenericRepository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(DbContext dbContext): base(dbContext)
        {
        }
    }
}
