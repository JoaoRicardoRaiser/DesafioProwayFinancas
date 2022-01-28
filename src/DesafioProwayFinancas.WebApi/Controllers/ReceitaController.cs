using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarReceita([FromBody] CadastrarReceitaRequestModel body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Alguma das informações de request da receita estão inválidas");
                }

                await _receitaService.CadastrarReceita(body);
                return Ok($"Receita cadastrada com sucesso na conta {body.ContaId}");
            }
            catch(Exception e)
            {
                return BadRequest($"Não foi possível cadastrar receita. Erro: {e.Message}");
            }
        }
    }
}
