using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Repositories
{
    public interface IImportacaoClienteKundenRepository
    {
        bool ExisteCliente(string cnpj);
        Cliente Importar(Cliente clienteImportacao);

    }
}