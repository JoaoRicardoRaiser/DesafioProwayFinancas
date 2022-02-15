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
    public class CadastrarContaTest
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public CadastrarContaTest()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task CadastrarContaDeveRetornarContaCadastrada()
        {
            //Arrange
            var body = new CadastrarContaRequestModel
            {
                InstituicaoFinanceira = "BancoXPTO",
                Saldo = 0,
                TipoConta = CrossCutting.Enums.TipoConta.CONTA_CORRENTE
            };

            //Action
            var resultado = await _contaController.CadastrarConta(body);
            var objectResult = resultado as ObjectResult;
            
            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().Be("Conta cadastrada com sucesso!");
        }

        [Fact]
        public async Task CadastrarContaDeveRetornarErroNoBodyDaRequest()
        {
            //Arrange
            var body = new CadastrarContaRequestModel();
            _contaController.ModelState.AddModelError("InstituicaoFinanceira", "InstituicaoFinanceira inválida");
            
            //Action
            var resultado = await _contaController.CadastrarConta(body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be("Alguma das informações da request de cadastro da Conta estão inválidas");
        }

        [Fact]
        public async Task CadastrarContaDeveLancarException()
        {
            //Arrange
            var body = new CadastrarContaRequestModel();

            //Action

            _contaController.CadastrarConta(body).Throws(new Exception("Erro inesperado"));
            var resultado = await _contaController.CadastrarConta(body);
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be("Não foi possível cadastrar conta. Erro: Erro inesperado");
        }
    }
}
