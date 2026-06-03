namespace AlgoritmosDDA
{
    partial class FrmCirculoBase
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtXC = new System.Windows.Forms.TextBox();
            this.txtYC = new System.Windows.Forms.TextBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.dgvPasos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCentro = new System.Windows.Forms.Label();
            this.lblRadioInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtXC
            // 
            this.txtXC.Location = new System.Drawing.Point(195, 52);
            this.txtXC.Name = "txtXC";
            this.txtXC.Size = new System.Drawing.Size(50, 20);
            this.txtXC.TabIndex = 5;
            this.txtXC.Text = "0";
            // 
            // txtYC
            // 
            this.txtYC.Location = new System.Drawing.Point(280, 52);
            this.txtYC.Name = "txtYC";
            this.txtYC.Size = new System.Drawing.Size(50, 20);
            this.txtYC.TabIndex = 6;
            this.txtYC.Text = "0";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(195, 89);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(50, 20);
            this.txtRadio.TabIndex = 7;
            this.txtRadio.Text = "4";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(28, 131);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 26);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnResetear.Location = new System.Drawing.Point(195, 131);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(94, 26);
            this.btnResetear.TabIndex = 9;
            this.btnResetear.Text = "RESETEAR";
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(375, 89);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(423, 381);
            this.panelDibujo.TabIndex = 10;
            // 
            // dgvPasos
            // 
            this.dgvPasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvPasos.Location = new System.Drawing.Point(20, 269);
            this.dgvPasos.Name = "dgvPasos";
            this.dgvPasos.Size = new System.Drawing.Size(330, 166);
            this.dgvPasos.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentro.Location = new System.Drawing.Point(38, 207);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(74, 15);
            this.lblCentro.TabIndex = 12;
            this.lblCentro.Text = "Centro: (0,0)";
            // 
            // lblRadioInfo
            // 
            this.lblRadioInfo.AutoSize = true;
            this.lblRadioInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadioInfo.Location = new System.Drawing.Point(38, 242);
            this.lblRadioInfo.Name = "lblRadioInfo";
            this.lblRadioInfo.Size = new System.Drawing.Size(60, 15);
            this.lblRadioInfo.TabIndex = 13;
            this.lblRadioInfo.Text = "Radio r: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "CENTRO DE LA RECTA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "RADIO DE CIRCULO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "SALIDAS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "ENTRADAS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(397, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "GRÁFICO:";
            // 
            // FrmCirculoBase
            // 
            this.ClientSize = new System.Drawing.Size(820, 500);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXC);
            this.Controls.Add(this.txtYC);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Controls.Add(this.dgvPasos);
            this.Controls.Add(this.lblCentro);
            this.Controls.Add(this.lblRadioInfo);
            this.Name = "FrmCirculoBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circulo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Declaraciones de componentes...
        private System.Windows.Forms.TextBox txtXC, txtYC, txtRadio;
        private System.Windows.Forms.Button btnGenerar, btnResetear;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.DataGridView dgvPasos;
        private System.Windows.Forms.Label lblCentro, lblRadioInfo, label1, label2, label3, label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label5;
    }
}