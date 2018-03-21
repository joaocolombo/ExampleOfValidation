

using System.Collections.Generic;
using Domain.Produtos.Interfaces.Repositories;
using Domain.Produtos.Interfaces.Services;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Services
{
   public class B2bService:IProdutoB2bService
   {
       private readonly IPastaRepository _pasta;
       private readonly IProdutoRepository _produto;

       public B2bService(IPastaRepository pasta, IProdutoRepository produto)
       {
           _pasta = pasta;
           _produto = produto;
       }

       public List<Pasta> BuscarPastas(string grife)
       {
           return _pasta.BuscarPastasValidas(grife);
       }

        public List<Produto> BuscarProdutosDaPasta(string pastaId)
        {
            var produtos = _produto.BuscarProdutoDaPasta(pastaId);
            foreach (var produto in produtos)
            {
                produto.AtribuirImagens(_produto.BuscarImagens(produto.Id));
            }
            return produtos;
        }

       public Produto BuscarCompleto(string id)
       {
           var produto = _produto.BuscarProduto(id);
           
               produto.AtribuirImagens(_produto.BuscarImagens(produto.Id));
               produto.AtribuirAtributos(_produto.BuscarAtributos(produto));
           return produto;
       }

        public List<Pasta> BuscarPastas(string grife, string tipo)
        {
            return _pasta.BuscarPastasValidas(grife, tipo);
        }
    }
}
