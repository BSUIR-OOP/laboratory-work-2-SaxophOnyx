using System.Windows;
using System.Windows.Media;

namespace LabProject
{
    public sealed class DisplayableDot : Dot, IDisplayable
    {
        public DisplayableDot(double x, double y)
            : base(x, y)
        {

        }


        ShapeInfo IDisplayable.GetShapeInfo()
        {
            System.Windows.Shapes.Ellipse shape = new System.Windows.Shapes.Ellipse
            {
                Width = OutlineThickness,
                Height = OutlineThickness,
                Margin = new Thickness(X - OutlineThickness / 2, Y - OutlineThickness / 2, 0, 0),
                Stroke = new SolidColorBrush(OutlineColor),
                StrokeThickness = 0,
                Fill = new SolidColorBrush(OutlineColor)
            };

            Rect bb = new Rect(shape.Margin.Left, shape.Margin.Top, shape.Width, shape.Height);

            return new ShapeInfo(shape, bb);
        }
    }
}
