using DesafioProwayFinancas.CrossCutting.Enums;
using DesafioProwayFinancas.Dados.Models;
using System;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class Receita: EntidadeBase
    {
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataRecebimentoEsperado { get; set; }
        public string Descricao { get; set; }
        public TipoReceita TipoReceita { get; set; }
        public Guid ContaId { get; set; }
        
        public virtual Conta Conta { get; set; }

        public Receita(
            decimal valor,
            DateTime dataRecebimento,
            DateTime dataRecebimentoEsperado,
            string descricao,
            TipoReceita tipoReceita,
            Guid contaId
            )
        {
            ValidarParametros(valor, descricao);
            
            Valor = valor;
            DataRecebimento = dataRecebimento;
            DataRecebimentoEsperado = dataRecebimentoEsperado;
            Descricao = descricao;
            TipoReceita = tipoReceita;
            ContaId = contaId;
        }

        public Receita(CadastrarReceitaRequestModel model)
        {
            ValidarParametros(model.Valor, model.Descricao);

            Valor = model.Valor;
            DataRecebimento = model.DataRecebimento;
            DataRecebimentoEsperado = model.DataRecebimentoEsperado;
            Descricao = model.Descricao;
            TipoReceita = model.TipoReceita;
            ContaId = model.ContaId;
        }

        private static void ValidarParametros(
            decimal valor,
            string descricao
        )
        {
            if(valor == 0)
            {
                throw new ArgumentException($"O campo {nameof(Valor)} da {nameof(Receita)} não pode ser 0");
            }

            if(string.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException($"O campo {nameof(Descricao)} da {nameof(Receita)} não pode ser nula ou vazia");
            }
        }
    }
}
