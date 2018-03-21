using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Produtos.Models.Negotti
{
    public class ProdutoNegotti : ValueObject
    {
        public ProdutoNegotti( string gradeExclusiva, string agrupamento)
        {
            GradeExclusiva = gradeExclusiva;
            Agrupamento = agrupamento;
        }
        private List<string> _entregas { get; set; }
        private List<int> _quantidadesAceitas { get; set; }
        private List<string> _tamanhosBloqueados { get; set; }
        private List<AtributoNegotti> _atributos { get; set; }

        public string GradeExclusiva { get; private set; }
        public IReadOnlyList<string> Entregas => _entregas;
        public IReadOnlyList<string> TamanhosBloqueados => _tamanhosBloqueados;
        public IReadOnlyList<int> QuantidadeAceitas => _quantidadesAceitas;
        public IReadOnlyList<AtributoNegotti> Atributos => _atributos;
        public FichaTecnica FichaTecnica { get; set; }
        public string Agrupamento { get; private set; }

        public void AtribuirTamanhosBloqueados(List<string> tamanhosBloqueados)
        {
            if (tamanhosBloqueados.Any())
                _tamanhosBloqueados = tamanhosBloqueados;
        }

        public void AtribuirEntregas(DateTime dataInicial, DateTime dataFinal)
        {
            if (dataInicial > dataFinal) throw new ArgumentException("Data inicial Maior que a final");

            _entregas = new List<string>();
            var dataAux = dataInicial.ToShortDateString();
            _entregas.Add(dataAux);

            if (dataInicial.Day <= 15)
                _entregas.Add(new DateTime(dataInicial.Year, dataInicial.Month, 01).AddMonths(1).AddDays(-1).ToShortDateString());

            for (var i = 1; i <= 12; i++)
            {
                dataAux = new DateTime(dataInicial.AddMonths(i).Year, dataInicial.AddMonths(i).Month, 15).ToShortDateString();
                if (Convert.ToDateTime(dataAux) <= dataFinal)
                    _entregas.Add(dataAux);

                var dia = new DateTime(dataInicial.Year, dataInicial.Month, 01).AddMonths(i + 1).AddDays(-1).Day;
                dataAux = new DateTime(dataInicial.AddMonths(i).Year, dataInicial.AddMonths(i).Month, dia).ToShortDateString();
                if (Convert.ToDateTime(dataAux) <= dataFinal)
                    _entregas.Add(dataAux);
            }
        }

        public void AtribuirQuantidadesAceitas(string grife, string grupo, string fabricanteId)
        {
            if (grife.Equals("JORGE BISCHOFF") && grupo.Equals("CALÇADOS"))
            {
                //regra da rede plast
                if (fabricanteId.Equals("001095"))
                    _quantidadesAceitas = new List<int>() { 6, 8, 9, 10, 12, 14 };
                _quantidadesAceitas = new List<int>() { 6, 8, 9, 10, 12 };
            }
            if (grife.Equals("LOUCOS E SANTOS") && grupo.Equals("CALÇADOS"))
            {
                //regra da rede plast
                if (fabricanteId.Equals("001095"))
                    _quantidadesAceitas = new List<int>() { 8, 9, 10, 12, 14 };
                _quantidadesAceitas = new List<int>() { 8, 9, 10, 12 };
            }
        }

        public void AtribuirAtributos(List<AtributoNegotti> atributos)
        {
            if (atributos.Any())
                _atributos = atributos;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}