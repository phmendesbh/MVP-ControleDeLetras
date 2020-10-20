using ControleDeLetras.Entidade;
using ControleDeLetras.Repositorio;
using ControleDeLetras.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmMaterial : Form
    {
        readonly MaterialRepositorio letraRepositorio = new MaterialRepositorio();
        readonly CorRepositorio corRepositorio = new CorRepositorio();
        readonly Tipo_MaterialRepositorio tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();

        private Material materialSelecionado = new Material();
        private List<Cor> cores;
        private Enumeradores.Acao Acao = Enumeradores.Acao.Default;

        public FrmMaterial()
        {
            InitializeComponent();
        }

        private void FrmLetras_Load(object sender, EventArgs e)
        {
            AtivarBotoes(Enumeradores.Acao.Default);
            AtualizaTela();
        }

        private void txtAcresc_ValueChanged(object sender, EventArgs e)
        {
            btnAcresc.Enabled = (txtAcresc.Value != 0);
        }

#region BOTOES
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            AtivarBotoes(Enumeradores.Acao.Novo);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (materialSelecionado.Id == int.MinValue || string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            AtivarBotoes(Enumeradores.Acao.Alterar);
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (materialSelecionado.Id == int.MinValue || string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

            AtivarBotoes(Enumeradores.Acao.Apagar);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AcaoBotoes(Acao);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtivarBotoes(Enumeradores.Acao.Cancelar);
        }

        private void btnAcresc_Click(object sender, EventArgs e)
        {
            var retorno = MessageBox.Show($"Confirma acrescentar a Quantidade: '{txtAcresc.Value}' ao material '{txtDescricao.Text}' ?", "Acrescentar", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                letraRepositorio.AlterarQuantidade(materialSelecionado.Id, txtAcresc.Value);
                AtualizaTela();
            }
        }
#endregion

        private void AtualizaTela()
        {
            LimpaCampos();

            dgvMateriais.DataSource = letraRepositorio.ObterTodasInformacoes();
            dgvMateriais.Columns["Id"].Visible = false;
            dgvMateriais.Columns["Tipo_Material_Id"].Visible = false;
            dgvMateriais.Columns["Cor_Id"].Visible = false;
            dgvMateriais.Columns["Cor_ValorARGB"].Visible = false;

            PreencheCombo();

            AtivarBotoes(Acao);
        }

        private void LimpaCampos()
        {
            txtDescricao.Text = "";
            txtQtde.Value = 0;
            txtAcresc.Value = 0;
            btnAcresc.Enabled = false;
            pnlCor.BackColor = Color.Empty;
        }

        private void PreencheCombo()
        {
            if (cmbTipoMaterial.Items.Count == 0)
            {
                cmbTipoMaterial.DataSource = tipo_MaterialRepositorio.Obter();
                cmbTipoMaterial.ValueMember = "Id";
                cmbTipoMaterial.DisplayMember = "Descricao";
            }

            if (cmbCores.Items.Count == 0)
            {
                cores = corRepositorio.Obter();
                cmbCores.DataSource = cores;
                cmbCores.ValueMember = "Id";
                cmbCores.DisplayMember = "Descricao";
            }
        }

        private void dgvMateriais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaObjetos();
        }

        private void AtualizaObjetos()
        {
            materialSelecionado.Id = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Id"].Value;
            materialSelecionado.Descricao = dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Descricao"].Value.ToString();
            materialSelecionado.Tipo_Material_Id = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Tipo_Material_Id"].Value;
            materialSelecionado.Tipo_Material_Descricao = dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Tipo_Material_Descricao"].Value.ToString();
            materialSelecionado.Cor_Id = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Cor_Id"].Value;
            materialSelecionado.Cor_ValorARGB = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Cor_ValorARGB"].Value;
            materialSelecionado.Quantidade = (int)dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Quantidade"].Value;

            txtDescricao.Text = materialSelecionado.Descricao;
            cmbTipoMaterial.SelectedValue = materialSelecionado.Tipo_Material_Id;
            txtQtde.Value = materialSelecionado.Quantidade;
            txtAcresc.Value = 0;
            pnlCor.BackColor = Color.FromArgb(materialSelecionado.Cor_ValorARGB);
            cmbCores.SelectedValue = materialSelecionado.Cor_Id;
        }

        private void AcaoBotoes(Enumeradores.Acao acao)
        {
            switch (acao)
            {
                case Enumeradores.Acao.Novo:
                    if (string.IsNullOrWhiteSpace(txtDescricao.Text)) return;

                    if (MessageBox.Show(ResourceMensagensPadrao.CONFIRMA_INCLUSAO, "Novo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        letraRepositorio.Inserir(new Material()
                        {
                            Descricao = txtDescricao.Text,
                            Tipo_Material_Id = (int)cmbTipoMaterial.SelectedValue,
                            Quantidade = (int)txtQtde.Value
                        });
                    }

                    break;

                case Enumeradores.Acao.Alterar:
                    var retorno = MessageBox.Show(ResourceMensagensPadrao.CONFIRMA_ALTERACAO, "Alterar", MessageBoxButtons.YesNo);

                    if (retorno == DialogResult.Yes)
                    {
                        letraRepositorio.Alterar(new Material()
                        {
                            Id = materialSelecionado.Id,
                            Descricao = txtDescricao.Text,
                            Tipo_Material_Id = (int)cmbTipoMaterial.SelectedValue,
                            Quantidade = (int)txtQtde.Value,
                            Cor_Id = materialSelecionado.Cor_Id
                        });
                    }
                    break;

                case Enumeradores.Acao.Apagar:
                    if (MessageBox.Show(ResourceMensagensPadrao.CONFIRMA_REMOCAO, "Apagar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        letraRepositorio.Remover(materialSelecionado.Id);
                    }
                    break;
                case Enumeradores.Acao.Cancelar:

                    break;
                default:
                    break;
            }

            Acao = Enumeradores.Acao.Default;
            AtualizaTela();
        }

        private void AtivarBotoes(Enumeradores.Acao acao)
        {
            Acao = acao;

            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnApagar.Enabled = false;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            btnAcresc.Enabled = false;
            txtAcresc.Enabled = false;
            cmbCores.Enabled = false;

            switch (acao)
            {
                case Enumeradores.Acao.Novo:
                case Enumeradores.Acao.Alterar:
                    btnSalvar.Visible = true;
                    btnCancelar.Visible = true;
                    cmbCores.Enabled = true;
                    break;
                case Enumeradores.Acao.Salvar:
                case Enumeradores.Acao.Cancelar:
                default:
                    btnNovo.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnApagar.Enabled = true;
                    btnSalvar.Visible = false;
                    btnCancelar.Visible = false;
                    cmbCores.Enabled = false;
                    txtAcresc.Enabled = true;
                    Acao = Enumeradores.Acao.Default;
                    break;
            }
        }

        private void cmbCores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cores != null && cmbCores.Items.Count > 0)
            {
                var cor = (int)cores.Where(w => w.Id == (int)cmbCores.SelectedValue).Select(s => s.ValorARBG).FirstOrDefault();
                pnlCor.BackColor = Color.FromArgb(cor);
            }
        }
    }
}
