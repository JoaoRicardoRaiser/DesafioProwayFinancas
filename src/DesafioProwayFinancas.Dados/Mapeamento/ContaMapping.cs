using DesafioProwayFinancas.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioProwayFinancas.Dados.Mapeamento
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("conta");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Saldo).HasColumnName("saldo");
            builder.Property(x => x.TipoConta).HasColumnName("tipo_conta").HasConversion<string>().IsRequired();
            builder.Property(x => x.InstituicaoFinanceira).HasColumnName("instituicao_financeira").IsRequired();
        }
    }
}
