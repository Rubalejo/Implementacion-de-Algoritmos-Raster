using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public class PasoRecta
    {
        public int Paso { get; set; }
        public int D { get; set; } // Parámetro de decisión
        public int X { get; set; }
        public int Y { get; set; }
        public Point Punto { get; set; }
    }

    public class PuntoMedioRecta
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        public PuntoMedioRecta(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public List<PasoRecta> CalcularPasos()
        {
            List<PasoRecta> pasos = new List<PasoRecta>();

            int x1 = P1.X;
            int y1 = P1.Y;
            int x2 = P2.X;
            int y2 = P2.Y;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int x = x1;
            int y = y1;
            int numPaso = 0;

            // Caso 1: Pendiente entre 0 y 1 (m <= 1)
            if (dx >= dy)
            {
                int d = 2 * dy - dx;
                int d1 = 2 * dy;
                int d2 = 2 * (dy - dx);

                pasos.Add(new PasoRecta { Paso = numPaso++, D = d, X = x, Y = y, Punto = new Point(x, y) });

                while (x != x2)
                {
                    x += sx;
                    if (d < 0)
                    {
                        d += d1;
                    }
                    else
                    {
                        y += sy;
                        d += d2;
                    }
                    pasos.Add(new PasoRecta { Paso = numPaso++, D = d, X = x, Y = y, Punto = new Point(x, y) });
                }
            }
            // Caso 2: Pendiente mayor a 1 (m > 1)
            else
            {
                int d = 2 * dx - dy;
                int d1 = 2 * dx;
                int d2 = 2 * (dx - dy);

                pasos.Add(new PasoRecta { Paso = numPaso++, D = d, X = x, Y = y, Punto = new Point(x, y) });

                while (y != y2)
                {
                    y += sy;
                    if (d < 0)
                    {
                        d += d1;
                    }
                    else
                    {
                        x += sx;
                        d += d2;
                    }
                    pasos.Add(new PasoRecta { Paso = numPaso++, D = d, X = x, Y = y, Punto = new Point(x, y) });
                }
            }

            return pasos;
        }
    }
}