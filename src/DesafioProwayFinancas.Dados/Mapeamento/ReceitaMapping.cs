using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioProwayFinancas.Dados.Mapeamento
{
    public class ReceitaMapping : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("receita");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContaId).HasColumnName("conta_id").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").IsRequired();
            builder.Property(x => x.DataRecebimento).HasColumnName("data_recebimento").IsRequired();
            builder.Property(x => x.DataRecebimentoEsperado).HasColumnName("data_recebimento_esperado").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();
            builder.Property(x => x.TipoReceita).HasColumnName("tipo_receita").HasConversion<string>().IsRequired();

            builder
                .HasOne(x => x.Conta)
                .WithMany(x => x.Receitas);
        }
    }
}
