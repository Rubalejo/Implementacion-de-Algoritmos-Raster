using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LiangBarskyApp
{
    public partial class LiangBarskyForm : Form
    {
        private bool _clipped = false;
        private bool _accepted = false;
        private float _origX1, _origY1, _origX2, _origY2;
        private float _clipX1, _clipY1, _clipX2, _clipY2;
        private float _lastU1, _lastU2;

        public LiangBarskyForm()
        {
            InitializeComponent();
            LoadDemo();
        }

        private bool TryParseInputs(out float x1, out float y1, out float x2, out float y2, out float xmin, out float ymin, out float xmax, out float ymax)
        {
            x1 = y1 = x2 = y2 = xmin = ymin = xmax = ymax = 0;
            return float.TryParse(txtX1.Text, out x1) &&
                   float.TryParse(txtY1.Text, out y1) &&
                   float.TryParse(txtX2.Text, out x2) &&
                   float.TryParse(txtY2.Text, out y2) &&
                   float.TryParse(txtXmin.Text, out xmin) &&
                   float.TryParse(txtYmin.Text, out ymin) &&
                   float.TryParse(txtXmax.Text, out xmax) &&
                   float.TryParse(txtYmax.Text, out ymax);
        }

        private void DrawScene()
        {
            if (!TryParseInputs(out float x1, out float y1, out float x2, out float y2,
                                 out float xmin, out float ymin, out float xmax, out float ymax))
            {
                lblStatus.Text = "Error: verifica que todos los campos contengan números válidos.";
                return;
            }

            _origX1 = x1; _origY1 = y1; _origX2 = x2; _origY2 = y2;
            _clipped = false;
            _accepted = false;

            UpdateResult();
            panelCanvas.Invalidate();
            lblStatus.Text = "Línea y ventana dibujadas. Presiona 'Recortar' para aplicar el algoritmo.";
        }

        private void RunClip()
        {
            if (!TryParseInputs(out float x1, out float y1, out float x2, out float y2,
                                 out float xmin, out float ymin, out float xmax, out float ymax))
            {
                lblStatus.Text = "Error: verifica los valores ingresados.";
                return;
            }

            _origX1 = x1; _origY1 = y1; _origX2 = x2; _origY2 = y2;

            _accepted = LiangBarsky.ClipLineWithParams(x1, y1, x2, y2, xmin, ymin, xmax, ymax,
                                                       out _lastU1, out _lastU2);

            _clipX1 = x1; _clipY1 = y1; _clipX2 = x2; _clipY2 = y2;

            if (_accepted)
            {
                LiangBarsky.ClipLine(ref _clipX1, ref _clipY1, ref _clipX2, ref _clipY2,
                                     xmin, ymin, xmax, ymax);
            }

            _clipped = true;
            UpdateResult();
            panelCanvas.Invalidate();

            lblStatus.Text = _accepted
                ? $"Línea ACEPTADA. Segmento visible: ({_clipX1:F1},{_clipY1:F1}) → ({_clipX2:F1},{_clipY2:F1})"
                : "Línea RECHAZADA. Queda completamente fuera de la ventana de recorte.";

            lblU1.Text = $"u1 = {_lastU1:F4}   ";
            lblU2.Text = $"u2 = {_lastU2:F4}";
        }

        private void LoadDemo()
        {
            txtX1.Text = "60";
            txtY1.Text = "300";
            txtX2.Text = "540";
            txtY2.Text = "90";
            txtXmin.Text = "130";
            txtYmin.Text = "100";
            txtXmax.Text = "440";
            txtYmax.Text = "320";

            _clipped = false;
            _accepted = false;
            UpdateResult();

            _origX1 = 60; _origY1 = 300; _origX2 = 540; _origY2 = 90;
            panelCanvas.Invalidate();
            lblStatus.Text = "Demo cargado. Presiona 'Recortar' para ver el resultado.";
            lblU1.Text = "";
            lblU2.Text = "";
        }

        private void ClearScene()
        {
            txtX1.Text = txtY1.Text = txtX2.Text = txtY2.Text = "";
            txtXmin.Text = txtYmin.Text = txtXmax.Text = txtYmax.Text = "";
            _clipped = false;
            _accepted = false;
            UpdateResult();
            panelCanvas.Invalidate();
            lblStatus.Text = "Canvas limpiado.";
            lblU1.Text = "";
            lblU2.Text = "";
        }

        private void UpdateResult()
        {
            if (!_clipped)
            {
                lblResultStatus.Text = "—";
                lblResultStatus.ForeColor = Color.FromArgb(160, 160, 190);
                lblResultCoords.Text = "";
                lblResultU.Text = "";
                return;
            }

            if (_accepted)
            {
                lblResultStatus.Text = "ACEPTADA";
                lblResultStatus.ForeColor = Color.FromArgb(100, 220, 130);
                lblResultCoords.Text = $"P1: ({_clipX1:F1}, {_clipY1:F1})\nP2: ({_clipX2:F1}, {_clipY2:F1})";
                lblResultU.Text = $"u1 = {_lastU1:F4}\nu2 = {_lastU2:F4}";
            }
            else
            {
                lblResultStatus.Text = "RECHAZADA";
                lblResultStatus.ForeColor = Color.FromArgb(255, 100, 100);
                lblResultCoords.Text = "Fuera de la ventana";
                lblResultU.Text = $"u1 = {_lastU1:F4}\nu2 = {_lastU2:F4}";
            }
        }

        // ── Paint ────────────────────────────────────────────────────────

        private void OnCanvasPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            DrawBackground(g);

            if (!TryParseInputs(out float x1, out float y1, out float x2, out float y2,
                                 out float xmin, out float ymin, out float xmax, out float ymax))
                return;

            PointF o = Origin();
            float sc = Scale();

            DrawGrid(g, o, sc);
            DrawAxes(g, o, sc);
            DrawClipWindow(g, o, sc, xmin, ymin, xmax, ymax);

            using (Pen penOrig = new Pen(Color.FromArgb(220, 70, 70), 1.8f))
            {
                penOrig.DashStyle = DashStyle.Dash;
                g.DrawLine(penOrig, ToCanvas(x1, y1, o, sc), ToCanvas(x2, y2, o, sc));
            }

            DrawEndpoints(g, o, sc, x1, y1, x2, y2, Color.FromArgb(220, 80, 80));

            if (_clipped && _accepted)
            {
                using (Pen penClip = new Pen(Color.FromArgb(80, 220, 130), 2.5f))
                    g.DrawLine(penClip, ToCanvas(_clipX1, _clipY1, o, sc), ToCanvas(_clipX2, _clipY2, o, sc));

                DrawEndpoints(g, o, sc, _clipX1, _clipY1, _clipX2, _clipY2, Color.FromArgb(80, 220, 130));
                DrawClipLabels(g, o, sc, _clipX1, _clipY1, _clipX2, _clipY2);
            }
            else if (_clipped && !_accepted)
            {
                DrawRejectedLabel(g, o, sc, x1, y1, x2, y2);
            }

            DrawCoordLabel(g, o, sc, x1, y1, x2, y2);
        }

        // ── Canvas helpers ───────────────────────────────────────────────

        private PointF Origin()
        {
            return new PointF(panelCanvas.Width * 0.08f, panelCanvas.Height * 0.92f);
        }

        private float Scale()
        {
            return Math.Min(panelCanvas.Width, panelCanvas.Height) / 650f;
        }

        private PointF ToCanvas(float wx, float wy, PointF o, float sc)
        {
            return new PointF(o.X + wx * sc, o.Y - wy * sc);
        }

        private void DrawBackground(Graphics g)
        {
            g.Clear(Color.FromArgb(24, 24, 34));

            using (var dotBrush = new SolidBrush(Color.FromArgb(38, 38, 54)))
            {
                for (int x = 0; x < panelCanvas.Width; x += 28)
                    for (int y = 0; y < panelCanvas.Height; y += 28)
                        g.FillEllipse(dotBrush, x - 1, y - 1, 2, 2);
            }
        }

        private void DrawGrid(Graphics g, PointF o, float sc)
        {
            using (Pen p = new Pen(Color.FromArgb(40, 80, 80, 110), 1f))
            {
                p.DashStyle = DashStyle.Dot;
                float step = 50f;
                for (float v = 0; v < 700; v += step)
                {
                    PointF a = ToCanvas(v, 0, o, sc);
                    PointF b = ToCanvas(v, 700, o, sc);
                    g.DrawLine(p, a, b);
                    PointF c = ToCanvas(0, v, o, sc);
                    PointF d = ToCanvas(700, v, o, sc);
                    g.DrawLine(p, c, d);
                }
            }
        }

        private void DrawAxes(Graphics g, PointF o, float sc)
        {
            using (Pen ax = new Pen(Color.FromArgb(70, 80, 80, 110), 1.2f))
            {
                g.DrawLine(ax, ToCanvas(0, 0, o, sc), ToCanvas(650, 0, o, sc));
                g.DrawLine(ax, ToCanvas(0, 0, o, sc), ToCanvas(0, 550, o, sc));
            }

            using (Font f = new Font("Consolas", 8f))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(80, 90, 110)))
            {
                for (float v = 100; v <= 600; v += 100)
                {
                    PointF px = ToCanvas(v, 0, o, sc);
                    g.DrawString(((int)v).ToString(), f, b, px.X - 12, px.Y + 4);
                    PointF py = ToCanvas(0, v, o, sc);
                    g.DrawString(((int)v).ToString(), f, b, py.X - 30, py.Y - 6);
                }
            }
        }

        private void DrawClipWindow(Graphics g, PointF o, float sc, float xmin, float ymin, float xmax, float ymax)
        {
            PointF tl = ToCanvas(xmin, ymax, o, sc);
            PointF br = ToCanvas(xmax, ymin, o, sc);
            RectangleF rect = new RectangleF(tl.X, tl.Y, br.X - tl.X, br.Y - tl.Y);

            using (SolidBrush fill = new SolidBrush(Color.FromArgb(20, 80, 130, 200)))
                g.FillRectangle(fill, rect);

            using (Pen border = new Pen(Color.FromArgb(80, 130, 210), 1.8f))
            {
                border.DashStyle = DashStyle.Solid;
                g.DrawRectangle(border, rect.X, rect.Y, rect.Width, rect.Height);
            }

            using (Font f = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(100, 150, 230)))
            {
                g.DrawString($"({xmin},{ymax})", f, b, tl.X + 2, tl.Y - 14);
                g.DrawString($"({xmax},{ymin})", f, b, br.X - 60, br.Y + 3);
                g.DrawString("Ventana", f, b, tl.X + 4, tl.Y + 4);
            }
        }

        private void DrawEndpoints(Graphics g, PointF o, float sc, float x1, float y1, float x2, float y2, Color color)
        {
            using (SolidBrush b = new SolidBrush(color))
            {
                PointF p1 = ToCanvas(x1, y1, o, sc);
                PointF p2 = ToCanvas(x2, y2, o, sc);
                g.FillEllipse(b, p1.X - 4, p1.Y - 4, 8, 8);
                g.FillEllipse(b, p2.X - 4, p2.Y - 4, 8, 8);
            }
        }

        private void DrawCoordLabel(Graphics g, PointF o, float sc, float x1, float y1, float x2, float y2)
        {
            using (Font f = new Font("Consolas", 8f))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(180, 90, 90)))
            {
                PointF p1 = ToCanvas(x1, y1, o, sc);
                PointF p2 = ToCanvas(x2, y2, o, sc);
                g.DrawString($"P1({x1:F0},{y1:F0})", f, b, p1.X + 6, p1.Y - 14);
                g.DrawString($"P2({x2:F0},{y2:F0})", f, b, p2.X + 6, p2.Y - 14);
            }
        }

        private void DrawClipLabels(Graphics g, PointF o, float sc, float cx1, float cy1, float cx2, float cy2)
        {
            using (Font f = new Font("Consolas", 8f, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(80, 220, 130)))
            {
                PointF p1 = ToCanvas(cx1, cy1, o, sc);
                PointF p2 = ToCanvas(cx2, cy2, o, sc);
                g.DrawString($"C1({cx1:F1},{cy1:F1})", f, b, p1.X + 6, p1.Y + 4);
                g.DrawString($"C2({cx2:F1},{cy2:F1})", f, b, p2.X + 6, p2.Y + 4);
            }
        }

        private void DrawRejectedLabel(Graphics g, PointF o, float sc,float x1, float y1, float x2, float y2)
        {
            float mx = (x1 + x2) / 2f;
            float my = (y1 + y2) / 2f;
            PointF mid = ToCanvas(mx, my, o, sc);

            using (Font f = new Font("Segoe UI", 10f, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(220, 80, 80)))
            {
                string msg = "RECHAZADA";
                SizeF sz = g.MeasureString(msg, f);
                using (SolidBrush bg = new SolidBrush(Color.FromArgb(160, 20, 20, 30)))
                    g.FillRectangle(bg, mid.X - sz.Width / 2 - 4,
                                       mid.Y - sz.Height / 2 - 2,
                                       sz.Width + 8, sz.Height + 4);
                g.DrawString(msg, f, b, mid.X - sz.Width / 2, mid.Y - sz.Height / 2);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter) RunClip();
            if (e.KeyCode == Keys.Escape) ClearScene();
            if (e.KeyCode == Keys.F5) LoadDemo();
        }
    }
}