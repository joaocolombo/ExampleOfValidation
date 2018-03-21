using Domain.Clientes.Models;

namespace Domain.Clientes.Interfaces.Repositories
{
    public interface ILogClienteRepository
    {
        void GravarLog(Log log);
    }
}