using System.Collections.Generic;
using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Services
{
    public interface IBuscaClienteService
    {
        List<Cliente> BuscarClientesParaNegotti();
        Cliente BuscarClienteLinxPorId(string id);
        Cliente BuscarClienteLinxPorCnpj(string cnpj);
        Cliente BuscarClienteKundenPorCnpj(string cnpj);
    }
}