using System.Collections.Generic;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Interfaces.Services
{
    public interface IProdutoB2bService
    {
        List<Pasta> BuscarPastas(string grife);
        List<Pasta> BuscarPastas(string grife, string tipo);
        List<Produto> BuscarProdutosDaPasta(string pastaId);
        Produto BuscarCompleto(string id);
    }
}