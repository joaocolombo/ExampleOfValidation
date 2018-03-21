using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Services
{
    public interface IImportacaoClienteKundenService
    {
        Cliente Importar(Cliente clienteImportacao);
    }
}