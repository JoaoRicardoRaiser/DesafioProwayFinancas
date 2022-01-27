using DesafioProwayFinancas.Dados.Models;
using DesafioProwayFinancas.Dados.Repositories.ReceitaRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProwayFinancas.Services.Services.Receita
{
    public class ReceitaService: IReceitaService
    {
        private readonly ILogger<ReceitaService> _logger;
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(
            ILogger<ReceitaService> logger,
            IReceitaRepository receitaRepository)
        {
            _logger = logger;
            _receitaRepository = receitaRepository;
        }

        public async Task CadastrarReceita(CadastrarReceitaModel model)
        {
            
        }
    }
}
