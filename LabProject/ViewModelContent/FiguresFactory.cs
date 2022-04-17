using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace LabProject
{
    public static class FiguresFactory
    {
        public static DisplayableCircle CreateDisplayableCircle(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 2;

            if (points.Count >= minPointsNumber)
            {
                Point center = points.Dequeue();
                Point point = points.Dequeue();

                DisplayableCircle circle = new DisplayableCircle(center, point)
                {
                    FillingColor = fillingColor,
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness
                };

                return circle;
            }
            else
                return null;
        }

        public static DisplayableDot CreateDisplayableDot(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 1;

            if (points.Count >= minPointsNumber)
            {
                Point point = points.Dequeue();

                DisplayableDot dot = new DisplayableDot(point.X, point.Y)
                {
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness
                };

                return dot;
            }
            else
                return null;
        }

        public static DisplayableEllipse CreateDisplayableEllipse(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 2;

            if (points.Count >= minPointsNumber)
            {
                Point point1 = points.Dequeue();
                Point point2 = points.Dequeue();

                DisplayableEllipse ellipse = new DisplayableEllipse(point1, point2)
                {
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness,
                    FillingColor = fillingColor
                };

                return ellipse;
            }
            else
                return null;
        }

        public static DisplayableLineSegment CreateDisplayableLineSegment(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 2;

            if (points.Count >= minPointsNumber)
            {
                Point point1 =  points.Dequeue();
                Point point2 = points.Dequeue();

                DisplayableLineSegment segment = new DisplayableLineSegment(point1, point2)
                {
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness
                };

                return segment;
            }
            else
                return null;
        }

        public static DisplayableRectangle CreateDisplayableRectangle(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 2;

            if (points.Count >= minPointsNumber)
            {
                Point point1 = points.Dequeue();
                Point point2 = points.Dequeue();

                DisplayableRectangle rectangle = new DisplayableRectangle(point1, point2)
                {
                    FillingColor = fillingColor,
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness
                };

                return rectangle;
            }
            else
                return null;
        }

        public static DisplayablePolygon CreateDisplayablePolygon(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 3;

            if (points.Count >= minPointsNumber)
            {
                DisplayablePolygon polygon = new DisplayablePolygon(points)
                {
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness,
                    FillingColor = fillingColor
                };

                points.Clear();
                return polygon;
            }
            else
                return null;
        }

        public static DisplayableRegularPolygon CreateDisplayableRegularPolygon(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness)
        {
            int minPointsNumber = 4;

            if (points.Count >= minPointsNumber)
            {
                Point center = points.Dequeue();
                Point point = points.Dequeue();

                DisplayableRegularPolygon polygon = new DisplayableRegularPolygon(center, point, points.Count + 1)
                {
                    OutlineColor = outlineColor,
                    OutlineThickness = outlineThickness,
                    FillingColor = fillingColor
                };

                points.Clear();
                return polygon;
            }
            else
                return null;
        }
    }
}
