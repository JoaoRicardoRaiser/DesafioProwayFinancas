using FluentMigrator;

namespace DesafioProwayFinancas.Database.Migrations
{
    [Migration(20210126202024, "Criação da tabela receita")]
    public class Migration20210126202024CreateTableReceita : Migration
    {
        public override void Up()
        {
            Create
                .Table("receita")
                .WithColumn("id").AsGuid().PrimaryKey().Unique()
                .WithColumn("conta_id").AsGuid().NotNullable().ForeignKey("conta", "id")
                .WithColumn("valor").AsDecimal().NotNullable()
                .WithColumn("data_recebimento").AsDate().NotNullable()
                .WithColumn("data_recebimento_esperado").AsDate().NotNullable()
                .WithColumn("tipo_receita").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete
                .Table("receita");
        }

    }
}
