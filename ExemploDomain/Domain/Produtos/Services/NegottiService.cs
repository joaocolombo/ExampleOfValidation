using Domain.Produtos.Models;
using System.Collections.Generic;
using Domain.Produtos.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Produtos.Interfaces.Services;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Services
{
    public class NegottiService : IProdutoNegottiService
    {
        private readonly IPastaRepository _pasta;
        private readonly IItemProntaEntregaRepository _itemProntaEntrega;
        private readonly IProdutoNegottiRepository _produtoNegotti;
        private readonly IProdutoRepository _produto;

        public NegottiService(IPastaRepository pasta, IItemProntaEntregaRepository itemProntaEntrega, IProdutoNegottiRepository produtoNegotti, IProdutoRepository produto)
        {
            _pasta = pasta;
            _itemProntaEntrega = itemProntaEntrega;
            _produtoNegotti = produtoNegotti;
            _produto = produto;
        }

        public List<Pasta> GerarPastas(string grife)
        {
            var pastas = _pasta.BuscarPastasValidas(grife);
            AtualizarPastasNoBanco(pastas);
            foreach (var pasta in pastas)
                pasta.Produtos = _produtoNegotti.BuscarParaPasta(pasta);

            return pastas;
        }

        public List<Produto> GerarProdutos(string grife)
        {
            var dataEntregaInicial = _produtoNegotti.BuscarDataInicioVenda();
         

            var produtos = _produtoNegotti.BuscarProdutos(grife);
            foreach (var produto in produtos)
            {
                produto.AtribuirImagens(_produto.BuscarImagens(produto.Id));
                produto.ProdutoNegotti.AtribuirEntregas(dataEntregaInicial, dataEntregaInicial.AddMonths(6));
                produto.ProdutoNegotti.AtribuirQuantidadesAceitas(produto.Classificacoes.Grife.Descricao, produto.Classificacoes.Grupo.Descricao,produto.Fabricante.Id);
                produto.ProdutoNegotti.AtribuirTamanhosBloqueados(_produtoNegotti.BuscarTamanhosBloqueados(produto.ReferenciaFabricante));
                produto.ProdutoNegotti.AtribuirAtributos(_produtoNegotti.BuscarAtributos(produto));

            }
            return  produtos;
        }

        private void AtualizarPastasNoBanco(List<Pasta> pastas)
        {
            foreach (var pasta in pastas)
            {
                if (pasta.ProntaEntrega)
                    pasta.Filtro = AjustarFiltroProntaEntrega(pasta) + pasta.Filtro.Replace("AND 'TESTE' = 'T'", "");
                _pasta.AtualizarPastaBanco(pasta);
            }
        }

        private string AjustarFiltroProntaEntrega(Pasta pasta)
        {
            var filtro = "";
            var listPe = _itemProntaEntrega.BuscarProntaEntregas(pasta.Grife);
            if (pasta.TipoUsuarioId == 19)
            {
                listPe = listPe.Where(x => x.TipoUsuario == null).ToList();
            }
            else if (pasta.TipoUsuarioId == 20)
            {
                listPe = listPe.Where(x => x.TipoUsuario == null || x.TipoUsuario.Equals("Franqueado")).ToList();
            }
            if (listPe.Any())
            {
                filtro = @" AND P.PRODUTO in (";
                foreach (var pe in listPe)
                    filtro += "'" + pe.ProdutoId + "',";
                filtro = filtro.Substring(0, filtro.Length - 1) + ")";
            }
            else
            {
                filtro = @" AND 'SEM PRONTA ENTREGA' = '0'";
            }
            return filtro;
        }
    }
}
