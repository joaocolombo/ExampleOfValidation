using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Core.Models;
using Core.ObjectsValue;

namespace Domain.Clientes.Models
{
    public class Cliente : Entity
    {
        private Cliente()
        {
            Erros = new List<Error>();

        }

        private string _codigoKunden;

        public Representante Representante { get; private set; }
        public string CodigoKunden
        {
            get => _codigoKunden;
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (!string.IsNullOrEmpty(_codigoKunden)) return;
                _codigoKunden = value;
            }
        }
        public Cnpj Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string InscricaoMunicipal { get; private set; }
        public string NomeFantasia { get; private set; }
        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Mercado { get; private set; }
        public string GradePais => TipoGrade.ObterGradeExclusivaPeloPais(Endereco.Pais);
        public List<CondicaoPagamento> CondicoesPagamento { get; set; }
        public string Usuario { get; private set; }
        public bool Inativo { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FimVigencia { get; private set; }
        public bool CompraJorgeBischoff { get; private set; }
        public bool CompraLoucosSantos { get; private set; }
        public string PropriedadeNomeFantasia { get; private set; }


        public void AtribuirContato(Contato contato)
        {
            Contato = contato;
            ValidarContato();
        }
        public void AtribuirCnpj(Cnpj cnpj)
        {
            Cnpj = cnpj;
            ValidarCnpj();
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
            ValidarEndereco();
            
        }

        public void AtribuirRepresentante(Representante representate)
        {
            Representante = representate;
            ValidarRepresentate();
        }

        public void AjustarNomeFantasia()
        {
            PropriedadeNomeFantasia = NomeFantasia;
            if (NomeFantasia.Length > 23)
                NomeFantasia = NomeFantasia.Substring(0, 22);
           var hash = Guid.NewGuid().ToString().Substring(0, 2);
            NomeFantasia +="-"+ hash;
        }
        



        #region Validations

        public override bool EhValido()
        {
            Erros = new List<Error>();
            ValidarSituacao();
            ValidarVigente();
            ValidarEndereco();
            ValidarContato();
            ValidarCnpj();
            ValidarInscricaoEstadual();
            ValidarRazaoSocial();
            ValidarNomeFantasia();

            return !Erros.Any();
        }

        public bool EhValidoKunden()
        {
            Erros = new List<Error>();
            ValidarSituacao();
            ValidarVigente();
            ValidarEndereco();
            ValidarContato();
            PossuiCodigoKunden();

            return !Erros.Any();
        }

        private void ValidarRepresentate()
        {
            
        }

        private void ValidarSituacao()
        {
            if (Inativo)
                Erros.Add(
                    Error.ErrorFactory.NewError("Situação",
                        "A Situação do cliente é diferente de Liberado ou é Inativo", ErroTypes.Error));
        }

        private void ValidarVigente()
        {
            if ((InicioVigencia > DateTime.Now || FimVigencia < DateTime.Now) &&
                (InicioVigencia != DateTime.MinValue || FimVigencia != DateTime.MinValue))
                Erros.Add(Error.ErrorFactory.NewError("Vigente", "O Cliente não esta vigente", ErroTypes.Error));
        }

        private void ValidarEndereco()
        {
            if (Endereco == null)
            {
                Erros.Add(Error.ErrorFactory.NewError("Endereço", "O Cliente não possui endereço", ErroTypes.Error));
                return;
            }
            if (Endereco.EhValido()) return;
            foreach (var erro in Endereco.Erros)
                Erros.Add(erro);
        }

        private void ValidarContato()
        {
            if (Contato == null)
            {
                Erros.Add(Error.ErrorFactory.NewError("Contato", "O Cliente não possui contato", ErroTypes.Error));
                return;
            }
            if (Contato.EhValido()) return;
            foreach (var erro in Contato.Erros)
                Erros.Add(erro);
        }

        private void ValidarCnpj()
        {
            if (!Cnpj.EhValido())
                Erros.Add(Error.ErrorFactory.NewError("Cnpj", "O Cnpj é Invalido", ErroTypes.Error));
        }

        private void ValidarInscricaoEstadual()
        {
            if (string.IsNullOrEmpty(InscricaoEstadual))
                Erros.Add(Error.ErrorFactory.NewError("Inscricao estadual",
                    "A inscricao estadual não pode ser nula nem vazia", ErroTypes.Error));
        }

        private void ValidarRazaoSocial()
        {
            if (string.IsNullOrEmpty(RazaoSocial))
                Erros.Add(Error.ErrorFactory.NewError("Razao Social", "A razão social esta vazia", ErroTypes.Error));

            if (RazaoSocial.Length < 5)
                Erros.Add(Error.ErrorFactory.NewError("Razao Social", "A razão social precisa ter mais de 5 caracteres",
                    ErroTypes.Error));
        }

        private void ValidarNomeFantasia()
        {
            if (string.IsNullOrEmpty(NomeFantasia))
                Erros.Add(Error.ErrorFactory.NewError("Nome Fantasia", "O nome fantasia esta vazio", ErroTypes.Error));

            if (NomeFantasia.Length < 5)
                Erros.Add(Error.ErrorFactory.NewError("Nome Fantasia", "Deve ser ter entre mais 5 ",
                    ErroTypes.Error));
        }

        private void PossuiCodigoKunden()
        {
            if (string.IsNullOrEmpty(CodigoKunden))
                Erros.Add(Error.ErrorFactory.NewError("Codigo Kunden", "o Cliente não possui codigo Kunden",
                    ErroTypes.Warning));
        }

        #endregion

        #region Factories
        
        public static class ClienteFactory
        {
            public static Cliente ImportarClienteKundenParaLinx(string nomeFantasia, string rasaoSocial, string cnpj,
                string inscricaoEstadual, string email, string emailNfe, string telefoneNumero, string ddd,
                string ddi, string pais, string estado, string cidade, string bairro,
                string logradouro, string cep, string numero, string cnpjRepresentante, string usuarioRepresentante,
                string idRepresentante, string codigoKunden, string complemento = null)
            {
                var cliente = new Cliente()
                {
                    NomeFantasia = nomeFantasia,
                    RazaoSocial = rasaoSocial,
                    Cnpj = new Cnpj(cnpj),
                    InscricaoEstadual = inscricaoEstadual,
                    CodigoKunden = codigoKunden,
                    Contato = new Contato(email, emailNfe, new Telefone(telefoneNumero, ddd, ddi)),
                    Endereco = new Endereco(pais, estado, cidade, bairro, logradouro, cep, numero, complemento),
                    Representante = new Representante(new Cnpj(cnpjRepresentante), usuarioRepresentante, idRepresentante)

                };
                cliente.EhValidoKunden();
                return cliente;
            }

            public static Cliente ImportarCliente(string nomeFantasia, string rasaoSocial, string cnpj,
                string inscricaoEstadual, string email, string emailNfe, string telefoneNumero, string ddd,
                string ddi, string pais, string estado, string cidade, string bairro, string logradouro,
                string cep, string numero, string cnpjRepresentante, string usuarioRepresentante,
                string idRepresentante, string complemento = null)
            {
                var cliente = new Cliente()
                {
                    NomeFantasia = nomeFantasia,
                    RazaoSocial = rasaoSocial,
                    Cnpj = new Cnpj(cnpj),
                    InscricaoEstadual = inscricaoEstadual,
                    Contato = new Contato(email, emailNfe, new Telefone(telefoneNumero, ddd, ddi)),
                    Endereco = new Endereco(pais, estado, cidade, bairro, logradouro, cep, numero, complemento),
                    Representante = new Representante(new Cnpj(cnpjRepresentante), usuarioRepresentante, idRepresentante)

                };
                cliente.EhValido();
                return cliente;
            }

            public static Cliente Exportar(string id ,string nomeFantasia, string rasaoSocial, string cnpj,
                string inscricaoEstadual, string email, string emailNfe, string telefoneNumero, string ddd,
                string ddi, string pais, string estado, string cidade, string bairro, string logradouro,
                string cep, string numero, string cnpjRepresentante, string usuarioRepresentante,
                string idRepresentante, string complemento = null)
            {
                var cliente = new Cliente()
                {
                    Id = id,

                    NomeFantasia = nomeFantasia,
                    RazaoSocial = rasaoSocial,
                    Cnpj = new Cnpj(cnpj),
                    InscricaoEstadual = inscricaoEstadual,
                    Contato = new Contato(email, emailNfe, new Telefone(telefoneNumero, ddd, ddi)),
                    Endereco = new Endereco(pais, estado, cidade, bairro, logradouro, cep, numero, complemento),
                    Representante = new Representante(new Cnpj(cnpjRepresentante), usuarioRepresentante,idRepresentante)

                };
                cliente.EhValido();
                return cliente;
            }
        }
        #endregion

    }
}