using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosDDA.Clases;

namespace AlgoritmosDDA.Formularios
{
    public partial class FrmBezier : Form
    {
        private BezierCuadratico algoritmoBezier;
        private bool listoParaDibujar = false;
        private const int ESCALA = 20;

        public FrmBezier()
        {
            InitializeComponent();
            // Activación del búfer doble para evitar parpadeos molestos al redibujar el panel
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPasos.Rows.Clear();

                string[] p0Txt = txtP0.Text.Split(',');
                string[] p2Txt = txtP2.Text.Split(',');

                Point p0 = new Point(int.Parse(p0Txt[0].Trim()), int.Parse(p0Txt[1].Trim()));
                Point p2 = new Point(int.Parse(p2Txt[0].Trim()), int.Parse(p2Txt[1].Trim()));

                int medioX = (p0.X + p2.X) / 2;
                int medioY = (p0.Y + p2.Y) / 2;
                Point p1 = new Point(medioX, medioY);

                // Inicializamos la estructura de Bézier con nuestro punto de control calculado de forma invisible
                algoritmoBezier = new BezierCuadratico(p0, p1, p2);

                List<PasoBezier> pasos = algoritmoBezier.CalcularPasos();
                foreach (var p in pasos)
                {
                    dgvPasos.Rows.Add(p.Paso, p.T.ToString("0.00"), $"({p.X}, {p.Y})", $"({p.PuntoDiscreto.X}, {p.PuntoDiscreto.Y})");
                }

                listoParaDibujar = true;
                panelLienzo.Invalidate(); // Fuerza al panel a ejecutar el evento Paint
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresa las coordenadas en formato 'X,Y' (ej: -4,5).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelLienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int altoPanel = panelLienzo.Height;
            int anchoPanel = panelLienzo.Width;
            int origenX = anchoPanel / 2;
            int origenY = altoPanel / 2;

            Pen penCuadricula = new Pen(Color.LightGray, 1);
            Font fontEjes = new Font("Arial", 8);
            Brush brushTexto = Brushes.Gray;

            // Dibujo de la rejilla cartesiana adaptada al centro del panel
            for (int x = origenX; x < anchoPanel; x += ESCALA) g.DrawLine(penCuadricula, x, 0, x, altoPanel);
            for (int x = origenX - ESCALA; x > 0; x -= ESCALA) g.DrawLine(penCuadricula, x, 0, x, altoPanel);
            for (int y = origenY; y > 0; y -= ESCALA) g.DrawLine(penCuadricula, 0, y, anchoPanel, y);
            for (int y = origenY + ESCALA; y < altoPanel; y += ESCALA) g.DrawLine(penCuadricula, 0, y, anchoPanel, y);

            // Ejes centrales principales
            Pen penEjes = new Pen(Color.Black, 2);
            g.DrawLine(penEjes, origenX, 0, origenX, altoPanel);
            g.DrawLine(penEjes, 0, origenY, anchoPanel, origenY);

            if (!listoParaDibujar || algoritmoBezier == null) return;

            List<PasoBezier> pasosGrafico = algoritmoBezier.CalcularPasos();
            Brush brushCelda = new SolidBrush(Color.FromArgb(160, 46, 139, 87)); 

            foreach (var paso in pasosGrafico)
            {
                int fisicoX = origenX + (paso.X * ESCALA);
                int fisicoY = origenY - (paso.Y * ESCALA) - ESCALA; 
                g.FillRectangle(brushCelda, fisicoX, fisicoY, ESCALA, ESCALA);
            }

            List<PointF> centrosCurva = new List<PointF>();
            foreach (var paso in pasosGrafico)
            {
                float cx = origenX + (paso.X * ESCALA) + (ESCALA / 2f);
                float cy = origenY - (paso.Y * ESCALA) - (ESCALA / 2f);
                centrosCurva.Add(new PointF(cx, cy));
            }

            if (centrosCurva.Count > 1)
            {
                Pen penCurva = new Pen(Color.DarkGreen, 2f);
                g.DrawLines(penCurva, centrosCurva.ToArray());
            }

            float p0X = origenX + (algoritmoBezier.P0.X * ESCALA) + (ESCALA / 2f);
            float p0Y = origenY - (algoritmoBezier.P0.Y * ESCALA) - (ESCALA / 2f);
            float p2X = origenX + (algoritmoBezier.P2.X * ESCALA) + (ESCALA / 2f);
            float p2Y = origenY - (algoritmoBezier.P2.Y * ESCALA) - (ESCALA / 2f);

            g.FillEllipse(Brushes.Red, p0X - 4, p0Y - 4, 8, 8);
            g.FillEllipse(Brushes.Red, p2X - 4, p2Y - 4, 8, 8);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtP0.Clear();
            txtP2.Clear();
            dgvPasos.Rows.Clear();
            listoParaDibujar = false;
            algoritmoBezier = null;
            panelLienzo.Invalidate();
        }
    }
}