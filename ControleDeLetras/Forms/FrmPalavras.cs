using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using ControleDeLetras.Util;
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
        readonly MaterialRepositorio MaterialRepositorio = new MaterialRepositorio();
        List<Palavra> lstPalavras = new List<Palavra>();
        readonly Utils Utils = new Utils();

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
            foreach (KeyValuePair<string, int> letra in Utils.CalculaQtdeLetras(palavras))
            {
                serie.Points.AddXY(letra.Key, letra.Value);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var palavra = txtPalavra.Text.ToUpper();

            if (palavra == string.Empty) return;

            var retorno = MessageBox.Show($"Confirma inclusão da palavra '{palavra}' ?", "Adicionar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.Inserir(palavra);
                MaterialRepositorio.AtualizaEstoqueLetras(new Palavra(null, palavra));
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var palavraSelecionada = lstBPalavras.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(palavraSelecionada)) return;

            var retorno = MessageBox.Show($"Confirma remoção da palavra '{palavraSelecionada}' ?", "Remover", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                Palavra palavra = new Palavra(
                    lstPalavras.Where(s => s.Descricao == palavraSelecionada).FirstOrDefault().Id,
                    string.Empty)
                {
                    DescricaoAntiga = palavraSelecionada
                };

                PalavraRepositorio.Remover(palavra);
                MaterialRepositorio.AtualizaEstoqueLetras(palavra);
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

            Palavra palavra = new Palavra(
                lstPalavras.Where(s => s.Descricao == lstBPalavras.SelectedItem.ToString()).FirstOrDefault().Id,
                txtPalavra.Text.Trim())
            {
                DescricaoAntiga = lstBPalavras.SelectedItem.ToString()
            };

            var retorno = MessageBox.Show($"Confirma alteração da palavra '{palavra.DescricaoAntiga}' para '{palavra.Descricao}'? Isso irá alterar o estoque de letras.", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                PalavraRepositorio.Alterar(palavra);
                MaterialRepositorio.AtualizaEstoqueLetras(palavra);
                AtualizaTela();
            }
        }
    }
}
