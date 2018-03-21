using Domain.Pedidos.Interfaces.Repositories;
using Domain.Pedidos.Interfaces.Services;
using Domain.Pedidos.Models;

namespace Domain.Pedidos.Services
{
    public class Exportacao:IExportacaoPedidoService
    {
        private readonly IExportacaoPedidoRepository _iExportacao;

        public Exportacao(IExportacaoPedidoRepository iExportacao)
        {
            _iExportacao = iExportacao;
        }

        public Pedido BuscarPedido(string id)
        {
            return _iExportacao.BuscarPedido(id);
           
        }
    }
}