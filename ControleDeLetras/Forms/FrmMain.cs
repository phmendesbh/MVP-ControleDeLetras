using System;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

#if DEBUG
            Repositorio.RepositorioMontaDados montaDados = new Repositorio.RepositorioMontaDados();
#endif
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FechaFormAberto();

            FrmMaterial frmMateriais = new FrmMaterial();
            frmMateriais.MdiParent = this;
            frmMateriais.Show();
        }

        private void FechaFormAberto()
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FechaFormAberto();

            FrmPalavras frmPalavras = new FrmPalavras();
            frmPalavras.MdiParent = this;
            frmPalavras.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FechaFormAberto();

            FrmTipo_Material frmTipo_Material = new FrmTipo_Material();
            frmTipo_Material.MdiParent = this;
            frmTipo_Material.Show();
        }
    }
}
