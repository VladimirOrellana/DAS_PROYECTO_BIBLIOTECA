using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace DAS_BIBLIOTECA
{
    public partial class grafico : Form
    {
        public grafico()
        {
            InitializeComponent();
        }

        private void grafico_Load(object sender, EventArgs e)
        {   //vectors data
            string[] series = { "J. K. ROWLING", "MIGUEL CERVANTES", "JULIO VERNE", "CHARLES DICKEN", "EDGAR ALLAN POE" };
            int[] puntos = { 7, 1, 3, 1, 4 };
            //cambio de color
            chart1.Palette = ChartColorPalette.Grayscale;

            chart1.Titles.Add("libros por autor");

            for (int i = 0; i < series.Length; i++)
            {

                //titulos
                Series Serie = chart1.Series.Add(series[i]);

                //cantidades
                Serie.Label = puntos[i].ToString();

                Serie.Points.Add(puntos[i]);

            }



        }
    }
}

