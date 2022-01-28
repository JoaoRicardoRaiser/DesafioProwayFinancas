using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Services;
using Microsoft.AspNetCore.Mvc;
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
                    return BadRequest("Alguma das informações de request da conta estão inválidas");
                }

                await _contaService.CadastrarConta(body);
                return Ok($"Conta cadastrada com sucesso!"); //No futuro adicionar pessoa, eai melhorar log
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível cadastrar receita. Erro: {e.Message}");
            }
        }
    }
}
