using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA
{
    public class CalculadorCirculoMatrices
    {
        public List<Point> CalcularCirculoMatrices(
            int xc,
            int yc,
            int radio)
        {
            List<Point> listaPuntos = new List<Point>();

            double x = radio;
            double y = 0;

            double angulo = 1.0 / radio;

            double cos = Math.Cos(angulo);
            double sin = Math.Sin(angulo);

            int pasos = (int)(2 * Math.PI / angulo);

            for (int i = 0; i <= pasos; i++)
            {
                int px = (int)Math.Round(x + xc);
                int py = (int)Math.Round(y + yc);

                Point nuevo = new Point(px, py);

                if (!listaPuntos.Contains(nuevo))
                    listaPuntos.Add(nuevo);

                double nuevoX = (x * cos) - (y * sin);
                double nuevoY = (x * sin) + (y * cos);

                x = nuevoX;
                y = nuevoY;
            }

            return listaPuntos;
        }
    }
}