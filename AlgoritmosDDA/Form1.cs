using AlgoritmosDDA.Formularios;
using LiangBarskyApp;
using NLNApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosDDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ejercicio1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgoritmoDDA1 algoritmoDDA1 = new AlgoritmoDDA1();
            algoritmoDDA1.Show();
        }


        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuntoMedio frmPuntoMedio = new FrmPuntoMedio();
            frmPuntoMedio.Show();
        }

        private void curvaDeBézierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBezier frmBezier = new FrmBezier();
            frmBezier.Show();
        }

        private void circuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCirculoBase frmCirculoBase = new FrmCirculoBase();
            frmCirculoBase.Show();
        }

        private void polaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPolares frmPolares = new FrmPolares();
            frmPolares.Show();
        }

        private void métodoRotacióMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetodoCirculoMatrices metodoCirculoMatrices = new MetodoCirculoMatrices();
            metodoCirculoMatrices.Show();
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FloodFill floodFill = new FloodFill();
            floodFill.Show();
        }

        private void boundaryFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoundaryFill boundaryFill = new BoundaryFill();
            boundaryFill.Show();
        }

        private void scanLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanlineFill scanlineFill = new ScanlineFill();
            scanlineFill.Show();
        }

        private void cohenSutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CohenSutherlandForm cohenSutherlandForm = new CohenSutherlandForm();
            cohenSutherlandForm.Show();
        }

        private void liangBarskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiangBarskyForm liangBarskyForm = new LiangBarskyForm();
            liangBarskyForm.Show();
        }

        private void nichollLeeNichollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NichollLeeNichollForm nichollLeeNichollForm = new NichollLeeNichollForm();
            nichollLeeNichollForm.Show();
        }
    }
}
