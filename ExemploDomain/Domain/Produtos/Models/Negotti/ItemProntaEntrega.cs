using System.Collections.Generic;
using System.Reflection;

namespace Domain.Produtos.Models.Negotti
{
    public class ItemProntaEntrega
    {
        public string Pedido { get; set; }
        public string ProdutoId { get; set; }
        public string Grade { get; set; }
        public string GradeFechada { get; set; }
        public int QuantidadePorCaixa { get; set; }
        public int Saldo { get; set; }
        public int SaldoCaixa { get; set; }
        public int SaldoCaixas { get; set; }
        public string TipoUsuario { get; set; }
        public string DataEntrega { get; set; }
        public string PedidoOrigem { get; set; }
        public string EstoqueProdutoId { get; set; }
        public int GradeFechadaId { get; set; }
        public List<int> QuantidadeTamanho { get; set; }
        public string ReferenciaFabricante { get; set; }

    }
}