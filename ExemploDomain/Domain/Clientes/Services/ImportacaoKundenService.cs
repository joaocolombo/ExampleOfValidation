
using System.Linq;
using Domain.Clientes.Interfaces.Repositories;
using Domain.Clientes.Interfaces.Services;
using Domain.Clientes.Models;

namespace Domain.Clientes.Services
{
    public class ImportacaoKundenService : IImportacaoClienteKundenService
    {
        private readonly IImportacaoClienteKundenRepository _kundenRepository;
        private readonly IBuscaClienteRepository _busca;

        public ImportacaoKundenService(IImportacaoClienteKundenRepository kundenRepository, IBuscaClienteRepository busca)
        {
            _kundenRepository = kundenRepository;
            _busca = busca;
        }
            
        public Cliente Importar(Cliente clienteImportacao)
        {
            if (clienteImportacao.Erros.Any()) return clienteImportacao;
            if (ExisteCliente(clienteImportacao.Cnpj.Valor))
                return _busca.BuscarClienteKundenPorCnpj(clienteImportacao.Cnpj.Valor);
            return _kundenRepository.Importar(clienteImportacao);
        }

        private bool ExisteCliente(string cnpj)
        {
            return _kundenRepository.ExisteCliente(cnpj);
        }
    }
}