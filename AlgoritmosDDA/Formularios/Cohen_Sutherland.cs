using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AlgoritmosDDA.Clases;

namespace AlgoritmosDDA.Formularios
{
    public partial class CohenSutherlandForm : Form
    {


        private readonly List<LineSegment> _segments = new List<LineSegment>();

        private readonly ClipWindow _clipWindow = new ClipWindow();

        private DrawingToolMode _currentMode = DrawingToolMode.None;

        private PointF _firstPoint;

        private bool _waitingForSecondClick = false;

        private PointF _mousePos;

        private PointF _dragStart;

        private bool _isDragging = false;

        private RectangleF _previewRect = RectangleF.Empty;

        private int _segmentCounter = 0;

        private bool _clipped = false;

        public CohenSutherlandForm()
        {
            InitializeComponent();

            SetDoubleBuffer(drawingPanel, true);
        }

        private void CohenSutherlandForm_Load(object sender, EventArgs e)
        {
            ActualizarEstado("Seleccione una herramienta para comenzar.");
            ActualizarContadorLineas();
        }

        private void BtnNuevoSegmento_Click(object sender, EventArgs e)
        {
            _currentMode = DrawingToolMode.DrawSegment;
            _waitingForSecondClick = false;
            _isDragging = false;
            drawingPanel.Cursor = Cursors.Cross;
            ActualizarEstado("Modo: Nuevo Segmento — Clic para el punto inicial.");
            ResaltarBotonActivo(btnNuevoSegmento);
        }

        private void BtnNuevaVentana_Click(object sender, EventArgs e)
        {
            _currentMode = DrawingToolMode.DrawClipWindow;
            _waitingForSecondClick = false;
            _isDragging = false;
            drawingPanel.Cursor = Cursors.SizeAll;
            ActualizarEstado("Modo: Nueva Ventana — Arrastre para definir el área de recorte.");
            ResaltarBotonActivo(btnNuevaVentana);
        }

