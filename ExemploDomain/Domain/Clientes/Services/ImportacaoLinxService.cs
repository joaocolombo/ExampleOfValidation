using System;
using System.Linq;
using Core.Models;
using Domain.Clientes.Interfaces.Repositories;
using Domain.Clientes.Interfaces.Services;
using Domain.Clientes.Models;

namespace Domain.Clientes.Services
{
    public class ImportacaoLinxService : IImportcaoClienteLinxService
    {
        private readonly IImportacaoClienteLinxRepository _linxRepository;

        public ImportacaoLinxService(IImportacaoClienteLinxRepository iImportacaoLinxRepository)
        {
            _linxRepository = iImportacaoLinxRepository;
        }

        public Cliente ImportarClienteDoKunden(Cliente clienteImportacao)
        {
            if (clienteImportacao.Erros.Any()) return clienteImportacao;
            if (TemVinculoKunden(clienteImportacao.CodigoKunden))
                return ValidarClienteComCodigoKunden(clienteImportacao);
            return Importar(clienteImportacao);
        }

        public Cliente Importar(Cliente clienteImportacao)
        {
            if (clienteImportacao.Erros.Any()) return clienteImportacao;
            if (ExisteCadastroCliFor(clienteImportacao.Cnpj.Valor))
                return VincularClienteAoCadastroCliFor(clienteImportacao);
            clienteImportacao.AjustarNomeFantasia();
            var clienteImportado = _linxRepository.Importar(clienteImportacao);
            PreencherCodigoKunden(clienteImportado);
            return clienteImportado;
        }


        private bool TemVinculoKunden(string codigoKunden)
        {
            return _linxRepository.BuscarClienteCnpjPorCodigoKunden(codigoKunden)!= null;
        }

        private bool ExisteCadastroCliFor(string cnpj)
        {
            return _linxRepository.ContarCadastroCliFor(cnpj) != 0;
        }

        private Cliente ValidarClienteComCodigoKunden(Cliente cliente)
        {
            var cnpj = _linxRepository.BuscarClienteCnpjPorCodigoKunden(cliente.CodigoKunden);
            if (!CnpjSaoIguais(cliente.Cnpj.Valor, cnpj))
                cliente.Erros.Add(Error.ErrorFactory.NewError("CNPJ", "Cnpj do Linx difere do importado",
                    ErroTypes.Error));
            return cliente;
        }

        private Cliente VincularClienteAoCadastroCliFor(Cliente cliente)
        {
            if (!CadastroCliforEhSingular(cliente.Cnpj.Valor))
                cliente.Erros.Add(Error.ErrorFactory.NewError("CadastroCliFor",
                    "Existe mais de um cadastroCliFor para esse Cnpj", ErroTypes.Error));
            if (cliente.Erros.Any()) return cliente;
            if (ExisteClienteComEsseCnpj(cliente.Cnpj.Valor))
            {
                PreencherCodigoKunden(cliente);
                return cliente;
            }
            var clienteImportado = _linxRepository.VincularClienteAoCadastroCliFor(cliente);
            PreencherCodigoKunden(clienteImportado);
            return clienteImportado;
        }

        private bool ExisteClienteComEsseCnpj(string cnpj)
        {
            return _linxRepository.ExisteCliente(cnpj);
        }

        private void PreencherCodigoKunden(Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.CodigoKunden))
                _linxRepository.PreencherCodigoKunden(cliente);
        }

        private bool CnpjSaoIguais(string cnpjImportado, string cnpjBase)
        {
            var cnpjImportadoNormalizado = Convert.ToInt64(cnpjImportado);
            var cnpjBaseNormalizado = Convert.ToInt64(cnpjBase);
            return cnpjImportadoNormalizado == cnpjBaseNormalizado;
        }

        private bool CadastroCliforEhSingular(string cnpj)
        {
            return _linxRepository.ContarCadastroCliFor(cnpj) == 1;
        }
    }
}