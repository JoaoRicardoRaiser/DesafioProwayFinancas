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
    public class EditarContaTest
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public EditarContaTest()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task EditarContaDeveRetornarContaEditada()
        {
            //Arrange
            var contaId = Guid.NewGuid();
            var body = new EditarContaRequestModel
            {
                InstituicaoFinanceira = "BancoXPTO",
                Saldo = 30,
                TipoConta = CrossCutting.Enums.TipoConta.CONTA_CORRENTE
            };

            //Action
            var resultado = await _contaController.EditarConta(contaId, body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().Be($"Conta com Id '{contaId}' editada com sucesso!");
        }

        [Fact]
        public async Task EditarContaDeveRetornarErroNoBodyDaRequest()
        {
            //Arrange
            var contaId = Guid.NewGuid();
            var body = new EditarContaRequestModel();
            _contaController.ModelState.AddModelError("InstituicaoFinanceira", "InstituicaoFinanceira inválida");

            //Action
            var resultado = await _contaController.EditarConta(contaId, body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be("Alguma das informações da request de edição da Conta estão inválidas");
        }

        [Fact]
        public async Task EditarContaDeveLancarException()
        {
            //Arrange
            var contaId = Guid.NewGuid();
            var body = new EditarContaRequestModel();

            //Action

            _contaController.EditarConta(contaId, body).Throws(new Exception("Erro inesperado"));
            var resultado = await _contaController.EditarConta(contaId, body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be($"Não foi possível editar Conta com Id '{contaId}'. Erro: Erro inesperado");
        }

    }
}
