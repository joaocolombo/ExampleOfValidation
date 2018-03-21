using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Pedidos.Models
{
    public class Item:ValueObject
    {
        private IList<Grade> _grade;

        public string ProdutoId { get; set; }
        public IReadOnlyCollection<Grade> Grade => _grade.ToArray();
        public int Quantidade => Grade.Sum(x => x.Quantidade);
        public DateTime Entrega { get; set; }

        public void AdicionarGrade(IList<Grade> grade)
        {
            _grade = grade;
        }


        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }

}
}