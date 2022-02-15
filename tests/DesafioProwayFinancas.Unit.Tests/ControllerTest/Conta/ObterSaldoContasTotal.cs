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
    public class ObterSaldoContasTotal
    {
        private readonly ContaController _contaController;
        private readonly IContaService _contaService;

        public ObterSaldoContasTotal()
        {
            _contaService = Substitute.For<IContaService>();
            _contaController = new ContaController(_contaService);
        }

        [Fact]
        public async Task ObterSaldoTotalDeveRetornarSaldoTotal()
        {
            // Arrange
            _contaService.ObterSaldoTotal().Returns(100.02M);

            // Action
            var resultado = await _contaController.ObterSaldoTotal();
            var objectResult = resultado as ObjectResult;
            var objectResultValue = objectResult.Value as Dictionary<string, string>;

            // Assert

            objectResultValue["saldoTotal"].Should().Be("R$100,02");
        }

        [Fact]
        public async Task ObterSaldoTotalDeveLancarException()
        {
            // Arrange
            _contaService.ObterSaldoTotal().Throws(new Exception("Erro inesperado"));

            // Action
            var resultado = await _contaController.ObterSaldoTotal();
            var objectResult = resultado as ObjectResult;

            // Assert

            objectResult.Value.Should().Be("Não foi possível obter o saldo total. Erro: Erro inesperado");
        }

    }
}
