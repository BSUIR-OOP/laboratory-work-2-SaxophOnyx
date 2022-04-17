using System.Windows;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableCircle: Circle, IDisplayable
    {
        public DisplayableCircle(Point center, double radius)
            : base(center, radius)
        {

        }

        public DisplayableCircle(Point center, Point point)
            : base(center, point)
        {

        }


        ShapeInfo IDisplayable.GetShapeInfo()
        {
            System.Windows.Shapes.Ellipse shape = new System.Windows.Shapes.Ellipse
            {
                Width = Radius * 2,
                Height = Radius * 2,
                Margin = new Thickness(CenterPos.X - Radius, CenterPos.Y - Radius, 0, 0),
                Stroke = new SolidColorBrush(OutlineColor),
                StrokeThickness = OutlineThickness,
                Fill = new SolidColorBrush(FillingColor)
            };

            Rect bb = new Rect(shape.Margin.Left, shape.Margin.Top, shape.Width, shape.Height);

            return new ShapeInfo(shape, bb);
        }
    }
}
