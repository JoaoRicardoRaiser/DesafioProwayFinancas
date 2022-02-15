using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Services;
using DesafioProwayFinancas.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DesafioProwayFinancas.Unit.Tests.ControllerTest
{
    public class ObterTodasContasTest
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public ObterTodasContasTest()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task ObterTodasContasDeveRetornarDuasContas()
        {
            //Arrange
            var conta1 = new Conta(0, CrossCutting.Enums.TipoConta.CONTA_CORRENTE, "BancoXPTO");
            var conta2 = new Conta(50, CrossCutting.Enums.TipoConta.CARTEIRA, "Bolso");
            var contas = new List<Conta>
            {
                conta1,
                conta2
            };
            _contaService.ObterTodasAsContas().Returns(contas);

            //Action
            var resultado = await _contaController.ObterTodasContas();
            var objectResult = resultado as ObjectResult;
            var objectResultValue = objectResult.Value as List<Conta>;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);
            objectResultValue[0].Id.Should().Be(conta1.Id);
            objectResultValue[0].Saldo.Should().Be(conta1.Saldo);
            objectResultValue[0].TipoConta.Should().Be(conta1.TipoConta);
            objectResultValue[0].InstituicaoFinanceira.Should().Be(conta1.InstituicaoFinanceira);
            objectResultValue[0].Receitas.Should().BeNull();
            objectResultValue[0].Despesas.Should().BeNull();

            objectResultValue[1].Id.Should().Be(conta2.Id);
            objectResultValue[1].Saldo.Should().Be(conta2.Saldo);
            objectResultValue[1].TipoConta.Should().Be(conta2.TipoConta);
            objectResultValue[1].InstituicaoFinanceira.Should().Be(conta2.InstituicaoFinanceira);
            objectResultValue[1].Receitas.Should().BeNull();
            objectResultValue[1].Despesas.Should().BeNull();
        }

        [Fact]
        public async Task ObterTodasContasDeveLancarException()
        {
            //Arrange

            //Action

            _contaController.ObterTodasContas().Throws(new Exception("Erro inesperado"));
            var resultado = await _contaController.ObterTodasContas();
            var objectResult = resultado as ObjectResult;

            //Assert
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(400);
            objectResult.Value.Should().Be($"Não foi possível listar todas as Contas. Erro: Erro inesperado");
        }
    }
}

