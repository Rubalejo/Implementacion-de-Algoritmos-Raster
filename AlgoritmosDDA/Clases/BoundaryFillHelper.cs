using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public static class BoundaryFillHelper
    {
        public static void BoundaryFillIterative(int[,] grid, int x, int y, int fillColor, int borderColor)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (x < 0 || x >= rows || y < 0 || y >= cols) return;
            if (grid[x, y] == borderColor || grid[x, y] == fillColor) return;

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();
                if (p.X < 0 || p.X >= rows || p.Y < 0 || p.Y >= cols) continue;
                if (grid[p.X, p.Y] == borderColor || grid[p.X, p.Y] == fillColor) continue;

                grid[p.X, p.Y] = fillColor;

                queue.Enqueue(new Point(p.X + 1, p.Y));
                queue.Enqueue(new Point(p.X - 1, p.Y));
                queue.Enqueue(new Point(p.X, p.Y + 1));
                queue.Enqueue(new Point(p.X, p.Y - 1));
            }
        }
    }
}