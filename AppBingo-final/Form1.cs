using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AppBingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string SoNumero(string Texto)
        {
            string resultado = "";
            for (int i = 0; i < Texto.Length; i++)
            {
                if (char.IsDigit(Texto[i]))
                {
                    resultado += Texto[i];
                }
            }
            return resultado;
        }

        bool ArquivoExiste(string caminho)
        {
            return File.Exists(caminho);
        }

        void GravarArquivo(string caminho, string conteudo)
        {
            string pasta = Path.GetDirectoryName(caminho);
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            File.WriteAllText(caminho, conteudo);
        }

        string GetDirArquivo(string nomePasta, string nomeArquivo)
        {
            string raizExe = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(raizExe, nomePasta, nomeArquivo + ".txt");
        }

        public DateTime inicioBingo = DateTime.Now;  // Corrigido para DateTime

        string GetCadastro()
        {
            string cadastro = "Nome do Prêmio: " + txtPremio.Text + Environment.NewLine +
                              "Horário de início: " + inicioBingo.ToShortTimeString();
            return cadastro;
        }

        public string caminhoArquivoAtual;

        public void Salvar()
        {
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();

            string caminhoCompleto = GetDirArquivo("Bingo", ("Bingo_" + SoNumero(date) + "_" + SoNumero(time)));

            if (ArquivoExiste(caminhoCompleto))
            {
                MessageBox.Show("Usuário já cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                GravarArquivo(caminhoCompleto, GetCadastro());
                MessageBox.Show("Registro salvo com sucesso!" + Environment.NewLine + Environment.NewLine +
                                "Salvo em :" + caminhoCompleto, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o cadastro." + Environment.NewLine + "Erro original: " + ex.Message,
                                "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            caminhoArquivoAtual = caminhoCompleto;
        }

        private void btnIniciarBingo_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void InicializarLabels()
        {
            for (int i = 1; i <= 75; i++)
            {
                Label lbl = this.Controls.Find($"lbsNum{i}", true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    string letra = GetLetra(i);
                    lbl.Text = $"{letra}\n{i.ToString("00")}";
                    lbl.TextAlign = ContentAlignment.TopCenter;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new Font("Arial", 8, FontStyle.Regular);
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            numerosRestantes = Enumerable.Range(1, 75).ToList();
            InicializarLabels();
        }

        private string GetLetra(int numero)
        {
            if (numero <= 15) return "B";
            if (numero <= 30) return "I";
            if (numero <= 45) return "N";
            if (numero <= 60) return "G";
            return "O";
        }

        private List<int> numerosRestantes;
        private Random random = new Random();
        private string numeroAtual = "";
        private List<int> ListaDosNumeorosSorteados = new List<int>();

        public void SorteioDeNumeros()
        {
            if (numerosRestantes.Count == 0)
            {
                MessageBox.Show("Todos os números foram sorteados!");
                return;
            }

            int aleatorio = random.Next(numerosRestantes.Count);
            int numeroSorteado = numerosRestantes[aleatorio];
            numerosRestantes.RemoveAt(aleatorio);

            string letra = GetLetra(numeroSorteado);
            string resultado = $"{letra} {numeroSorteado}";

            if (!string.IsNullOrEmpty(numeroAtual))
            {
                lblNumAnterior.Text = numeroAtual;
            }

            numeroAtual = resultado;
            lblNumAtual.Text = numeroAtual;

            Label lbl = this.Controls.Find($"lbsNum{numeroSorteado}", true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.BackColor = Color.Green;
            }

            File.AppendAllText(caminhoArquivoAtual, Environment.NewLine + $"Sorteado: {numeroAtual}");
            ListaDosNumeorosSorteados.Add(numeroSorteado);
        }

        private void btnSortearNumero_Click(object sender, EventArgs e)
        {
            SorteioDeNumeros();
        }

        string nomeJogador;
        string numerosDigitados;

        private void btnBingo_Click(object sender, EventArgs e)
        {
            FormCartelaBingo formCartela = new FormCartelaBingo(
                caminhoArquivoAtual,
                ListaDosNumeorosSorteados.ToArray());

            if (formCartela.ShowDialog() == DialogResult.OK)
            {
                nomeJogador = formCartela.NomeJogador;
                numerosDigitados = formCartela.NumerosCartela;
 
            }
        }


        private void btnFinalizarBingo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeJogador) || string.IsNullOrEmpty(numerosDigitados))
            {
                MessageBox.Show("Preencha o nome e os números da cartela!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime horaFinal = DateTime.Now;
            TimeSpan duracao = horaFinal - inicioBingo;

            List<string> numerosSorteados = ListaDosNumeorosSorteados.Select(n => n.ToString()).ToList();

            string textoFinal = Environment.NewLine +
                                "======== FIM DO BINGO ========" + Environment.NewLine +
                                "Nome do vencedor: " + nomeJogador + Environment.NewLine +
                                "Números da cartela: " + string.Join(", ", numerosDigitados) + Environment.NewLine +
                                "Hora de término: " + horaFinal.ToShortTimeString() + Environment.NewLine +
                                "Tempo total: " + duracao.Minutes + " minuto(s) e " + duracao.Seconds + " segundo(s)" + Environment.NewLine +
                                "Números sorteados: " + string.Join(", ", numerosSorteados) + Environment.NewLine +
                                "==============================";

            try
            {
                File.AppendAllText(caminhoArquivoAtual, textoFinal);
                MessageBox.Show("Bingo finalizado e salvo no arquivo!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Iremos abrir o seu registro de bingo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistros tela = new FormRegistros();
                tela.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
