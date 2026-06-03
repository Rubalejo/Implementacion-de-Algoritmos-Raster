using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public class PasoBezier
    {
        public int Paso { get; set; }
        public double T { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Point PuntoDiscreto { get; set; }
    }

    public class BezierCuadratico
    {
        public Point P0 { get; private set; }
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        public BezierCuadratico(Point p0, Point p1, Point p2)
        {
            this.P0 = p0;
            this.P1 = p1;
            this.P2 = p2;
        }

        public List<PasoBezier> CalcularPasos()
        {
            List<PasoBezier> listaPasos = new List<PasoBezier>();

            // AUTOMATIZACIÓN: Determinamos el número óptimo de divisiones basándonos
            // en la distancia máxima entre los extremos (Concepto adaptado de DDA)
            int dx = Math.Abs(P2.X - P0.X);
            int dy = Math.Abs(P2.Y - P0.Y);
            int pasosTotales = Math.Max(dx, dy);

            if (pasosTotales == 0) pasosTotales = 1; // Evita divisiones para cero

            double dt = 1.0 / pasosTotales;

            for (int i = 0; i <= pasosTotales; i++)
            {
                double t = i * dt;
                if (t > 1.0) t = 1.0; // Control de precisión decimal

                double u = 1 - t;
                double tt = t * t;
                double uu = u * u;

                // Ecuación paramétrica de Bézier Cuadrática
                double xCalc = uu * P0.X + 2 * u * t * P1.X + tt * P2.X;
                double yCalc = uu * P0.Y + 2 * u * t * P1.Y + tt * P2.Y;

                // Mapeo discreto a la celda de la cuadrícula
                int xDiscreto = (int)Math.Round(xCalc);
                int yDiscreto = (int)Math.Round(yCalc);

                listaPasos.Add(new PasoBezier
                {
                    Paso = i,
                    T = Math.Round(t, 2),
                    X = xDiscreto,
                    Y = yDiscreto,
                    PuntoDiscreto = new Point(xDiscreto, yDiscreto)
                });
            }

            return listaPasos;
        }
    }
}