using DesafioProwayFinancas.CrossCutting.Enums;

namespace DesafioProwayFinancas.Dados.Models
{
    public class CadastrarContaRequestModel
    {
        public decimal Saldo { get; set; }
        public TipoConta TipoConta { get; set; }
        public string InstituicaoFinanceira { get; set; }
    }
}
