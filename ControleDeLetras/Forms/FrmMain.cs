using System;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FechaFormAberto();

            FrmMateriais frmMateriais = new FrmMateriais();
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
    }
}
