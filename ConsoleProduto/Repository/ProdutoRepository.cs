using System;
using ConsoleProduto.Entities;
using System.IO;

namespace ConsoleProduto.Repository
{
    public class ProdutoRepository
    {
        public void ExportarParaTXT(Produto p)
        {
            //criando uma variável para definir o nome do arquivo
            string nomeArquivo = "produtos.txt";

            //abrindo o arquivo para gravação..
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            using (StreamWriter writer = File.AppendText(path + nomeArquivo))
            {
                writer.WriteLine("Id.................: " + p.ProdutoId);
                writer.WriteLine("Nome...............: " + p.Nome);
                writer.WriteLine("Preço  ............: " + p.Preco.ToString("c")); //currency
                writer.WriteLine("Data de Validade...: " + p.DataValidade.ToString("dd/MM/yyyy"));
                writer.WriteLine("Categoria..........: " + p.Categoria.CategoriaID);
                writer.WriteLine("Categoria Descricão: " + p.Categoria.Descricao);
                writer.WriteLine();

            }

        }
    }
}
