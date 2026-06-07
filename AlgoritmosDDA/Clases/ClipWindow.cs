// ============================================================
// ClipWindow.cs
// Proyecto: AlgoritmosDDA
// Autor: Arquitecto de Software Senior
// Versión: 1.0.0
// ============================================================

using System.Drawing;
using System.Drawing.Drawing2D;

namespace AlgoritmosDDA.Clases
{

    public class ClipWindow
    {


        private RectangleF _bounds;

        public RectangleF Bounds
        {
            get => _bounds;
            set => _bounds = NormalizeRect(value);
        }

        public float Left => _bounds.Left;

        public float Right => _bounds.Right;

        public float Top => _bounds.Top;

        public float Bottom => _bounds.Bottom;

        public bool IsDefined => _bounds.Width > 0 && _bounds.Height > 0;

        public ClipWindow()
        {
            _bounds = RectangleF.Empty;
        }

        public ClipWindow(RectangleF bounds)
        {
            _bounds = NormalizeRect(bounds);
        }

        public bool Contains(PointF point)
        {
            if (!IsDefined) return false;

            return point.X >= Left
                && point.X <= Right
                && point.Y >= Top
                && point.Y <= Bottom;
        }

        /// <param name="g">Contexto <see cref="Graphics"/> donde se renderiza.</param>
        public void Draw(Graphics g)
        {
            if (!IsDefined) return;

            // Relleno semitransparente
            using (SolidBrush fill = new SolidBrush(Color.FromArgb(25, 255, 60, 60)))
            {
                g.FillRectangle(fill, _bounds);
            }

            // Borde principal rojo
            using (Pen borderPen = new Pen(Color.Red, 2f))
            {
                borderPen.DashStyle = DashStyle.Solid;
                g.DrawRectangle(borderPen, _bounds.X, _bounds.Y, _bounds.Width, _bounds.Height);
            }

            // Marcadores de esquina
            DrawCornerMarkers(g);

            // Etiqueta de dimensiones
            DrawDimensionLabel(g);
        }

        private void DrawCornerMarkers(Graphics g)
        {
            const int size = 6;
            using (Pen cornerPen = new Pen(Color.OrangeRed, 1.5f))
            {
                // Esquina superior-izquierda
                g.DrawLine(cornerPen, Left, Top, Left + size, Top);
                g.DrawLine(cornerPen, Left, Top, Left, Top + size);

                // Esquina superior-derecha
                g.DrawLine(cornerPen, Right, Top, Right - size, Top);
                g.DrawLine(cornerPen, Right, Top, Right, Top + size);

                // Esquina inferior-izquierda
                g.DrawLine(cornerPen, Left, Bottom, Left + size, Bottom);
                g.DrawLine(cornerPen, Left, Bottom, Left, Bottom - size);

                // Esquina inferior-derecha
                g.DrawLine(cornerPen, Right, Bottom, Right - size, Bottom);
                g.DrawLine(cornerPen, Right, Bottom, Right, Bottom - size);
            }
        }

        private void DrawDimensionLabel(Graphics g)
        {
            string label = string.Format("  {0:F0} × {1:F0}", _bounds.Width, _bounds.Height);

            using (Font font = new Font("Consolas", 7.5f))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(220, 255, 100, 100)))
            {
                g.DrawString(label, font, textBrush, _bounds.X, _bounds.Y - 14);
            }
        }

        /// <param name="rect">Rectángulo a normalizar.</param>
        private static RectangleF NormalizeRect(RectangleF rect)
        {
            float x = rect.Width < 0 ? rect.X + rect.Width : rect.X;
            float y = rect.Height < 0 ? rect.Y + rect.Height : rect.Y;
            float w = rect.Width < 0 ? -rect.Width : rect.Width;
            float h = rect.Height < 0 ? -rect.Height : rect.Height;
            return new RectangleF(x, y, w, h);
        }
    }
}