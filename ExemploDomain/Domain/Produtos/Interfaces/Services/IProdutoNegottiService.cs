using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Interfaces.Services
{
    public interface IProdutoNegottiService
    {
        List<Pasta> GerarPastas(string grife);
        List<Produto> GerarProdutos(string grife);

    }
}