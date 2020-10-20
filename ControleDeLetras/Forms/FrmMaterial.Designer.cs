namespace ControleDeLetras.Forms
{
    partial class FrmMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCores = new System.Windows.Forms.ComboBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pnlCor = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAcresc = new System.Windows.Forms.NumericUpDown();
            this.txtQtde = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnAcresc = new System.Windows.Forms.Button();
            this.dgvMateriais = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcresc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriais)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbCores);
            this.panel1.Controls.Add(this.pnlBotoes);
            this.panel1.Controls.Add(this.pnlCor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbTipoMaterial);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAcresc);
            this.panel1.Controls.Add(this.txtQtde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.btnAcresc);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 142);
            this.panel1.TabIndex = 8;
            // 
            // cmbCores
            // 
            this.cmbCores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCores.FormattingEnabled = true;
            this.cmbCores.Location = new System.Drawing.Point(48, 70);
            this.cmbCores.Name = "cmbCores";
            this.cmbCores.Size = new System.Drawing.Size(158, 21);
            this.cmbCores.TabIndex = 2;
            this.cmbCores.SelectionChangeCommitted += new System.EventHandler(this.cmbCores_SelectionChangeCommitted);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnApagar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Location = new System.Drawing.Point(-1, 110);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(417, 27);
            this.pnlBotoes.TabIndex = 18;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(284, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(62, 23);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(352, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(139, 2);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(62, 23);
            this.btnApagar.TabIndex = 8;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(72, 2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(4, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(62, 23);
            this.btnNovo.TabIndex = 6;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pnlCor
            // 
            this.pnlCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCor.Location = new System.Drawing.Point(9, 70);
            this.pnlCor.Name = "pnlCor";
            this.pnlCor.Size = new System.Drawing.Size(33, 21);
            this.pnlCor.TabIndex = 14;
            this.pnlCor.Tag = "Selecione a cor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cor";
            // 
            // cmbTipoMaterial
            // 
            this.cmbTipoMaterial.FormattingEnabled = true;
            this.cmbTipoMaterial.Location = new System.Drawing.Point(212, 23);
            this.cmbTipoMaterial.Name = "cmbTipoMaterial";
            this.cmbTipoMaterial.Size = new System.Drawing.Size(196, 21);
            this.cmbTipoMaterial.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo Material";
            // 
            // txtAcresc
            // 
            this.txtAcresc.Location = new System.Drawing.Point(283, 70);
            this.txtAcresc.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtAcresc.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.txtAcresc.Name = "txtAcresc";
            this.txtAcresc.Size = new System.Drawing.Size(43, 20);
            this.txtAcresc.TabIndex = 4;
            this.txtAcresc.ValueChanged += new System.EventHandler(this.txtAcresc_ValueChanged);
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(219, 70);
            this.txtQtde.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(43, 20);
            this.txtQtde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Qtde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(9, 23);
            this.txtDescricao.MaxLength = 30;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(197, 20);
            this.txtDescricao.TabIndex = 0;
            // 
            // btnAcresc
            // 
            this.btnAcresc.Enabled = false;
            this.btnAcresc.Location = new System.Drawing.Point(332, 70);
            this.btnAcresc.Name = "btnAcresc";
            this.btnAcresc.Size = new System.Drawing.Size(72, 23);
            this.btnAcresc.TabIndex = 5;
            this.btnAcresc.Text = "Acrescentar";
            this.btnAcresc.UseVisualStyleBackColor = true;
            this.btnAcresc.Click += new System.EventHandler(this.btnAcresc_Click);
            // 
            // dgvMateriais
            // 
            this.dgvMateriais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriais.Location = new System.Drawing.Point(12, 160);
            this.dgvMateriais.Name = "dgvMateriais";
            this.dgvMateriais.ReadOnly = true;
            this.dgvMateriais.Size = new System.Drawing.Size(418, 342);
            this.dgvMateriais.TabIndex = 11;
            this.dgvMateriais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMateriais_CellClick);
            // 
            // FrmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 514);
            this.Controls.Add(this.dgvMateriais);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materiais";
            this.Load += new System.EventHandler(this.FrmLetras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAcresc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriais)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView dgvMateriais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAcresc;
        private System.Windows.Forms.NumericUpDown txtAcresc;
        private System.Windows.Forms.NumericUpDown txtQtde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoMaterial;
        private System.Windows.Forms.Panel pnlCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ComboBox cmbCores;
    }
}