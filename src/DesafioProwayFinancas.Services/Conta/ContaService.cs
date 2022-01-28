using DesafioProwayFinancas.Dados;
using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Dados.Repositories.ContaRepository;
using Microsoft.Extensions.Logging;
using System;
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
    }
}
