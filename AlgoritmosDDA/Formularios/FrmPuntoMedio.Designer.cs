namespace AlgoritmosDDA.Formularios
{
    partial class FrmPuntoMedio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLienzo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDX = new System.Windows.Forms.Label();
            this.lblDY = new System.Windows.Forms.Label();
            this.lblEcuacion = new System.Windows.Forms.Label();
            this.dgvPasos = new System.Windows.Forms.DataGridView();
            this.ColPaso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColXY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLienzo
            // 
            this.panelLienzo.BackColor = System.Drawing.Color.White;
            this.panelLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLienzo.Location = new System.Drawing.Point(367, 62);
            this.panelLienzo.Name = "panelLienzo";
            this.panelLienzo.Size = new System.Drawing.Size(403, 376);
            this.panelLienzo.TabIndex = 0;
            this.panelLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLienzo_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ENTRADAS DE LOS PUNTOS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "PRIMER PUNTO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SEGUNDO PUNTO:";
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(210, 62);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(110, 20);
            this.txtP1.TabIndex = 5;
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(210, 96);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(110, 20);
            this.txtP2.TabIndex = 6;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(53, 149);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(90, 25);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetear.Location = new System.Drawing.Point(201, 149);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(90, 25);
            this.btnResetear.TabIndex = 8;
            this.btnResetear.Text = "RESETEAR";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SALIDAS:";
            // 
            // lblDX
            // 
            this.lblDX.AutoSize = true;
            this.lblDX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDX.Location = new System.Drawing.Point(64, 220);
            this.lblDX.Name = "lblDX";
            this.lblDX.Size = new System.Drawing.Size(30, 15);
            this.lblDX.TabIndex = 10;
            this.lblDX.Text = "Δx: ";
            // 
            // lblDY
            // 
            this.lblDY.AutoSize = true;
            this.lblDY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDY.Location = new System.Drawing.Point(207, 220);
            this.lblDY.Name = "lblDY";
            this.lblDY.Size = new System.Drawing.Size(29, 15);
            this.lblDY.TabIndex = 11;
            this.lblDY.Text = "Δy: ";
            // 
            // lblEcuacion
            // 
            this.lblEcuacion.AutoSize = true;
            this.lblEcuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEcuacion.Location = new System.Drawing.Point(64, 249);
            this.lblEcuacion.Name = "lblEcuacion";
            this.lblEcuacion.Size = new System.Drawing.Size(74, 15);
            this.lblEcuacion.TabIndex = 12;
            this.lblEcuacion.Text = "Ecuación: ";
            // 
            // dgvPasos
            // 
            this.dgvPasos.AllowUserToAddRows = false;
            this.dgvPasos.AllowUserToDeleteRows = false;
            this.dgvPasos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPaso,
            this.ColD,
            this.ColXY,
            this.ColPunto});
            this.dgvPasos.Location = new System.Drawing.Point(12, 283);
            this.dgvPasos.Name = "dgvPasos";
            this.dgvPasos.ReadOnly = true;
            this.dgvPasos.RowHeadersVisible = false;
            this.dgvPasos.Size = new System.Drawing.Size(318, 155);
            this.dgvPasos.TabIndex = 13;
            // 
            // ColPaso
            // 
            this.ColPaso.HeaderText = "Paso";
            this.ColPaso.Name = "ColPaso";
            this.ColPaso.ReadOnly = true;
            this.ColPaso.Width = 45;
            // 
            // ColD
            // 
            this.ColD.HeaderText = "d";
            this.ColD.Name = "ColD";
            this.ColD.ReadOnly = true;
            this.ColD.Width = 45;
            // 
            // ColXY
            // 
            this.ColXY.HeaderText = "(X, Y)";
            this.ColXY.Name = "ColXY";
            this.ColXY.ReadOnly = true;
            this.ColXY.Width = 75;
            // 
            // ColPunto
            // 
            this.ColPunto.HeaderText = "Punto";
            this.ColPunto.Name = "ColPunto";
            this.ColPunto.ReadOnly = true;
            this.ColPunto.Width = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "GRÁFICO:";
            // 
            // FrmPuntoMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPasos);
            this.Controls.Add(this.lblEcuacion);
            this.Controls.Add(this.lblDY);
            this.Controls.Add(this.lblDX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelLienzo);
            this.Name = "FrmPuntoMedio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo del Punto Medio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLienzo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDX;
        private System.Windows.Forms.Label lblDY;
        private System.Windows.Forms.Label lblEcuacion;
        private System.Windows.Forms.DataGridView dgvPasos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPunto;
        private System.Windows.Forms.Label label1;
    }
}