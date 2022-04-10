using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableEllipse : Ellipse, IDisplayable
    {
        public DisplayableEllipse(Point center, double semiaxisX, double semiaxisY)
            : base(center, semiaxisX, semiaxisY)
        {

        }

        public DisplayableEllipse(Point point1, Point point2)
            : base(point1, point2)
        {

        }


        Shape IDisplayable.CreateShape()
        {
            System.Windows.Shapes.Ellipse shape = new System.Windows.Shapes.Ellipse
            {
                Width = SemiaxisX * 2,
                Height = SemiaxisY * 2,
                Margin = new Thickness(CenterPos.X - SemiaxisX, CenterPos.Y - SemiaxisY, 0, 0),
                Stroke = new SolidColorBrush(OutlineColor),
                StrokeThickness = OutlineThickness,
                Fill = new SolidColorBrush(FillingColor)
            };

            return shape;
        }
    }
}
