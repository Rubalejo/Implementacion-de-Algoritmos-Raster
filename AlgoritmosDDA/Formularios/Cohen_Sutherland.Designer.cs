namespace AlgoritmosDDA.Formularios
{
    partial class CohenSutherlandForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ── Controles principales ──────────────────────────────
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer;

        // ── ToolStrip buttons ──────────────────────────────────
        private System.Windows.Forms.ToolStripButton btnNuevoSegmento;
        private System.Windows.Forms.ToolStripButton btnNuevaVentana;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripButton btnRecortar;
        private System.Windows.Forms.ToolStripButton btnDemo;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripSeparator sep3;

        // ── StatusStrip labels ─────────────────────────────────
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador1;
        private System.Windows.Forms.ToolStripStatusLabel lblLineas;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador2;
        private System.Windows.Forms.ToolStripStatusLabel lblPosicion;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador3;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;

        // ── Panel de dibujo ────────────────────────────────────
        private System.Windows.Forms.Panel drawingPanel;

        // ── Panel lateral ──────────────────────────────────────
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label lblTituloLateral;
        private System.Windows.Forms.ListBox listBoxSegmentos;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label lblInfoContenido;
        private System.Windows.Forms.Label lblTituloVentana;
        private System.Windows.Forms.Label lblVentanaInfo;

        /// <summary>
        /// Limpia los recursos utilizados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método requerido para la compatibilidad con el Diseñador de Visual Studio.
        /// No modifique el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNuevoSegmento = new System.Windows.Forms.ToolStripButton();
            this.btnNuevaVentana = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecortar = new System.Windows.Forms.ToolStripButton();
            this.btnDemo = new System.Windows.Forms.ToolStripButton();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLineas = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPosicion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblVentanaInfo = new System.Windows.Forms.Label();
            this.lblTituloVentana = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfoContenido = new System.Windows.Forms.Label();
            this.listBoxSegmentos = new System.Windows.Forms.ListBox();
            this.lblTituloLateral = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoSegmento,
            this.btnNuevaVentana,
            this.sep1,
            this.btnRecortar,
            this.btnDemo,
            this.sep2,
            this.btnLimpiar,
            this.sep3});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1100, 27);
            this.toolStrip.TabIndex = 1;
            // 
            // btnNuevoSegmento
            // 
            this.btnNuevoSegmento.ForeColor = System.Drawing.Color.White;
            this.btnNuevoSegmento.Name = "btnNuevoSegmento";
            this.btnNuevoSegmento.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnNuevoSegmento.Size = new System.Drawing.Size(126, 20);
            this.btnNuevoSegmento.Text = "✏ Nuevo Segmento";
            this.btnNuevoSegmento.ToolTipText = "Activa el modo para dibujar un nuevo segmento (2 clics)";
            this.btnNuevoSegmento.Click += new System.EventHandler(this.BtnNuevoSegmento_Click);
            // 
            // btnNuevaVentana
            // 
            this.btnNuevaVentana.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVentana.Name = "btnNuevaVentana";
            this.btnNuevaVentana.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnNuevaVentana.Size = new System.Drawing.Size(111, 20);
            this.btnNuevaVentana.Text = "⬜ Nueva Ventana";
            this.btnNuevaVentana.ToolTipText = "Activa el modo para definir la ventana de recorte (arrastrar)";
            this.btnNuevaVentana.Click += new System.EventHandler(this.BtnNuevaVentana_Click);
            // 
            // sep1
            // 
            this.sep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnRecortar
            // 
            this.btnRecortar.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRecortar.Size = new System.Drawing.Size(78, 20);
            this.btnRecortar.Text = "✂ Recortar";
            this.btnRecortar.ToolTipText = "Aplica el algoritmo Cohen-Sutherland a todos los segmentos";
            this.btnRecortar.Click += new System.EventHandler(this.BtnRecortar_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.ForeColor = System.Drawing.Color.SkyBlue;
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnDemo.Size = new System.Drawing.Size(64, 20);
            this.btnDemo.Text = "▶ Demo";
            this.btnDemo.ToolTipText = "Carga una demostración automática con 5 segmentos variados";
            this.btnDemo.Click += new System.EventHandler(this.BtnDemo_Click);
            // 
            // sep2
            // 
            this.sep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.Tomato;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnLimpiar.Size = new System.Drawing.Size(74, 20);
            this.btnLimpiar.Text = "🗑 Limpiar";
            this.btnLimpiar.ToolTipText = "Borra todos los segmentos y la ventana de recorte";
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // sep3
            // 
            this.sep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 23);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(33)))));
            this.statusStrip.ForeColor = System.Drawing.Color.Silver;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado,
            this.lblSeparador1,
            this.lblLineas,
            this.lblSeparador2,
            this.lblPosicion,
            this.lblSeparador3,
            this.lblResultado});
            this.statusStrip.Location = new System.Drawing.Point(0, 638);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.ForeColor = System.Drawing.Color.LightGray;
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(32, 17);
            this.lblEstado.Text = "Listo";
            // 
            // lblSeparador1
            // 
            this.lblSeparador1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.lblSeparador1.Name = "lblSeparador1";
            this.lblSeparador1.Size = new System.Drawing.Size(13, 17);
            this.lblSeparador1.Text = "│";
            // 
            // lblLineas
            // 
            this.lblLineas.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblLineas.Name = "lblLineas";
            this.lblLineas.Size = new System.Drawing.Size(52, 17);
            this.lblLineas.Text = "Líneas: 0";
            // 
            // lblSeparador2
            // 
            this.lblSeparador2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.lblSeparador2.Name = "lblSeparador2";
            this.lblSeparador2.Size = new System.Drawing.Size(13, 17);
            this.lblSeparador2.Text = "│";
            // 
            // lblPosicion
            // 
            this.lblPosicion.ForeColor = System.Drawing.Color.LightGray;
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(54, 17);
            this.lblPosicion.Text = "X: 0   Y: 0";
            // 
            // lblSeparador3
            // 
            this.lblSeparador3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.lblSeparador3.Name = "lblSeparador3";
            this.lblSeparador3.Size = new System.Drawing.Size(13, 17);
            this.lblSeparador3.Text = "│";
            // 
            // lblResultado
            // 
            this.lblResultado.ForeColor = System.Drawing.Color.Gold;
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(63, 17);
            this.lblResultado.Text = "Sin recorte";
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.drawingPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.sidePanel);
            this.splitContainer.Size = new System.Drawing.Size(1100, 611);
            this.splitContainer.SplitterDistance = 1071;
            this.splitContainer.TabIndex = 0;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(38)))));
            this.drawingPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1071, 611);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseUp);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.sidePanel.Controls.Add(this.lblVentanaInfo);
            this.sidePanel.Controls.Add(this.lblTituloVentana);
            this.sidePanel.Controls.Add(this.groupBoxInfo);
            this.sidePanel.Controls.Add(this.listBoxSegmentos);
            this.sidePanel.Controls.Add(this.lblTituloLateral);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Padding = new System.Windows.Forms.Padding(6);
            this.sidePanel.Size = new System.Drawing.Size(25, 611);
            this.sidePanel.TabIndex = 0;
            // 
            // lblVentanaInfo
            // 
            this.lblVentanaInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentanaInfo.Font = new System.Drawing.Font("Consolas", 7.5F);
            this.lblVentanaInfo.ForeColor = System.Drawing.Color.LightGray;
            this.lblVentanaInfo.Location = new System.Drawing.Point(6, 360);
            this.lblVentanaInfo.Name = "lblVentanaInfo";
            this.lblVentanaInfo.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.lblVentanaInfo.Size = new System.Drawing.Size(13, 42);
            this.lblVentanaInfo.TabIndex = 0;
            this.lblVentanaInfo.Text = "No definida";
            // 
            // lblTituloVentana
            // 
            this.lblTituloVentana.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloVentana.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloVentana.ForeColor = System.Drawing.Color.Tomato;
            this.lblTituloVentana.Location = new System.Drawing.Point(6, 338);
            this.lblTituloVentana.Name = "lblTituloVentana";
            this.lblTituloVentana.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.lblTituloVentana.Size = new System.Drawing.Size(13, 22);
            this.lblTituloVentana.TabIndex = 1;
            this.lblTituloVentana.Text = "VENTANA DE RECORTE";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.groupBoxInfo.Controls.Add(this.lblInfoContenido);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.ForeColor = System.Drawing.Color.SkyBlue;
            this.groupBoxInfo.Location = new System.Drawing.Point(6, 208);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(13, 130);
            this.groupBoxInfo.TabIndex = 2;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Detalle";
            // 
            // lblInfoContenido
            // 
            this.lblInfoContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoContenido.Font = new System.Drawing.Font("Consolas", 7.5F);
            this.lblInfoContenido.ForeColor = System.Drawing.Color.LightGray;
            this.lblInfoContenido.Location = new System.Drawing.Point(3, 18);
            this.lblInfoContenido.Name = "lblInfoContenido";
            this.lblInfoContenido.Padding = new System.Windows.Forms.Padding(4);
            this.lblInfoContenido.Size = new System.Drawing.Size(7, 109);
            this.lblInfoContenido.TabIndex = 0;
            this.lblInfoContenido.Text = "Seleccione un segmento\npara ver sus detalles.";
            // 
            // listBoxSegmentos
            // 
            this.listBoxSegmentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.listBoxSegmentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSegmentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxSegmentos.Font = new System.Drawing.Font("Consolas", 7.5F);
            this.listBoxSegmentos.ForeColor = System.Drawing.Color.LightGray;
            this.listBoxSegmentos.ItemHeight = 12;
            this.listBoxSegmentos.Location = new System.Drawing.Point(6, 28);
            this.listBoxSegmentos.Name = "listBoxSegmentos";
            this.listBoxSegmentos.Size = new System.Drawing.Size(13, 180);
            this.listBoxSegmentos.TabIndex = 3;
            this.listBoxSegmentos.SelectedIndexChanged += new System.EventHandler(this.ListBoxSegmentos_SelectedIndexChanged);
            // 
            // lblTituloLateral
            // 
            this.lblTituloLateral.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloLateral.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloLateral.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblTituloLateral.Location = new System.Drawing.Point(6, 6);
            this.lblTituloLateral.Name = "lblTituloLateral";
            this.lblTituloLateral.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.lblTituloLateral.Size = new System.Drawing.Size(13, 22);
            this.lblTituloLateral.TabIndex = 4;
            this.lblTituloLateral.Text = "SEGMENTOS";
            // 
            // CohenSutherlandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.Name = "CohenSutherlandForm";
            this.Text = "Cohen-Sutherland — AlgoritmosDDA";
            this.Load += new System.EventHandler(this.CohenSutherlandForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}