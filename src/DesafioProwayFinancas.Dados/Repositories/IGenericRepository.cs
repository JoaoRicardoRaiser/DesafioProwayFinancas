using DesafioProwayFinancas.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Dados.Repositories
{
    public interface IGenericRepository<T> where T:EntidadeBase
    {
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(Guid id);
        Task<List<T>> ObterPorIdAsync(List<Guid> ids);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
