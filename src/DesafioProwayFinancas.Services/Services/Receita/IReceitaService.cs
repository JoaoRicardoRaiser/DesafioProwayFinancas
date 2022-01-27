using DesafioProwayFinancas.Dados.Models;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services.Services.Receita
{
    public interface IReceitaService
    {
        Task CadastrarReceita(CadastrarReceitaModel model);
    }
}