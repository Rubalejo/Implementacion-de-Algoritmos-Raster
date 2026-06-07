using System;

namespace NLNApp
{
    public enum NLNRegion
    {
        Inside, Left, Right, Top, Bottom,
        TopLeft, TopRight, BottomLeft, BottomRight
    }

    public static class NichollLeeNicholl
    {
        private static NLNRegion Classify(float x, float y, float xmin, float ymin, float xmax, float ymax)
        {
            bool left = x < xmin;
            bool right = x > xmax;
            bool bottom = y < ymin;
            bool top = y > ymax;

            if (!left && !right && !bottom && !top) return NLNRegion.Inside;
            if (left && top) return NLNRegion.TopLeft;
            if (right && top) return NLNRegion.TopRight;
            if (left && bottom) return NLNRegion.BottomLeft;
            if (right && bottom) return NLNRegion.BottomRight;
            if (left) return NLNRegion.Left;
            if (right) return NLNRegion.Right;
            if (top) return NLNRegion.Top;
            return NLNRegion.Bottom;
        }

        private static float IntersectX(float x1, float y1, float x2, float y2, float y)
        {
            if (Math.Abs(y2 - y1) < 1e-10f) return x1;
            return x1 + (x2 - x1) * (y - y1) / (y2 - y1);
        }

        private static float IntersectY(float x1, float y1, float x2, float y2, float x)
        {
            if (Math.Abs(x2 - x1) < 1e-10f) return y1;
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }

        public static bool ClipLine(
            ref float x1, ref float y1,
            ref float x2, ref float y2,
            float xmin, float ymin, float xmax, float ymax,
            out NLNRegion region, out string ncase)
        {
            region = Classify(x1, y1, xmin, ymin, xmax, ymax);
            ncase = "";

            NLNRegion r2 = Classify(x2, y2, xmin, ymin, xmax, ymax);

            // Ambos dentro
            if (region == NLNRegion.Inside && r2 == NLNRegion.Inside)
            {
                ncase = "Caso 1 — Trivial aceptado";
                return true;
            }

            // Mismo lado exterior → rechazo trivial
            if (region == r2 && region != NLNRegion.Inside)
            {
                ncase = "Caso 2 — Trivial rechazado";
                return false;
            }

            float nx1 = x1, ny1 = y1, nx2 = x2, ny2 = y2;

            // P1 fuera, P2 dentro → invertir y procesar
            bool swapped = false;
            NLNRegion rP1 = region;

            if (rP1 == NLNRegion.Inside)
            {
                // P1 dentro, P2 fuera → swap
                float tx = nx1; nx1 = nx2; nx2 = tx;
                float ty = ny1; ny1 = ny2; ny2 = ty;
                NLNRegion tr = rP1; rP1 = r2; r2 = tr;
                swapped = true;
            }

            // Ahora rP1 es la región de P1 (exterior o borde)
            // Calcular intersecciones según clasificación NLN
            bool clipped = ApplyNLN(ref nx1, ref ny1, ref nx2, ref ny2,
                                    xmin, ymin, xmax, ymax, rP1, r2, ref ncase);

            if (!clipped) return false;

            if (swapped)
            {
                x1 = nx2; y1 = ny2;
                x2 = nx1; y2 = ny1;
            }
            else
            {
                x1 = nx1; y1 = ny1;
                x2 = nx2; y2 = ny2;
            }

            return true;
        }

        // Sobrecarga sin out params para uso simple
        public static bool ClipLine(
            ref float x1, ref float y1,
            ref float x2, ref float y2,
            float xmin, float ymin, float xmax, float ymax)
        {
            NLNRegion r; string c;
            return ClipLine(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, out r, out c);
        }

