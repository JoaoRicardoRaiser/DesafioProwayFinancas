using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Dados.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services
{
    public interface IContaService
    {
        Task CadastrarConta(CadastrarContaRequestModel model);
        Task AtualizarConta(Guid contaId, EditarContaRequestModel model);
        Task DeletarConta(Guid contaId);
        Task<List<Conta>> ObterTodasAsContas();
        Task TransferirEntreContas(TransferirEntreContasRequestModel model);
        Task<decimal> ObterSaldoTotal();
    }
}