using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AlgoritmosDDA
{
    public partial class FrmPolares : Form
    {
        private const int TAMANO_PIXEL = 20;

        private List<Point> puntosCirculo =
            new List<Point>();

        private bool dibujar = false;

        public FrmPolares()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            panelDibujo.Paint += panelDibujo_Paint;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (
                !int.TryParse(txtXC.Text, out int xc) ||
                !int.TryParse(txtYC.Text, out int yc) ||
                !int.TryParse(txtRadio.Text, out int radio)
            )
            {
                MessageBox.Show(
                    "Ingrese valores válidos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            CalculadorCirculoPolares calculador = new CalculadorCirculoPolares();

            puntosCirculo = calculador.CalcularCirculoPolares(
                    xc, yc, radio
                );

            lstPixeles.Items.Clear();

            foreach (Point p in puntosCirculo)
            {
                lstPixeles.Items.Add(
                    $"({p.X}, {p.Y})"
                );
            }

            dibujar = true;

            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtXC.Clear();
            txtYC.Clear();
            txtRadio.Clear();

            lstPixeles.Items.Clear();

            puntosCirculo.Clear();

            dibujar = false;

            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(
            object sender,
            PaintEventArgs e
        )
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.None;

            int origenX = panelDibujo.Width / 2;

            int origenY = panelDibujo.Height / 2;

            DibujarPlanoCartesiano(
                g, origenX,origenY
            );

            if (!dibujar)
            {
                return;
            }

            Brush brushPixel =
                new SolidBrush(Color.FromArgb(180,138,43,226));

            foreach (Point p in puntosCirculo)
            {
                int x = origenX + (p.X * TAMANO_PIXEL);

                int y = origenY - (p.Y * TAMANO_PIXEL);

                Rectangle rect = new Rectangle(x,y - TAMANO_PIXEL,TAMANO_PIXEL,TAMANO_PIXEL);

                g.FillRectangle(
                    brushPixel,
                    rect
                );

                g.DrawRectangle(
                    Pens.White,
                    rect
                );

                int centroX =
                    rect.X +
                    (TAMANO_PIXEL / 2);

                int centroY =
                    rect.Y +
                    (TAMANO_PIXEL / 2);

                g.FillEllipse(
                    Brushes.Black,
                    centroX - 2,
                    centroY - 2,
                    4,
                    4
                );
            }
        }

        private void DibujarPlanoCartesiano(
            Graphics g,
            int origenX,
            int origenY
        )
        {
            Pen penGrid =
                new Pen(
                    Color.Gainsboro,
                    1
                );

            // Líneas verticales derecha
            for (
                int x = origenX;
                x <= panelDibujo.Width;
                x += TAMANO_PIXEL
            )
            {
                g.DrawLine(
                    penGrid,
                    x,
                    0,
                    x,
                    panelDibujo.Height
                );
            }

            // Líneas verticales izquierda
            for (
                int x = origenX;
                x >= 0;
                x -= TAMANO_PIXEL
            )
            {
                g.DrawLine(
                    penGrid,
                    x,
                    0,
                    x,
                    panelDibujo.Height
                );
            }

            // Líneas horizontales abajo
            for (
                int y = origenY;
                y <= panelDibujo.Height;
                y += TAMANO_PIXEL
            )
            {
                g.DrawLine(
                    penGrid,
                    0,
                    y,
                    panelDibujo.Width,
                    y
                );
            }

            // Líneas horizontales arriba
            for (
                int y = origenY;
                y >= 0;
                y -= TAMANO_PIXEL
            )
            {
                g.DrawLine(
                    penGrid,
                    0,
                    y,
                    panelDibujo.Width,
                    y
                );
            }

            // Ejes principales
            Pen penEjes =
                new Pen(
                    Color.Black,
                    2
                );

            g.DrawLine(
                penEjes,
                origenX,
                0,
                origenX,
                panelDibujo.Height
            );

            g.DrawLine(
                penEjes,
                0,
                origenY,
                panelDibujo.Width,
                origenY
            );

            // Numeración eje X
            Font fuente =
                new Font(
                    "Segoe UI",
                    8
                );

            for (
                int x = origenX, valor = 0;
                x <= panelDibujo.Width;
                x += TAMANO_PIXEL, valor++
            )
            {
                g.DrawString(
                    valor.ToString(),
                    fuente,
                    Brushes.Black,
                    x + 2,
                    origenY + 2
                );
            }

            for (
                int x = origenX - TAMANO_PIXEL, valor = -1;
                x >= 0;
                x -= TAMANO_PIXEL, valor--
            )
            {
                g.DrawString(
                    valor.ToString(),
                    fuente,
                    Brushes.Black,
                    x + 2,
                    origenY + 2
                );
            }

            // Numeración eje Y
            for (
                int y = origenY - TAMANO_PIXEL, valor = 1;
                y >= 0;
                y -= TAMANO_PIXEL, valor++
            )
            {
                g.DrawString(
                    valor.ToString(),
                    fuente,
                    Brushes.Black,
                    origenX + 2,
                    y + 2
                );
            }

            for (
                int y = origenY + TAMANO_PIXEL, valor = -1;
                y <= panelDibujo.Height;
                y += TAMANO_PIXEL, valor--
            )
            {
                g.DrawString(
                    valor.ToString(),
                    fuente,
                    Brushes.Black,
                    origenX + 2,
                    y + 2
                );
            }
        }
    }
}