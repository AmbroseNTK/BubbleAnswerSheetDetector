using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectorHelper
{
    public class Line
    {
        private Point pointA;
        private Point pointB;

        public Line() { }
        public Line(Point pointA, Point pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }

        public Point PointA { get => pointA; set => pointA = value; }
        public Point PointB { get => pointB; set => pointB = value; }

        public PointF DirectorVector
        {
            get => new PointF(pointA.X - pointB.X, PointA.Y - pointB.Y);
        }
        public PointF NormalVector
        {
            get => new PointF(DirectorVector.Y, -DirectorVector.X);
        }

        public double CFactor => -NormalVector.X * pointA.X - NormalVector.Y * pointA.Y;

        public static double Distance(Point pointA, Point pointB)
        => Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2));

        public static double Distance(Line line, Point point)
        => Math.Abs(line.NormalVector.X * point.X + line.NormalVector.Y * point.Y + line.CFactor) / Math.Sqrt(Math.Pow(line.NormalVector.X, 2) + Math.Pow(line.NormalVector.Y, 2));


        public static double AngleBetween(Line line1, Line line2)
        => Math.Acos(
            Math.Abs(line1.NormalVector.X * line2.NormalVector.X + line1.NormalVector.Y * line2.NormalVector.Y)
            / (Math.Sqrt(Math.Pow(line1.NormalVector.X, 2) + Math.Pow(line1.NormalVector.Y, 2)) * Math.Pow(line2.NormalVector.X, 2) + Math.Pow(line2.NormalVector.Y, 2)));
    }
    public class DiagonalLineFinder
    {
        private Point[] contourPoints;

        public Point[] ContourPoints { get => contourPoints; set => contourPoints = value; }
        public Line FirstLine { get => firstLine; set => firstLine = value; }
        public Line SecondLine { get => secondLine; set => secondLine = value; }

        private Line firstLine;
        private Line secondLine;

        public void Find()
        {
            Point maxPointA = new Point();
            Point maxPointB = new Point();
            double maxDistance = 0;
            for(int i = 0; i < contourPoints.Length; i++)
            {
                for(int j = 0; j < contourPoints.Length; j++)
                {
                    double currentDistance = Line.Distance(contourPoints[i], contourPoints[j]);
                    if (currentDistance > maxDistance)
                    {
                        maxDistance = currentDistance;
                        maxPointA = contourPoints[i];
                        maxPointB = contourPoints[j];
                    }
                }
            }
            firstLine = new Line(maxPointA, maxPointB);

        }

    }
}
