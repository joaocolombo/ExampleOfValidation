using Core.Models;

namespace Domain.Clientes.Models
{
    public class CondicaoPagamento : ValueObject
    {
        public CondicaoPagamento(string id, string descricao, string inativo)
        {
            Id = id;
            Descricao = descricao;
            Inativo = inativo;
        }

        private CondicaoPagamento()
        {
            
        }
        public string Id { get; private set; }      
        public string Descricao { get; private set; }
        public string Inativo { get; private set; }
        
        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}