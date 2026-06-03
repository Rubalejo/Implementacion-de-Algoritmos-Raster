namespace AlgoritmosDDA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmosDDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejercicio1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvaDeBézierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloDDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.polaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodoRotacióMatrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosDDAToolStripMenuItem,
            this.circuloDDAToolStripMenuItem,
            this.rellenoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmosDDAToolStripMenuItem
            // 
            this.algoritmosDDAToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowText;
            this.algoritmosDDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejercicio1ToolStripMenuItem,
            this.puntoMedioToolStripMenuItem,
            this.curvaDeBézierToolStripMenuItem});
            this.algoritmosDDAToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algoritmosDDAToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.algoritmosDDAToolStripMenuItem.Name = "algoritmosDDAToolStripMenuItem";
            this.algoritmosDDAToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.algoritmosDDAToolStripMenuItem.Text = "Recta";
            // 
            // ejercicio1ToolStripMenuItem
            // 
            this.ejercicio1ToolStripMenuItem.Name = "ejercicio1ToolStripMenuItem";
            this.ejercicio1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ejercicio1ToolStripMenuItem.Text = "Recta";
            this.ejercicio1ToolStripMenuItem.Click += new System.EventHandler(this.ejercicio1ToolStripMenuItem_Click);
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.puntoMedioToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // curvaDeBézierToolStripMenuItem
            // 
            this.curvaDeBézierToolStripMenuItem.Name = "curvaDeBézierToolStripMenuItem";
            this.curvaDeBézierToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.curvaDeBézierToolStripMenuItem.Text = "Curva de Bézier";
            this.curvaDeBézierToolStripMenuItem.Click += new System.EventHandler(this.curvaDeBézierToolStripMenuItem_Click);
            // 
            // circuloDDAToolStripMenuItem
            // 
            this.circuloDDAToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowText;
            this.circuloDDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circuloToolStripMenuItem1,
            this.polaresToolStripMenuItem,
            this.métodoRotacióMatrizToolStripMenuItem});
            this.circuloDDAToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circuloDDAToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.circuloDDAToolStripMenuItem.Name = "circuloDDAToolStripMenuItem";
            this.circuloDDAToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.circuloDDAToolStripMenuItem.Text = "Circulo";
            // 
            // circuloToolStripMenuItem1
            // 
            this.circuloToolStripMenuItem1.Name = "circuloToolStripMenuItem1";
            this.circuloToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.circuloToolStripMenuItem1.Text = "Circulo";
            this.circuloToolStripMenuItem1.Click += new System.EventHandler(this.circuloToolStripMenuItem1_Click);
            // 
            // polaresToolStripMenuItem
            // 
            this.polaresToolStripMenuItem.Name = "polaresToolStripMenuItem";
            this.polaresToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.polaresToolStripMenuItem.Text = "Método Polares";
            this.polaresToolStripMenuItem.Click += new System.EventHandler(this.polaresToolStripMenuItem_Click);
            // 
            // métodoRotacióMatrizToolStripMenuItem
            // 
            this.métodoRotacióMatrizToolStripMenuItem.Name = "métodoRotacióMatrizToolStripMenuItem";
            this.métodoRotacióMatrizToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.métodoRotacióMatrizToolStripMenuItem.Text = "Método Rotación Por Matriz";
            this.métodoRotacióMatrizToolStripMenuItem.Click += new System.EventHandler(this.métodoRotacióMatrizToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowText;
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floodFillToolStripMenuItem,
            this.boundaryFillToolStripMenuItem,
            this.scanLineToolStripMenuItem});
            this.rellenoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // floodFillToolStripMenuItem
            // 
            this.floodFillToolStripMenuItem.Name = "floodFillToolStripMenuItem";
            this.floodFillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.floodFillToolStripMenuItem.Text = "Flood Fill";
            this.floodFillToolStripMenuItem.Click += new System.EventHandler(this.floodFillToolStripMenuItem_Click);
            // 
            // boundaryFillToolStripMenuItem
            // 
            this.boundaryFillToolStripMenuItem.Name = "boundaryFillToolStripMenuItem";
            this.boundaryFillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boundaryFillToolStripMenuItem.Text = "Boundary Fill";
            this.boundaryFillToolStripMenuItem.Click += new System.EventHandler(this.boundaryFillToolStripMenuItem_Click);
            // 
            // scanLineToolStripMenuItem
            // 
            this.scanLineToolStripMenuItem.Name = "scanLineToolStripMenuItem";
            this.scanLineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scanLineToolStripMenuItem.Text = "Scan Line";
            this.scanLineToolStripMenuItem.Click += new System.EventHandler(this.scanLineToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ALGORITMOS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // AQUÍ ESTABA EL CAMBIO: Se agregó la definición del menuStrip1 que faltaba
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmosDDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejercicio1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvaDeBézierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloDDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem polaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodoRotacióMatrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundaryFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanLineToolStripMenuItem;
    }
}