using System.Linq;
using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Services
{
    public interface IImportcaoClienteLinxService
    {
        Cliente ImportarClienteDoKunden(Cliente clienteImportacao);
        Cliente Importar(Cliente clienteImportacao);
    }
}