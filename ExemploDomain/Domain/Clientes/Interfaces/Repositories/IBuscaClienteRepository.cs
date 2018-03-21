using System.Collections.Generic;
using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Repositories
{
    public interface IBuscaClienteRepository
    {
        List<Cliente> BuscarClientesParaNegotti();
        Cliente BuscarClienteLinxPorId(string id);
        Cliente BuscarClienteLinxPorCnpj(string cnpj);
        Cliente BuscarClienteLinxPorCodigoKunden(string codigoKuden);
        Cliente BuscarClienteKundenPorCnpj(string cnpj);
    }
}