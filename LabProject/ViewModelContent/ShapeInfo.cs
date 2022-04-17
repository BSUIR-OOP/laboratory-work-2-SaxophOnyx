using System.Windows;
using System.Windows.Shapes;

namespace LabProject
{
    public class ShapeInfo
    {
        public Shape Shape { get; set; }

        public Rect BoundingBox { get; set; }


        public ShapeInfo(Shape shape, Rect boundingBox)
        {
            Shape = shape;
            BoundingBox = boundingBox;
        }
    }
}
