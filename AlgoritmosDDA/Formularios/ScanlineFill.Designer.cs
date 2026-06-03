using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosDDA.Formularios
{
    partial class ScanlineFill
    {
        private Panel _canvasPanel;
        private Button _btnNewPoly;
        private Button _btnClosePoly;
        private Button _btnClear;

        private void InitializeComponent()
        {
            this._canvasPanel = new Panel();
            this._btnNewPoly = new Button();
            this._btnClosePoly = new Button();
            this._btnClear = new Button();

            // Canvas
            _canvasPanel.Dock = DockStyle.Fill;
            _canvasPanel.BackColor = Color.White;
            _canvasPanel.Paint += OnCanvasPaint;
            _canvasPanel.MouseClick += OnCanvasMouseClick;

            // Botón Nuevo
            _btnNewPoly.Text = "Nuevo Polígono";
            _btnNewPoly.Dock = DockStyle.Top;
            _btnNewPoly.Click += (s, e) => StartNewPolygon();

            // Botón Cerrar
            _btnClosePoly.Text = "Cerrar Polígono";
            _btnClosePoly.Dock = DockStyle.Top;
            _btnClosePoly.Click += (s, e) => CloseActivePolygon();

            // Botón Limpiar
            _btnClear.Text = "Limpiar";
            _btnClear.Dock = DockStyle.Top;
            _btnClear.Click += (s, e) => ClearCanvas();

            // Form
            this.Controls.Add(_canvasPanel);
            this.Controls.Add(_btnNewPoly);
            this.Controls.Add(_btnClosePoly);
            this.Controls.Add(_btnClear);
            this.Text = "Scanline Fill Básico";
            this.ClientSize = new Size(800, 600);
        }
    }
}

