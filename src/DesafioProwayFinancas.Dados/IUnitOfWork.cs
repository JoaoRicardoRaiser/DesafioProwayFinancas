using System.Threading.Tasks;

namespace DesafioProwayFinancas.Dados
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task Rollback();
    }
}