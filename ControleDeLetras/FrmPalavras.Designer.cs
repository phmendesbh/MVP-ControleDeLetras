namespace ControleDeLetras
{
    partial class FrmPalavras
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lstPalavras = new System.Windows.Forms.ListBox();
            this.chtLetras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPalavra = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtLetras)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(8, 51);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(62, 23);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lstPalavras
            // 
            this.lstPalavras.FormattingEnabled = true;
            this.lstPalavras.Location = new System.Drawing.Point(12, 100);
            this.lstPalavras.Name = "lstPalavras";
            this.lstPalavras.Size = new System.Drawing.Size(213, 329);
            this.lstPalavras.Sorted = true;
            this.lstPalavras.TabIndex = 4;
            this.lstPalavras.SelectedIndexChanged += new System.EventHandler(this.lstPalavras_SelectedIndexChanged);
            // 
            // chtLetras
            // 
            this.chtLetras.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chtLetras.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtLetras.Legends.Add(legend1);
            this.chtLetras.Location = new System.Drawing.Point(231, 12);
            this.chtLetras.Name = "chtLetras";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtLetras.Series.Add(series1);
            this.chtLetras.Size = new System.Drawing.Size(300, 417);
            this.chtLetras.TabIndex = 5;
            this.chtLetras.Text = "Letras utilizadas";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPalavra);
            this.panel1.Controls.Add(this.btnRemover);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 82);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Palavra:";
            // 
            // txtPalavra
            // 
            this.txtPalavra.Location = new System.Drawing.Point(8, 25);
            this.txtPalavra.MaxLength = 26;
            this.txtPalavra.Name = "txtPalavra";
            this.txtPalavra.Size = new System.Drawing.Size(197, 20);
            this.txtPalavra.TabIndex = 0;
            this.txtPalavra.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(143, 51);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(62, 23);
            this.btnRemover.TabIndex = 3;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(76, 51);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 23);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Modificar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // FrmPalavras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chtLetras);
            this.Controls.Add(this.lstPalavras);
            this.Name = "FrmPalavras";
            this.Text = "Controle de Letras";
            this.Load += new System.EventHandler(this.FrmPalavras_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPalavras_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.chtLetras)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox lstPalavras;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtLetras;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPalavra;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
    }
}

