using System.Collections.Generic;
using Domain.Produtos.Models;

namespace Domain.Produtos.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> BuscarProdutoDaPasta(string pastaId);
        Dictionary<string,string >BuscarImagens(string produtoId);
        List<Atributo> BuscarAtributos(Produto produto);
        Produto BuscarProduto(string id);
    }
}