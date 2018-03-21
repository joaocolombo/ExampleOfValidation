using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Repositories
{
    public interface IImportacaoClienteLinxRepository
    {
        void PreencherCodigoKunden(Cliente cliente);
        Cliente Importar(Cliente cliente);
        string BuscarClienteCnpjPorCodigoKunden(string codigoKuden);
        Cliente VincularClienteAoCadastroCliFor(Cliente cliente);
        int ContarCadastroCliFor(string cnpj);
        bool ExisteCliente(string cnpj);
    }
}