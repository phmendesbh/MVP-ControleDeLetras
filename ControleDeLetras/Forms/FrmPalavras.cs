using ControleDeLetras.Entidade;
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
        readonly PalavraRepositorio PalavraRepositorio = new PalavraRepositorio();
        List<Palavra> lstPalavras = new List<Palavra>();

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
            lstPalavras = PalavraRepositorio.Obter().ToList();

            List<string> lista = lstPalavras.Select(palavra => palavra.Descricao).ToList();

            lstBPalavras.DataSource = lista;

            MontaGrafico(lista);

            txtPalavra.Text = "";
        }

        private void MontaGrafico(List<string> palavras)
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

        private IDictionary<string, int> CalculaQtdeLetras(List<string> lstPalavras)
        {
            IDictionary<string, int> letrasQtde = new Dictionary<string, int>();

            lstPalavras.ForEach(palavra => {
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
                PalavraRepositorio.Inserir(palavra);
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstBPalavras.SelectedItem == null) return;

            var retorno = MessageBox.Show($"Confirma remoção da palavra '{lstBPalavras.SelectedItem}' ?", "Remover", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.Remover(lstPalavras.Where(s=> s.Descricao == lstBPalavras.SelectedItem.ToString()).FirstOrDefault().Id);
                AtualizaTela();
            }
        }

        private void lstPalavras_DoubleClick(object sender, EventArgs e)
        {
            txtPalavra.Text = lstBPalavras.SelectedItem.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (lstBPalavras.SelectedItem == null || txtPalavra.Text.Trim() == string.Empty) return;

            string palavraAntiga = lstBPalavras.SelectedItem.ToString();

            Palavra palavraNova = new Palavra(
                lstPalavras.Where(s => s.Descricao == lstBPalavras.SelectedItem.ToString()).FirstOrDefault().Id,
                txtPalavra.Text.Trim());

            var retorno = MessageBox.Show($"Confirma alteração da palavra '{palavraAntiga}' para '{palavraNova.Descricao}'?", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.Alterar(palavraNova);

                AtualizaTela();
            }
        }
    }
}
