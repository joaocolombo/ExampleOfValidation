using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.ObjectsValue;
using Domain.Pedidos.Models.FormasPagamento;

namespace Domain.Pedidos.Models
{
    public class Pedido:Entity
    {
        private IList<Item> _itens;

        public string Cliente { get; set; }
        public string Fabricante { get; set; }
        public DateTime Emissao { get; set; }
        public IReadOnlyCollection<Item> Itens => _itens.ToArray();
        public int Quantidade => Itens.Sum(x => x.Quantidade);
        public FormaPagamento FormaPagamento { get; set; }

        public void AdicionarItens(List<Item> itens)
        {
            _itens = itens;
        }
        

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}