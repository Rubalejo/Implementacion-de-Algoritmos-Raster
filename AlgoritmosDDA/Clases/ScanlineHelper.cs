using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public class Edge
    {
        public float X;
        public float DX;
        public int YMax;

        public Edge(float x, float dx, int yMax)
        {
            X = x;
            DX = dx;
            YMax = yMax;
        }

        public void Avanzar()
        {
            X += DX;
        }
    }

    public class PolygonBuffer
    {
        public List<Point> Vertices { get; private set; }
        public Color FillColor { get; set; }

        public PolygonBuffer()
        {
            Vertices = new List<Point>();
            FillColor = Color.CornflowerBlue;
        }

        public void AddVertex(Point p)
        {
            Vertices.Add(p);
        }

        public bool IsValid => Vertices.Count >= 3;

        public List<Point> CalcularIntersecciones(int y)
        {
            List<float> intersecciones = new List<float>();
            int n = Vertices.Count;

            for (int i = 0; i < n; i++)
            {
                Point p1 = Vertices[i];
                Point p2 = Vertices[(i + 1) % n];

                if ((p1.Y <= y && y < p2.Y) || (p2.Y <= y && y < p1.Y))
                {
                    float x = p1.X + (float)(y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                    intersecciones.Add(x);
                }
            }

            intersecciones.Sort();

            List<Point> segmentos = new List<Point>();
            for (int i = 0; i + 1 < intersecciones.Count; i += 2)
                segmentos.Add(new Point((int)intersecciones[i], (int)intersecciones[i + 1]));

            return segmentos;
        }
    }
}
