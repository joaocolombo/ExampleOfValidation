using System.Collections.Generic;
using Domain.Clientes.Interfaces.Repositories;
using Domain.Clientes.Interfaces.Services;
using Domain.Clientes.Models;

namespace Domain.Clientes.Services
{
    public class BuscaService: IBuscaClienteService
    {
        private readonly IBuscaClienteRepository _buscarRepository;
        public BuscaService(IBuscaClienteRepository iBuscarClienteRepository)
        {
            _buscarRepository = iBuscarClienteRepository;

        }

        public List<Cliente> BuscarClientesParaNegotti()
        {
            return null;
            //  return _kunden.BuscarClientesParaNegotti();
        }

        public Cliente BuscarClienteLinxPorId(string id)
        {
            return _buscarRepository.BuscarClienteLinxPorId(id);
        }

        public Cliente BuscarClienteLinxPorCnpj(string cnpj)
        {
            return _buscarRepository.BuscarClienteLinxPorCnpj(cnpj);
        }
        public Cliente BuscarClienteKundenPorCnpj(string cnpj)
        {
        
            return _buscarRepository.BuscarClienteKundenPorCnpj(cnpj);
        }
    }
}