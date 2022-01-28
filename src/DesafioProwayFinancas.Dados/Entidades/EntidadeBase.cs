using System;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class EntidadeBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
