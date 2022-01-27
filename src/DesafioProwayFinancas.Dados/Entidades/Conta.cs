using DesafioProwayFinancas.CrossCutting.Enums;
using System.Collections.Generic;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class Conta: EntidadeBase
    {
        public decimal Saldo { get; set; }
        public TipoConta TipoConta { get; set; }
        public string InstituicaoFinanceira { get; set; }

        public virtual List<Despesa> Despesas { get; set; }
        public virtual List<Receita> Receitas { get; set; }
    }
}
