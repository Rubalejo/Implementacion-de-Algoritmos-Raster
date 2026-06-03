using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosDDA
{
    public partial class FrmCirculoBase : Form
    {
        private const int ESCALA = 28;
        private List<Point> puntos = new List<Point>();
        private int centroX = 0;
        private int centroY = 0;
        private int radio = 0;

        public FrmCirculoBase()
        {
            InitializeComponent();
            panelDibujo.Paint += panelDibujo_Paint;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dgvPasos.Rows.Clear();
            if (!int.TryParse(txtXC.Text, out centroX) || !int.TryParse(txtYC.Text, out centroY) || !int.TryParse(txtRadio.Text, out radio))
            {
                MessageBox.Show("Ingrese datos válidos");
                return;
            }
            Circulo circulo = new Circulo();
            puntos = circulo.ObtenerPuntosCompletos(centroX, centroY, radio);
            List<PasoCirculo> pasos = circulo.CalcularCirculo(centroX, centroY, radio);
            foreach (var p in pasos)
            {
                dgvPasos.Rows.Add(p.Paso, p.P, $"({p.Punto.X}, {p.Punto.Y})", $"({p.Simetria.X}, {p.Simetria.Y})");
            }
            lblCentro.Text = $"Centro: ({centroX}, {centroY})";
            lblRadioInfo.Text = $"Radio r: {radio}";
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtXC.Clear(); txtYC.Clear(); txtRadio.Clear();
            dgvPasos.Rows.Clear(); puntos.Clear();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int ancho = panelDibujo.Width; int alto = panelDibujo.Height;
            int origenX = ancho / 2; int origenY = alto / 2;
            g.Clear(Color.White);

            using (Pen penGrid = new Pen(Color.LightGray))
            {
                for (int x = 0; x < ancho; x += ESCALA) g.DrawLine(penGrid, x, 0, x, alto);
                for (int y = 0; y < alto; y += ESCALA) g.DrawLine(penGrid, 0, y, ancho, y);
            }
            using (Pen penEje = new Pen(Color.Black, 2))
            {
                g.DrawLine(penEje, origenX, 0, origenX, alto);
                g.DrawLine(penEje, 0, origenY, ancho, origenY);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(170, 140, 70, 220)))
            {
                foreach (Point p in puntos)
                {
                    g.FillRectangle(brush, origenX + (p.X * ESCALA) - (ESCALA / 2f), origenY - (p.Y * ESCALA) - (ESCALA / 2f), ESCALA, ESCALA);
                }
            }

            using (Pen penCirculo = new Pen(Color.Red, 2))
            {
                float radioPx = radio * ESCALA;
                float cX = origenX + (centroX * ESCALA);
                float cY = origenY - (centroY * ESCALA);
                g.DrawEllipse(penCirculo, cX - radioPx, cY - radioPx, radioPx * 2, radioPx * 2);
            }

            float cx = origenX + (centroX * ESCALA);
            float cy = origenY - (centroY * ESCALA);
            g.FillEllipse(Brushes.Red, cx - 4, cy - 4, 8, 8);
            g.DrawString($"C({centroX},{centroY})", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, cx + 10, cy + 10);
        }
    }
}