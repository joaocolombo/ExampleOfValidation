namespace Domain.Produtos.Models
{
    public class Classificacao
    {
        public Classificacao(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public string Id { get; private set; }
        public string Descricao { get; private set; }
    }
}