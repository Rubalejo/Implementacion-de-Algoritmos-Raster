using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA
{
    public class PasoDDA
    {
        public int NumPaso { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Point PuntoDiscreto { get; set; }
    }
    public class DDA
    {
        public Point Punto1 { get; private set; }
        public Point Punto2 { get; private set; }
        public double Dx { get; private set; }
        public double Dy { get; private set; }
        public double M { get; private set; }

        public DDA(Point p1, Point p2)
        {
            this.Punto1 = p1;
            this.Punto2 = p2;
            CalcularAtributos();
        }

        // Método privado para calcular los deltas y la pendiente internamente
        private void CalcularAtributos()
        {
            Dx = Punto2.X - Punto1.X;
            Dy = Punto2.Y - Punto1.Y;
            M = (Dx != 0) ? Dy / Dx : Dy;
        }

        // Método público que procesa el algoritmo y devuelve la lista de pasos para la interfaz
        public List<PasoDDA> ObtenerPasosDelAlgoritmo()
        {
            List<PasoDDA> listaPasos = new List<PasoDDA>();

            double steps = Math.Max(Math.Abs(Dx), Math.Abs(Dy));
            double xIncrement = Dx / steps;
            double yIncrement = Dy / steps;

            double currentX = Punto1.X;
            double currentY = Punto1.Y;

            for (int i = 0; i <= steps; i++)
            {
                int xRedondeado = (int)Math.Round(currentX);
                int yRedondeado = (int)Math.Round(currentY);

                listaPasos.Add(new PasoDDA
                {
                    NumPaso = i,
                    X = currentX,
                    Y = currentY,
                    PuntoDiscreto = new Point(xRedondeado, yRedondeado)
                });

                currentX += xIncrement;
                currentY += yIncrement;
            }

            return listaPasos;
        }
    }
}