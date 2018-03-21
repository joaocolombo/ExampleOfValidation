using Domain.Pedidos.Models;

namespace Domain.Pedidos.Interfaces.Services
{
    public interface IExportacaoPedidoService
    {
        Pedido BuscarPedido(string id);
    }
}