namespace AlgoritmosDDA.Formularios
{
    partial class FrmBezier
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtP0 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.dgvPasos = new System.Windows.Forms.DataGridView();
            this.ColPaso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColT = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panelLienzo.Location = new System.Drawing.Point(350, 74);
            this.panelLienzo.Name = "panelLienzo";
            this.panelLienzo.Size = new System.Drawing.Size(427, 364);
            this.panelLienzo.TabIndex = 0;
            this.panelLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLienzo_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "COORDENADAS DE LA LÍNEA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "PUNTO INICIAL (P0):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "PUNTO FINAL (P2):";
            // 
            // txtP0
            // 
            this.txtP0.Location = new System.Drawing.Point(180, 65);
            this.txtP0.Name = "txtP0";
            this.txtP0.Size = new System.Drawing.Size(140, 20);
            this.txtP0.TabIndex = 4;
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(180, 98);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(140, 20);
            this.txtP2.TabIndex = 3;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(45, 148);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(110, 25);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnResetear.Location = new System.Drawing.Point(191, 148);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(110, 25);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "RESETEAR";
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // dgvPasos
            // 
            this.dgvPasos.AllowUserToAddRows = false;
            this.dgvPasos.AllowUserToDeleteRows = false;
            this.dgvPasos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPaso,
            this.ColT,
            this.ColXY,
            this.ColPunto});
            this.dgvPasos.Location = new System.Drawing.Point(34, 195);
            this.dgvPasos.Name = "dgvPasos";
            this.dgvPasos.ReadOnly = true;
            this.dgvPasos.RowHeadersVisible = false;
            this.dgvPasos.Size = new System.Drawing.Size(276, 217);
            this.dgvPasos.TabIndex = 0;
            // 
            // ColPaso
            // 
            this.ColPaso.HeaderText = "Paso";
            this.ColPaso.Name = "ColPaso";
            this.ColPaso.ReadOnly = true;
            this.ColPaso.Width = 45;
            // 
            // ColT
            // 
            this.ColT.HeaderText = "t";
            this.ColT.Name = "ColT";
            this.ColT.ReadOnly = true;
            this.ColT.Width = 45;
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
            this.ColPunto.HeaderText = "Píxel Pintado";
            this.ColPunto.Name = "ColPunto";
            this.ColPunto.ReadOnly = true;
            this.ColPunto.Width = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "GRÁFICO:";
            // 
            // FrmBezier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPasos);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelLienzo);
            this.Name = "FrmBezier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Línea por Ecuación de Bézier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLienzo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtP0;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.DataGridView dgvPasos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPunto;
        private System.Windows.Forms.Label label1;
    }
}