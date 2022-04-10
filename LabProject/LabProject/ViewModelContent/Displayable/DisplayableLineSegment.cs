using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableLineSegment : LineSegment, IDisplayable
    {
        public DisplayableLineSegment(Point a, Point b)
            : base(a, b)
        {

        }


        Shape IDisplayable.CreateShape()
        {
            Line shape = new Line
            {
                X1 = A.X,
                Y1 = A.Y,
                X2 = B.X,
                Y2 = B.Y,
                Margin = new Thickness(0, 0, 0, 0),
                Stroke = new SolidColorBrush(OutlineColor),
                StrokeThickness = OutlineThickness,
                Fill = new SolidColorBrush(OutlineColor)
            };

            return shape;
        }
    }
}
