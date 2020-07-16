using ControleDeLetras.Repositorio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControleDeLetras
{
    public partial class FrmPalavras : Form
    {
        PalavraRepositorio PalavraRepositorio = new PalavraRepositorio();

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
            var palavras = PalavraRepositorio.ObterPalavras();
            lstPalavras.DataSource = palavras;

            // Monta gráfico
            var serie = chtLetras.Series["Letras"];

            chtLetras.ChartAreas[0].AxisX.Interval = 1;
            serie.Points.Clear();
            serie.Color = Color.LightPink;
            foreach (KeyValuePair<string, int> letra in calculaQtdeLetras(palavras))
            {
                serie.Points.AddXY(letra.Key, letra.Value);
            }
        }

        private IDictionary<string, int> calculaQtdeLetras(List<string> palavras)
        {
            IDictionary<string, int> letrasQtde = new Dictionary<string, int>();

            palavras.ForEach(palavra => {
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

            return letrasQtde;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtPalavra.Text.Trim() != String.Empty)
            {
                var palavra = txtPalavra.Text.ToUpper();

                PalavraRepositorio.InserirPalavra(palavra);
                AtualizaTela();
            }
        }

        private void lstPalavras_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPalavra.Text = lstPalavras.SelectedItem.ToString();
        }

        private void frmPalavras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtPalavra.Text = "";
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var retorno = MessageBox.Show("Confirma remoção da palavra?", "Aviso", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.RemoverPalavra();
                AtualizaTela();
            }
        }
    }
}
