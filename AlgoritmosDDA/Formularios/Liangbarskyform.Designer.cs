namespace LiangBarskyApp
{
    partial class LiangBarskyForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsBtnDraw;
        private System.Windows.Forms.ToolStripButton tsBtnClip;
        private System.Windows.Forms.ToolStripButton tsBtnDemo;
        private System.Windows.Forms.ToolStripButton tsBtnClear;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripLabel tsLblTitle;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblU1;
        private System.Windows.Forms.ToolStripStatusLabel lblU2;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Panel panelSide;

        private System.Windows.Forms.Label lblLineCoords;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.TextBox txtY2;

        private System.Windows.Forms.Label lblSep1;

        private System.Windows.Forms.Label lblClipCoords;
        private System.Windows.Forms.Label lblXmin;
        private System.Windows.Forms.TextBox txtXmin;
        private System.Windows.Forms.Label lblYmin;
        private System.Windows.Forms.TextBox txtYmin;
        private System.Windows.Forms.Label lblXmax;
        private System.Windows.Forms.TextBox txtXmax;
        private System.Windows.Forms.Label lblYmax;
        private System.Windows.Forms.TextBox txtYmax;

        private System.Windows.Forms.Label lblSep2;

        private System.Windows.Forms.Label lblAlgoName;

        private System.Windows.Forms.Label lblSep3;

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnClip;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.Label lblSep4;

        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label lblResultStatus;
        private System.Windows.Forms.Label lblResultCoords;
        private System.Windows.Forms.Label lblResultU;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            toolStrip = new System.Windows.Forms.ToolStrip();
            tsLblTitle = new System.Windows.Forms.ToolStripLabel();
            tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            tsBtnDraw = new System.Windows.Forms.ToolStripButton();
            tsBtnClip = new System.Windows.Forms.ToolStripButton();
            tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            tsBtnDemo = new System.Windows.Forms.ToolStripButton();
            tsBtnClear = new System.Windows.Forms.ToolStripButton();

            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            lblU1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblU2 = new System.Windows.Forms.ToolStripStatusLabel();

            panelCanvas = new System.Windows.Forms.Panel();
            panelSide = new System.Windows.Forms.Panel();

            lblLineCoords = new System.Windows.Forms.Label();
            lblX1 = new System.Windows.Forms.Label();
            txtX1 = new System.Windows.Forms.TextBox();
            lblY1 = new System.Windows.Forms.Label();
            txtY1 = new System.Windows.Forms.TextBox();
            lblX2 = new System.Windows.Forms.Label();
            txtX2 = new System.Windows.Forms.TextBox();
            lblY2 = new System.Windows.Forms.Label();
            txtY2 = new System.Windows.Forms.TextBox();
            lblSep1 = new System.Windows.Forms.Label();
            lblClipCoords = new System.Windows.Forms.Label();
            lblXmin = new System.Windows.Forms.Label();
            txtXmin = new System.Windows.Forms.TextBox();
            lblYmin = new System.Windows.Forms.Label();
            txtYmin = new System.Windows.Forms.TextBox();
            lblXmax = new System.Windows.Forms.Label();
            txtXmax = new System.Windows.Forms.TextBox();
            lblYmax = new System.Windows.Forms.Label();
            txtYmax = new System.Windows.Forms.TextBox();
            lblSep2 = new System.Windows.Forms.Label();
            lblAlgoName = new System.Windows.Forms.Label();
            lblSep3 = new System.Windows.Forms.Label();
            btnDraw = new System.Windows.Forms.Button();
            btnClip = new System.Windows.Forms.Button();
            btnDemo = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            lblSep4 = new System.Windows.Forms.Label();
            lblResultTitle = new System.Windows.Forms.Label();
            lblResultStatus = new System.Windows.Forms.Label();
            lblResultCoords = new System.Windows.Forms.Label();
            lblResultU = new System.Windows.Forms.Label();

            // ── ToolStrip ────────────────────────────────────────────────
            toolStrip.BackColor = System.Drawing.Color.FromArgb(30, 30, 40);
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            toolStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            toolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            toolStrip.Size = new System.Drawing.Size(1100, 34);

            tsLblTitle.Text = "  LIANG-BARSKY  LINE CLIPPING";
            tsLblTitle.ForeColor = System.Drawing.Color.FromArgb(130, 170, 255);
            tsLblTitle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);

            tsBtnDraw.Text = "▶  Dibujar";
            tsBtnDraw.ForeColor = System.Drawing.Color.FromArgb(140, 210, 140);
            tsBtnDraw.Font = new System.Drawing.Font("Segoe UI", 9f);
            tsBtnDraw.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            tsBtnDraw.Click += (s, e) => DrawScene();

            tsBtnClip.Text = "✂  Recortar";
            tsBtnClip.ForeColor = System.Drawing.Color.FromArgb(255, 200, 80);
            tsBtnClip.Font = new System.Drawing.Font("Segoe UI", 9f);
            tsBtnClip.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            tsBtnClip.Click += (s, e) => RunClip();

            tsBtnDemo.Text = "★  Demo";
            tsBtnDemo.ForeColor = System.Drawing.Color.FromArgb(180, 140, 255);
            tsBtnDemo.Font = new System.Drawing.Font("Segoe UI", 9f);
            tsBtnDemo.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            tsBtnDemo.Click += (s, e) => LoadDemo();

            tsBtnClear.Text = "✗  Limpiar";
            tsBtnClear.ForeColor = System.Drawing.Color.FromArgb(255, 110, 110);
            tsBtnClear.Font = new System.Drawing.Font("Segoe UI", 9f);
            tsBtnClear.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            tsBtnClear.Click += (s, e) => ClearScene();

            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                tsLblTitle, tsSep1, tsBtnDraw, tsBtnClip, tsSep2, tsBtnDemo, tsBtnClear
            });

            // ── StatusStrip ──────────────────────────────────────────────
            statusStrip.BackColor = System.Drawing.Color.FromArgb(22, 22, 32);
            statusStrip.SizingGrip = false;
            statusStrip.Font = new System.Drawing.Font("Consolas", 8.5f);

            lblStatus.Text = "Listo. Ingresa coordenadas o carga un demo.";
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(190, 190, 210);
            lblStatus.AutoSize = false;
            lblStatus.Width = 420;

            lblSpring.Spring = true;

            lblU1.ForeColor = System.Drawing.Color.FromArgb(120, 200, 255);
            lblU1.Text = "";

            lblU2.ForeColor = System.Drawing.Color.FromArgb(120, 255, 180);
            lblU2.Text = "";

            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                lblStatus, lblSpring, lblU1, lblU2
            });

            // ── Panel Canvas ─────────────────────────────────────────────
            panelCanvas.BackColor = System.Drawing.Color.FromArgb(24, 24, 34);
            panelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCanvas.Paint += OnCanvasPaint;

            typeof(System.Windows.Forms.Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelCanvas, new object[] { true });

            // ── Panel Lateral ────────────────────────────────────────────
            panelSide.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            panelSide.Width = 230;
            panelSide.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            // ── Helpers locales ──────────────────────────────────────────
            System.Drawing.Color clrLabel = System.Drawing.Color.FromArgb(150, 155, 185);
            System.Drawing.Color clrCaption = System.Drawing.Color.FromArgb(120, 140, 200);
            System.Drawing.Color clrSep = System.Drawing.Color.FromArgb(55, 55, 72);
            System.Drawing.Color clrTextBack = System.Drawing.Color.FromArgb(36, 36, 52);
            System.Drawing.Color clrTextFore = System.Drawing.Color.FromArgb(215, 220, 240);
            System.Drawing.Font fntLabel = new System.Drawing.Font("Segoe UI", 8.5f);
            System.Drawing.Font fntCaption = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            System.Drawing.Font fntTextBox = new System.Drawing.Font("Consolas", 9.5f);

            int lx = 10, tw = 95, tx = 115, lw = 100, rowH = 26, y = 8;

            System.Action<System.Windows.Forms.Label, string, int> configLbl = (lbl, text, top) =>
            {
                lbl.Text = text;
                lbl.Font = fntLabel;
                lbl.ForeColor = clrLabel;
                lbl.AutoSize = false;
                lbl.Width = lw;
                lbl.Height = 20;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lbl.Location = new System.Drawing.Point(lx, top + 3);
            };

            System.Action<System.Windows.Forms.TextBox, string, int> configTxt = (txt, val, top) =>
            {
                txt.Text = val;
                txt.Font = fntTextBox;
                txt.BackColor = clrTextBack;
                txt.ForeColor = clrTextFore;
                txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                txt.Width = tw;
                txt.Height = 22;
                txt.Location = new System.Drawing.Point(tx, top);
                txt.TextChanged += (s, e) => DrawScene();
            };

            System.Action<System.Windows.Forms.Label, string, int> configCaption = (lbl, text, top) =>
            {
                lbl.Text = text;
                lbl.Font = fntCaption;
                lbl.ForeColor = clrCaption;
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(lx, top);
            };

            System.Action<System.Windows.Forms.Label, int> configSep = (lbl, top) =>
            {
                lbl.Text = "";
                lbl.BackColor = clrSep;
                lbl.Height = 1;
                lbl.Width = 206;
                lbl.Location = new System.Drawing.Point(lx, top);
            };

            // ─── Sección: Línea ──────────────────────────────────────────
            configCaption(lblLineCoords, "COORDENADAS DE LÍNEA", y); y += 20;

            configLbl(lblX1, "X1", y); configTxt(txtX1, "50", y); y += rowH;
            configLbl(lblY1, "Y1", y); configTxt(txtY1, "300", y); y += rowH;
            configLbl(lblX2, "X2", y); configTxt(txtX2, "550", y); y += rowH;
            configLbl(lblY2, "Y2", y); configTxt(txtY2, "100", y); y += rowH + 4;

            configSep(lblSep1, y); y += 10;

            // ─── Sección: Ventana de Recorte ─────────────────────────────
            configCaption(lblClipCoords, "VENTANA DE RECORTE", y); y += 20;

            configLbl(lblXmin, "Xmin", y); configTxt(txtXmin, "120", y); y += rowH;
            configLbl(lblYmin, "Ymin", y); configTxt(txtYmin, "80", y); y += rowH;
            configLbl(lblXmax, "Xmax", y); configTxt(txtXmax, "440", y); y += rowH;
            configLbl(lblYmax, "Ymax", y); configTxt(txtYmax, "340", y); y += rowH + 4;

            configSep(lblSep2, y); y += 10;

            // ─── Nombre del algoritmo ────────────────────────────────────
            lblAlgoName.Text = "Algoritmo\nLiang-Barsky";
            lblAlgoName.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblAlgoName.ForeColor = System.Drawing.Color.FromArgb(110, 160, 255);
            lblAlgoName.AutoSize = true;
            lblAlgoName.Location = new System.Drawing.Point(lx, y);
            y += 36;

            configSep(lblSep3, y); y += 10;

            // ─── Botones ─────────────────────────────────────────────────
            System.Action<System.Windows.Forms.Button, string, System.Drawing.Color, int> configBtn =
                (btn, text, fore, top) =>
                {
                    btn.Text = text;
                    btn.ForeColor = fore;
                    btn.BackColor = System.Drawing.Color.FromArgb(40, 40, 58);
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 65, 90);
                    btn.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
                    btn.Width = 206;
                    btn.Height = 28;
                    btn.Location = new System.Drawing.Point(lx, top);
                    btn.Cursor = System.Windows.Forms.Cursors.Hand;
                };

            configBtn(btnDraw, "▶  Dibujar Línea",
                System.Drawing.Color.FromArgb(140, 210, 140), y);
            btnDraw.Click += (s, e) => DrawScene();
            y += 34;

            configBtn(btnClip, "✂  Ejecutar Recorte",
                System.Drawing.Color.FromArgb(255, 200, 80), y);
            btnClip.Click += (s, e) => RunClip();
            y += 34;

            configBtn(btnDemo, "★  Cargar Demo",
                System.Drawing.Color.FromArgb(190, 150, 255), y);
            btnDemo.Click += (s, e) => LoadDemo();
            y += 34;

            configBtn(btnClear, "✗  Limpiar",
                System.Drawing.Color.FromArgb(255, 110, 110), y);
            btnClear.Click += (s, e) => ClearScene();
            y += 38;

            configSep(lblSep4, y); y += 10;

            // ─── Resultado ───────────────────────────────────────────────
            lblResultTitle.Text = "RESULTADO";
            lblResultTitle.Font = fntCaption;
            lblResultTitle.ForeColor = clrCaption;
            lblResultTitle.AutoSize = true;
            lblResultTitle.Location = new System.Drawing.Point(lx, y);
            y += 20;

            lblResultStatus.Text = "—";
            lblResultStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblResultStatus.ForeColor = System.Drawing.Color.FromArgb(160, 160, 190);
            lblResultStatus.AutoSize = false;
            lblResultStatus.Width = 206;
            lblResultStatus.Height = 20;
            lblResultStatus.Location = new System.Drawing.Point(lx, y);
            y += 22;

            lblResultCoords.Text = "";
            lblResultCoords.Font = new System.Drawing.Font("Consolas", 8f);
            lblResultCoords.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            lblResultCoords.AutoSize = false;
            lblResultCoords.Width = 206;
            lblResultCoords.Height = 36;
            lblResultCoords.Location = new System.Drawing.Point(lx, y);
            y += 38;

            lblResultU.Text = "";
            lblResultU.Font = new System.Drawing.Font("Consolas", 8f);
            lblResultU.ForeColor = System.Drawing.Color.FromArgb(140, 220, 160);
            lblResultU.AutoSize = false;
            lblResultU.Width = 206;
            lblResultU.Height = 36;
            lblResultU.Location = new System.Drawing.Point(lx, y);

            // ─── Agregar controles al panel lateral ──────────────────────
            panelSide.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblLineCoords, lblX1, txtX1, lblY1, txtY1, lblX2, txtX2, lblY2, txtY2,
                lblSep1,
                lblClipCoords, lblXmin, txtXmin, lblYmin, txtYmin, lblXmax, txtXmax, lblYmax, txtYmax,
                lblSep2,
                lblAlgoName,
                lblSep3,
                btnDraw, btnClip, btnDemo, btnClear,
                lblSep4,
                lblResultTitle, lblResultStatus, lblResultCoords, lblResultU
            });

            // ── Formulario ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 34);
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.MinimumSize = new System.Drawing.Size(800, 520);
            this.Text = "Liang-Barsky — Recorte de Líneas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPreview = true;

            this.Controls.Add(panelCanvas);
            this.Controls.Add(panelSide);
            this.Controls.Add(toolStrip);
            this.Controls.Add(statusStrip);
        }
    }
}