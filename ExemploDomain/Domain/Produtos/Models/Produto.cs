using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Models
{
    public class Produto : Entity
    {
        private Produto()
        {

        }
        private Dictionary<string, string> _imagens;
        private List<Atributo> _atributos { get; set; }

        public string ReferenciaFabricante { get; private set; }
        public string StatusLinx { get; private set; }
        public DateTime Cadastro { get; private set; }
        public bool Inativo { get; private set; }
        public Classificacoes Classificacoes { get; private set; }
        public ProdutoNegotti ProdutoNegotti { get; private set; }
        public Fabricante Fabricante { get; private set; }
        public string Grade { get; private set; }
        public int Tamanhos { get; private set; }
        public string Cliente { get; private set; }
        public Preco Preco { get; private set; }
        public IReadOnlyDictionary<string, string> Imagens => _imagens;
        public IReadOnlyList<Atributo> Atributos => _atributos;

        public void AtribuirImagens(Dictionary<string, string> imagens)
        {
            if (imagens == null || !imagens.Any())
            {
                _imagens = new Dictionary<string, string>
                {
                    { "1", "http://assets.jorgebischoff.com.br/produtos/_placeholder/imagem-indisponivel-1024px.jpg" },
                    { "100", "http://assets.jorgebischoff.com.br/produtos/_placeholder/imagem-indisponivel-1024px.jpg" }
                };
            }
            else
            {
                _imagens = imagens;
            }
        }

        public void AtribuirProdutoNegotti(ProdutoNegotti produtoNegotti)
        {
            if (produtoNegotti.EhValido())
                ProdutoNegotti = produtoNegotti;
        }

        public void AtribuirClassificacoes(Classificacoes classificacoes)
        {
            Classificacoes = classificacoes;
        }

        public void AtribuirFabricante(Fabricante fabricante)
        {
            Fabricante = fabricante;
        }

        public void AtribuirPreco(Preco preco)
        {
            if (!preco.EhValido()) return;
            if (Fabricante != null && Classificacoes != null)
                preco.CalcularMarkup(Fabricante.RazaoSocial, Classificacoes.Grupo.Descricao);
            Preco = preco;
        }


        public void AtribuirAtributos(List<Atributo> atributos)
        {
            if (atributos.Any())
                _atributos = atributos;
        }

        #region Validation
        public override bool EhValido()
        {
            Erros = new List<Error>();
            ValidarProdutoLiberado();
            ValidarReferencia();

            return !Erros.Any();
        }

        public bool EhValidoNegotti()
        {
            Erros = new List<Error>();
            ValidarProdutoLiberado();
            ValidarReferencia();
            ValidarPreco();
            ValidarClassificacaoNegotti();
            return !Erros.Any();
        }

        private void ValidarPreco()
        {
            if (Preco.EhValido()) return;
            foreach (var error in Erros)
                Erros.Add(error);
        }

        private void ValidarClassificacaoNegotti()
        {
            if (Classificacoes.Grupo == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem Grupo", ErroTypes.Error));
            if (Classificacoes.SubGrupo == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem SubGrupo", ErroTypes.Error));
            if (Classificacoes.Colecao == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem Coleção", ErroTypes.Error));
            if (Classificacoes.Lancamento == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem Lancamento", ErroTypes.Error));
            if (Classificacoes.Nicho == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem Nicho", ErroTypes.Error));
            if (Classificacoes.Sexo == null)
                Erros.Add(Error.ErrorFactory.NewError("Classificação", "O produto esta sem Sexo", ErroTypes.Error));
        }

        private void ValidarProdutoLiberado()
        {
            if (StatusLinx != "LIBERADO" || Inativo)
                Erros.Add(Error.ErrorFactory.NewError("Status", "O status é difrente de liberado", ErroTypes.Error));
        }

        private void ValidarReferencia()
        {
            if (Id.Length != 12 && Cadastro > new DateTime(2017, 01, 01))//todo:verificar data de cadstro
                Erros.Add(Error.ErrorFactory.NewError("Referencia", "A referencia tem menos de 12 caracteres", ErroTypes.Error));

        }
        #endregion Validações

        #region Factory
        public static class ProdutoFactory
        {

            public static Produto Negotti(string id, string referenciaFabricante, string grade, string statusLinx, bool inativo,
                DateTime cadastro, Fabricante fabricante, ProdutoNegotti produtoNegotti, Classificacoes classificacoes, FichaTecnica fichaTecnica,
                Preco preco)
            {
                var produto = new Produto()
                {
                    Id = id,
                    ReferenciaFabricante = referenciaFabricante,
                    Grade = grade,
                    StatusLinx = statusLinx,
                    Inativo = inativo,
                    Cadastro = cadastro,

                };

                produto.AtribuirFabricante(fabricante);
                produto.AtribuirProdutoNegotti(produtoNegotti);
                produto.AtribuirClassificacoes(classificacoes);
                produto.ProdutoNegotti.FichaTecnica = fichaTecnica;
                produto.Preco = preco;

                return produto;
            }
            public static Produto NovoProdutoValidado()
            {
                //todo: aplicar validações
                return new Produto();
            }

            public static Produto B2b(string id, string referenciaFabricante, string grade, string statusLinx,
                bool inativo, DateTime cadastro, Fabricante fabricante, Classificacoes classificacoes, Preco preco)
            {
                var produto = new Produto()
                {
                    Id = id,
                    ReferenciaFabricante = referenciaFabricante,
                    Grade = grade,
                    StatusLinx = statusLinx,
                    Inativo = inativo,
                    Cadastro = cadastro

                };
                produto.AtribuirFabricante(fabricante);
                produto.AtribuirClassificacoes(classificacoes);
                produto.Preco = preco;

                return produto;
            }

        }
        #endregion
    }
}