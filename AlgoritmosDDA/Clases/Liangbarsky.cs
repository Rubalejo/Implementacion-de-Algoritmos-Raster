using System;

namespace LiangBarskyApp
{
    public static class LiangBarsky
    {
        public static bool ClipLine(
            ref float x1, ref float y1,
            ref float x2, ref float y2,
            float xmin, float ymin,
            float xmax, float ymax)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float[] p = { -dx, dx, -dy, dy };
            float[] q = { x1 - xmin, xmax - x1, y1 - ymin, ymax - y1 };

            float u1 = 0f, u2 = 1f;

            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(p[i]) < 1e-10f)
                {
                    if (q[i] < 0) return false;
                }
                else
                {
                    float t = q[i] / p[i];
                    if (p[i] < 0) u1 = Math.Max(u1, t);
                    else u2 = Math.Min(u2, t);
                }
            }

            if (u1 > u2) return false;

            float nx1 = x1 + u1 * dx;
            float ny1 = y1 + u1 * dy;
            float nx2 = x1 + u2 * dx;
            float ny2 = y1 + u2 * dy;

            x1 = nx1; y1 = ny1;
            x2 = nx2; y2 = ny2;
            return true;
        }

        public static bool ClipLineWithParams(
            float x1, float y1, float x2, float y2,
            float xmin, float ymin, float xmax, float ymax,
            out float u1, out float u2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float[] p = { -dx, dx, -dy, dy };
            float[] q = { x1 - xmin, xmax - x1, y1 - ymin, ymax - y1 };

            u1 = 0f; u2 = 1f;

            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(p[i]) < 1e-10f)
                {
                    if (q[i] < 0) return false;
                }
                else
                {
                    float t = q[i] / p[i];
                    if (p[i] < 0) u1 = Math.Max(u1, t);
                    else u2 = Math.Min(u2, t);
                }
            }

            return u1 <= u2;
        }
    }
}