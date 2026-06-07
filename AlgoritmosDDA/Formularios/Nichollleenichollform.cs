using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NLNApp
{
    public partial class NichollLeeNichollForm : Form
    {
        private bool _hasLine = false;
        private bool _clipped = false;
        private bool _accepted = false;
        private float _ox1, _oy1, _ox2, _oy2;
        private float _cx1, _cy1, _cx2, _cy2;
        private NLNRegion _region;
        private string _ncase = "";

        public NichollLeeNichollForm()
        {
            InitializeComponent();
            LoadDemo();
        }

        // ── Parsing ──────────────────────────────────────────────────────

        private bool TryParse(out float x1, out float y1, out float x2, out float y2, out float xmin, out float ymin, out float xmax, out float ymax)
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

        // ── Acciones ─────────────────────────────────────────────────────

        private void DrawScene()
        {
            if (!TryParse(out float x1, out float y1, out float x2, out float y2,
                          out float xmin, out float ymin, out float xmax, out float ymax))
            {
                lblStatus.Text = "Error: verifica que todos los campos tengan valores numéricos válidos.";
                return;
            }

            _ox1 = x1; _oy1 = y1; _ox2 = x2; _oy2 = y2;
            _hasLine = true;
            _clipped = false;
            _accepted = false;
            _region = NLNRegion.Inside;
            _ncase = "";

            ResetResultPanel();
            panelCanvas.Invalidate();
            lblStatus.Text = "Línea dibujada. Pulsa 'Recortar' para aplicar Nicholl-Lee-Nicholl.";
            lblRegionStatus.Text = "";
        }

        private void RunClip()
        {
            if (!TryParse(out float x1, out float y1, out float x2, out float y2,
                          out float xmin, out float ymin, out float xmax, out float ymax))
            {
                lblStatus.Text = "Error: revisa los valores ingresados.";
                return;
            }

            _ox1 = x1; _oy1 = y1; _ox2 = x2; _oy2 = y2;
            _hasLine = true;

            _cx1 = x1; _cy1 = y1; _cx2 = x2; _cy2 = y2;

            _accepted = NichollLeeNicholl.ClipLine(
                ref _cx1, ref _cy1, ref _cx2, ref _cy2,
                xmin, ymin, xmax, ymax,
                out _region, out _ncase);

            _clipped = true;
            UpdateResultPanel();
            panelCanvas.Invalidate();

            lblStatus.Text = _accepted
                ? $"ACEPTADA — ({_cx1:F1},{_cy1:F1}) → ({_cx2:F1},{_cy2:F1})"
                : "RECHAZADA — La línea queda completamente fuera de la ventana.";
            lblRegionStatus.Text = $"Región P1: {_region}";
        }

        private void LoadDemo()
        {
            txtX1.Text = "60"; txtY1.Text = "310";
            txtX2.Text = "530"; txtY2.Text = "85";
            txtXmin.Text = "130"; txtYmin.Text = "100";
            txtXmax.Text = "430"; txtYmax.Text = "310";

            _ox1 = 60; _oy1 = 310; _ox2 = 530; _oy2 = 85;
            _hasLine = true; _clipped = false; _accepted = false;
            _region = NLNRegion.Inside; _ncase = "";

            ResetResultPanel();
            panelCanvas.Invalidate();
            lblStatus.Text = "Demo cargado. Pulsa 'Recortar' para ejecutar el algoritmo NLN.";
            lblRegionStatus.Text = "";
        }

        private void ClearScene()
        {
            txtX1.Text = txtY1.Text = txtX2.Text = txtY2.Text = "";
            txtXmin.Text = txtYmin.Text = txtXmax.Text = txtYmax.Text = "";
            _hasLine = false; _clipped = false; _accepted = false;
            _ncase = "";

            ResetResultPanel();
            panelCanvas.Invalidate();
            lblStatus.Text = "Canvas limpiado.";
            lblRegionStatus.Text = "";
        }

        // ── Panel de resultado ───────────────────────────────────────────

        private void ResetResultPanel()
        {
            lblRegionValue.Text = "—";
            lblRegionValue.ForeColor = Color.FromArgb(130, 200, 255);
            lblCaseValue.Text = "—";
            lblResultState.Text = "—";
            lblResultState.ForeColor = Color.FromArgb(160, 162, 195);
            lblResultP1.Text = "";
            lblResultP2.Text = "";
        }

        private void UpdateResultPanel()
        {
            lblRegionValue.Text = _region.ToString();

            lblCaseValue.Text = string.IsNullOrEmpty(_ncase) ? "—" : _ncase;

            if (_accepted)
            {
                lblResultState.Text = "ACEPTADA";
                lblResultState.ForeColor = Color.FromArgb(95, 215, 130);
                lblResultP1.Text = $"P1: ({_cx1:F2}, {_cy1:F2})";
                lblResultP2.Text = $"P2: ({_cx2:F2}, {_cy2:F2})";
            }
            else
            {
                lblResultState.Text = "RECHAZADA";
                lblResultState.ForeColor = Color.FromArgb(255, 95, 95);
                lblResultP1.Text = "Fuera de ventana";
                lblResultP2.Text = "";
            }
        }

        // ── Paint ────────────────────────────────────────────────────────

        private void OnCanvasPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            DrawBackground(g);

            if (!TryParse(out float x1, out float y1, out float x2, out float y2,
                          out float xmin, out float ymin, out float xmax, out float ymax))
                return;

            PointF origin = GetOrigin();
            float scale = GetScale();

            DrawGrid(g, origin, scale);
            DrawAxes(g, origin, scale);
            DrawClipWindow(g, origin, scale, xmin, ymin, xmax, ymax);

            if (_hasLine)
            {
                DrawOriginalLine(g, origin, scale);

                if (_clipped && _accepted)
                    DrawClippedLine(g, origin, scale);
                else if (_clipped && !_accepted)
                    DrawRejectedLabel(g, origin, scale);
            }
        }

        // ── Canvas drawing helpers ───────────────────────────────────────

        private PointF GetOrigin() => new PointF(panelCanvas.Width * 0.07f, panelCanvas.Height * 0.92f);

        private float GetScale() => Math.Min(panelCanvas.Width, panelCanvas.Height) / 660f;

        private PointF W2C(float wx, float wy, PointF o, float sc)
            => new PointF(o.X + wx * sc, o.Y - wy * sc);

        private void DrawBackground(Graphics g)
        {
            g.Clear(Color.FromArgb(22, 22, 32));
            using (var b = new SolidBrush(Color.FromArgb(36, 36, 52)))
                for (int x = 0; x < panelCanvas.Width; x += 30)
                    for (int y = 0; y < panelCanvas.Height; y += 30)
                        g.FillEllipse(b, x - 1, y - 1, 2, 2);
        }

        private void DrawGrid(Graphics g, PointF o, float sc)
        {
            using (var p = new Pen(Color.FromArgb(38, 75, 75, 105), 1f))
            {
                p.DashStyle = DashStyle.Dot;
                for (float v = 0; v <= 650; v += 50)
                {
                    g.DrawLine(p, W2C(v, 0, o, sc), W2C(v, 650, o, sc));
                    g.DrawLine(p, W2C(0, v, o, sc), W2C(650, v, o, sc));
                }
            }
        }

        private void DrawAxes(Graphics g, PointF o, float sc)
        {
            using (var p = new Pen(Color.FromArgb(65, 75, 90, 115), 1.2f))
            {
                g.DrawLine(p, W2C(0, 0, o, sc), W2C(620, 0, o, sc));
                g.DrawLine(p, W2C(0, 0, o, sc), W2C(0, 540, o, sc));
            }
            using (var f = new Font("Consolas", 7.5f))
            using (var b = new SolidBrush(Color.FromArgb(72, 82, 105)))
                for (float v = 100; v <= 600; v += 100)
                {
                    var px = W2C(v, 0, o, sc); g.DrawString(((int)v).ToString(), f, b, px.X - 12, px.Y + 4);
                    var py = W2C(0, v, o, sc); g.DrawString(((int)v).ToString(), f, b, py.X - 30, py.Y - 6);
                }
        }

        private void DrawClipWindow(Graphics g, PointF o, float sc,
                                    float xmin, float ymin, float xmax, float ymax)
        {
            PointF tl = W2C(xmin, ymax, o, sc);
            PointF br = W2C(xmax, ymin, o, sc);
            var rect = new RectangleF(tl.X, tl.Y, br.X - tl.X, br.Y - tl.Y);

            using (var fill = new SolidBrush(Color.FromArgb(18, 75, 125, 200)))
                g.FillRectangle(fill, rect);

            using (var border = new Pen(Color.FromArgb(80, 135, 220), 1.8f))
                g.DrawRectangle(border, rect.X, rect.Y, rect.Width, rect.Height);

            using (var f = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(100, 155, 235)))
            {
                g.DrawString($"({xmin},{ymax})", f, b, tl.X + 2, tl.Y - 14);
                g.DrawString($"({xmax},{ymin})", f, b, br.X - 64, br.Y + 3);
                g.DrawString("Ventana", f, b, tl.X + 4, tl.Y + 4);
            }
        }

        private void DrawOriginalLine(Graphics g, PointF o, float sc)
        {
            using (var p = new Pen(Color.FromArgb(215, 65, 65), 1.8f))
            {
                p.DashStyle = DashStyle.Dash;
                g.DrawLine(p, W2C(_ox1, _oy1, o, sc), W2C(_ox2, _oy2, o, sc));
            }
            DrawDot(g, W2C(_ox1, _oy1, o, sc), Color.FromArgb(225, 80, 80));
            DrawDot(g, W2C(_ox2, _oy2, o, sc), Color.FromArgb(225, 80, 80));

            using (var f = new Font("Consolas", 7.5f))
            using (var b = new SolidBrush(Color.FromArgb(190, 90, 90)))
            {
                g.DrawString($"P1({_ox1:F0},{_oy1:F0})", f, b, W2C(_ox1, _oy1, o, sc).X + 6, W2C(_ox1, _oy1, o, sc).Y - 14);
                g.DrawString($"P2({_ox2:F0},{_oy2:F0})", f, b, W2C(_ox2, _oy2, o, sc).X + 6, W2C(_ox2, _oy2, o, sc).Y - 14);
            }
        }

        private void DrawClippedLine(Graphics g, PointF o, float sc)
        {
            using (var p = new Pen(Color.FromArgb(80, 218, 130), 2.6f))
                g.DrawLine(p, W2C(_cx1, _cy1, o, sc), W2C(_cx2, _cy2, o, sc));

            DrawDot(g, W2C(_cx1, _cy1, o, sc), Color.FromArgb(80, 220, 130), 5);
            DrawDot(g, W2C(_cx2, _cy2, o, sc), Color.FromArgb(80, 220, 130), 5);

            using (var f = new Font("Consolas", 7.5f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(80, 215, 130)))
            {
                var p1c = W2C(_cx1, _cy1, o, sc);
                var p2c = W2C(_cx2, _cy2, o, sc);
                g.DrawString($"C1({_cx1:F1},{_cy1:F1})", f, b, p1c.X + 6, p1c.Y + 5);
                g.DrawString($"C2({_cx2:F1},{_cy2:F1})", f, b, p2c.X + 6, p2c.Y + 5);
            }
        }

        private void DrawRejectedLabel(Graphics g, PointF o, float sc)
        {
            float mx = (_ox1 + _ox2) / 2f, my = (_oy1 + _oy2) / 2f;
            PointF mid = W2C(mx, my, o, sc);
            const string msg = "RECHAZADA";

            using (var f = new Font("Segoe UI", 10f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(225, 80, 80)))
            {
                SizeF sz = g.MeasureString(msg, f);
                using (var bg = new SolidBrush(Color.FromArgb(170, 18, 18, 28)))
                    g.FillRectangle(bg, mid.X - sz.Width / 2 - 4, mid.Y - sz.Height / 2 - 2,
                                        sz.Width + 8, sz.Height + 4);
                g.DrawString(msg, f, b, mid.X - sz.Width / 2, mid.Y - sz.Height / 2);
            }
        }

        private void DrawDot(Graphics g, PointF p, Color c, int r = 4)
        {
            using (var b = new SolidBrush(c))
                g.FillEllipse(b, p.X - r, p.Y - r, r * 2, r * 2);
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