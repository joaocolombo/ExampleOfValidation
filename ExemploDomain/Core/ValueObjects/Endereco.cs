using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Models;

namespace Core.ObjectsValue
{
    public class Endereco : ValueObject
    {
        public Endereco(string pais, string estado, string cidade, string bairro, string logradouro, string cep, string numero, string complemento = "")
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
        }

        private Endereco()
        {

        }
        private string _cep;

        public string Pais { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Logradouro { get; private set; }
        public string Cep
        {
            get => _cep;
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                value = value.Trim().Replace("-", "");
                _cep = value;
            }
        }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public override string ToString()
        {
            return $"{Cidade}-{Estado} / {Logradouro} {Numero}";
        }


        public override bool EhValido()
        {
            Erros = new List<Error>();
            ValidarPais();
            ValidarEstado();
            ValidarCidade();
            ValidarBairro();
            ValidarLogradouro();
            ValidarCep();
            ValidarNumero();

            return !Erros.Any();
        }

        private void ValidarPais()
        {
            if (string.IsNullOrEmpty(Pais))
            {
                Erros.Add(Error.ErrorFactory.NewError("Pais", "O pais esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Pais.Length < 3)
                Erros.Add(Error.ErrorFactory.NewError("Pais", "O pais precisa ter mais que 3 caracteres", ErroTypes.Error));

        }

        private void ValidarEstado()
        {
            if (string.IsNullOrEmpty(Estado))
            {
                Erros.Add(Error.ErrorFactory.NewError("Estado", "O estado esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Estado.Length != 2)
                Erros.Add(Error.ErrorFactory.NewError("Estado", "O estado deve ter dois caracteres", ErroTypes.Error));
        }

        private void ValidarCidade()
        {
            if (string.IsNullOrEmpty(Cidade))
            {
                Erros.Add(Error.ErrorFactory.NewError("Cidade", "O cidade esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Cidade.Length < 4)
                Erros.Add(Error.ErrorFactory.NewError("Cidade", "O cidade precisa ter mais que 3 caracteres", ErroTypes.Error));

        }

        private void ValidarBairro()
        {
            if (string.IsNullOrEmpty(Bairro))
            {
                Erros.Add(Error.ErrorFactory.NewError("Bairro", "O bairro esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Bairro.Length < 4)
                Erros.Add(Error.ErrorFactory.NewError("Bairro", "O bairro precisa ter mais que 3 caracteres", ErroTypes.Error));

        }

        private void ValidarNumero()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                Erros.Add(Error.ErrorFactory.NewError("Numero", "O numero esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Numero.Length > 6)
                Erros.Add(Error.ErrorFactory.NewError("Numero", "O numero precisa ter menos que 6 caracteres", ErroTypes.Error));

        }

        private void ValidarCep()
        {
            if (string.IsNullOrEmpty(Cep))
            {
                Erros.Add(Error.ErrorFactory.NewError("Cep", "O cep esta nulo ou em branco", ErroTypes.Error));
                return;
            }

            var funcaoRegular = new Regex("d{8}$");
            if (funcaoRegular.IsMatch(Cep) || Cep.Length != 8)
            {
                Erros.Add(Error.ErrorFactory.NewError("Cep", "O cep deve conter 9 digitos", ErroTypes.Error));

            }
        }

        private void ValidarLogradouro()
        {
            if (string.IsNullOrEmpty(Logradouro))
            {
                Erros.Add(Error.ErrorFactory.NewError("Logradouro", "O logradouro esta nulo ou em branco", ErroTypes.Error));
                return;
            }
            if (Logradouro.Length < 6)
                Erros.Add(Error.ErrorFactory.NewError("Logradouro", "O logradouro precisa ter mais que 3 caracteres", ErroTypes.Error));

        }
    }
}