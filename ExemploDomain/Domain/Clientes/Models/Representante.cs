using System;
using System.Collections.Generic;
using Core.Models;
using Core.ObjectsValue;

namespace Domain.Clientes.Models
{
    public class Representante
    {
        public Representante(Cnpj cnpj, string usuario, string id)
        {
            Cnpj = cnpj;
            Usuario = usuario;
            Id = id;
        }

        private Representante()
        {
            
        }

        public string Id { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public string Usuario { get; private set; }


    }
}