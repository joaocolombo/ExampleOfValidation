using Core.Models;

namespace Domain.Clientes.Models
{
    public class Telefone : ValueObject
    {
        public Telefone(string numero, string ddd, string ddi)
        {
            Numero = numero;
            Ddd = ddd;
            Ddi = ddi;
        }

        private Telefone()
        {
            
        }
        public string Numero { get; private set; }
        public string Ddd { get; private set; }
        public string Ddi { get; private set; }

        public override bool EhValido()
        {
            //todo:fazer
            return true;
        }
    }
}