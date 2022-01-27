using DesafioProwayFinancas.CrossCutting.Enums;
using System;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class Despesa : EntidadeBase
    {
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataPagamentoEsperado { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
        public Guid ContaId { get; set; }
        
        public virtual Conta Conta { get; set; }
    }
}
