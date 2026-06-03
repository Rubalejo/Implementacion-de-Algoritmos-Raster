namespace AlgoritmosDDA.Formularios
{
    partial class BoundaryFill
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnDibujar, btnReiniciar;
        private System.Windows.Forms.ComboBox cmbFiguras;
        private System.Windows.Forms.TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label lblVelocidad;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.cmbFiguras = new System.Windows.Forms.ComboBox();
            this.trackBarVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelocidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).BeginInit();
            this.SuspendLayout();

            this.btnDibujar.Location = new System.Drawing.Point(620, 20);
            this.btnDibujar.Size = new System.Drawing.Size(120, 30);
            this.btnDibujar.Text = "Dibujar Figura";
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);

            this.cmbFiguras.Items.AddRange(new object[] { "Cuadrado", "Flecha", "Casa" });
            this.cmbFiguras.Location = new System.Drawing.Point(620, 60);
            this.cmbFiguras.SelectedIndex = 0;

            this.lblVelocidad.Location = new System.Drawing.Point(620, 100);
            this.lblVelocidad.Text = "Velocidad:";

            this.trackBarVelocidad.Location = new System.Drawing.Point(620, 120);
            this.trackBarVelocidad.Minimum = 10; this.trackBarVelocidad.Maximum = 200; this.trackBarVelocidad.Value = 50;
            this.trackBarVelocidad.Scroll += new System.EventHandler(this.trackBarVelocidad_Scroll);

            this.btnReiniciar.Location = new System.Drawing.Point(620, 180);
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);

            this.ClientSize = new System.Drawing.Size(760, 650);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { btnDibujar, cmbFiguras, lblVelocidad, trackBarVelocidad, btnReiniciar });
            this.Name = "BoundaryFill";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BoundaryFill_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoundaryFill_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}