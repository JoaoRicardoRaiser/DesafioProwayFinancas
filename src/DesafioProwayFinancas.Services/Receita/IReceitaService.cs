using DesafioProwayFinancas.Dados.Models;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services
{
    public interface IReceitaService
    {
        Task CadastrarReceita(CadastrarReceitaRequestModel model);
    }
}