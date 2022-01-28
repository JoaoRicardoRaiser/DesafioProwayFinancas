using DesafioProwayFinancas.CrossCutting.Enums;
using System;

namespace DesafioProwayFinancas.Dados.Models
{
    public class CadastrarReceitaRequestModel
    {
        public Guid ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataRecebimentoEsperado { get; set; }
        public string Descricao { get; set; }
        public TipoReceita TipoReceita { get; set; }
    }
}
