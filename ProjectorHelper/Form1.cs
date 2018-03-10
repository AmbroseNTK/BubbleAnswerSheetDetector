using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectorHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PointF[] points;
        private void tbLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Point data";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[]lines = System.IO.File.ReadAllText(openFileDialog.FileName).Split('\n');
                points = new PointF[lines.Length];
                for(int i = 0; i < lines.Length; i++)
                {
                    points[i] = new PointF(float.Parse(lines[i].Split(',')[0]), float.Parse(lines[i].Split(',')[1]));
                }
            }
            canvas1.Points = points;
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            canvas1.ZoomIn();
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            canvas1.ZoomOut();
        }
    }
}
