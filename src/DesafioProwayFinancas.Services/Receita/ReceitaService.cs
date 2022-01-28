using DesafioProwayFinancas.CrossCutting.Exceptions;
using DesafioProwayFinancas.Dados;
using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Dados.Repositories.ContaRepository;
using DesafioProwayFinancas.Dados.Repositories.ReceitaRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services
{
    public class ReceitaService: IReceitaService
    {
        private readonly ILogger<ReceitaService> _logger;
        private readonly IReceitaRepository _receitaRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReceitaService(
            ILogger<ReceitaService> logger,
            IReceitaRepository receitaRepository,
            IContaRepository contaRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _receitaRepository = receitaRepository;
            _contaRepository = contaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarReceita(CadastrarReceitaRequestModel model)
        {
            try
            {
                _logger.LogInformation($"Iniciando o cadastro da {nameof(Receita)} {model.Descricao} para a {nameof(Conta)} {model.ContaId}");
                var conta = await _contaRepository.ObterPorIdAsync(model.ContaId);
            
                if(conta == null)
                {
                    throw new ObjetoNaoEncontradoException($"Não foi encontrado {nameof(Conta)} com o id {model.ContaId}");
                }

                var receita = new Receita(model);

                await _receitaRepository.Create(receita);

                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Finalizado com sucesso o cadastro da {nameof(Receita)} {model.Descricao} para a {nameof(Conta)} {model.ContaId}");
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Ocorreu um erro ao cadastrar a {nameof(Receita)} {model.Descricao} para a {nameof(Conta)} {model.ContaId}" +
                    $" - Motivo: {e.Message}");
                throw;
            }
        }
    }
}
