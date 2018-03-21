using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Pedidos.Models.FormasPagamento
{
    public class FormaPagamento : ValueObject
    {
        private FormaPagamento()
        {
            _parcelas = new List<Parcela>();
            Erros = new List<Error>();
        }
        private readonly List<Parcela> _parcelas;

        public IReadOnlyList<Parcela> Parcelas => _parcelas;
        public int QuantidadeParcelas => Parcelas.Count;
        public override string ToString()
        {
            return QuantidadeParcelas.ToString();
        }

        public override bool EhValido()
        {
            ValidarParcelas();
            return !Erros.Any();
        }

        public void ValidarParcelas()
        {
            foreach (var parcela in Parcelas)
                parcela.EhValido();
            if (Parcelas.Sum(x => x.Percentual) != 100)
                Erros.Add(Error.ErrorFactory.NewError("Parcelas", "A divisão das parcelas não é 100%", ErroTypes.Error));

        }

        public void GerarParcelas(double valor, int quantidadeParcelas, int diasCarencia,
        int diasEntreParcelas)
        {
            var valorDividido = valor / quantidadeParcelas;
            var agregadorValor = 0.00;
            var agregadorPercentual = 0.00;
            var agregadorData = diasCarencia;

            for (int i = 1; i <= quantidadeParcelas; i++)
            {
                var vencimento = DateTime.Now.AddDays(agregadorData);
                agregadorData += diasEntreParcelas;

                var valorArredondado = 0.00;
                valorArredondado = Math.Floor(valorDividido);
                var percentual = (valorArredondado * 100) / valor;
                
                if (i == quantidadeParcelas)
                {
                    valorArredondado = valor - agregadorValor;
                    percentual = 100 - agregadorPercentual;
                }
                agregadorValor += valorArredondado;
                agregadorPercentual += percentual;

                _parcelas.Add(new Parcela(i, valorArredondado, percentual,vencimento));
            }
        }

        public static class FormaPagamentoFactory
        {
            public static FormaPagamento GerarFormaPagamento(double valor, int quantidadeParcelas, int diasCarencia,
                int diasEntreParcelas)
            {
                var formaPagamento = new FormaPagamento();
                formaPagamento.GerarParcelas(valor, quantidadeParcelas, diasCarencia, diasEntreParcelas);
                formaPagamento.EhValido();
                return formaPagamento;
            }
        }
    }
}