using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosDDA
{
    public partial class AlgoritmoDDA1 : Form
    {
        private Point punto1;
        private Point punto2;
        private bool listoParaDibujar = false;

        private const int ESCALA = 20;
        private const int MARGEN_X = 40;
        private const int MARGEN_Y = 40;

        public AlgoritmoDDA1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxPuntos.Items.Clear();

                string[] p1Texto = textBox1.Text.Split(',');
                string[] p2Texto = textBox2.Text.Split(',');

                int x1 = int.Parse(p1Texto[0].Trim());
                int y1 = int.Parse(p1Texto[1].Trim());
                int x2 = int.Parse(p2Texto[0].Trim());
                int y2 = int.Parse(p2Texto[1].Trim());

                punto1 = new Point(x1, y1);
                punto2 = new Point(x2, y2);

                double dx = x2 - x1;
                double dy = y2 - y1;
                double m = (dx != 0) ? dy / dx : dy;

                label6.Text = $"△x: {dx}";
                label7.Text = $"△y: {dy}";
                label8.Text = $"m = {Math.Round(m, 2)}";

                // --- GENERACIÓN DE PUNTOS ANALÍTICOS (TABLA DE SEGUIMIENTO) ---
                double steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                double xIncrement = dx / steps;
                double yIncrement = dy / steps;

                double currentX = x1;
                double currentY = y1;

                // Encabezados estéticos para el ListBox
                listBoxPuntos.Items.Add("Paso\tX\tY\tPunto");
                listBoxPuntos.Items.Add("-----------------------------------------------------");

                for (int i = 0; i <= steps; i++)
                {
                    // Redondeo estándar de coordenadas discretas
                    int xRedondeado = (int)Math.Round(currentX);
                    int yRedondeado = (int)Math.Round(currentY);

                    // Agregar fila formateada al ListBox
                    listBoxPuntos.Items.Add($"{i}\t{currentX:F2}\t{currentY:F2}\t({xRedondeado},{yRedondeado})");

                    currentX += xIncrement;
                    currentY += yIncrement;
                }

                listoParaDibujar = true;
                panel1.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Asegúrate de ingresar las coordenadas en formato 'X,Y' (ej. 2,3 y 7,12).",
                                "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int altoPanel = panel1.Height;
            int anchoPanel = panel1.Width;

            int origenX = MARGEN_X;
            int origenY = altoPanel - MARGEN_Y;

            // --- 1. DIBUJAR LA CUADRÍCULA Y LAS ETIQUETAS ---
            Pen penCuadricula = new Pen(Color.LightGray, 1);
            Font fontEjes = new Font("Arial", 8);
            Brush brushTexto = Brushes.Gray;

            int valorEjeX = 0;
            for (int x = origenX; x < anchoPanel; x += ESCALA)
            {
                g.DrawLine(penCuadricula, x, 0, x, origenY);
                g.DrawString(valorEjeX.ToString(), fontEjes, brushTexto, x - 5, origenY + 5);
                valorEjeX++;
            }

            int valorEjeY = 0;
            for (int y = origenY; y > 0; y -= ESCALA)
            {
                g.DrawLine(penCuadricula, origenX, y, anchoPanel, y);
                g.DrawString(valorEjeY.ToString(), fontEjes, brushTexto, origenX - 25, y - 6);
                valorEjeY++;
            }

            Pen penEjes = new Pen(Color.Black, 2);
            g.DrawLine(penEjes, origenX, 0, origenX, origenY);
            g.DrawLine(penEjes, origenX, origenY, anchoPanel, origenY);


            // --- 2. TRAZADO DE LA LÍNEA RECTA CONTINUA (ALGORITMO DDA) ---
            if (!listoParaDibujar) return;

            double dx = punto2.X - punto1.X;
            double dy = punto2.Y - punto1.Y;
            double steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            double xIncrement = dx / steps;
            double yIncrement = dy / steps;

            double currentX = punto1.X;
            double currentY = punto1.Y;

            Pen penLineaDDA = new Pen(Color.RoyalBlue, 2f);

            float antFisicoX = (float)(origenX + (currentX * ESCALA));
            float antFisicoY = (float)(origenY - (currentY * ESCALA));

            for (int i = 0; i < steps; i++)
            {
                currentX += xIncrement;
                currentY += yIncrement;

                float sigFisicoX = (float)(origenX + (currentX * ESCALA));
                float sigFisicoY = (float)(origenY - (currentY * ESCALA));

                g.DrawLine(penLineaDDA, antFisicoX, antFisicoY, sigFisicoX, sigFisicoY);

                antFisicoX = sigFisicoX;
                antFisicoY = sigFisicoY;
            }

            // --- 3. DIBUJAR PUNTOS DE CONTROL (EXTREMOS) Y TEXTOS ---
            Brush brushPuntos = Brushes.Red;
            Font fontRotulos = new Font("Arial", 9, FontStyle.Bold);

            float p1FisicoX = origenX + (punto1.X * ESCALA);
            float p1FisicoY = origenY - (punto1.Y * ESCALA);
            float p2FisicoX = origenX + (punto2.X * ESCALA);
            float p2FisicoY = origenY - (punto2.Y * ESCALA);

            g.FillEllipse(brushPuntos, p1FisicoX - 5, p1FisicoY - 5, 10, 10);
            g.FillEllipse(brushPuntos, p2FisicoX - 5, p2FisicoY - 5, 10, 10);

            g.DrawString($"P1 ({punto1.X}, {punto1.Y})", fontRotulos, Brushes.Black, p1FisicoX + 8, p1FisicoY - 8);
            g.DrawString($"P2 ({punto2.X}, {punto2.Y})", fontRotulos, Brushes.Black, p2FisicoX + 8, p2FisicoY - 8);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label6.Text = "△x:";
            label7.Text = "△y:";
            label8.Text = "m=";
            listBoxPuntos.Items.Clear(); // Limpia la lista
            listoParaDibujar = false;
            panel1.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void AlgoritmoDDA1_Load(object sender, EventArgs e) { }
    }
}