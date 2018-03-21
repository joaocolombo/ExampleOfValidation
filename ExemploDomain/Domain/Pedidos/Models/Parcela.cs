using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Pedidos.Models
{
    public class Parcela : ValueObject
    {
        public Parcela(int numero, double valor, double percentual, DateTime vencimento)
        {
            Percentual = percentual;
            Numero = numero;
            Valor = valor;
            Vencimento = vencimento;
            Erros = new List<Error>();
        }
        public int Numero { get; private set; }
        public double Valor { get; private set; }
        public double Percentual { get; private set; }
        public DateTime Vencimento { get; private set; }


        public override string ToString()
        {
            return Numero.ToString();
        }

        public override bool EhValido()
        {
            ValidarValor();
            return !Erros.Any();
        }

        public void ValidarValor()
        {
            if (Valor == 0.00)
                Erros.Add(Error.ErrorFactory.NewError("Parcelas", "O Valor da parcela {Numero} é 0", ErroTypes.Error));
        }
    }
}