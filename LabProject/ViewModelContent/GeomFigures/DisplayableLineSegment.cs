using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System;

namespace LabProject
{
    public sealed class DisplayableLineSegment : LineSegment, IDisplayable
    {
        public DisplayableLineSegment(Point a, Point b)
            : base(a, b)
        {

        }


        ShapeInfo IDisplayable.GetShapeInfo()
        {
            Line line = new Line
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

            double left = Math.Min(line.X1, line.X2);
            double top = Math.Min(line.Y1, line.Y2);
            double right = Math.Max(line.X1, line.X2);
            double bottom = Math.Max(line.Y1, line.Y2);

            Rect bb = new Rect(left, top, (right - left) + line.StrokeThickness * 2, (bottom - top) + line.StrokeThickness * 2);

            return new ShapeInfo(line, bb);
        }
    }
}