        private static bool ApplyNLN(
            ref float x1, ref float y1,
            ref float x2, ref float y2,
            float xmin, float ymin, float xmax, float ymax,
            NLNRegion rP1, NLNRegion rP2, ref string ncase)
        {
            // ── P1 en Left ───────────────────────────────────────────────
            if (rP1 == NLNRegion.Left)
            {
                float yi = IntersectY(x1, y1, x2, y2, xmin);

                if (rP2 == NLNRegion.Inside)
                {
                    ncase = "Caso 3a — Left→Inside";
                    x1 = xmin; y1 = yi;
                    ClampP1ToWindow(ref x1, ref y1, xmin, ymin, xmax, ymax);
                    return true;
                }

                // P2 también exterior
                if (yi >= ymin && yi <= ymax)
                {
                    x1 = xmin; y1 = yi;
                    // Clip P2
                    NLNRegion dummy = rP2;
                    string dcase = "";
                    return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dcase, ref ncase, "Caso 3b — Left+clip P2");
                }
                else
                {
                    ncase = "Caso 3c — Left, sin intersección válida";
                    return false;
                }
            }

            // ── P1 en Right ──────────────────────────────────────────────
            if (rP1 == NLNRegion.Right)
            {
                float yi = IntersectY(x1, y1, x2, y2, xmax);

                if (rP2 == NLNRegion.Inside)
                {
                    ncase = "Caso 4a — Right→Inside";
                    x1 = xmax; y1 = yi;
                    ClampP1ToWindow(ref x1, ref y1, xmin, ymin, xmax, ymax);
                    return true;
                }

                if (yi >= ymin && yi <= ymax)
                {
                    x1 = xmax; y1 = yi;
                    string dcase = "";
                    return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dcase, ref ncase, "Caso 4b — Right+clip P2");
                }
                else
                {
                    ncase = "Caso 4c — Right, sin intersección válida";
                    return false;
                }
            }

