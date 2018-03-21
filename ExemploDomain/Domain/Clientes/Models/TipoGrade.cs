using System.Collections.Generic;
using System.Linq;

namespace Domain.Clientes.Models
{
    public static class TipoGrade
    {
        public static string ObterGradeExclusivaPeloPais(string pais)
        {
            var tabela = new Dictionary<string, string>
            {
                {"AFRICA DO SUL", "Europa"},
                {"ALEMANHA", "Europa"},
                {"ARABIA SAUDITA", "Europa"},
                {"BARBADOS", "Europa"},
                {"BELGICA", "Europa"},
                {"BOTSUANA", "Europa"},
                {"CANADA", "USA"},
                {"CAZAQUISTAO REPUBLI", "Europa"},
                {"CHILE", "Mercosul"},
                {"CHINA", "Europa"},
                {"CHIPRE", "Europa"},
                {"COLOMBIA", "Mercosul"},
                {"COSTA RICA", "Mercosul"},
                {"CROACIA", "Europa"},
                {"DINAMARCA", "Europa"},
                {"EL SALVADOR", "Mercosul"},
                {"EMIRADOS ARABES", "Europa"},
                {"EQUADOR", "Mercosul"},
                {"ESTADOS UNIDOS", "USA"},
                {"FRANCA", "Europa"},
                {"GANA", "Europa"},
                {"GRECIA", "Europa"},
                {"GUATEMALA", "Mercosul"},
                {"HONG KONG", "Europa"},
                {"INGLATERRA", "Europa"},
                {"IRLANDA", "Europa"},
                {"ISRAEL", "Europa"},
                {"ITALIA", "Europa"},
                {"JAPAO", "Europa"},
                {"KUWAIT", "Europa"},
                {"LESOTHO", "Europa"},
                {"MALASIA", "Europa"},
                {"MARROCOS", "Europa"},
                {"MOLDAVIA", "Europa"},
                {"PANAMA", "Europa"},
                {"PERU", "Mercosul"},
                {"PORTO RICO", "USA"},
                {"PORTUGAL", "Europa"},
                {"REPUBLICA DEMOCRATICA DO CONGO", "Europa"},
                {"REPUBLICA DOMINICANA", "USA"},
                {"ROMENIA", "Europa"},
                {"RUSSIA", "Europa"},
                {"SUICA", "Europa"},
                {"TAILANDIA", "Europa"},
                {"UCRANIA", "Europa"},
                {"VENEZUELA", "Mercosul"},
                {"ZIMBABUE", "Europa"}

            };

            if (tabela.ContainsKey(pais))
            {
                return tabela.FirstOrDefault(x => x.Key.Equals(pais)).Value;
            }

            return "Padrao";
        }
    }
}

