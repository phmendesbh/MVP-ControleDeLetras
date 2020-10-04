using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmCor : Form
    {
        readonly CorRepositorio CorRepositorio = new CorRepositorio();
        private Cor corSelecionado = new Cor();

        public FrmCor()
        {
            InitializeComponent();
        }

        private void FrmCor_Load(object sender, EventArgs e)
        {
            AtualizaTela();
        }

        private void AtualizaTela()
        {
            var cores = CorRepositorio.Obter();

            txtDescricao.Text = "";
            pnlCor.BackColor = Color.Empty;

            dgvCores.DataSource = cores;
            dgvCores.Columns[0].Visible = false;

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma inclusão da Cor {txtDescricao.Text} ?", "Adicionar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                CorRepositorio.Inserir(new Cor()
                {
                    Descricao = txtDescricao.Text,
                    ValorARBG = pnlCor.BackColor.ToArgb()
                });
                AtualizaTela();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (corSelecionado.Id == int.MinValue || string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma alteração da Cor {corSelecionado.Descricao}?", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                CorRepositorio.Alterar(new Cor()
                {
                    Id = corSelecionado.Id,
                    Descricao = txtDescricao.Text,
                    ValorARBG = pnlCor.BackColor.ToArgb()
                });
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (corSelecionado.Id == int.MinValue) return;

            var retorno = MessageBox.Show($"Confirma remover a Cor {txtDescricao.Text} ?", "Apagar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                CorRepositorio.Remover(corSelecionado.Id);

                AtualizaTela();
            }
        }

        private void dgvCores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaObjetos();
        }

        private void AtualizaObjetos()
        {
            corSelecionado.Id = (int)dgvCores.Rows[dgvCores.CurrentCell.RowIndex].Cells[0].Value;
            corSelecionado.Descricao = dgvCores.Rows[dgvCores.CurrentCell.RowIndex].Cells[1].Value.ToString();
            corSelecionado.ValorARBG = (int)dgvCores.Rows[dgvCores.CurrentCell.RowIndex].Cells[2].Value;

            txtDescricao.Text = corSelecionado.Descricao;
            pnlCor.BackColor = Color.FromArgb(corSelecionado.ValorARBG);
        }

        private void pnlCor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var str = dlg.Color;
                pnlCor.BackColor = str;
            }
        }

        private void dgvCores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rowCor in dgvCores.Rows)
            {
                rowCor.Cells[2].Style.BackColor = Color.FromArgb((int)rowCor.Cells[2].Value);
                rowCor.Cells[2].Style.ForeColor = Color.FromArgb((int)rowCor.Cells[2].Value);
                rowCor.Cells[2].Style.SelectionBackColor = Color.FromArgb((int)rowCor.Cells[2].Value);
                rowCor.Cells[2].Style.SelectionForeColor = Color.FromArgb((int)rowCor.Cells[2].Value);

            }
        }
    }
}
