using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using AlgoritmosDDA.Clases;

namespace AlgoritmosDDA.Formularios
{
    public partial class BoundaryFill : Form
    {
        private const int GRID_SIZE = 20;
        private const int CELL_SIZE = 30;
        private int[,] grid = new int[GRID_SIZE, GRID_SIZE];
        private Queue<Point> cola = new Queue<Point>();
        private Timer timer = new Timer();

        public BoundaryFill()
        {
            InitializeComponent();
            timer.Interval = 50;
            timer.Tick += (s, e) => EjecutarPaso();
        }

        private void EjecutarPaso()
        {
            if (cola.Count == 0) { timer.Stop(); return; }
            Point p = cola.Dequeue();

            if (p.X >= 0 && p.X < GRID_SIZE && p.Y >= 0 && p.Y < GRID_SIZE && grid[p.X, p.Y] == 0)
            {
                grid[p.X, p.Y] = 2; // Relleno
                cola.Enqueue(new Point(p.X + 1, p.Y)); cola.Enqueue(new Point(p.X - 1, p.Y));
                cola.Enqueue(new Point(p.X, p.Y + 1)); cola.Enqueue(new Point(p.X, p.Y - 1));
            }
            this.Invalidate();
        }

        private void trackBarVelocidad_Scroll(object sender, EventArgs e) => timer.Interval = trackBarVelocidad.Value;

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            grid = new int[GRID_SIZE, GRID_SIZE];
            string fig = cmbFiguras.SelectedItem.ToString();

            if (fig == "Cuadrado")
            {
                for (int i = 5; i < 15; i++) { grid[5, i] = 1; grid[14, i] = 1; grid[i, 5] = 1; grid[i, 14] = 1; }
            }
            else if (fig == "Flecha")
            {
                for (int i = 0; i < 10; i++) { grid[14, 5 + i] = 1; grid[14 - i, 5] = 1; grid[14 - i, 5 + i] = 1; }
            }
            else if (fig == "Casa")
            {
                for (int i = 6; i < 14; i++) { grid[13, i] = 1; grid[7, i] = 1; grid[i, 6] = 1; grid[i, 13] = 1; }
                for (int i = 0; i < 4; i++) { grid[7 - i, 6 + i] = 1; grid[7 - i, 13 - i] = 1; }
            }
            this.Invalidate();
        }

        private void BoundaryFill_MouseClick(object sender, MouseEventArgs e)
        {
            int r = e.Y / CELL_SIZE; int c = e.X / CELL_SIZE;
            if (r >= 0 && r < GRID_SIZE && c >= 0 && c < GRID_SIZE && grid[r, c] == 0)
            {
                cola.Enqueue(new Point(r, c));
                timer.Start();
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e) { grid = new int[GRID_SIZE, GRID_SIZE]; this.Invalidate(); }

        private void BoundaryFill_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < GRID_SIZE; i++)
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Brush b = grid[i, j] == 1 ? Brushes.Black : (grid[i, j] == 2 ? Brushes.Red : Brushes.White);
                    e.Graphics.FillRectangle(b, j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                    e.Graphics.DrawRectangle(Pens.Gray, j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                }
        }
    }
}