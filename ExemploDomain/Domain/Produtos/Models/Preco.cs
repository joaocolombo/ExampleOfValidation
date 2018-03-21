using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Produtos.Models
{
    public class Preco : ValueObject
    {
        public Preco(decimal precoVenda, decimal precoCusto)
        {
            PrecoVenda = precoVenda;
            PrecoCusto = precoCusto;
        }

        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal Markup { get; private set; }


        public void CalcularMarkup(string fabricanteRazaoSocial, string grupo)
        {
            if (!EhValido()) return;

            if (fabricanteRazaoSocial.Equals("MCM IND. E COM. ARTEF.")
                || fabricanteRazaoSocial.Equals("ALBANESE")
                || fabricanteRazaoSocial.Equals("NEWCOMFORT")
                || fabricanteRazaoSocial.Equals("DELGATTO")
                && grupo.Equals("BOLSAS")
                || grupo.Equals("CALÇADOS")
                || grupo.Equals("KIT"))

                Markup = Convert.ToDecimal((PrecoVenda / PrecoCusto).ToString("N2"));
            else
                Markup = Convert.ToDecimal((PrecoVenda / (PrecoCusto * 1.1M)).ToString("N2"));
        }

        public override bool EhValido()
        {
            Erros = new List<Error>();
            ValidarPrecoCusto();
            ValidarPrecoVenda();
            return !Erros.Any();
        }

        private void ValidarPrecoVenda()
        {
            if (PrecoVenda<=0)
            Erros.Add(Error.ErrorFactory.NewError("Preco", "O preço de venda é invalido",ErroTypes.Error));
        }

        private void ValidarPrecoCusto()
        {
            if (PrecoCusto <= 0)
                Erros.Add(Error.ErrorFactory.NewError("Preco", "O preço de Custo é invalido", ErroTypes.Error));
        }
    }
}