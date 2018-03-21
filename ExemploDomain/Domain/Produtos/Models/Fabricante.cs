using System;
using Core.Models;

namespace Domain.Produtos.Models
{
     public class Fabricante
    {
        public Fabricante(string id, string razaoSocial)
        {
            Id = id;
            RazaoSocial = razaoSocial;
        }
        public string Id {get; private set;}
        public string RazaoSocial {get; private set;}

    }
}
