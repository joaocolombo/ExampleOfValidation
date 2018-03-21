using Core.Models;

namespace Domain.Produtos.Models
{
    public class Atributo:ValueObject
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}