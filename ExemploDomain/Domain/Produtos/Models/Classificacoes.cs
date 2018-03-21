using Core.Models;

namespace Domain.Produtos.Models
{
    public class Classificacoes
    {
        public Classificacao Grife { get; set; }
        public Classificacao Colecao { get; set; }
        public Classificacao Grupo { get; set; }
        public Classificacao SubGrupo { get; set; }
        public Classificacao Categoria { get; set; }
        public Classificacao SubCategoria { get; set; }
        public Classificacao Tipo { get; set; }
        public Classificacao Lancamento { get; set; }
        public Classificacao Familia { get; set; }
        public Classificacao Sexo { get; set; }
        public Classificacao Cor { get; set; }
        public Classificacao Material { get; set; }
        public Classificacao MaterialCor { get; set; }
        public Classificacao Nicho { get; set; }
        public Classificacao Modelagem { get; set; }
    }
}