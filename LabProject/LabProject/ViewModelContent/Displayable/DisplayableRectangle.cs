using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableRectangle : Rectangle, IDisplayable
    {
        public DisplayableRectangle(Point center, double width, double height)
            : base(center, width, height)
        {

        }

        public DisplayableRectangle(Point point1, Point point2)
            : base(point1, point2)
        {

        }


        Shape IDisplayable.CreateShape()
        {
            System.Windows.Shapes.Rectangle shape = new System.Windows.Shapes.Rectangle
            {
                Height = Height,
                Width = Width,
                Margin = new Thickness(CenterPos.X - Width / 2, CenterPos.Y - Height / 2, 0, 0),
                Stroke = new SolidColorBrush(OutlineColor),
                StrokeThickness = OutlineThickness,
                Fill = new SolidColorBrush(FillingColor)
            };

            return shape;
        }
    }
}
