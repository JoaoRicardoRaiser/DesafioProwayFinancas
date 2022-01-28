using System;

namespace DesafioProwayFinancas.Dados.Models
{
    public class TransferirEntreContasRequestModel
    {
        public Guid IdContaOrigem { get; set; }
        public Guid IdContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
