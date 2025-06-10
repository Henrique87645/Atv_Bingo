using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AppBingo
{
    public partial class FormCartelaBingo : Form
    {

        Array ListaDosNumeorosSorteados;

        public string NomeJogador { get; private set; }
        public string NumerosCartela { get; private set; }

        public FormCartelaBingo(string pcaminhoArquivoAtual, Array pListaDosNumeorosSorteados)
        {
            InitializeComponent();
            ListaDosNumeorosSorteados = pListaDosNumeorosSorteados;
        }

        private bool SolicitarCartela(out List<int> cartela)
        {
            cartela = new List<int>();
            string nomeJogador = txtNomeJogador.Text.Trim();
            string numCartela = txtNumCartela.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeJogador) || string.IsNullOrWhiteSpace(numCartela))
            {
                MessageBox.Show("Erro ao conferir cadastro.\nPreencha todos os campos!",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Tentar converter a string da cartela em números inteiros
            string[] numeros = numCartela.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var numStr in numeros)
            {
                if (int.TryParse(numStr.Trim(), out int numero))
                {
                    if (!cartela.Contains(numero))
                        cartela.Add(numero);
                }
                else
                {
                    MessageBox.Show($"Número inválido encontrado na cartela: '{numStr}'",
                        "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public void Conferir()
        {
            if (!SolicitarCartela(out List<int> cartela))
            {
                MessageBox.Show("Informações inválidas!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cartela.Count != 5)
            {
                MessageBox.Show("A cartela deve conter exatamente 5 números diferentes!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lista de números sorteados
            List<int> sorteados = ListaDosNumeorosSorteados.Cast<int>().ToList();

            // Verificar se TODOS os números da cartela foram sorteados
            bool todosSorteados = cartela.All(num => sorteados.Contains(num));

            if (todosSorteados)
            {
                MessageBox.Show("BINGO! Parabéns, todos os números foram sorteados!",
                    "BINGO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Salvar os dados para o Form1
                NomeJogador = txtNomeJogador.Text.Trim();
                NumerosCartela = txtNumCartela.Text.Trim();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cartela inválida! Alguns números ainda não foram sorteados.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Fecha o formulário sem sucesso
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnConferirBingo_Click(object sender, EventArgs e)
        {
            Conferir();
        }
    }
}
