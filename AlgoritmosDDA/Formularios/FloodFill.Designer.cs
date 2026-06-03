namespace AlgoritmosDDA.Formularios
{
    partial class FloodFill
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnModo, btnReiniciar;
        private System.Windows.Forms.ComboBox cmbHerramienta;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.btnModo = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.cmbHerramienta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnModo
            // 
            this.btnModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModo.Location = new System.Drawing.Point(620, 20);
            this.btnModo.Name = "btnModo";
            this.btnModo.Size = new System.Drawing.Size(120, 30);
            this.btnModo.TabIndex = 0;
            this.btnModo.Text = "Modo: Dibujar";
            this.btnModo.Click += new System.EventHandler(this.btnModo_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(620, 100);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(120, 30);
            this.btnReiniciar.TabIndex = 1;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // cmbHerramienta
            // 
            this.cmbHerramienta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHerramienta.Items.AddRange(new object[] {
            "Muro",
            "Cuadrado",
            "Cruz"});
            this.cmbHerramienta.Location = new System.Drawing.Point(620, 60);
            this.cmbHerramienta.Name = "cmbHerramienta";
            this.cmbHerramienta.Size = new System.Drawing.Size(121, 21);
            this.cmbHerramienta.TabIndex = 2;
            // 
            // FloodFill
            // 
            this.ClientSize = new System.Drawing.Size(760, 650);
            this.Controls.Add(this.btnModo);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.cmbHerramienta);
            this.Name = "FloodFill";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FloodFill_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FloodFill_MouseClick);
            this.ResumeLayout(false);

        }
    }
}