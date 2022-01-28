using DesafioProwayFinancas.Dados.Models;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services
{
    public interface IContaService
    {
        Task CadastrarConta(CadastrarContaRequestModel model);
    }
}