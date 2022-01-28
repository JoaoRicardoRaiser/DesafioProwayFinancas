using DesafioProwayFinancas.CrossCutting.Exceptions;
using DesafioProwayFinancas.Dados;
using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Dados.Repositories.ContaRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services
{
    public class ContaService: IContaService
    {
        private readonly ILogger<ContaService> _logger;
        private readonly IContaRepository _contaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContaService(
            ILogger<ContaService> logger,
            IContaRepository contaRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _contaRepository = contaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarConta(CadastrarContaRequestModel model)
        {
            // No futuro quando adicionar pessoa, fazer validação caso a conta já exista, pelas informações do model.
            try
            {
                _logger.LogInformation($"Iniciando o cadastro da {nameof(Conta)}"); //No futuro, adicionar pessoa, eai melhorar o log.

                var conta = new Conta(model);

                await _contaRepository.Create(conta);

                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Finalizando o cadastro da {nameof(Conta)}"); //No futuro, adicionar pessoa, eai melhorar o log.
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao cadastrar {nameof(Conta)}" +
                    $" - Motivo: {e.Message}"); //No futuro, adicionar pessoa, eai melhorar o log.
                throw;
            }
        }

        public async Task AtualizarConta(Guid contaId ,EditarContaRequestModel model)
        {
            try
            {
                _logger.LogInformation($"Iniciando edição da {nameof(Conta)} com Id '{contaId}'"); //No futuro, adicionar pessoa, eai melhorar o log.

                var conta = await _contaRepository.ObterPorIdAsync(contaId);
                if (conta == null)
                {
                    throw new ObjetoNaoEncontradoException($"Não foi possível encontrar {nameof(Conta)} com Id '{contaId}'");
                }

                conta.Atualizar(model.Saldo, model.TipoConta, model.InstituicaoFinanceira);

                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Finalizando edição da {nameof(Conta)} com Id '{contaId}'"); //No futuro, adicionar pessoa, eai melhorar o log.
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao editar a {nameof(Conta)} com ID '{contaId}'" +
                    $" - Motivo: {e.Message}"); //No futuro, adicionar pessoa, eai melhorar o log.
                throw;
            }
        }

        public async Task DeletarConta(Guid contaId)
        {
            try
            {
                _logger.LogInformation($"Iniciando exclusão da {nameof(Conta)} com Id '{contaId}'"); //No futuro, adicionar pessoa, eai melhorar o log.

                var conta = await _contaRepository.ObterPorIdAsync(contaId);
                if (conta == null)
                {
                    throw new ObjetoNaoEncontradoException($"Não foi possível encontrar {nameof(Conta)} com Id '{contaId}'");
                }

                _contaRepository.Delete(conta);
                
                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Finalizando exclusão da {nameof(Conta)} com Id '{contaId}'"); //No futuro, adicionar pessoa, eai melhorar o log.
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao excluir a {nameof(Conta)} com ID '{contaId}'" +
                    $" - Motivo: {e.Message}"); //No futuro, adicionar pessoa, eai melhorar o log.
                throw;
            }
        }

        public async Task<List<Conta>> ObterTodasAsContas()
        {
            try
            {
                _logger.LogInformation($"Iniciando busca de todas as {nameof(Conta)}s"); //No futuro, adicionar pessoa, eai melhorar o log.

                var contas = await _contaRepository.ObterTodosAsync();

                _logger.LogInformation($"Finalizando busca de todas as {nameof(Conta)}s"); //No futuro, adicionar pessoa, eai melhorar o log.

                return contas;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao listar todas as {nameof(Conta)}s" +
                    $" - Motivo: {e.Message}"); //No futuro, adicionar pessoa, eai melhorar o log.
                throw;
            }
        }

        public async Task TransferirEntreContas(TransferirEntreContasRequestModel model)
        {
            try
            {
                _logger.LogInformation($"Iniciando a transferencia da quantia R${model.Valor} da {nameof(Conta)} {model.IdContaOrigem} para a {nameof(Conta)} {model.IdContaDestino}");
                
                var contasIds = new List<Guid> { model.IdContaOrigem, model.IdContaDestino };
                var contas = await _contaRepository.ObterPorIdAsync(contasIds);

                var contaOrigem = contas.SingleOrDefault(x => x.Id == model.IdContaOrigem);
                if(contaOrigem == null)
                {
                    throw new ObjetoNaoEncontradoException($"Não foi possível encontrar {nameof(Conta)} com o Id '{model.IdContaOrigem}'");
                }

                var contaDestino = contas.SingleOrDefault(x => x.Id == model.IdContaDestino);
                if (contaDestino == null)
                {
                    throw new ObjetoNaoEncontradoException($"Não foi possível encontrar {nameof(Conta)} com o Id '{model.IdContaDestino}'");
                }

                contaOrigem.RetirarSaldo(model.Valor);
                contaDestino.AdicionarSaldo(model.Valor);

                await _unitOfWork.CommitAsync();
                _logger.LogInformation($"Finalizando a transferencia da quantia R${model.Valor} da {nameof(Conta)} '{model.IdContaOrigem}' para a {nameof(Conta)} '{model.IdContaDestino}'");
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao transferir a quantia de R${model.Valor} da {nameof(Conta)} '{model.IdContaOrigem}' para a {nameof(Conta)} '{model.IdContaDestino}'" +
                    $" - Motivo: {e.Message}"); //No futuro, adicionar pessoa, eai melhorar o log.
                throw;
            }
        }

        public async Task<decimal> ObterSaldoTotal()
        {
            try
            {
                var contas = await _contaRepository.ObterTodosAsync();
                decimal saldoTotal = 0;
                
                // Forma 1
                //foreach(var conta in contas)
                //{
                //    saldoTotal += conta.Saldo;
                //}

                // Forma 2
                //contas.ForEach(delegate (Conta conta)
                //    {
                //        saldoTotal += conta.Saldo;
                //    }
                //);

                // Usando Linq.
                saldoTotal = contas.Sum(x => x.Saldo);

                return saldoTotal;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao obter o saldo total" +
                    $" - Motivo: {e.Message}"); //Melhorar log quando houver pessoa.
                throw;
            }
        }
    }
}
