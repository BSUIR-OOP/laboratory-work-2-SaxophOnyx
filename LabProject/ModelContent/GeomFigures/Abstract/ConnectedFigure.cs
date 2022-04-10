using System.Windows.Media;

namespace LabProject
{
    public abstract class ConnectedFigure: AbstractFigure
    {
        public Color FillingColor { get; set; }


        public ConnectedFigure()
            : base()
        {
            FillingColor = Color.FromArgb(255, 0, 0, 0);
        }
    }
}
