using System;
using ConsoleFuncionario.Entities;
using ConsoleFuncionario.Repository;

namespace ConsoleFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDep = 0;
            Funcionario funcionario = new Funcionario();
            //List<Dependente> listaDependentes = new List<Dependente>();


            Console.Write("Informe o Id do Funcionário.................: ");
            funcionario.Id = int.Parse(Console.ReadLine());

            Console.Write("Informe o Nome do Funcionário...............: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Informe a Data de Admissão do Funcionário...: ");
            funcionario.DataAdmissao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\n\nInforme o Número de Dependentes..: \n");
            numDep = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < numDep; i++)
            {
                Dependente dependente = new Dependente();
                //Inserindo Dependentes
                Console.Write("\nInforme o Id do Dependente.................: ");
                dependente.DependenteId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Informe o Nome do Dependente.................: ");
                dependente.Nome = Console.ReadLine();
                Console.Write("Informe a Data de Nascimento do Dependente...: ");
                dependente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

                //listaDependentes.Add(dependente);
                funcionario.Dependentes.Add(dependente);
            }

            //Exportar para TXT
            FuncionarioRepository.ExportarParaTXT(funcionario);
            //Exportar para JSON
            FuncionarioRepository.ExportarParaJSON(funcionario);
            //Exportar para XML
            FuncionarioRepository.ExportarParaXML(funcionario);
        }
    }
}
