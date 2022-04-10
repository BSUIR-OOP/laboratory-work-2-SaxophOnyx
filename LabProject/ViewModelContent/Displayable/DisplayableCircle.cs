using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

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


        Shape IDisplayable.CreateShape()
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

            return shape;
        }
    }
}
