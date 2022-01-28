using DesafioProwayFinancas.Dados.Entidades;
using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarConta([FromBody] CadastrarContaRequestModel body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Alguma das informações da request de cadastro da {nameof(Conta)} estão inválidas");
                }

                await _contaService.CadastrarConta(body);
                return Ok($"{nameof(Conta)} cadastrada com sucesso!"); //No futuro adicionar pessoa, eai melhorar log
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível cadastrar conta. Erro: {e.Message}");
            }
        }

        [HttpPut("editar/{contaId}")]
        public async Task<IActionResult> EditarConta([FromRoute] Guid contaId, [FromBody] EditarContaRequestModel body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Alguma das informações da request de edição da {nameof(Conta)} estão inválidas");
                }

                await _contaService.AtualizarConta(contaId, body);
                return Ok($"{nameof(Conta)} com Id '{contaId}' editada com sucesso!"); //No futuro adicionar pessoa, eai melhorar log
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível editar {nameof(Conta)} com Id '{contaId}'. Erro: {e.Message}");
            }
        }

        [HttpDelete("deletar/{contaId}")]
        public async Task<IActionResult> DeletarConta([FromRoute] Guid contaId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Alguma das informações da request de exclusão da {nameof(Conta)} estão inválidas");
                }

                await _contaService.DeletarConta(contaId);
                return Ok($"{nameof(Conta)} com Id '{contaId}' deletada com sucesso!"); //No futuro adicionar pessoa, eai melhorar log

            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível deletar {nameof(Conta)} com Id {contaId}. Erro: {e.Message}");
            }
        }

        [HttpGet("todas")]
        public async Task<IActionResult> ObterTodasContas()
        {
            try
            {
                var contas = await _contaService.ObterTodasAsContas();
                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível listar todas as {nameof(Conta)}s. Erro: {e.Message}");
            }
        }

        [HttpPost("transferir")]
        public async Task<IActionResult> TransferirValorEntreContas([FromBody] TransferirEntreContasRequestModel body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Alguma das informações da request de transferência entre {nameof(Conta)}s estão inválidas");
                }

                await _contaService.TransferirEntreContas(body);
                return Ok($"Transferência de R${body.Valor} realizada com sucesso da {nameof(Conta)} '{body.IdContaOrigem}' para a {nameof(Conta)} '{body.IdContaDestino}'.");
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível realizar a transferencia de R${body.Valor} da {nameof(Conta)} '{body.IdContaOrigem}' para a {nameof(Conta)} '{body.IdContaDestino}'. Erro: {e.Message}");
            }
        }

        //No futuro, adaptar esse endpoint para mostrar saldo total para cada pessoa.
        [HttpGet("saldo/total")]
        public async Task<IActionResult> ObterSaldoTotal()
        {
            try
            {
                var saldoTotal = await _contaService.ObterSaldoTotal();
                var resposta = new() { ResultadoTotal = JsonConvert.SerializeObject($"O saldo total é: {Math.Round(saldoTotal, 2)}")};
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível obter o saldo total. Erro {e.Message}"); //Melhorar log quando tiver pessoa implementada.
            }
        }
    }
}
