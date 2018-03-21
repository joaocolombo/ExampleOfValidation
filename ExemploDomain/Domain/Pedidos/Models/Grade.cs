using Core.Models;

namespace Domain.Pedidos.Models
{
    public class Grade : ValueObject
    {
        public string Tamanho { get; set; }
        public int Quantidade { get; set; }


        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}