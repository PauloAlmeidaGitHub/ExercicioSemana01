using System;
using ConsoleProduto.Entities;
using ConsoleProduto.Repository;

namespace ConsoleProduto
{
    class Program
    {
        static void Main(string[] args)
        {
            string loop = "";
            DateTime dataValidade = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            Produto produto = new Produto();
            produto.Categoria = new Categoria();
            ProdutoRepository repository = new ProdutoRepository();

            Console.WriteLine("Informe o Id do Produto...........: ");
            produto.ProdutoId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o Nome do Produto.........: ");
            produto.Nome = Console.ReadLine();
            Console.WriteLine("Informe o Preço do Produto........: ");
            produto.Preco = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Data de validade do Produto.......: " + dataValidade);
            produto.DataValidade = dataValidade;
            Console.WriteLine("Informe o Id da Categoria.........: ");
            produto.Categoria.CategoriaID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe a descrição da categoria..: ");
            produto.Categoria.Descricao = Console.ReadLine();

            repository.ExportarParaTXT(produto);

            Console.WriteLine("\n\n Escreva FIM para terminar ou <ENTER> para continuar");
            loop = Console.ReadLine();
            if (!loop.Equals("FIM")) Main(null);
            
        }
    }
}
