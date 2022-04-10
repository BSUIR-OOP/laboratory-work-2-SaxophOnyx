namespace LabProject
{
    public class Dot : AbstractFigure
    {
        public double X { get; set; }

        public double Y { get; set; }


        public Dot(double x, double y)
            : base()
        {
            X = x;
            Y = y;
        }
    }
}
