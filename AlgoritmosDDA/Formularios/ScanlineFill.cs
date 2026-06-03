using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosDDA.Clases;

namespace AlgoritmosDDA.Formularios
{
    public partial class ScanlineFill : Form
    {
        private PolygonBuffer _activePolygon;
        private List<PolygonBuffer> _scenePolygons;

        public ScanlineFill()
        {
            _scenePolygons = new List<PolygonBuffer>();
            InitializeComponent();
        }


        private void OnCanvasPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            foreach (var poly in _scenePolygons)
            {
                if (poly.IsValid)
                {
                    var vertices = poly.Vertices.ToArray();
                    g.FillPolygon(new SolidBrush(poly.FillColor), vertices);
                    g.DrawPolygon(Pens.White, vertices);

                    foreach (var v in vertices)
                    {
                        g.FillEllipse(Brushes.Red, v.X - 3, v.Y - 3, 6, 6);
                    }
                }
            }

            if (_activePolygon != null && _activePolygon.Vertices.Count > 0)
            {
                var vertices = _activePolygon.Vertices.ToArray();

                if (vertices.Length > 1)
                {
                    g.DrawLines(Pens.Yellow, vertices);
                }
                else
                {
                    g.FillEllipse(Brushes.Yellow, vertices[0].X - 4, vertices[0].Y - 4, 8, 8);
                }
            }

            this.Text = $"Scanline Fill Básico - Polígonos en escena: {_scenePolygons.Count}";
        }

        private void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            if (_activePolygon != null)
            {
                _activePolygon.AddVertex(e.Location);
                _canvasPanel.Invalidate();
            }
        }

        private void StartNewPolygon()
        {
            _activePolygon = new PolygonBuffer();
            _activePolygon.FillColor = Color.CornflowerBlue;
            MessageBox.Show("Nuevo polígono iniciado. Haz clic en el canvas para agregar vértices.");
        }

        private void CloseActivePolygon()
        {
            if (_activePolygon != null && _activePolygon.IsValid)
            {
                _scenePolygons.Add(_activePolygon);
                _activePolygon = null;
                _canvasPanel.Invalidate();
                MessageBox.Show("Polígono cerrado y agregado a la escena.");
            }
            else
            {
                MessageBox.Show("Necesitas al menos 3 vértices para cerrar el polígono.");
            }
        }

        private void ClearCanvas()
        {
            _scenePolygons.Clear();
            _activePolygon = null;
            _canvasPanel.Invalidate();
            MessageBox.Show("Canvas limpiado.");
        }

        private void DeleteLastPolygon()
        {
            if (_scenePolygons.Count > 0)
            {
                _scenePolygons.RemoveAt(_scenePolygons.Count - 1);
                _canvasPanel.Invalidate();
                MessageBox.Show("Último polígono eliminado.");
            }
            else
            {
                MessageBox.Show("No hay polígonos para eliminar.");
            }
        }
    }
}
