using System.Windows.Media;

namespace LabProject
{
    public abstract class AbstractFigure
    {
        public Color OutlineColor { get; set; }

        public double OutlineThickness { get; set; }


        public AbstractFigure()
        {
            OutlineColor = Color.FromArgb(255, 0, 0, 0);
            OutlineThickness = 1;
        }
    }
}
