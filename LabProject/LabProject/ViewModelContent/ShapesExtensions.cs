using System;
using System.Linq;
using System.Windows;

namespace LabProject
{
    public static class ShapesExtensions
    {
        public static Rect GetBoundingBox(this System.Windows.Shapes.Polygon pol)
        {
            Point left = pol.Points.OrderBy(p => p.X).First();
            Point top = pol.Points.OrderBy(p => p.Y).First();
            Point right = pol.Points.OrderBy(p => p.X).Last();
            Point bottom = pol.Points.OrderBy(p => p.Y).Last();

            return new Rect(left.X, top.Y, right.X - left.X + pol.StrokeThickness * 2, bottom.Y - top.Y + pol.StrokeThickness * 2);
        }

        public static Rect GetBoundingBox(this System.Windows.Shapes.Line line)
        {
            double left = Math.Min(line.X1, line.X2);
            double top = Math.Min(line.Y1, line.Y2);
            double right = Math.Max(line.X1, line.X2);
            double bottom = Math.Max(line.Y1, line.Y2);

            return new Rect(left, top, (right - left) + line.StrokeThickness * 2, (bottom - top) + line.StrokeThickness * 2);
        }
    }
}
