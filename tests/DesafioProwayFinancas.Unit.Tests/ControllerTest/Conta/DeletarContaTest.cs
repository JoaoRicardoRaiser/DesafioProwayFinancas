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
    public class DeletarContaTest
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public DeletarContaTest()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task DeletarContaDeveRetornarContaDeletada()
        {
            //Arrange
            var contaId = Guid.NewGuid();
           
            //Action
            var resultado = await _contaController.DeletarConta(contaId);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().Be($"Conta com Id '{contaId}' deletada com sucesso!");
        }

        [Fact]
        public async Task DeletarContaDeveRetornarErroNoBodyDaRequest()
        {
            //Arrange
            var contaId = Guid.NewGuid();
            _contaController.ModelState.AddModelError("GuidErro", "GuidErro");

            //Action
            var resultado = await _contaController.DeletarConta(contaId);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be("Alguma das informações da request de exclusão da Conta estão inválidas");
        }

        [Fact]
        public async Task DeletarContaDeveLancarException()
        {
            //Arrange
            var contaId = Guid.NewGuid();

            //Action

            _contaController.DeletarConta(contaId).Throws(new Exception("Erro inesperado"));
            var resultado = await _contaController.DeletarConta(contaId);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be($"Não foi possível deletar Conta com Id {contaId}. Erro: Erro inesperado");
        }
    }
}
