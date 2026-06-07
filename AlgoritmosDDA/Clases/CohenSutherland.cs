// ============================================================
// CohenSutherland.cs
// Proyecto: AlgoritmosDDA
// Autor: Arquitecto de Software Senior
// Versión: 1.0.0
// ============================================================

using System.Drawing;

namespace AlgoritmosDDA.Clases
{
    /// <summary>
    /// Implementación del algoritmo de recorte de líneas Cohen-Sutherland.
    /// Determina qué porción de un segmento de línea queda dentro de una
    /// ventana de recorte rectangular, asignando códigos de región a cada
    /// punto extremo e intersectando iterativamente con los bordes.
    /// </summary>
    public static class CohenSutherland
    {
        // ─────────────────────────────────────────────────────
        // Códigos de región (outcode)
        // ─────────────────────────────────────────────────────

        /// <summary>Punto dentro de la ventana. Todos los bits en cero.</summary>
        private const int INSIDE = 0;   // 0000

        /// <summary>Punto a la izquierda de la ventana.</summary>
        private const int LEFT = 1;   // 0001

        /// <summary>Punto a la derecha de la ventana.</summary>
        private const int RIGHT = 2;   // 0010

        /// <summary>Punto por debajo de la ventana (Y mayor en coordenadas de pantalla).</summary>
        private const int BOTTOM = 4;   // 0100

        /// <summary>Punto por encima de la ventana (Y menor en coordenadas de pantalla).</summary>
        private const int TOP = 8;   // 1000

        // ─────────────────────────────────────────────────────
        // API pública
        // ─────────────────────────────────────────────────────

        /// <summary>
        /// Ejecuta el algoritmo Cohen-Sutherland sobre el segmento dado.
        /// Actualiza las propiedades <see cref="LineSegment.ClippedStart"/>,
        /// <see cref="LineSegment.ClippedEnd"/>, <see cref="LineSegment.IsVisible"/>
        /// e <see cref="LineSegment.IsClipped"/> del segmento.
        /// </summary>
        /// <param name="segment">
        /// Segmento de línea a recortar. Sus propiedades de recorte serán modificadas.
        /// </param>
        /// <param name="window">
        /// Ventana de recorte rectangular contra la que se recorta el segmento.
        /// </param>
        /// <returns>
        /// <c>true</c> si alguna porción del segmento queda visible dentro de la ventana;
        /// <c>false</c> si el segmento es completamente rechazado.
        /// </returns>
        public static bool ClipLine(LineSegment segment, ClipWindow window)
        {
            // Coordenadas de trabajo (se modificarán en cada iteración)
            float x0 = segment.Start.X;
            float y0 = segment.Start.Y;
            float x1 = segment.End.X;
            float y1 = segment.End.Y;

            // Límites de la ventana de recorte
            float xMin = window.Left;
            float xMax = window.Right;
            float yMin = window.Top;
            float yMax = window.Bottom;

            // Calcular códigos iniciales para ambos extremos
            int code0 = ComputeCode(x0, y0, xMin, xMax, yMin, yMax);
            int code1 = ComputeCode(x1, y1, xMin, xMax, yMin, yMax);

            bool accepted = false;

            while (true)
            {
                if ((code0 | code1) == INSIDE)
                {
                    // Caso trivial de aceptación: ambos puntos dentro de la ventana
                    accepted = true;
                    break;
                }
                else if ((code0 & code1) != INSIDE)
                {
                    // Caso trivial de rechazo: ambos puntos en la misma región exterior
                    accepted = false;
                    break;
                }
                else
                {
                    // Al menos un punto está fuera; calcular intersección con borde
                    float x = 0f;
                    float y = 0f;

                    // Seleccionar el punto exterior (se prioriza code0)
                    int codeOut = (code0 != INSIDE) ? code0 : code1;

                    // Calcular intersección según el borde que cruza el outcode
                    if ((codeOut & TOP) != 0)
                    {
                        // Intersección con borde superior (yMin)
                        x = x0 + (x1 - x0) * (yMin - y0) / (y1 - y0);
                        y = yMin;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        // Intersección con borde inferior (yMax)
                        x = x0 + (x1 - x0) * (yMax - y0) / (y1 - y0);
                        y = yMax;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        // Intersección con borde derecho (xMax)
                        y = y0 + (y1 - y0) * (xMax - x0) / (x1 - x0);
                        x = xMax;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        // Intersección con borde izquierdo (xMin)
                        y = y0 + (y1 - y0) * (xMin - x0) / (x1 - x0);
                        x = xMin;
                    }

                    // Reemplazar el punto exterior por el punto de intersección
                    if (codeOut == code0)
                    {
                        x0 = x;
                        y0 = y;
                        code0 = ComputeCode(x0, y0, xMin, xMax, yMin, yMax);
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        code1 = ComputeCode(x1, y1, xMin, xMax, yMin, yMax);
                    }
                }
            }

            // ── Actualizar el segmento con los resultados ──────────
            segment.IsVisible = accepted;

            if (accepted)
            {
                PointF clippedStart = new PointF(x0, y0);
                PointF clippedEnd = new PointF(x1, y1);

                segment.ClippedStart = clippedStart;
                segment.ClippedEnd = clippedEnd;

                // Determinar si fue recortado comparando con los extremos originales
                segment.IsClipped =
                    !PointsEqual(clippedStart, segment.Start) ||
                    !PointsEqual(clippedEnd, segment.End);
            }
            else
            {
                segment.ClippedStart = segment.Start;
                segment.ClippedEnd = segment.End;
                segment.IsClipped = false;
            }

            return accepted;
        }

        // ─────────────────────────────────────────────────────
        // Métodos privados
        // ─────────────────────────────────────────────────────

        /// <summary>
        /// Calcula el código de región (outcode) de un punto respecto
        /// a la ventana de recorte definida por sus cuatro bordes.
        /// </summary>
        /// <param name="x">Coordenada X del punto.</param>
        /// <param name="y">Coordenada Y del punto.</param>
        /// <param name="xMin">Borde izquierdo de la ventana.</param>
        /// <param name="xMax">Borde derecho de la ventana.</param>
        /// <param name="yMin">Borde superior de la ventana (Y mínima en pantalla).</param>
        /// <param name="yMax">Borde inferior de la ventana (Y máxima en pantalla).</param>
        /// <returns>
        /// Código de región como combinación OR de las constantes
        /// <see cref="INSIDE"/>, <see cref="LEFT"/>, <see cref="RIGHT"/>,
        /// <see cref="TOP"/> y <see cref="BOTTOM"/>.
        /// </returns>
        private static int ComputeCode(
            float x, float y,
            float xMin, float xMax,
            float yMin, float yMax)
        {
            int code = INSIDE;

            if (x < xMin)
                code |= LEFT;
            else if (x > xMax)
                code |= RIGHT;

            if (y < yMin)
                code |= TOP;
            else if (y > yMax)
                code |= BOTTOM;

            return code;
        }

        /// <summary>
        /// Compara dos puntos con una tolerancia de 0.5 píxeles para
        /// evitar falsos positivos por aritmética de punto flotante.
        /// </summary>
        /// <param name="a">Primer punto.</param>
        /// <param name="b">Segundo punto.</param>
        /// <returns><c>true</c> si los puntos son prácticamente iguales.</returns>
        private static bool PointsEqual(PointF a, PointF b)
        {
            const float tolerance = 0.5f;
            return System.Math.Abs(a.X - b.X) < tolerance
                && System.Math.Abs(a.Y - b.Y) < tolerance;
        }
    }
}