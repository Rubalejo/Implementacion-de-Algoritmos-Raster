using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosDDA.Clases; 

namespace AlgoritmosDDA.Formularios
{
    public partial class FrmPuntoMedio : Form
    {
        private PuntoMedioRecta algoritmoPM;
        private bool listoParaDibujar = false;
        private const int ESCALA = 20;

        public FrmPuntoMedio()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPasos.Rows.Clear();

                string[] p1Texto = txtP1.Text.Split(',');
                string[] p2Texto = txtP2.Text.Split(',');

                Point p1 = new Point(int.Parse(p1Texto[0].Trim()), int.Parse(p1Texto[1].Trim()));
                Point p2 = new Point(int.Parse(p2Texto[0].Trim()), int.Parse(p2Texto[1].Trim()));

                algoritmoPM = new PuntoMedioRecta(p1, p2);

                int dx = Math.Abs(p2.X - p1.X);
                int dy = Math.Abs(p2.Y - p1.Y);
                lblDX.Text = $"Δx: {dx}";
                lblDY.Text = $"Δy: {dy}";
                lblEcuacion.Text = $"Ecuación: {2 * dy}X - {2 * dx}Y + C = 0";

                List<PasoRecta> pasos = algoritmoPM.CalcularPasos();
                foreach (var p in pasos)
                {
                    dgvPasos.Rows.Add(p.Paso, p.D, $"({p.X}, {p.Y})", $"({p.Punto.X}, {p.Punto.Y})");
                }

                listoParaDibujar = true;
                panelLienzo.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresa los puntos en formato 'X,Y' (ej: 1,2).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Rejilla e Indices de los Ejes
            int valorEjeX = 0;
            for (int x = origenX; x < anchoPanel; x += ESCALA)
            {
                g.DrawLine(penCuadricula, x, 0, x, altoPanel);
                if (valorEjeX != 0) g.DrawString(valorEjeX.ToString(), fontEjes, brushTexto, x - 5, origenY + 5);
                valorEjeX++;
            }
            valorEjeX = -1;
            for (int x = origenX - ESCALA; x > 0; x -= ESCALA)
            {
                g.DrawLine(penCuadricula, x, 0, x, altoPanel);
                g.DrawString(valorEjeX.ToString(), fontEjes, brushTexto, x - 8, origenY + 5);
                valorEjeX--;
            }

            int valorEjeY = 0;
            for (int y = origenY; y > 0; y -= ESCALA)
            {
                g.DrawLine(penCuadricula, 0, y, anchoPanel, y);
                if (valorEjeY != 0) g.DrawString(valorEjeY.ToString(), fontEjes, brushTexto, origenX - 18, y - 6);
                valorEjeY++;
            }
            valorEjeY = -1;
            for (int y = origenY + ESCALA; y < altoPanel; y += ESCALA)
            {
                g.DrawLine(penCuadricula, 0, y, anchoPanel, y);
                g.DrawString(valorEjeY.ToString(), fontEjes, brushTexto, origenX - 22, y - 6);
                valorEjeY--;
            }

            Pen penEjes = new Pen(Color.Black, 2);
            g.DrawLine(penEjes, origenX, 0, origenX, altoPanel);
            g.DrawLine(penEjes, 0, origenY, anchoPanel, origenY);

            if (!listoParaDibujar || algoritmoPM == null) return;

            // 1. Colorear todos los cuadros por donde pasa la línea (FillRectangle)
            List<PasoRecta> pasosGrafico = algoritmoPM.CalcularPasos();
            Brush brushCelda = new SolidBrush(Color.FromArgb(160, 147, 112, 219)); 

            foreach (var paso in pasosGrafico)
            {
                int fisicoX = origenX + (paso.X * ESCALA);
                int fisicoY = origenY - (paso.Y * ESCALA) - ESCALA; 
                g.FillRectangle(brushCelda, fisicoX, fisicoY, ESCALA, ESCALA);
            }
                      
            Pen penLinea = new Pen(Color.Blue, 2);
            float p1FisicoX = origenX + (algoritmoPM.P1.X * ESCALA) + (ESCALA / 2f);
            float p1FisicoY = origenY - (algoritmoPM.P1.Y * ESCALA) - (ESCALA / 2f);
            float p2FisicoX = origenX + (algoritmoPM.P2.X * ESCALA) + (ESCALA / 2f);
            float p2FisicoY = origenY - (algoritmoPM.P2.Y * ESCALA) - (ESCALA / 2f);
            g.DrawLine(penLinea, p1FisicoX, p1FisicoY, p2FisicoX, p2FisicoY);
                        
            g.FillEllipse(Brushes.Red, p1FisicoX - 4, p1FisicoY - 4, 8, 8);
            g.FillEllipse(Brushes.Red, p2FisicoX - 4, p2FisicoY - 4, 8, 8);
            g.DrawString($"P1 ({algoritmoPM.P1.X},{algoritmoPM.P1.Y})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, p1FisicoX + 6, p1FisicoY - 6);
            g.DrawString($"P2 ({algoritmoPM.P2.X},{algoritmoPM.P2.Y})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, p2FisicoX + 6, p2FisicoY - 6);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtP1.Clear();
            txtP2.Clear();
            lblDX.Text = "Δx:";
            lblDY.Text = "Δy:";
            lblEcuacion.Text = "Ecuación:";
            dgvPasos.Rows.Clear();
            listoParaDibujar = false;
            algoritmoPM = null;
            panelLienzo.Invalidate();
        }
    }
}