using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Services;
using DesafioProwayFinancas.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DesafioProwayFinancas.Unit.Tests.ControllerTest
{
    public class TransferirEntreContasTest
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public TransferirEntreContasTest()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task TransferirEntreContasDeveRetornarSucesso()
        {
            //Arrange
            var contaOrigemId = Guid.NewGuid();
            var contaDestinoId = Guid.NewGuid();
            var body = new TransferirEntreContasRequestModel
            {
                IdContaOrigem = contaOrigemId,
                IdContaDestino = contaDestinoId,
                Valor = 100
            };

            //Action
            var resultado = await _contaController.TransferirValorEntreContas(body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().Be($"Transferência de R${body.Valor} realizada com sucesso da Conta '{body.IdContaOrigem}' para a Conta '{body.IdContaDestino}'.");
        }

        [Fact]
        public async Task TransferirEntreContasDeveRetornarErroNoBodyDaRequest()
        {
            //Arrange
            var contaOrigemId = Guid.NewGuid();
            var contaDestinoId = Guid.NewGuid();
            var body = new TransferirEntreContasRequestModel
            {
                IdContaOrigem = contaOrigemId,
                IdContaDestino = contaDestinoId,
                Valor = 100
            };
            _contaController.ModelState.AddModelError("KeyErro", "KeyErro");

            //Action
            var resultado = await _contaController.TransferirValorEntreContas(body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be("Alguma das informações da request de transferência entre Contas estão inválidas");
        }

        [Fact]
        public async Task TransferirEntreContasDeveLancarException()
        {
            //Arrange
            var contaOrigemId = Guid.NewGuid();
            var contaDestinoId = Guid.NewGuid();
            var body = new TransferirEntreContasRequestModel
            {
                IdContaOrigem = contaOrigemId,
                IdContaDestino = contaDestinoId,
                Valor = 100
            };

            //Action

            _contaController.TransferirValorEntreContas(body).Throws(new Exception("Erro inesperado"));
            var resultado = await _contaController.TransferirValorEntreContas(body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be($"Não foi possível realizar a transferencia de R${body.Valor} da Conta '{body.IdContaOrigem}' para a Conta '{body.IdContaDestino}'. Erro: Erro inesperado");
        }
    }
}
