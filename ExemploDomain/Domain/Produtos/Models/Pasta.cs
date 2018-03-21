using System;
using System.Collections.Generic;
using Core.Models;

namespace Domain.Produtos.Models
{
    public class Pasta : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Grife { get; set; }
        public int TipoUsuarioId { get; set; }
        public string ImagemTablet { get; set; }
        public string ImagemSmartPhone { get; set; }
        public bool Oculto { get; set; }
        public int Prioridade { get; set; }
        public bool Inativo { get; set; }
        public string Filtro { get; set; }
        public bool ProntaEntrega { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public List<string> Produtos { get; set; }
        
        public override bool EhValido()
        {
            //todo: efetuar as validaçoes
            return true;
        }
    }
}