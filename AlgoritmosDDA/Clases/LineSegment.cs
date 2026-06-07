using System;
using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    public class LineSegment
    {
        public PointF Start { get; set; }

        public PointF End { get; set; }

        public PointF ClippedStart { get; set; }

        public PointF ClippedEnd { get; set; }

        public bool IsVisible { get; set; }

        public bool IsClipped { get; set; }

        public Color OriginalColor { get; set; }

        public Color ClippedColor { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="LineSegment"/>
        /// con los puntos indicados y valores predeterminados de color.
        /// </summary>
        /// <param name="start">Punto inicial del segmento.</param>
        /// <param name="end">Punto final del segmento.</param>
        /// <param name="name">Nombre identificador del segmento.</param>
        public LineSegment(PointF start, PointF end, string name = "Segmento")
        {
            Start = start;
            End = end;
            ClippedStart = start;
            ClippedEnd = end;
            IsVisible = false;
            IsClipped = false;
            OriginalColor = Color.Gray;
            ClippedColor = Color.Lime;
            Name = name;
        }

        public float Length
        {
            get
            {
                float dx = End.X - Start.X;
                float dy = End.Y - Start.Y;
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
        }

        public float ClippedLength
        {
            get
            {
                if (!IsVisible) return 0f;
                float dx = ClippedEnd.X - ClippedStart.X;
                float dy = ClippedEnd.Y - ClippedStart.Y;
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
        }

        public void ResetClip()
        {
            ClippedStart = Start;
            ClippedEnd = End;
            IsVisible = false;
            IsClipped = false;
        }

        public override string ToString()
        {
            string estado = IsVisible
                ? (IsClipped ? "Parcialmente visible" : "Totalmente visible")
                : "Rechazado";

            return string.Format(
                "{0} | ({1:F0},{2:F0})→({3:F0},{4:F0}) | L={5:F1}px | {6}",
                Name,
                Start.X, Start.Y,
                End.X, End.Y,
                Length,
                estado);
        }
    }
}