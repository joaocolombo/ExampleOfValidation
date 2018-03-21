using System;
using Core.Models;

namespace Core.ObjectsValue
{
    public class Cnpj : ValueObject
    {
        public Cnpj(string valor)
        {
            if (string.IsNullOrEmpty(valor)) return;
            Valor = valor.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public string Valor { get; private set; }

        public override string ToString()
        {
            return Valor;
        }

        public override bool EhValido()
        {
            return Validar();
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(Valor)) return false;
            if (Convert.ToInt64(Valor) == 0) return false;
            if (Valor.Length != 14) return false;

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var soma = 0;
            var resto = 0;
            
            var tempCnpj = Valor.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return Valor.EndsWith(digito);
        }
    }

}