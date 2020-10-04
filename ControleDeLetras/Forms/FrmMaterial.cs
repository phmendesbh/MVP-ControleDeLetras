using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmMaterial : Form
    {
        readonly MaterialRepositorio letraRepositorio = new MaterialRepositorio();
        readonly Tipo_MaterialRepositorio tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();

        private Material materialSelecionado = new Material();

        public FrmMaterial()
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
            txtDescricao.Text = "";
            txtQtde.Value = 0;
            txtAcresc.Value = 0;

            if (cmbTipoMaterial.Items.Count == 0) PreencheCombo();

            dgvMateriais.DataSource = letraRepositorio.Obter();
            dgvMateriais.Columns[0].Visible = false;
            dgvMateriais.Columns[2].Visible = false;
        }

        private void PreencheCombo()
        {
            cmbTipoMaterial.DataSource = tipo_MaterialRepositorio.Obter();
            cmbTipoMaterial.ValueMember = "Id";
            cmbTipoMaterial.DisplayMember = "Descricao";
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
                    Tipo_Material_Id = (int)cmbTipoMaterial.SelectedValue,
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
                    Tipo_Material_Id = (int)cmbTipoMaterial.SelectedValue,
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
            materialSelecionado.Tipo_Material_Id = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[2].Value;
            materialSelecionado.Tipo_Material_Descricao = dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[3].Value.ToString();
            materialSelecionado.Quantidade = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells[4].Value;

            txtDescricao.Text = materialSelecionado.Descricao;
            cmbTipoMaterial.SelectedValue = materialSelecionado.Tipo_Material_Id;
            txtQtde.Value = materialSelecionado.Quantidade;
            txtAcresc.Value = 0;
        }

    }
}
