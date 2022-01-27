using FluentMigrator;

namespace DesafioProwayFinancas.Database.Migrations
{
    [Migration(20210125215338, "Criação da tabela conta")]
    public class Migration20210125215338CreateTableConta : Migration
    {
        public override void Up()
        {
            Create.Table("conta")
                .WithColumn("id").AsGuid().PrimaryKey().Unique()
                .WithColumn("saldo").AsDecimal()
                .WithColumn("tipo_conta").AsString().NotNullable()
                .WithColumn("instituicao_financeira").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete
                .Table("conta");
        }

    }
}
