using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Interfaces.Repositories
{
    public interface IProdutoNegottiRepository
    {
        List<Produto> BuscarProdutos(string grife);
        List<string> BuscarParaPasta(Pasta pasta);
        DateTime BuscarDataInicioVenda();
        List<string> BuscarTamanhosBloqueados(string referenciaFabricante);
        List<AtributoNegotti> BuscarAtributos(Produto produto);
    }
}