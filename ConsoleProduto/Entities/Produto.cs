using System;

namespace ConsoleProduto.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public String  Nome { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataValidade { get; set; }

        public Categoria Categoria { get; set; }
    }
}