            // ── P1 en Bottom ─────────────────────────────────────────────
            if (rP1 == NLNRegion.Bottom)
            {
                float xi = IntersectX(x1, y1, x2, y2, ymin);

                if (rP2 == NLNRegion.Inside)
                {
                    ncase = "Caso 5a — Bottom→Inside";
                    x1 = xi; y1 = ymin;
                    ClampP1ToWindow(ref x1, ref y1, xmin, ymin, xmax, ymax);
                    return true;
                }

                if (xi >= xmin && xi <= xmax)
                {
                    x1 = xi; y1 = ymin;
                    string dcase = "";
                    return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dcase, ref ncase, "Caso 5b — Bottom+clip P2");
                }
                else
                {
                    ncase = "Caso 5c — Bottom, sin intersección válida";
                    return false;
                }
            }

            // ── P1 en Top ────────────────────────────────────────────────
            if (rP1 == NLNRegion.Top)
            {
                float xi = IntersectX(x1, y1, x2, y2, ymax);

                if (rP2 == NLNRegion.Inside)
                {
                    ncase = "Caso 6a — Top→Inside";
                    x1 = xi; y1 = ymax;
                    ClampP1ToWindow(ref x1, ref y1, xmin, ymin, xmax, ymax);
                    return true;
                }

                if (xi >= xmin && xi <= xmax)
                {
                    x1 = xi; y1 = ymax;
                    string dcase = "";
                    return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dcase, ref ncase, "Caso 6b — Top+clip P2");
                }
                else
                {
                    ncase = "Caso 6c — Top, sin intersección válida";
                    return false;
                }
            }

            // ── P1 en TopLeft ────────────────────────────────────────────
            if (rP1 == NLNRegion.TopLeft)
            {
                ncase = "Caso 7 — TopLeft";
                float xiTop = IntersectX(x1, y1, x2, y2, ymax);
                float yiLeft = IntersectY(x1, y1, x2, y2, xmin);

                if (xiTop >= xmin && xiTop <= xmax)
                {
                    x1 = xiTop; y1 = ymax;
                }
                else if (yiLeft >= ymin && yiLeft <= ymax)
                {
                    x1 = xmin; y1 = yiLeft;
                }
                else return false;

                string dc = "";
                return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dc, ref ncase, ncase);
            }

            // ── P1 en TopRight ───────────────────────────────────────────
            if (rP1 == NLNRegion.TopRight)
            {
                ncase = "Caso 8 — TopRight";
                float xiTop = IntersectX(x1, y1, x2, y2, ymax);
                float yiRight = IntersectY(x1, y1, x2, y2, xmax);

                if (xiTop >= xmin && xiTop <= xmax)
                {
                    x1 = xiTop; y1 = ymax;
                }
                else if (yiRight >= ymin && yiRight <= ymax)
                {
                    x1 = xmax; y1 = yiRight;
                }
                else return false;

                string dc = "";
                return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dc, ref ncase, ncase);
            }

            // ── P1 en BottomLeft ─────────────────────────────────────────
            if (rP1 == NLNRegion.BottomLeft)
            {
                ncase = "Caso 9 — BottomLeft";
                float xiBot = IntersectX(x1, y1, x2, y2, ymin);
                float yiLeft = IntersectY(x1, y1, x2, y2, xmin);

                if (xiBot >= xmin && xiBot <= xmax)
                {
                    x1 = xiBot; y1 = ymin;
                }
                else if (yiLeft >= ymin && yiLeft <= ymax)
                {
                    x1 = xmin; y1 = yiLeft;
                }
                else return false;

                string dc = "";
                return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dc, ref ncase, ncase);
            }

            // ── P1 en BottomRight ────────────────────────────────────────
            if (rP1 == NLNRegion.BottomRight)
            {
                ncase = "Caso 10 — BottomRight";
                float xiBot = IntersectX(x1, y1, x2, y2, ymin);
                float yiRight = IntersectY(x1, y1, x2, y2, xmax);

                if (xiBot >= xmin && xiBot <= xmax)
                {
                    x1 = xiBot; y1 = ymin;
                }
                else if (yiRight >= ymin && yiRight <= ymax)
                {
                    x1 = xmax; y1 = yiRight;
                }
                else return false;

                string dc = "";
                return ClipP2(ref x1, ref y1, ref x2, ref y2, xmin, ymin, xmax, ymax, rP2, ref dc, ref ncase, ncase);
            }

            ncase = "Caso desconocido";
            return false;
        }

        private static bool ClipP2(
            ref float x1, ref float y1,
            ref float x2, ref float y2,
            float xmin, float ymin, float xmax, float ymax,
            NLNRegion rP2, ref string dc, ref string ncase, string caseLabel)
        {
            ncase = caseLabel;
            if (rP2 == NLNRegion.Inside) return true;

            float nx2 = x2, ny2 = y2;

            if (rP2 == NLNRegion.Left || rP2 == NLNRegion.TopLeft || rP2 == NLNRegion.BottomLeft)
            {
                float yi = IntersectY(x1, y1, nx2, ny2, xmin);
                if (yi >= ymin && yi <= ymax) { nx2 = xmin; ny2 = yi; }
                else if (rP2 == NLNRegion.TopLeft)
                {
                    float xi = IntersectX(x1, y1, x2, y2, ymax);
                    if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymax; }
                    else return false;
                }
                else if (rP2 == NLNRegion.BottomLeft)
                {
                    float xi = IntersectX(x1, y1, x2, y2, ymin);
                    if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymin; }
                    else return false;
                }
                else return false;
            }
            else if (rP2 == NLNRegion.Right || rP2 == NLNRegion.TopRight || rP2 == NLNRegion.BottomRight)
            {
                float yi = IntersectY(x1, y1, nx2, ny2, xmax);
                if (yi >= ymin && yi <= ymax) { nx2 = xmax; ny2 = yi; }
                else if (rP2 == NLNRegion.TopRight)
                {
                    float xi = IntersectX(x1, y1, x2, y2, ymax);
                    if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymax; }
                    else return false;
                }
                else if (rP2 == NLNRegion.BottomRight)
                {
                    float xi = IntersectX(x1, y1, x2, y2, ymin);
                    if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymin; }
                    else return false;
                }
                else return false;
            }
            else if (rP2 == NLNRegion.Top)
            {
                float xi = IntersectX(x1, y1, nx2, ny2, ymax);
                if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymax; }
                else return false;
            }
            else if (rP2 == NLNRegion.Bottom)
            {
                float xi = IntersectX(x1, y1, nx2, ny2, ymin);
                if (xi >= xmin && xi <= xmax) { nx2 = xi; ny2 = ymin; }
                else return false;
            }

            x2 = nx2; y2 = ny2;
            return true;
        }

        private static void ClampP1ToWindow(ref float x, ref float y,
            float xmin, float ymin, float xmax, float ymax)
        {
            x = Math.Max(xmin, Math.Min(xmax, x));
            y = Math.Max(ymin, Math.Min(ymax, y));
        }
    }
}