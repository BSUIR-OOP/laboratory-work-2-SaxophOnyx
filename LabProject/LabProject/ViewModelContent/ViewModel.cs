using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace LabProject
{
    public class ViewModel: INotifyPropertyChanged
    {
        private List<IDisplayable> _figures;

        private Queue<Point> _markupPoints;

        private ObservableCollection<ButtonWrapper> _buttonWrappers;

        public ObservableCollection<ButtonWrapper> ButtonWrappers
        {
            get { return _buttonWrappers; }
            set
            {
                _buttonWrappers = value;
                NotifyPropertyChanged(nameof(ButtonWrappers));
            }
        }

        public BitmapHandler BitmapHandler { get; set; }

        private ColorPicker _outlineColor;

        public ColorPicker OutlineColor
        {
            get { return _outlineColor; }
            set
            {
                _outlineColor = value;
                NotifyPropertyChanged(nameof(OutlineColor));
            }
        }

        private ColorPicker _fillingColor;

        public ColorPicker FillingColor
        {
            get { return _fillingColor; }
            set
            {
                _fillingColor = value;
                NotifyPropertyChanged(nameof(FillingColor));
            }
        }

        private byte _outlineThickness;

        public byte OutlineThickness
        {
            get { return _outlineThickness; }
            set
            {
                _outlineThickness = value;
                NotifyPropertyChanged(nameof(OutlineThickness));
            }
        }

        public ICommand ClearMarkupPointsCommand { get; set; }


        public ViewModel()
        {
            OutlineColor = new ColorPicker(255, 0, 0, 0);
            FillingColor = new ColorPicker(255, 0, 0, 0);
            OutlineThickness = 1;

            BitmapHandler = new BitmapHandler(1000, 600);
            _figures = new List<IDisplayable>();
            _markupPoints = new Queue<Point>();

            ClearMarkupPointsCommand = new DelegateCommand(ClearMarkupPoints);

            ButtonWrappers = new ObservableCollection<ButtonWrapper>
            {
                new ButtonWrapper(new DelegateCommand(CreateCircle), "Добавить круг"),
                new ButtonWrapper(new DelegateCommand(CreateRectangle), "Добавить прямоугольник"),
                new ButtonWrapper(new DelegateCommand(CreateDot), "Добавить точку"),
                new ButtonWrapper(new DelegateCommand(CreateLineSegment), "Добавить отрезок"),
                new ButtonWrapper(new DelegateCommand(CreateEllipse), "Добавить эллипс"),
                new ButtonWrapper(new DelegateCommand(CreatePolygon), "Добавить многоугольник"),
                new ButtonWrapper(new DelegateCommand(CreateRegularPolygon), "Добавить правильный многоугольник")
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddMarkupPoint(double x, double y)
        {
            Point point = new Point(x, y);

            _markupPoints.Enqueue(point);
            BitmapHandler.DisplayMarkupPoint(point);
        }

        private void RedrawBitmap()
        {
            BitmapHandler.Clear();
            BitmapHandler.Display(_figures);
            BitmapHandler.DisplayMarkupPoint(_markupPoints);
        }

        private void ClearMarkupPoints()
        {
            if (_markupPoints.Count > 0)
            {
                _markupPoints.Clear();
                RedrawBitmap();
            }
        }

        private void CreateCircle()
        {
            int minPointsNumber = 2;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point center = _markupPoints.Dequeue();
                Point point = _markupPoints.Dequeue();

                DisplayableCircle circle = new DisplayableCircle(center, point)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness,
                    FillingColor = FillingColor.GetColor()
                };

                _figures.Add(circle);
                RedrawBitmap();
            }
        }

        private void CreateRectangle()
        {
            int minPointsNumber = 2;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point point1 = _markupPoints.Dequeue();
                Point point2 = _markupPoints.Dequeue();

                DisplayableRectangle rectangle = new DisplayableRectangle(point1, point2)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness,
                    FillingColor = FillingColor.GetColor()
                };

                _figures.Add(rectangle);
                RedrawBitmap();
            }
        }

        private void CreateDot()
        {
            int minPointsNumber = 1;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point point = _markupPoints.Dequeue();

                DisplayableDot dot = new DisplayableDot(point.X, point.Y)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness
                };

                _figures.Add(dot);
                RedrawBitmap();
            }
        }

        private void CreateLineSegment()
        {
            int minPointsNumber = 2;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point point1 = _markupPoints.Dequeue();
                Point point2 = _markupPoints.Dequeue();

                DisplayableLineSegment segment = new DisplayableLineSegment(point1, point2)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness
                };

                _figures.Add(segment);
                RedrawBitmap();
            }
        }

        private void CreateEllipse()
        {
            int minPointsNumber = 2;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point point1 = _markupPoints.Dequeue();
                Point point2 = _markupPoints.Dequeue();

                DisplayableEllipse ellipse = new DisplayableEllipse(point1, point2)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness,
                    FillingColor = FillingColor.GetColor()
                };

                _figures.Add(ellipse);
                RedrawBitmap();
            }
        }

        private void CreatePolygon()
        {
            int minPointsNumber = 3;

            if (_markupPoints.Count >= minPointsNumber)
            {
                DisplayablePolygon polygon = new DisplayablePolygon(_markupPoints)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness,
                    FillingColor = FillingColor.GetColor()
                };

                _figures.Add(polygon);
                _markupPoints.Clear();
                RedrawBitmap();
            }
        }

        private void CreateRegularPolygon()
        {
            int minPointsNumber = 3;

            if (_markupPoints.Count >= minPointsNumber)
            {
                Point center = _markupPoints.Dequeue();
                Point point = _markupPoints.Dequeue();

                DisplayableRegularPolygon polygon = new DisplayableRegularPolygon(center, point, _markupPoints.Count + 2)
                {
                    OutlineColor = OutlineColor.GetColor(),
                    OutlineThickness = OutlineThickness,
                    FillingColor = FillingColor.GetColor()
                };

                _figures.Add(polygon);
                _markupPoints.Clear();
                RedrawBitmap();
            }
        }
    }
}

