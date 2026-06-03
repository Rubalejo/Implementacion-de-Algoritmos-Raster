namespace AlgoritmosDDA
{
    partial class FrmPolares
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing
        )
        {
            if (
                disposing &&
                (components != null)
            )
            {
                components.Dispose();
            }

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
            this.lstPixeles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtXC
            // 
            this.txtXC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXC.Location = new System.Drawing.Point(90, 28);
            this.txtXC.Name = "txtXC";
            this.txtXC.Size = new System.Drawing.Size(120, 25);
            this.txtXC.TabIndex = 3;
            // 
            // txtYC
            // 
            this.txtYC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYC.Location = new System.Drawing.Point(90, 70);
            this.txtYC.Name = "txtYC";
            this.txtYC.Size = new System.Drawing.Size(120, 25);
            this.txtYC.TabIndex = 4;
            // 
            // txtRadio
            // 
            this.txtRadio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRadio.Location = new System.Drawing.Point(90, 108);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(120, 25);
            this.txtRadio.TabIndex = 5;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.GhostWhite;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.Black;
            this.btnGenerar.Location = new System.Drawing.Point(35, 157);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(95, 28);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.BackColor = System.Drawing.Color.Snow;
            this.btnResetear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetear.ForeColor = System.Drawing.Color.Black;
            this.btnResetear.Location = new System.Drawing.Point(158, 156);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(95, 29);
            this.btnResetear.TabIndex = 7;
            this.btnResetear.Text = "RESETEAR";
            this.btnResetear.UseVisualStyleBackColor = false;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(349, 31);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(708, 422);
            this.panelDibujo.TabIndex = 9;
            // 
            // lstPixeles
            // 
            this.lstPixeles.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstPixeles.ItemHeight = 15;
            this.lstPixeles.Location = new System.Drawing.Point(12, 209);
            this.lstPixeles.Name = "lstPixeles";
            this.lstPixeles.Size = new System.Drawing.Size(265, 259);
            this.lstPixeles.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "XC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "YC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(31, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Radio:";
            // 
            // FrmPolares
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXC);
            this.Controls.Add(this.txtYC);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.lstPixeles);
            this.Controls.Add(this.panelDibujo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPolares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Método de Coordenadas Polares";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtXC;
        private System.Windows.Forms.TextBox txtYC;
        private System.Windows.Forms.TextBox txtRadio;

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnResetear;

        private System.Windows.Forms.Panel panelDibujo;

        private System.Windows.Forms.ListBox lstPixeles;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}