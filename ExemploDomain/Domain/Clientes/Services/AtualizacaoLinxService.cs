using System;
using Core.Models;
using Domain.Clientes.Interfaces.Repositories;
using Domain.Clientes.Models;

namespace Domain.Clientes.Services
{
    public class AtualizacaoLinxService
    {
        private readonly IBuscaClienteRepository _busca;

        public AtualizacaoLinxService(IBuscaClienteRepository busca)
        {
            _busca = busca;
        }


        public Cliente Atualizar(Cliente clienteAtualizado)
        {
            if (!clienteAtualizado.EhValido()) return clienteAtualizado;
            var clienteDesatualizado = _busca.BuscarClienteLinxPorId(clienteAtualizado.Id);
            if (clienteDesatualizado==null)
            {
                clienteAtualizado.Erros.Add(Error.ErrorFactory.NewError
                    ("Cliente"
                    , $"Impossivel alterar cliente pois ele não existe. Id: {clienteAtualizado.Id}"
                    , ErroTypes.Error));
                return clienteAtualizado;
            }
            clienteAtualizado = AtualizarPropriedades(clienteAtualizado);
            return clienteAtualizado;

        }

        private Cliente AtualizarPropriedades(Cliente clienteAtualizado)
        {
            clienteAtualizado = AtualizarNomeFantasia(clienteAtualizado);
            return clienteAtualizado;
        }

        private Cliente AtualizarNomeFantasia(Cliente clienteAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}