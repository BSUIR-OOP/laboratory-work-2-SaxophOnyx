using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableRegularPolygon : RegularPolygon, IDisplayable
    {
        public DisplayableRegularPolygon(Point center, int sidesCount, double sideLength)
            : base(center, sidesCount, sideLength)
        {

        }

        public DisplayableRegularPolygon(Point center, Point point, int verticesNumber)
            : base(center, point, verticesNumber)
        {

        }


        Shape IDisplayable.CreateShape()
        {
            System.Windows.Shapes.Polygon shape = new System.Windows.Shapes.Polygon();

            int N = SidesCount;
            double L = SideLength;

            double rad = L / (2 * Math.Sin(Math.PI / N));
            for (int i = 0; i < N; ++i)
            {
                double x = rad * Math.Cos(Math.PI / N * (2 * i + 1));
                double y = rad * Math.Sin(Math.PI / N * (2 * i + 1));
                shape.Points.Add(new Point(x + CenterPos.X, y + CenterPos.Y));
            }

            shape.Margin = new Thickness(0, 0, 0, 0);
            shape.Stroke = new SolidColorBrush(OutlineColor);
            shape.StrokeThickness = OutlineThickness;
            shape.Fill = new SolidColorBrush(FillingColor);

            return shape;
        }
    }
}
