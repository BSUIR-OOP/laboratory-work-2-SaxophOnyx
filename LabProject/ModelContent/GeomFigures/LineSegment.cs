using System.Windows;

namespace LabProject
{
    public class LineSegment : AbstractFigure
    {
        public Point A { get; set; }

        public Point B { get; set; }


        public LineSegment(Point a, Point b)
            : base()
        {
            A = a;
            B = b;
        }
    }
}
