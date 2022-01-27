using FluentMigrator;

namespace DesafioProwayFinancas.Database.Migrations
{
    [Migration(20210126201213, "Criação da tabela despesa")]
    public class Migration20210126201213CreateTableDespesa : Migration
    {
        public override void Up()
        {
            Create
                .Table("despesa")
                .WithColumn("id").AsGuid().PrimaryKey().Unique()
                .WithColumn("conta_id").AsGuid().NotNullable().ForeignKey("conta", "id")
                .WithColumn("valor").AsDecimal().NotNullable()
                .WithColumn("data_pagamento").AsDate().NotNullable()
                .WithColumn("data_pagamento_esperado").AsDate().NotNullable()
                .WithColumn("tipo_despesa").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete
                .Table("despesa");
        }

    }
}
