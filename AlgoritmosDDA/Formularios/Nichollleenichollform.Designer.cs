namespace NLNApp
{
    partial class NichollLeeNichollForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsTitle;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripButton tsBtnDraw;
        private System.Windows.Forms.ToolStripButton tsBtnClip;
        private System.Windows.Forms.ToolStripButton tsBtnDemo;
        private System.Windows.Forms.ToolStripButton tsBtnClear;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblRegionStatus;

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Panel panelSide;

        // Line coords
        private System.Windows.Forms.Label lblLineSection;
        private System.Windows.Forms.Label lblX1, lblY1, lblX2, lblY2;
        private System.Windows.Forms.TextBox txtX1, txtY1, txtX2, txtY2;

        // Clip window
        private System.Windows.Forms.Label lblClipSection;
        private System.Windows.Forms.Label lblXmin, lblYmin, lblXmax, lblYmax;
        private System.Windows.Forms.TextBox txtXmin, txtYmin, txtXmax, txtYmax;

        // Separators
        private System.Windows.Forms.Label sepLine1, sepLine2, sepLine3, sepLine4;

        // NLN info
        private System.Windows.Forms.Label lblNLNSection;
        private System.Windows.Forms.Label lblRegionLabel, lblRegionValue;
        private System.Windows.Forms.Label lblCaseLabel, lblCaseValue;

        // Buttons
        private System.Windows.Forms.Button btnDraw, btnClip, btnDemo, btnClear;

        // Result
        private System.Windows.Forms.Label lblResultSection;
        private System.Windows.Forms.Label lblResultState;
        private System.Windows.Forms.Label lblResultP1, lblResultP2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            toolStrip = new System.Windows.Forms.ToolStrip();
            tsTitle = new System.Windows.Forms.ToolStripLabel();
            tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            tsBtnDraw = new System.Windows.Forms.ToolStripButton();
            tsBtnClip = new System.Windows.Forms.ToolStripButton();
            tsBtnDemo = new System.Windows.Forms.ToolStripButton();
            tsBtnClear = new System.Windows.Forms.ToolStripButton();

            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            lblRegionStatus = new System.Windows.Forms.ToolStripStatusLabel();

            panelCanvas = new System.Windows.Forms.Panel();
            panelSide = new System.Windows.Forms.Panel();

            lblLineSection = new System.Windows.Forms.Label();
            lblX1 = new System.Windows.Forms.Label(); txtX1 = new System.Windows.Forms.TextBox();
            lblY1 = new System.Windows.Forms.Label(); txtY1 = new System.Windows.Forms.TextBox();
            lblX2 = new System.Windows.Forms.Label(); txtX2 = new System.Windows.Forms.TextBox();
            lblY2 = new System.Windows.Forms.Label(); txtY2 = new System.Windows.Forms.TextBox();

            lblClipSection = new System.Windows.Forms.Label();
            lblXmin = new System.Windows.Forms.Label(); txtXmin = new System.Windows.Forms.TextBox();
            lblYmin = new System.Windows.Forms.Label(); txtYmin = new System.Windows.Forms.TextBox();
            lblXmax = new System.Windows.Forms.Label(); txtXmax = new System.Windows.Forms.TextBox();
            lblYmax = new System.Windows.Forms.Label(); txtYmax = new System.Windows.Forms.TextBox();

            sepLine1 = new System.Windows.Forms.Label();
            sepLine2 = new System.Windows.Forms.Label();
            sepLine3 = new System.Windows.Forms.Label();
            sepLine4 = new System.Windows.Forms.Label();

            lblNLNSection = new System.Windows.Forms.Label();
            lblRegionLabel = new System.Windows.Forms.Label(); lblRegionValue = new System.Windows.Forms.Label();
            lblCaseLabel = new System.Windows.Forms.Label(); lblCaseValue = new System.Windows.Forms.Label();

            btnDraw = new System.Windows.Forms.Button();
            btnClip = new System.Windows.Forms.Button();
            btnDemo = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            lblResultSection = new System.Windows.Forms.Label();
            lblResultState = new System.Windows.Forms.Label();
            lblResultP1 = new System.Windows.Forms.Label();
            lblResultP2 = new System.Windows.Forms.Label();

            // ── ToolStrip ────────────────────────────────────────────────
            toolStrip.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            toolStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            toolStrip.Dock = System.Windows.Forms.DockStyle.Top;

            tsTitle.Text = "  NICHOLL-LEE-NICHOLL  LINE CLIPPING";
            tsTitle.ForeColor = System.Drawing.Color.FromArgb(140, 180, 255);
            tsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);

            ConfigureToolBtn(tsBtnDraw, "▶  Dibujar", System.Drawing.Color.FromArgb(130, 210, 130));
            ConfigureToolBtn(tsBtnClip, "✂  Recortar", System.Drawing.Color.FromArgb(255, 195, 70));
            ConfigureToolBtn(tsBtnDemo, "★  Demo", System.Drawing.Color.FromArgb(185, 145, 255));
            ConfigureToolBtn(tsBtnClear, "✗  Limpiar", System.Drawing.Color.FromArgb(255, 105, 105));

            tsBtnDraw.Click += (s, e) => DrawScene();
            tsBtnClip.Click += (s, e) => RunClip();
            tsBtnDemo.Click += (s, e) => LoadDemo();
            tsBtnClear.Click += (s, e) => ClearScene();

            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                tsTitle, tsSep1, tsBtnDraw, tsBtnClip, tsBtnDemo, tsBtnClear
            });

            // ── StatusStrip ──────────────────────────────────────────────
            statusStrip.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            statusStrip.SizingGrip = false;
            statusStrip.Font = new System.Drawing.Font("Consolas", 8.5f);

            lblStatus.Text = "Listo.";
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(190, 190, 210);
            lblStatus.AutoSize = false;
            lblStatus.Width = 500;
            lblSpring.Spring = true;
            lblRegionStatus.ForeColor = System.Drawing.Color.FromArgb(130, 200, 255);

            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                lblStatus, lblSpring, lblRegionStatus
            });

            // ── Canvas ───────────────────────────────────────────────────
            panelCanvas.BackColor = System.Drawing.Color.FromArgb(22, 22, 32);
            panelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCanvas.Paint += OnCanvasPaint;

            typeof(System.Windows.Forms.Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelCanvas, new object[] { true });

            // ── Side Panel ───────────────────────────────────────────────
            panelSide.BackColor = System.Drawing.Color.FromArgb(28, 28, 42);
            panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            panelSide.Width = 236;
            panelSide.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);

            // Colors / fonts
            var cLabel = System.Drawing.Color.FromArgb(145, 155, 190);
            var cCaption = System.Drawing.Color.FromArgb(115, 145, 210);
            var cSep = System.Drawing.Color.FromArgb(52, 52, 70);
            var cTxtBack = System.Drawing.Color.FromArgb(34, 34, 50);
            var cTxtFore = System.Drawing.Color.FromArgb(215, 220, 242);
            var fLabel = new System.Drawing.Font("Segoe UI", 8.5f);
            var fCaption = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            var fMono = new System.Drawing.Font("Consolas", 9.5f);
            var fValue = new System.Drawing.Font("Consolas", 8.5f);

            int lx = 8, lw = 46, tx = 60, tw = 160, rowH = 26, y = 6;

            System.Action<System.Windows.Forms.Label, string, int> cap = (l, t, top) =>
            {
                l.Text = t; l.Font = fCaption; l.ForeColor = cCaption;
                l.AutoSize = true; l.Location = new System.Drawing.Point(lx, top);
            };
            System.Action<System.Windows.Forms.Label, string, int> lbl = (l, t, top) =>
            {
                l.Text = t; l.Font = fLabel; l.ForeColor = cLabel;
                l.AutoSize = false; l.Width = lw - 2; l.Height = 20;
                l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                l.Location = new System.Drawing.Point(lx, top + 3);
            };
            System.Action<System.Windows.Forms.TextBox, string, int> txt = (t, v, top) =>
            {
                t.Text = v; t.Font = fMono;
                t.BackColor = cTxtBack; t.ForeColor = cTxtFore;
                t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                t.Width = tw; t.Height = 22;
                t.Location = new System.Drawing.Point(tx, top);
                t.TextChanged += (s, e) => DrawScene();
            };
            System.Action<System.Windows.Forms.Label, int> sep = (l, top) =>
            {
                l.Text = ""; l.BackColor = cSep;
                l.Height = 1; l.Width = 214;
                l.Location = new System.Drawing.Point(lx, top);
            };

            // ─── Línea ───────────────────────────────────────────────────
            cap(lblLineSection, "COORDENADAS DE LÍNEA", y); y += 20;
            lbl(lblX1, "X1", y); txt(txtX1, "50", y); y += rowH;
            lbl(lblY1, "Y1", y); txt(txtY1, "300", y); y += rowH;
            lbl(lblX2, "X2", y); txt(txtX2, "550", y); y += rowH;
            lbl(lblY2, "Y2", y); txt(txtY2, "100", y); y += rowH + 4;
            sep(sepLine1, y); y += 10;

            // ─── Ventana ─────────────────────────────────────────────────
            cap(lblClipSection, "VENTANA DE RECORTE", y); y += 20;
            lbl(lblXmin, "Xmin", y); txt(txtXmin, "120", y); y += rowH;
            lbl(lblYmin, "Ymin", y); txt(txtYmin, "80", y); y += rowH;
            lbl(lblXmax, "Xmax", y); txt(txtXmax, "440", y); y += rowH;
            lbl(lblYmax, "Ymax", y); txt(txtYmax, "340", y); y += rowH + 4;
            sep(sepLine2, y); y += 10;

            // ─── Info NLN ────────────────────────────────────────────────
            cap(lblNLNSection, "INFORMACIÓN NLN", y); y += 22;

            lblRegionLabel.Text = "Región:";
            lblRegionLabel.Font = fLabel; lblRegionLabel.ForeColor = cLabel;
            lblRegionLabel.AutoSize = true;
            lblRegionLabel.Location = new System.Drawing.Point(lx, y);

            lblRegionValue.Text = "—";
            lblRegionValue.Font = fValue; lblRegionValue.ForeColor = System.Drawing.Color.FromArgb(130, 200, 255);
            lblRegionValue.AutoSize = true;
            lblRegionValue.Location = new System.Drawing.Point(lx + 58, y);
            y += 20;

            lblCaseLabel.Text = "Caso:";
            lblCaseLabel.Font = fLabel; lblCaseLabel.ForeColor = cLabel;
            lblCaseLabel.AutoSize = true;
            lblCaseLabel.Location = new System.Drawing.Point(lx, y);

            lblCaseValue.Text = "—";
            lblCaseValue.Font = new System.Drawing.Font("Segoe UI", 8f);
            lblCaseValue.ForeColor = System.Drawing.Color.FromArgb(200, 175, 255);
            lblCaseValue.AutoSize = false; lblCaseValue.Width = 200; lblCaseValue.Height = 32;
            lblCaseValue.Location = new System.Drawing.Point(lx + 58, y);
            y += 36;

            sep(sepLine3, y); y += 10;

            // ─── Botones ─────────────────────────────────────────────────
            System.Action<System.Windows.Forms.Button, string, System.Drawing.Color, int> btn =
                (b, t, fore, top) =>
                {
                    b.Text = t; b.ForeColor = fore;
                    b.BackColor = System.Drawing.Color.FromArgb(38, 38, 56);
                    b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    b.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(58, 62, 90);
                    b.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
                    b.Width = 214; b.Height = 28;
                    b.Location = new System.Drawing.Point(lx, top);
                    b.Cursor = System.Windows.Forms.Cursors.Hand;
                };

            btn(btnDraw, "▶  Dibujar Línea", System.Drawing.Color.FromArgb(130, 210, 130), y); btnDraw.Click += (s, e) => DrawScene(); y += 33;
            btn(btnClip, "✂  Ejecutar Recorte", System.Drawing.Color.FromArgb(255, 195, 70), y); btnClip.Click += (s, e) => RunClip(); y += 33;
            btn(btnDemo, "★  Cargar Demo", System.Drawing.Color.FromArgb(185, 145, 255), y); btnDemo.Click += (s, e) => LoadDemo(); y += 33;
            btn(btnClear, "✗  Limpiar", System.Drawing.Color.FromArgb(255, 105, 105), y); btnClear.Click += (s, e) => ClearScene(); y += 37;

            sep(sepLine4, y); y += 10;

            // ─── Resultado ───────────────────────────────────────────────
            cap(lblResultSection, "RESULTADO", y); y += 22;

            lblResultState.Text = "—";
            lblResultState.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            lblResultState.ForeColor = System.Drawing.Color.FromArgb(160, 162, 195);
            lblResultState.AutoSize = true;
            lblResultState.Location = new System.Drawing.Point(lx, y);
            y += 22;

            lblResultP1.Text = "";
            lblResultP1.Font = fValue; lblResultP1.ForeColor = System.Drawing.Color.FromArgb(155, 205, 255);
            lblResultP1.AutoSize = false; lblResultP1.Width = 214; lblResultP1.Height = 20;
            lblResultP1.Location = new System.Drawing.Point(lx, y);
            y += 22;

            lblResultP2.Text = "";
            lblResultP2.Font = fValue; lblResultP2.ForeColor = System.Drawing.Color.FromArgb(155, 205, 255);
            lblResultP2.AutoSize = false; lblResultP2.Width = 214; lblResultP2.Height = 20;
            lblResultP2.Location = new System.Drawing.Point(lx, y);

            panelSide.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblLineSection,
                lblX1, txtX1, lblY1, txtY1, lblX2, txtX2, lblY2, txtY2,
                sepLine1,
                lblClipSection,
                lblXmin, txtXmin, lblYmin, txtYmin, lblXmax, txtXmax, lblYmax, txtYmax,
                sepLine2,
                lblNLNSection,
                lblRegionLabel, lblRegionValue,
                lblCaseLabel,   lblCaseValue,
                sepLine3,
                btnDraw, btnClip, btnDemo, btnClear,
                sepLine4,
                lblResultSection, lblResultState, lblResultP1, lblResultP2
            });

            // ── Form ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(22, 22, 32);
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Text = "Nicholl-Lee-Nicholl — Recorte de Líneas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPreview = true;

            this.Controls.Add(panelCanvas);
            this.Controls.Add(panelSide);
            this.Controls.Add(toolStrip);
            this.Controls.Add(statusStrip);
        }

        private void ConfigureToolBtn(System.Windows.Forms.ToolStripButton b, string text, System.Drawing.Color fore)
        {
            b.Text = text; b.ForeColor = fore;
            b.Font = new System.Drawing.Font("Segoe UI", 9f);
            b.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
        }
    }
}