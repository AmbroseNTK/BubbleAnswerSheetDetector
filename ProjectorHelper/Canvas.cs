using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectorHelper
{
    public partial class Canvas : UserControl
    {
        public Canvas()
        {
            InitializeComponent();
        }

        private PointF[] points;
        private float zoomFactor = 1;

        public PointF[] Points
        {
            get => points;
            set
            {
                points = value;
                Invalidate();
            }
        }
        private void Canvas_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (points != null)
            {

                e.Graphics.DrawPolygon(new Pen(ForeColor), points);

            }
        }
        public void ZoomIn()
        {
            zoomFactor *= 0.5f;
            for(int i = 0; i < points.Length; i++)
            {
                points[i].X *= zoomFactor;
                points[i].Y *= zoomFactor;
            }
            Invalidate();
        }
        public void ZoomOut()
        {
            zoomFactor *= 2;
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X *= zoomFactor;
                points[i].Y *= zoomFactor;
            }
            Invalidate();
        }
    }
}