        private void BtnRecortar_Click(object sender, EventArgs e)
        {
            if (!_clipWindow.IsDefined)
            {
                MessageBox.Show(
                    "Defina primero una ventana de recorte arrastrando sobre el panel.",
                    "Ventana no definida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_segments.Count == 0)
            {
                MessageBox.Show(
                    "Añada al menos un segmento antes de recortar.",
                    "Sin segmentos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            EjecutarRecorte();
        }

        private void BtnDemo_Click(object sender, EventArgs e)
        {
            CargarDemo();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            string mensaje =
                "Cohen-Sutherland — AlgoritmosDDA\n" +
                "─────────────────────────────────────\n\n" +
                "Algoritmo de recorte de líneas (1967)\n" +
                "Autores: Danny Cohen e Ivan Sutherland\n\n" +
                "Asigna un código de 4 bits a cada extremo\n" +
                "del segmento según su posición relativa a\n" +
                "la ventana de recorte:\n\n" +
                "  INSIDE = 0000\n" +
                "  LEFT   = 0001\n" +
                "  RIGHT  = 0010\n" +
                "  BOTTOM = 0100\n" +
                "  TOP    = 1000\n\n" +
                "Acepta trivialmente si code0 | code1 = 0\n" +
                "Rechaza trivialmente si code0 & code1 ≠ 0\n" +
                "Caso general: intersectar con el borde.\n\n" +
                "Versión: 1.0.0  |  .NET Framework 4.8  |  WinForms";

            MessageBox.Show(mensaje, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            PointF pt = new PointF(e.X, e.Y);

            switch (_currentMode)
            {
                case DrawingToolMode.DrawSegment:
                    ManejarClicSegmento(pt);
                    break;

                case DrawingToolMode.DrawClipWindow:
                    _dragStart = pt;
                    _isDragging = true;
                    _previewRect = RectangleF.Empty;
                    break;
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePos = new PointF(e.X, e.Y);
            lblPosicion.Text = string.Format("X: {0}   Y: {1}", e.X, e.Y);

            if (_isDragging && _currentMode == DrawingToolMode.DrawClipWindow)
            {
                _previewRect = RectangleFromPoints(_dragStart, _mousePos);
            }

            drawingPanel.Invalidate();
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (_isDragging && _currentMode == DrawingToolMode.DrawClipWindow)
            {
                _isDragging = false;
                RectangleF rect = RectangleFromPoints(_dragStart, new PointF(e.X, e.Y));

                if (rect.Width > 5 && rect.Height > 5)
                {
                    _clipWindow.Bounds = rect;
                    _clipped = false;

                    // Resetear recortes previos al cambiar la ventana
                    foreach (LineSegment seg in _segments)
                        seg.ResetClip();

                    ActualizarVentanaInfo();
                    ActualizarEstado("Ventana de recorte definida. Presione 'Recortar' para aplicar.");
                    ActualizarListBox();
                }
                else
                {
                    ActualizarEstado("Ventana demasiado pequeña. Arrastre más espacio.");
                }

                _previewRect = RectangleF.Empty;
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 1. Cuadrícula de fondo
            DibujarCuadricula(g);

            // 2. Ventana de recorte definitiva
            if (_clipWindow.IsDefined)
                _clipWindow.Draw(g);

            // 3. Previsualización de ventana mientras se arrastra
            if (_isDragging && _previewRect.Width > 0 && _previewRect.Height > 0)
                DibujarPreviewVentana(g);

            // 4. Segmentos (original + recortado)
            foreach (LineSegment seg in _segments)
                DibujarSegmento(g, seg);

            // 5. Previsualización de segmento mientras se elige el segundo punto
            if (_waitingForSecondClick && _currentMode == DrawingToolMode.DrawSegment)
                DibujarPreviewSegmento(g);

            // 6. Marcador del primer punto al trazar un segmento
            if (_waitingForSecondClick)
                DibujarMarcadorPunto(g, _firstPoint);
        }

        private void ManejarClicSegmento(PointF pt)
        {
            if (!_waitingForSecondClick)
            {
                // Primer clic: almacenar punto inicial
                _firstPoint = pt;
                _waitingForSecondClick = true;
                ActualizarEstado("Primer punto registrado. Clic para el punto final.");
            }
            else
            {
                // Segundo clic: crear el segmento
                _segmentCounter++;
                string nombre = "Seg " + _segmentCounter;
                LineSegment seg = new LineSegment(_firstPoint, pt, nombre);

                _segments.Add(seg);
                _waitingForSecondClick = false;
                _clipped = false;

                ActualizarListBox();
                ActualizarContadorLineas();
                ActualizarEstado(string.Format(
                    "Segmento '{0}' añadido. Longitud: {1:F1} px.", nombre, seg.Length));

                drawingPanel.Invalidate();
            }
        }

        private void EjecutarRecorte()
        {
            int visibles = 0;
            int rechazados = 0;
            int parciales = 0;

            foreach (LineSegment seg in _segments)
            {
                bool visible = CohenSutherland.ClipLine(seg, _clipWindow);

                if (visible)
                {
                    visibles++;
                    if (seg.IsClipped) parciales++;
                }
                else
                {
                    rechazados++;
                }
            }

            _clipped = true;
            ActualizarListBox();
            drawingPanel.Invalidate();

            string resultado = string.Format(
                "Recorte: {0} visible(s) [{1} parcial(es)], {2} rechazado(s)",
                visibles, parciales, rechazados);

            lblResultado.Text = resultado;
            ActualizarEstado(resultado);
        }

        private void CargarDemo()
        {
            LimpiarTodo();

            // Ventana de recorte centrada
            _clipWindow.Bounds = new RectangleF(200, 150, 400, 280);

            // ── Segmento 1: Totalmente dentro ──────────────────
            _segments.Add(new LineSegment(
                new PointF(250, 200),
                new PointF(550, 380),
                "Seg 1 (dentro)"));

            // ── Segmento 2: Parcialmente visible (cruza izquierda) ──
            _segments.Add(new LineSegment(
                new PointF(50, 240),
                new PointF(400, 320),
                "Seg 2 (parcial-L)"));

            // ── Segmento 3: Parcialmente visible (cruza derecha) ──
            _segments.Add(new LineSegment(
                new PointF(400, 260),
                new PointF(720, 310),
                "Seg 3 (parcial-R)"));

            // ── Segmento 4: Parcialmente visible (cruza arriba y abajo) ──
            _segments.Add(new LineSegment(
                new PointF(350, 60),
                new PointF(370, 520),
                "Seg 4 (parcial-TB)"));

            // ── Segmento 5: Totalmente rechazado (fuera a la izquierda) ──
            _segments.Add(new LineSegment(
                new PointF(20, 100),
                new PointF(150, 500),
                "Seg 5 (fuera)"));

            _segmentCounter = 5;

            ActualizarVentanaInfo();
            ActualizarListBox();
            ActualizarContadorLineas();
            ActualizarEstado("Demo cargada con 5 segmentos. Presione 'Recortar' para ver el resultado.");
            drawingPanel.Invalidate();
        }

        private void LimpiarTodo()
        {
            _segments.Clear();
            _clipWindow.Bounds = RectangleF.Empty;
            _waitingForSecondClick = false;
            _isDragging = false;
            _previewRect = RectangleF.Empty;
            _currentMode = DrawingToolMode.None;
            _segmentCounter = 0;
            _clipped = false;

            listBoxSegmentos.Items.Clear();
            lblInfoContenido.Text = "Seleccione un segmento\npara ver sus detalles.";
            lblVentanaInfo.Text = "No definida";
            lblResultado.Text = "Sin recorte";
            drawingPanel.Cursor = Cursors.Cross;

            foreach (ToolStripButton btn in new[] { btnNuevoSegmento, btnNuevaVentana })
                btn.Checked = false;

            ActualizarContadorLineas();
            ActualizarEstado("Canvas limpiado. Seleccione una herramienta para comenzar.");
            drawingPanel.Invalidate();
        }

        private void DibujarCuadricula(Graphics g)
        {
            const int paso = 30;
            using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(45, 255, 255, 255)))
            {
                for (int x = 0; x < drawingPanel.Width; x += paso)
                {
                    for (int y = 0; y < drawingPanel.Height; y += paso)
                    {
                        g.FillEllipse(dotBrush, x - 1, y - 1, 2, 2);
                    }
                }
            }
        }

        private void DibujarSegmento(Graphics g, LineSegment seg)
        {
            // Línea original (gris, punteada)
            using (Pen originalPen = new Pen(seg.OriginalColor, 1.5f))
            {
                originalPen.DashStyle = DashStyle.Dash;
                g.DrawLine(originalPen, seg.Start, seg.End);
            }

            // Puntos extremos originales
            DibujarPuntoExtremo(g, seg.Start, seg.OriginalColor);
            DibujarPuntoExtremo(g, seg.End, seg.OriginalColor);

            // Porción recortada visible (verde sólida, más gruesa)
            if (_clipped && seg.IsVisible)
            {
                using (Pen clippedPen = new Pen(seg.ClippedColor, 2.5f))
                {
                    g.DrawLine(clippedPen, seg.ClippedStart, seg.ClippedEnd);
                }

                DibujarPuntoExtremo(g, seg.ClippedStart, seg.ClippedColor);
                DibujarPuntoExtremo(g, seg.ClippedEnd, seg.ClippedColor);
            }

            // Etiqueta con el nombre del segmento
            DibujarEtiqueta(g, seg);
        }

        private void DibujarPuntoExtremo(Graphics g, PointF pt, Color color)
        {
            const int r = 3;
            using (SolidBrush b = new SolidBrush(color))
            {
                g.FillEllipse(b, pt.X - r, pt.Y - r, r * 2, r * 2);
            }
        }

        private void DibujarEtiqueta(Graphics g, LineSegment seg)
        {
            PointF mid = new PointF(
                (seg.Start.X + seg.End.X) / 2f + 4,
                (seg.Start.Y + seg.End.Y) / 2f - 12);

            using (Font f = new Font("Consolas", 7.5f))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(180, Color.White)))
            {
                g.DrawString(seg.Name, f, b, mid);
            }
        }

        private void DibujarPreviewSegmento(Graphics g)
        {
            using (Pen pen = new Pen(Color.FromArgb(120, Color.White), 1f))
            {
                pen.DashStyle = DashStyle.Dot;
                g.DrawLine(pen, _firstPoint, _mousePos);
            }
        }

        private void DibujarMarcadorPunto(Graphics g, PointF pt)
        {
            const int r = 5;
            using (Pen pen = new Pen(Color.Yellow, 1.5f))
            {
                g.DrawEllipse(pen, pt.X - r, pt.Y - r, r * 2, r * 2);
            }
            using (SolidBrush b = new SolidBrush(Color.Yellow))
            {
                g.FillEllipse(b, pt.X - 2, pt.Y - 2, 4, 4);
            }
        }

        private void DibujarPreviewVentana(Graphics g)
        {
            using (Pen pen = new Pen(Color.FromArgb(160, Color.OrangeRed), 1.5f))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen,
                    _previewRect.X, _previewRect.Y,
                    _previewRect.Width, _previewRect.Height);
            }
        }

        private void ActualizarEstado(string mensaje)
        {
            lblEstado.Text = mensaje;
        }


        private void ActualizarContadorLineas()
        {
            lblLineas.Text = string.Format("Líneas: {0}", _segments.Count);
        }


        private void ActualizarListBox()
        {
            listBoxSegmentos.Items.Clear();
            foreach (LineSegment seg in _segments)
                listBoxSegmentos.Items.Add(seg.ToString());
        }


        private void ActualizarVentanaInfo()
        {
            if (_clipWindow.IsDefined)
            {
                lblVentanaInfo.Text = string.Format(
                    "X:{0:F0} Y:{1:F0}\nW:{2:F0} H:{3:F0}",
                    _clipWindow.Left, _clipWindow.Top,
                    _clipWindow.Bounds.Width, _clipWindow.Bounds.Height);
            }
            else
            {
                lblVentanaInfo.Text = "No definida";
            }
        }


        private void ListBoxSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBoxSegmentos.SelectedIndex;
            if (idx < 0 || idx >= _segments.Count)
            {
                lblInfoContenido.Text = "Seleccione un segmento\npara ver sus detalles.";
                return;
            }

            LineSegment seg = _segments[idx];
            string estado = seg.IsVisible
                ? (seg.IsClipped ? "Parcialmente visible" : "Totalmente visible")
                : (_clipped ? "Rechazado" : "Sin recortar");

            lblInfoContenido.Text = string.Format(
                "Nombre : {0}\n" +
                "─────────────────\n" +
                "Inicio  : ({1:F1}, {2:F1})\n" +
                "Fin     : ({3:F1}, {4:F1})\n" +
                "Long.   : {5:F1} px\n" +
                "─────────────────\n" +
                "C.Start : ({6:F1}, {7:F1})\n" +
                "C.End   : ({8:F1}, {9:F1})\n" +
                "C.Long. : {10:F1} px\n" +
                "─────────────────\n" +
                "Estado  : {11}",
                seg.Name,
                seg.Start.X, seg.Start.Y,
                seg.End.X, seg.End.Y,
                seg.Length,
                seg.ClippedStart.X, seg.ClippedStart.Y,
                seg.ClippedEnd.X, seg.ClippedEnd.Y,
                seg.ClippedLength,
                estado);
        }


        private void ResaltarBotonActivo(ToolStripButton activo)
        {
            btnNuevoSegmento.Checked = false;
            btnNuevaVentana.Checked = false;
            activo.Checked = true;
        }


        private static void SetDoubleBuffer(Control control, bool enable)
        {
            System.Reflection.PropertyInfo prop =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            prop?.SetValue(control, enable, null);
        }


        /// Construye un <see cref="RectangleF"/> normalizado a partir de dos puntos,

        private static RectangleF RectangleFromPoints(PointF a, PointF b)
        {
            float x = Math.Min(a.X, b.X);
            float y = Math.Min(a.Y, b.Y);
            float w = Math.Abs(b.X - a.X);
            float h = Math.Abs(b.Y - a.Y);
            return new RectangleF(x, y, w, h);
        }
    }
}