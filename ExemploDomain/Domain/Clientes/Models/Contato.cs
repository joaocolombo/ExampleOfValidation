using System.Collections.Generic;
using Core.Models;

namespace Domain.Clientes.Models
{
    public class Contato : ValueObject
    {
        public Contato(string email, string emailNfe, Telefone telefone)
        {
            Email = email;
            EmailNfe = emailNfe;
            Telefone = telefone;
        }

        private Contato()
        {
            
        }
        public string Email { get; private set; }
        private string _emailNfe;
        public Telefone Telefone { get; set; }
        
        public string EmailNfe
        {
            get => _emailNfe;
            set
            {
                if (string.IsNullOrEmpty(value))
                    _emailNfe = Email;
                _emailNfe = value;
            }
        }

        public override bool EhValido()
        {
           Erros = new List<Error>();
            return true;
        }


    }
}