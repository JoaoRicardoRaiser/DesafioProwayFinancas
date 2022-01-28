using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioProwayFinancas.Dados.Mapeamento
{
    public class DespesaMapping : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("despesa");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.ContaId).HasColumnName("conta_id").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").IsRequired();
            builder.Property(x => x.DataPagamento).HasColumnName("data_pagamento").IsRequired();
            builder.Property(x => x.DataPagamentoEsperado).HasColumnName("data_pagamento_esperado").IsRequired();
            builder.Property(x => x.TipoDespesa).HasColumnName("tipo_despesa").HasConversion<string>().IsRequired();

            builder
                .HasOne(x => x.Conta)
                .WithMany(x => x.Despesas);
        }
    }
}
