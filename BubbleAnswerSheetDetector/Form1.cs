using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util.TypeEnum;


namespace BubbleAnswerSheetDetector
{
    public partial class Form1 : Form
    {
        Mat inputMat;
        Mat edgeInput;
        Mat grayInput;
        Mat cropped;

        VectorOfVectorOfPoint docContours;
        VectorOfPointF docConers;

        float cutOffset = 5;

        Size answerSheetRealSize;
        public Form1()
        {
            InitializeComponent();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open image...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputMat = CvInvoke.Imread(openFileDialog.FileName, ImreadModes.AnyColor);
                    imageResult.Image = inputMat;
                }
                catch
                {
                    MessageBox.Show("Cannot open this image", "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            answerSheetRealSize = new Size(956,593);
        }

        private void btStep1_Click(object sender, EventArgs e)
        {
            grayInput = new Mat();
            CvInvoke.CvtColor(inputMat, grayInput, ColorConversion.Bgr2Gray);

            Mat gaussianInput = new Mat();
            CvInvoke.GaussianBlur(grayInput, gaussianInput, new Size(5, 5), 0);

            edgeInput = new Mat();
            CvInvoke.Canny(gaussianInput, edgeInput,75, 200);

            imageResult.Image = edgeInput;

        }

        private void btStep2_Click(object sender, EventArgs e)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            Mat hierarchy = new Mat();

            Image<Bgr, Byte> input = inputMat.ToImage<Bgr, Byte>();
            CvInvoke.FindContours(edgeInput.Clone(), contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            docContours = new VectorOfVectorOfPoint();

            docConers = new VectorOfPointF();

            for(int i = 0; i < contours.Size; i++)
            {
                double peri = CvInvoke.ArcLength(contours[i], true);
                VectorOfPoint poly = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contours[i], poly, 0.02 * peri, true);
                Rectangle docBounding = CvInvoke.BoundingRectangle(poly);
                if (poly.Size == 4 && docBounding.Width>500 &&docBounding.Height>300)
                {
                    PointF[] listConer = new PointF[4];

                    Point[] ps = poly.ToArray().OrderBy(point => point.X).ToArray<Point>();
                    if (ps[0].Y > ps[1].Y)
                    {
                        listConer[0] = ps[1];
                        listConer[3] = ps[0];
                    }
                    else
                    {
                        listConer[3] = ps[1];
                        listConer[0] = ps[0];
                    }

                    if (ps[2].Y < ps[3].Y)
                    {
                        listConer[1] = ps[2];
                        listConer[2] = ps[3];
                    }
                    else
                    {
                        listConer[2] = ps[2];
                        listConer[1] = ps[3];
                    }

                    listConer[0].X += cutOffset;
                    listConer[0].Y += cutOffset;

                    listConer[1].X -= cutOffset;
                    listConer[1].Y += cutOffset;

                    listConer[2].X -= cutOffset;
                    listConer[2].Y -= cutOffset;

                    listConer[3].X += cutOffset;
                    listConer[3].Y -= cutOffset;

                    docConers.Push(listConer);
                    MessageBox.Show("Document was discovered");
                    break;
                }
            }

            //CvInvoke.DrawContours(inputMat, contours, -1, new MCvScalar(255, 0, 0),3);

            imageResult.Image = inputMat;
            //if (contours.Size == 4)
            docContours = contours;

        }

        private void btStep3_Click(object sender, EventArgs e)
        {
            Mat paper = new Mat();

            Image<Gray, Byte> input = inputMat.ToImage<Gray, Byte>();
            cropped = new Mat();
            VectorOfPointF coners = new VectorOfPointF();

            //List<Point> contourPoints;

            ////find bounding contour
            //contourPoints = docContours.ToArrayOfArray()
            //    .Where(group => group.Length == docContours.ToArrayOfArray().Max(points => points.Length))
            //    .SingleOrDefault().ToList();



            Rectangle rect = CvInvoke.BoundingRectangle(docContours[0]);
            Mat quad = new Mat();
            quad.Create(answerSheetRealSize.Height, answerSheetRealSize.Width, DepthType.Cv8U, 0);
            VectorOfPointF quadPts = new VectorOfPointF();
            quadPts.Push(new PointF[] { new PointF(0, 0), new PointF(quad.Cols, 0), new PointF(quad.Cols, quad.Rows), new PointF(0, quad.Rows) });

            Mat transmat = CvInvoke.GetPerspectiveTransform(docConers, quadPts);
            CvInvoke.WarpPerspective(grayInput, cropped, transmat, quad.Size);
            imageResult.Image = cropped;
            //input.DrawPolyline(contourPoints.ToArray<Point>(), true, new Gray(0), 10);
            //imageResult.Image = input;
        }

        private void btStep4_Click(object sender, EventArgs e)
        {
            Mat thresh = new Mat();
            CvInvoke.Threshold(cropped, thresh, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(thresh.Clone(), contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            CvInvoke.DrawContours(cropped, contours, -1, new MCvScalar(0), 2);

            imageResult.Image = cropped;

            List<Point[]> questionContours = new List<Point[]>();

            for (int i = 0; i < contours.Size; i++)
            {
                VectorOfPoint contour = contours[i];
                Rectangle bounding = CvInvoke.BoundingRectangle(contour.GetInputArray().GetMat());
                double ratio = bounding.Width / bounding.Height;
                if (bounding.Width >= 20 && bounding.Height >= 20 && ratio >= 0.95 && ratio <= 1.05)
                {
                    questionContours.Add(contour.ToArray());
                    CvInvoke.Rectangle(thresh, bounding, new MCvScalar(255, 0, 0), 1);
                }
            }
            imageResult.Image = thresh;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GUI gui = new GUI();
            gui.Show();
        }
    }
}
