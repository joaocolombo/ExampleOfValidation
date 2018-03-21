using System.Collections.Generic;
using Core.Models;
using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Services
{
    public interface ILogClienteService
    {
        void GravarLog(string jsonCliente, string comando, string usuario
            , string representanteId, List<Error> erros, string clienteId);
    }
}