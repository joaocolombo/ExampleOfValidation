using System.Collections.Generic;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Interfaces.Repositories
{
    public interface IItemProntaEntregaRepository
    {
        List<ItemProntaEntrega> BuscarProntaEntregas(string grife);
    }
}