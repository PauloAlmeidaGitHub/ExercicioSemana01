using System;
using ConsoleFuncionario.Entities;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace ConsoleFuncionario.Repository
{
    public class FuncionarioRepository
    {
        static string nomeArquivo = "funcionarios";

        //abrindo o arquivo para gravação..
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";

        #region Exportar
        //------------------------------------------------------------------------------------------
        public static void ExportarParaTXT(Funcionario funcionario)
        {
            using (StreamWriter writer = File.AppendText(path + nomeArquivo + ".txt"))
            {
                writer.WriteLine("Id.................: " + funcionario.Id);
                writer.WriteLine("Nome...............: " + funcionario.Nome);
                writer.WriteLine("Data de Admissão...: " + funcionario.DataAdmissao);
                writer.WriteLine();
                for (int i = 0; i < funcionario.Dependentes.Count; i++)
                {
                    writer.WriteLine("IdDependente.......: " + funcionario.Dependentes[i].DependenteId);
                    writer.WriteLine("Nome...............: " + funcionario.Dependentes[i].Nome);
                    writer.WriteLine("Data de Nascimento.: " + funcionario.Dependentes[i].DataNascimento);
                }
            }
            MessageBox.Show("Arquivo TXT gerado com sucesso!");
        }
        //------------------------------------------------------------------------------------------
        public static void ExportarParaJSON(Funcionario funcionario)
        {
            //criando um arquivo JSON..
            using (StreamWriter streamWriter = new StreamWriter(path + nomeArquivo + ".json"))
            {
                //transformar o objeto 'funcionario' em JSON
                string dados = JsonConvert.SerializeObject(funcionario, Newtonsoft.Json.Formatting.Indented);

                //escrever no arquivo..
                streamWriter.WriteLine(dados);
            }
            MessageBox.Show("Arquivo JSON gerado com sucesso!");
        }
        //------------------------------------------------------------------------------------------
        public static void ExportarParaXML(Funcionario funcionario)
        {
            //nome do arquivo..
            string dataHora = "_"+DateTime.Now.ToString("ddMMyyyyHHmmss");
            //string nomeArquivo = $"funcionario_{dataHora}.xml";

            //abrindo o arquivo XML
            using (XmlWriter xml = XmlWriter.Create($"{path + nomeArquivo + dataHora + ".xml"}"))
            {
                //escrevendo o cabeçalho do arquivo XML
                xml.WriteStartDocument(); //<?xml version='1.0'?>.

                xml.WriteStartElement("funcionario");
                for (int i = 0; i < funcionario.Dependentes.Count; i++)
                {
                    xml.WriteElementString("id", funcionario.Id.ToString("D4"));
                    xml.WriteElementString("nome", funcionario.Nome);
                    xml.WriteElementString("dataAdmissao", funcionario.DataAdmissao.ToString("dd/MM/yyyy"));

                    xml.WriteStartElement("dependentes");
                        xml.WriteElementString("Id", funcionario.Dependentes[i].DependenteId.ToString());
                        xml.WriteElementString("nome", funcionario.Dependentes[i].Nome);
                        xml.WriteElementString("dataNascimento", funcionario.Dependentes[i].DataNascimento.ToString("dd/MM/yyyy"));
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
            MessageBox.Show("Arquivo XML gerado com sucesso!");
        }
        #endregion
    }
}
