using DesafioProwayFinancas.CrossCutting.Enums;
using DesafioProwayFinancas.CrossCutting.Exceptions;
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
            VerificarSeParametrosSaoValidos(instituicaoFinanceira);
            
            Saldo = saldo;
            TipoConta = tipoConta;
            InstituicaoFinanceira = instituicaoFinanceira;
        }

        public Conta(
            CadastrarContaRequestModel model
            )
        {
            VerificarSeParametrosSaoValidos(model.InstituicaoFinanceira);
            
            Saldo = model.Saldo;
            TipoConta = model.TipoConta;
            InstituicaoFinanceira = model.InstituicaoFinanceira;
        }

        public void Atualizar(
            decimal saldo,
            TipoConta tipoConta,
            string instituicaoFinanceira)
        {
            VerificarSeParametrosSaoValidos(instituicaoFinanceira);

            Saldo = saldo;
            TipoConta = tipoConta;
            InstituicaoFinanceira = instituicaoFinanceira;

        }

        public void AdicionarSaldo(decimal valor)
        {
            Saldo += valor;
        }

        public void RetirarSaldo(decimal valor)
        {
            if(valor > Saldo)
            {
                throw new RegraInvalidaException($"O {nameof(Saldo)} é menor do que o valor solicitado para retirada");
            }

            Saldo -= valor;
        }

        private static void VerificarSeParametrosSaoValidos(string instituicaoFinanceira)
        {
            if (string.IsNullOrEmpty(instituicaoFinanceira))
            {
                throw new ArgumentException($"O campo {nameof(InstituicaoFinanceira)} da {nameof(Conta)} não pode ser nulo ou vazio");
            }
        }
    }
}
