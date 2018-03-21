using System.Collections.Generic;

namespace Domain.Produtos.Models.Negotti
{
    public class AtributoNegotti
    {
        public AtributoNegotti(string key, Classificacao classificacao, bool description = false, bool lineBreak = false)
        {
            Key = key;
            Value = classificacao.Id;
            Title = classificacao.Descricao;
            Description = description;
            LineBreak = lineBreak;
        }

        public AtributoNegotti(string key, string value, string title, bool description = false, bool lineBreak = false)
        {
            Key = key;
            Value = value;
            Title = title;
            Description = description;
            LineBreak = lineBreak;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public string Title { get; private set; }
        public bool Description { get; private set; }
        public bool LineBreak { get; private set; }
        public bool Label => false;

    }
}