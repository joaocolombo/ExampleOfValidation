using System.Collections.Generic;
using Domain.Pedidos.Models;

namespace Domain.Pedidos.Interfaces.Repositories
{
    public interface IExportacaoPedidoRepository
    {
        Pedido BuscarPedido(string id);
    }
}