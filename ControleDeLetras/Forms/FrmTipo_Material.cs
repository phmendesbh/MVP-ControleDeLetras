using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using System;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmTipo_Material : Form
    {
        readonly Tipo_MaterialRepositorio Tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();
        private Tipo_Material tipo_materialSelecionado = new Tipo_Material();

        public FrmTipo_Material()
        {
            InitializeComponent();
        }

        private void FrmTipo_Material_Load(object sender, EventArgs e)
        {
            AtualizaTela();
        }

        private void AtualizaTela()
        {
            txtDescricao.Text = "";

            dgvMateriais.DataSource = Tipo_MaterialRepositorio.Obter();
            dgvMateriais.Columns[0].Visible = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma inclusão do Tipo de Material '{txtDescricao.Text}' ?", "Adicionar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                Tipo_MaterialRepositorio.Inserir(new Tipo_Material()
                {
                    Descricao = txtDescricao.Text,
                });
                AtualizaTela();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tipo_materialSelecionado.Id == int.MinValue || string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            var retorno = MessageBox.Show($"Confirma alteração do Tipo de Material {tipo_materialSelecionado.Descricao}?", "Alterar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                Tipo_MaterialRepositorio.Alterar(new Tipo_Material()
                {
                    Id = tipo_materialSelecionado.Id,
                    Descricao = txtDescricao.Text
                });
                AtualizaTela();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (tipo_materialSelecionado.Id == int.MinValue) return;

            var retorno = MessageBox.Show($"Confirma remover o material {txtDescricao.Text} ?", "Apagar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                Tipo_MaterialRepositorio.Remover(tipo_materialSelecionado.Id);

                AtualizaTela();
            }
        }
    }
}
