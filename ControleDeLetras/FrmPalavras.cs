using ControleDeLetras.Repositorio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControleDeLetras
{
    public partial class FrmPalavras : Form
    {
        PalavraRepositorio PalavraRepositorio = new PalavraRepositorio();
        Dictionary<int, string> palavras;

        public FrmPalavras()
        {
            InitializeComponent();
            PalavraRepositorio.VerificaBanco();
        }

        private void FrmPalavras_Load(object sender, EventArgs e)
        {
            AtualizaTela();
        }

        private void AtualizaTela()
        {
            palavras = PalavraRepositorio.ObterPalavras();
            lstPalavras.DataSource = palavras.Select(s => s.Value).ToList();

            MontaGrafico(palavras);

            txtPalavra.Text = "";
        }

        private void MontaGrafico(Dictionary<int, string> palavras)
        {
            // Monta gráfico
            var serie = chtLetras.Series["Letras"];

            chtLetras.ChartAreas[0].AxisX.Interval = 1;
            serie.Points.Clear();
            serie.Color = Color.LightPink;
            foreach (KeyValuePair<string, int> letra in CalculaQtdeLetras(palavras))
            {
                serie.Points.AddXY(letra.Key, letra.Value);
            }
        }

        private IDictionary<string, int> CalculaQtdeLetras(Dictionary<int, string> palavras)
        {
            IDictionary<string, int> letrasQtde = new Dictionary<string, int>();
            var lstPalavars = palavras.Select(s => s.Value).ToList();

            lstPalavars.ForEach(palavra => {
                var letras = palavra.ToUpper().ToCharArray();
                foreach (var letra in letras)
                {
                    if (letrasQtde.ContainsKey(letra.ToString()))
                    {
                        letrasQtde[letra.ToString()] = letrasQtde[letra.ToString()] + 1;
                    }
                    else
                    {
                        letrasQtde.Add(letra.ToString(), 1);
                    }
                }
            });

            return new SortedDictionary<string, int>(letrasQtde);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var palavra = txtPalavra.Text.ToUpper();

            if (palavra == string.Empty) return;

            var retorno = MessageBox.Show($"Confirma inclusão da palavra '{palavra}' ?", "Adicionar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.InserirPalavra(palavra);
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstPalavras.SelectedItem == null) return;

            var retorno = MessageBox.Show($"Confirma remoção da palavra '{lstPalavras.SelectedItem}' ?", "Remover", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.RemoverPalavra(palavras.Where(s=> s.Value == lstPalavras.SelectedItem.ToString()).FirstOrDefault().Key);
                AtualizaTela();
            }
        }

        private void lstPalavras_DoubleClick(object sender, EventArgs e)
        {
            txtPalavra.Text = lstPalavras.SelectedItem.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (lstPalavras.SelectedItem == null || txtPalavra.Text.Trim() == string.Empty) return;

            var palavraAlterada = txtPalavra.Text.Trim();
            var retorno = MessageBox.Show($"Confirma alteração da palavra '{lstPalavras.SelectedItem}' para '{palavraAlterada}'?", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.AlterarPalavra(palavras.Where(s => s.Value == lstPalavras.SelectedItem.ToString()).FirstOrDefault().Key,palavraAlterada);
                AtualizaTela();
            }
        }
    }
}
