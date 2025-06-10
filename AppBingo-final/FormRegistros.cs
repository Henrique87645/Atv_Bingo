using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBingo
{
    public partial class FormRegistros : Form
    {
        public FormRegistros()
        {
            InitializeComponent();
        }
        //Função que retorna o camiunho da pasta 
        string GetCaminhoCadastro(string nomeCadastro)
        {
            //Recuperar o diretório 
            string raizExe = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(raizExe, nomeCadastro);
        }
        void ListarArquivos(string caminho)
        {
            //recuperar todos os arquivos .txt do caminho, onde cada arquivo tem seu diretório, onde cada diretório será uma string
            try
            {
                string[] arquivos = Directory.GetFiles(caminho, "*.txt");

                if (arquivos.Length == 0)
                {
                    MessageBox.Show("Não existem arquivos cadastrados", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lsbCadastros.Items.AddRange(arquivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar os cadastros " + Environment.NewLine, "Erro original: " + ex.Message + "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            //Iremos chamar o metodo para listar os arquivos 
            //o nome da pasta deve possuir o mesmo nome utilizado na tela de cadastro no momento da gravação do arquivo

            ListarArquivos(GetCaminhoCadastro("Clientes"));

        }

        private void lsbCadastros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCadastros.SelectedItems != null)
            {
                string caminhoArquivo = lsbCadastros.SelectedItem.ToString();
                txtConteudo.Text = CarregarArquivo(caminhoArquivo);
            }
        }

        string CarregarArquivo(string arquivo)
        {
            string conteudo = "";

            try
            {
                conteudo = File.ReadAllText(arquivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o conteúdo" + Environment.NewLine + "Erro original: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Se teve algum problema e a variavel não foi copulada retorna vazio
            //se deu tudo certo retorna o conteúdo do arquiovo
            return conteudo;
        }
    }
}
