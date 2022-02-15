using System.Collections.Generic;

namespace Trab
{
    public class Lista : List<Produto>
    {
        public List<Produto> prods = new List<Produto>();

        public override string ToString()
        {
            var produtos = "Minha Lista - Meu ToString\r\n";
            ForEach(p =>
            {
                produtos += $"Produto : {p.Codigo} - {p.Descricao}\r\n";
            });
            return produtos;
        }
    }
}
