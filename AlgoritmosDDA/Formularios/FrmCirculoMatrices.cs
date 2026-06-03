using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AlgoritmosDDA
{
    public partial class MetodoCirculoMatrices : Form
    {
        private const int TAMANO_PIXEL = 20;

        private List<Point> puntosCirculo = new List<Point>();
        private int xc = 0;
        private int yc = 0;
        private int radio = 0;

        public MetodoCirculoMatrices()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);

            panelDibujo.Paint += panelDibujo_Paint;
        }

        private void DibujarPlano(Graphics g)
        {
            int ancho = panelDibujo.Width;
            int alto = panelDibujo.Height;

            int origenX = ancho / 2;
            int origenY = alto / 2;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            using (Pen penGrid = new Pen(Color.Gainsboro, 1))
            {
                for (int x = origenX; x < ancho; x += TAMANO_PIXEL)
                    g.DrawLine(penGrid, x, 0, x, alto);

                for (int x = origenX; x > 0; x -= TAMANO_PIXEL)
                    g.DrawLine(penGrid, x, 0, x, alto);

                for (int y = origenY; y < alto; y += TAMANO_PIXEL)
                    g.DrawLine(penGrid, 0, y, ancho, y);

                for (int y = origenY; y > 0; y -= TAMANO_PIXEL)
                    g.DrawLine(penGrid, 0, y, ancho, y);
            }

            using (Pen penAxis = new Pen(Color.Black, 2))
            {
                g.DrawLine(penAxis, 0, origenY, ancho, origenY);
                g.DrawLine(penAxis, origenX, 0, origenX, alto);
            }

            using (Font font = new Font("Segoe UI", 7))
            {
                Brush brush = Brushes.Gray;

                int valorX = -origenX / TAMANO_PIXEL;

                for (int x = 0; x < ancho; x += TAMANO_PIXEL)
                {
                    if (valorX != 0)
                        g.DrawString(valorX.ToString(), font, brush, x + 2, origenY + 2);

                    valorX++;
                }

                int valorY = origenY / TAMANO_PIXEL;

                for (int y = 0; y < alto; y += TAMANO_PIXEL)
                {
                    if (valorY != 0)
                        g.DrawString(valorY.ToString(), font, brush, origenX + 2, y + 2);

                    valorY--;
                }
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DibujarPlano(g);

            if (puntosCirculo.Count == 0)
                return;

            int origenX = panelDibujo.Width / 2;
            int origenY = panelDibujo.Height / 2;

            using (SolidBrush brushPixel =
                new SolidBrush(Color.FromArgb(180, 147, 112, 219)))
            {
                foreach (Point p in puntosCirculo)
                {
                    int pixelX = origenX + (p.X * TAMANO_PIXEL);
                    int pixelY = origenY - (p.Y * TAMANO_PIXEL);

                    int esquinaX = pixelX - (TAMANO_PIXEL / 2);
                    int esquinaY = pixelY - (TAMANO_PIXEL / 2);

                    g.FillRectangle(
                        brushPixel, esquinaX,esquinaY, TAMANO_PIXEL, TAMANO_PIXEL);
                }
            }

            using (Pen penCircle = new Pen(Color.Blue, 2))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;

                float centroXPantalla = origenX + (xc * TAMANO_PIXEL);
                float centroYPantalla = origenY - (yc * TAMANO_PIXEL);

                float radioPixeles = radio * TAMANO_PIXEL;

                g.DrawEllipse(
                    penCircle,
                    centroXPantalla - radioPixeles,
                    centroYPantalla - radioPixeles,
                    radioPixeles * 2,
                    radioPixeles * 2);
            }

            float centroX = origenX + (xc * TAMANO_PIXEL);
            float centroY = origenY - (yc * TAMANO_PIXEL);

            g.FillEllipse(Brushes.Red, centroX - 5, centroY - 5, 10, 10);

            g.DrawString(
                $"C({xc},{yc})",
                new Font("Segoe UI", 9, FontStyle.Bold),
                Brushes.Black,
                centroX + 8,
                centroY + 5);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtXC.Text, out xc) ||
                !int.TryParse(txtYC.Text, out yc) ||
                !int.TryParse(txtRadio.Text, out radio))
            {
                MessageBox.Show(
                    "Ingrese valores válidos.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            if (radio <= 0)
            {
                MessageBox.Show(
                    "El radio debe ser mayor a 0.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            lstPixeles.Items.Clear();

            CalculadorCirculoMatrices calculador = new CalculadorCirculoMatrices();

            puntosCirculo = calculador.CalcularCirculoMatrices(xc, yc, radio);

            foreach (Point p in puntosCirculo)
            {
                lstPixeles.Items.Add($"({p.X}, {p.Y})");
            }

            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtXC.Text = "0";
            txtYC.Text = "0";
            txtRadio.Text = "5";

            puntosCirculo.Clear();

            lstPixeles.Items.Clear();

            panelDibujo.Invalidate();
        }
    }
}