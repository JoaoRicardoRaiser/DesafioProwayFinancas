using DesafioProwayFinancas.CrossCutting.Enums;
using DesafioProwayFinancas.Dados.Models;
using System;
using System.Collections.Generic;

namespace DesafioProwayFinancas.Dados.Entidades
{
    public class Conta: EntidadeBase
    {
        public decimal Saldo { get; set; }
        public TipoConta TipoConta { get; set; }
        public string InstituicaoFinanceira { get; set; }

        public virtual List<Despesa> Despesas { get; set; }
        public virtual List<Receita> Receitas { get; set; }

        public Conta(
            decimal saldo,
            TipoConta tipoConta,
            string instituicaoFinanceira)
        {
            ValidarParametros(instituicaoFinanceira);
            
            Saldo = saldo;
            TipoConta = tipoConta;
            InstituicaoFinanceira = instituicaoFinanceira;
        }

        public Conta(CadastrarContaRequestModel model)
        {
            ValidarParametros(model.InstituicaoFinanceira);
            
            Saldo = model.Saldo;
            TipoConta = model.TipoConta;
            InstituicaoFinanceira = model.InstituicaoFinanceira;
        }

        private static void ValidarParametros(string instituicaoFinanceira)
        {
            if (string.IsNullOrEmpty(instituicaoFinanceira))
            {
                throw new ArgumentException($"O campo {nameof(InstituicaoFinanceira)} da {nameof(Conta)} não pode ser nulo ou vazio");
            }
        }
    }
}
