namespace AlgoritmosDDA
{
    partial class MetodoCirculoMatrices
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
            this.txtXC = new System.Windows.Forms.TextBox();
            this.txtYC = new System.Windows.Forms.TextBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.lstPixeles = new System.Windows.Forms.ListBox();
            this.lblXC = new System.Windows.Forms.Label();
            this.lblYC = new System.Windows.Forms.Label();
            this.lblRadio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtXC
            // 
            this.txtXC.Location = new System.Drawing.Point(94, 61);
            this.txtXC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtXC.Name = "txtXC";
            this.txtXC.Size = new System.Drawing.Size(68, 20);
            this.txtXC.TabIndex = 3;
            this.txtXC.Text = "0";
            // 
            // txtYC
            // 
            this.txtYC.Location = new System.Drawing.Point(94, 90);
            this.txtYC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtYC.Name = "txtYC";
            this.txtYC.Size = new System.Drawing.Size(68, 20);
            this.txtYC.TabIndex = 4;
            this.txtYC.Text = "0";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(94, 118);
            this.txtRadio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(68, 20);
            this.txtRadio.TabIndex = 5;
            this.txtRadio.Text = "9";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(25, 160);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 32);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetear.Location = new System.Drawing.Point(161, 160);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(82, 32);
            this.btnResetear.TabIndex = 7;
            this.btnResetear.Text = "RESETEAR";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(313, 50);
            this.panelDibujo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(525, 422);
            this.panelDibujo.TabIndex = 8;
            // 
            // lstPixeles
            // 
            this.lstPixeles.FormattingEnabled = true;
            this.lstPixeles.Location = new System.Drawing.Point(22, 253);
            this.lstPixeles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstPixeles.Name = "lstPixeles";
            this.lstPixeles.Size = new System.Drawing.Size(255, 199);
            this.lstPixeles.TabIndex = 9;
            // 
            // lblXC
            // 
            this.lblXC.AutoSize = true;
            this.lblXC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXC.Location = new System.Drawing.Point(31, 62);
            this.lblXC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXC.Name = "lblXC";
            this.lblXC.Size = new System.Drawing.Size(26, 15);
            this.lblXC.TabIndex = 0;
            this.lblXC.Text = "XC:";
            // 
            // lblYC
            // 
            this.lblYC.AutoSize = true;
            this.lblYC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYC.Location = new System.Drawing.Point(31, 91);
            this.lblYC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYC.Name = "lblYC";
            this.lblYC.Size = new System.Drawing.Size(22, 15);
            this.lblYC.TabIndex = 1;
            this.lblYC.Text = "YC";
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadio.Location = new System.Drawing.Point(31, 119);
            this.lblRadio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(40, 15);
            this.lblRadio.TabIndex = 2;
            this.lblRadio.Text = "Radio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "SALIDAS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "ENTRADAS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "GRÁFICO:";
            // 
            // MetodoCirculoMatrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 483);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblXC);
            this.Controls.Add(this.lblYC);
            this.Controls.Add(this.lblRadio);
            this.Controls.Add(this.txtXC);
            this.Controls.Add(this.txtYC);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Controls.Add(this.lstPixeles);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MetodoCirculoMatrices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Método de Rotación de Matrices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXC;
        private System.Windows.Forms.TextBox txtYC;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.ListBox lstPixeles;
        private System.Windows.Forms.Label lblXC;
        private System.Windows.Forms.Label lblYC;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}