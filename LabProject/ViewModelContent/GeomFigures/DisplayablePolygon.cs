using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;

namespace LabProject
{
    public sealed class DisplayablePolygon : Polygon, IDisplayable
    {
        public DisplayablePolygon(IEnumerable<Point> points)
            : base(points)
        {

        }


        ShapeInfo IDisplayable.GetShapeInfo()
        {
            System.Windows.Shapes.Polygon shape = new System.Windows.Shapes.Polygon();

            foreach (Point p in Points)
                shape.Points.Add(p);

            shape.Margin = new Thickness(0, 0, 0, 0);
            shape.Stroke = new SolidColorBrush(OutlineColor);
            shape.StrokeThickness = OutlineThickness;
            shape.Fill = new SolidColorBrush(FillingColor);

            Point left = shape.Points.OrderBy(p => p.X).First();
            Point top = shape.Points.OrderBy(p => p.Y).First();
            Point right = shape.Points.OrderBy(p => p.X).Last();
            Point bottom = shape.Points.OrderBy(p => p.Y).Last();

            Rect bb = new Rect(left.X, top.Y, right.X - left.X + shape.StrokeThickness * 2, bottom.Y - top.Y + shape.StrokeThickness * 2);

            return new ShapeInfo(shape, bb);
        }
    }
}
