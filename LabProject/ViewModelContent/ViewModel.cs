using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LabProject
{
    public delegate IDisplayable CreateDisplayableFigure(Queue<Point> points, Color fillingColor, Color outlineColor, byte outlineThickness);


    public partial class ViewModel: INotifyPropertyChanged
    {
        private List<IDisplayable> _figures;

        private Queue<Point> _markupPoints;

        private ObservableCollection<ButtonWrapper> _buttonWrappers;

        public ReadOnlyObservableCollection<ButtonWrapper> ButtonWrappers { get; }

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

            _buttonWrappers = new ObservableCollection<ButtonWrapper>();
            ButtonWrappers = new ReadOnlyObservableCollection<ButtonWrapper>(_buttonWrappers);

            AddButtonWrapper(FiguresFactory.CreateDisplayableDot, "Добавить точку");
            AddButtonWrapper(FiguresFactory.CreateDisplayableLineSegment, "Добавить отрезок");
            AddButtonWrapper(FiguresFactory.CreateDisplayableCircle, "Добавить круг");
            AddButtonWrapper(FiguresFactory.CreateDisplayableRectangle, "Добавить прямоугольник");
            AddButtonWrapper(FiguresFactory.CreateDisplayableEllipse, "Добавить эллипс");
            AddButtonWrapper(FiguresFactory.CreateDisplayablePolygon, "Добавить многоугольник");
            AddButtonWrapper(FiguresFactory.CreateDisplayableRegularPolygon, "Добавить правильный многоугольник");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddButtonWrapper(CreateDisplayableFigure method, string content)
        {
            _buttonWrappers.Add(new ButtonWrapper(new AddFigureCommand(AddFigure, method), content));
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

        private void AddFigure(CreateDisplayableFigure method)
        {
            IDisplayable figure = method(_markupPoints, FillingColor.GetColor(), OutlineColor.GetColor(), OutlineThickness);

            if (figure != null)
            {
                _figures.Add(figure);
                RedrawBitmap();
            }
        }
    }
}

