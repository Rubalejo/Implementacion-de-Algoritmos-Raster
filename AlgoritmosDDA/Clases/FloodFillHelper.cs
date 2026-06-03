using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public static class FloodFillHelper
    {
        public static void FloodFillIterative(int[,] grid, int x, int y, int targetColor, int replacementColor)
        {
            if (targetColor == replacementColor) return;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));
            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();
                if (p.X < 0 || p.X >= rows || p.Y < 0 || p.Y >= cols) continue;
                if (grid[p.X, p.Y] != targetColor) continue;
                grid[p.X, p.Y] = replacementColor;
                queue.Enqueue(new Point(p.X + 1, p.Y));
                queue.Enqueue(new Point(p.X - 1, p.Y));
                queue.Enqueue(new Point(p.X, p.Y + 1));
                queue.Enqueue(new Point(p.X, p.Y - 1));
            }
        }
    }
}