using ControleDeLetras.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeLetras.Forms
{
    public partial class FrmTipo_Material : Form
    {
        readonly Tipo_MaterialRepositorio Tipo_MaterialRepositorio = new Tipo_MaterialRepositorio();

        public FrmTipo_Material()
        {
            InitializeComponent();
            Tipo_MaterialRepositorio.VerificaBanco();

        }
    }
}
