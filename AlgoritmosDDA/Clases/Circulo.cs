using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA
{
    public class PasoCirculo
    {
        public int Paso { get; set; }
        public int P { get; set; }
        public Point Punto { get; set; }
        public Point Simetria { get; set; }
    }

    public class Circulo
    {
        public List<PasoCirculo> CalcularCirculo(int xc, int yc, int radio)
        {
            List<PasoCirculo> pasos = new List<PasoCirculo>();
            int x = 0, y = radio, p = 1 - radio, contador = 0;
            while (x <= y)
            {
                pasos.Add(new PasoCirculo { Paso = contador, P = p, Punto = new Point(x, y), Simetria = new Point(y, x) });
                if (p < 0) p = p + (2 * x) + 3;
                else { p = p + 2 * (x - y) + 5; y--; }
                x++; contador++;
            }
            return pasos;
        }

        public List<Point> ObtenerPuntosCompletos(int xc, int yc, int radio)
        {
            List<Point> puntos = new List<Point>();
            int x = 0, y = radio, p = 1 - radio;
            while (x <= y)
            {
                puntos.Add(new Point(xc + x, yc + y)); puntos.Add(new Point(xc + y, yc + x));
                puntos.Add(new Point(xc - y, yc + x)); puntos.Add(new Point(xc - x, yc + y));
                puntos.Add(new Point(xc - x, yc - y)); puntos.Add(new Point(xc - y, yc - x));
                puntos.Add(new Point(xc + y, yc - x)); puntos.Add(new Point(xc + x, yc - y));
                if (p < 0) p = p + (2 * x) + 3;
                else { p = p + 2 * (x - y) + 5; y--; }
                x++;
            }
            return puntos;
        }
    }
}