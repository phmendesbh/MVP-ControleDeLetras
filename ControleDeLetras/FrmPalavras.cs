using ControleDeLetras.Repositorio;
using System;
using System.Windows.Forms;

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
            AtualizaLista();
        }

        private void AtualizaLista()
        {
            lstPalavras.DataSource = PalavraRepositorio.ObterPalavras();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtPalavra.Text.Trim() != String.Empty)
            {
                var palavra = txtPalavra.Text.ToUpper();

                PalavraRepositorio.InserirPalavra(palavra);
                AtualizaLista();
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
                //PalavraRepositorio.RemoverPalavra(lstPalavras.SelectedItem.ToString());
                AtualizaLista();
            }
        }
    }
}
