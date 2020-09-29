using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using System;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmMateriais : Form
    {
        readonly MaterialRepositorio letraRepositorio = new MaterialRepositorio();
        private Material materialSelecionado = new Material();

        public FrmMateriais()
        {
            InitializeComponent();
            letraRepositorio.VerificaBanco();
        }

        private void FrmLetras_Load(object sender, EventArgs e)
        {
            AtualizaTela();
        }

        private void AtualizaTela()
        {
            dgvMateriais.DataSource = letraRepositorio.Obter();
            dgvMateriais.Columns[0].Visible = false;
        }

        private void txtAcresc_ValueChanged(object sender, EventArgs e)
        {
            btnAcresc.Enabled = (txtAcresc.Value != 0);
        }

        private void btnAcresc_Click(object sender, EventArgs e)
        {
            var retorno = MessageBox.Show($"Confirma acrescentar a Quantidade: '{txtAcresc.Value}' ao material '{txtDescricao.Text}' ?", "Acrescentar", MessageBoxButtons.YesNo);

            if(retorno == DialogResult.Yes)
            {
                letraRepositorio.AlterarQuantidade(materialSelecionado.Id,txtAcresc.Value);
                AtualizaTela();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma inclusão do material '{txtDescricao.Text}' ?", "Adicionar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                letraRepositorio.Inserir(new Material()
                {
                    Descricao = txtDescricao.Text,
                    Quantidade = (int)txtQtde.Value
                });
                AtualizaTela();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (materialSelecionado.Id == int.MinValue || string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma alteração do material {materialSelecionado.Descricao}?", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                letraRepositorio.Alterar(new Material()
                {
                    Id = materialSelecionado.Id,
                    Descricao = txtDescricao.Text,
                    Quantidade = (int)txtQtde.Value
                });
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (materialSelecionado.Id == int.MinValue) return;

            var retorno = MessageBox.Show($"Confirma remover o material {txtDescricao.Text} ?", "Apagar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                letraRepositorio.Remover(materialSelecionado.Id);

                txtDescricao.Text = "";
                txtQtde.Value = 0;
                txtAcresc.Value = 0;

                AtualizaTela();
            }
        }

        private void dgvMateriais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaObjetos();
        }

        private void AtualizaObjetos()
        {
            materialSelecionado.Id = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[0].Value;
            materialSelecionado.Descricao = dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[1].Value.ToString();
            materialSelecionado.Quantidade = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[2].Value;

            txtDescricao.Text = materialSelecionado.Descricao;
            txtQtde.Value = materialSelecionado.Quantidade;
            txtAcresc.Value = 0;
        }
    }
}
