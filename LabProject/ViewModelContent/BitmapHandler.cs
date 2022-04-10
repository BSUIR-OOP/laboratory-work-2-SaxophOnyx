using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabProject
{
    public class BitmapHandler: INotifyPropertyChanged
    {
        private readonly double _dpiX;

        private readonly double _dpiY;

        public double BitmapWidth
        {
            get { return _bitmap.Width; }
        }

        public double BitmapHeight
        {
            get { return _bitmap.Height; }
        }

        private RenderTargetBitmap _bitmap;

        public RenderTargetBitmap Bitmap
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value;
                NotifyPropertyChanged(nameof(Bitmap));
            }
        }


        public BitmapHandler(int pixelWidth, int pixelHeight)
        {
            _dpiX = 96;
            _dpiY = 96;

            Bitmap = new RenderTargetBitmap(pixelWidth, pixelHeight, _dpiX, _dpiY, PixelFormats.Pbgra32);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Display(IDisplayable figure)
        {
            Shape shape = figure.CreateShape();
            shape.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            shape.Arrange(new Rect(0, 0, Bitmap.Width, Bitmap.Height));

            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(shape);

                if (shape is System.Windows.Shapes.Polygon)
                {
                    Rect bb = (shape as System.Windows.Shapes.Polygon).GetBoundingBox();
                    dc.DrawRectangle(vb, null, new Rect(bb.Left, bb.Top, bb.Width, bb.Height));
                }
                else if (shape is System.Windows.Shapes.Line)
                {
                    Rect bb = (shape as System.Windows.Shapes.Line).GetBoundingBox();
                    dc.DrawRectangle(vb, null, new Rect(bb.Left, bb.Top, bb.Width, bb.Height));
                }
                else
                    dc.DrawRectangle(vb, null, new Rect(new Point(shape.Margin.Left, shape.Margin.Top), new Size(shape.ActualWidth, shape.ActualHeight)));
            } 

            Bitmap.Render(visual);
        }

        public void Display(ICollection<IDisplayable> collection)
        {
            foreach (IDisplayable item in collection)
                Display(item);
        }

        public void DisplayMarkupPoint(Point point)
        {
            DisplayableDot dot = new DisplayableDot(point.X, point.Y)
            {
                OutlineThickness = 5,
                OutlineColor = Colors.Red
            };

            Display(dot);
        }

        public void DisplayMarkupPoint(IEnumerable<Point> points)
        {
            foreach (Point p in points)
                DisplayMarkupPoint(p);
        }

        public void Clear()
        {
            Bitmap.Clear();
        }
    }
}
