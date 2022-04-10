using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace LabProject
{
    public class Polygon : ConnectedFigure
    {
        public PointCollection Points { get; set; }


        public Polygon(IEnumerable<Point> points)
        {
            Points = new PointCollection(points);
        }
    }
}
