using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA
{
    public class CalculadorCirculoPolares
    {
        public List<Point> CalcularCirculoPolares(
            int xc,
            int yc,
            int radio
        )
        {
            List<Point> listaPuntos =
                new List<Point>();

            double incrementoAngulo = 0.01;

            for (
                double theta = 0;
                theta <= 2 * Math.PI;
                theta += incrementoAngulo
            )
            {
                double x =
                    xc +
                    radio *
                    Math.Cos(theta);

                double y =
                    yc +
                    radio *
                    Math.Sin(theta);

                int px =
                    (int)Math.Round(x);

                int py =
                    (int)Math.Round(y);

                Point nuevo =
                    new Point(px, py);

                if (
                    !listaPuntos.Contains(
                        nuevo
                    )
                )
                {
                    listaPuntos.Add(
                        nuevo
                    );
                }
            }

            return listaPuntos;
        }
    }
}