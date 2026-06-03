using System;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosDDA.Clases; 

namespace AlgoritmosDDA.Formularios
{
    public partial class FloodFill : Form
    {
        private const int GRID_SIZE = 20;
        private const int CELL_SIZE = 30;
        private int[,] grid = new int[GRID_SIZE, GRID_SIZE];
        private bool modoDibujo = true;

        public FloodFill() { InitializeComponent(); }

        private void FloodFill_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < GRID_SIZE; i++)
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Brush b = grid[i, j] == 1 ? Brushes.Black : (grid[i, j] == 2 ? Brushes.Blue : Brushes.White);
                    e.Graphics.FillRectangle(b, j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                    e.Graphics.DrawRectangle(Pens.Gray, j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                }
        }

        private void FloodFill_MouseClick(object sender, MouseEventArgs e)
        {
            int r = e.Y / CELL_SIZE; int c = e.X / CELL_SIZE;
            if (r < 0 || r >= GRID_SIZE || c < 0 || c >= GRID_SIZE) return;

            if (modoDibujo)
            {
                string h = cmbHerramienta.SelectedItem.ToString();
                if (h == "Muro") grid[r, c] = 1;
                else if (h == "Cuadrado") { for (int i = r - 1; i <= r + 1; i++) for (int j = c - 1; j <= c + 1; j++) if (i >= 0 && i < GRID_SIZE && j >= 0 && j < GRID_SIZE) grid[i, j] = 1; }
                else if (h == "Cruz") { grid[r, c] = 1; if (r > 0) grid[r - 1, c] = 1; if (r < GRID_SIZE - 1) grid[r + 1, c] = 1; if (c > 0) grid[r, c - 1] = 1; if (c < GRID_SIZE - 1) grid[r, c + 1] = 1; }
            }
            else FloodFillHelper.FloodFillIterative(grid, r, c, 0, 2);
            this.Invalidate();
        }

        private void btnModo_Click(object sender, EventArgs e)
        {
            modoDibujo = !modoDibujo;
            btnModo.Text = modoDibujo ? "Modo: Dibujar" : "Modo: Rellenar";
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            grid = new int[GRID_SIZE, GRID_SIZE];
            this.Invalidate();
        }
    }
}