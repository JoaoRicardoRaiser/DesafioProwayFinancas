using DesafioProwayFinancas.CrossCutting.Enums;
using System;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class Receita: EntidadeBase
    {
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataRecebimentoEsperado { get; set; }
        public string Descricao { get; set; }
        public TipoReceita TipoReceita { get; set; }
        public Guid ContaId { get; set; }
        
        public virtual Conta Conta { get; set; }
    }
}
