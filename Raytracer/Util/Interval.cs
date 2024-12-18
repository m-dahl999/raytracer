namespace Raytracer.Utilities
{
    public class Interval
    {
        public double Min { get; private set; }
        public double Max { get; private set; }

        public Interval(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public Interval()
        {
            Min = double.NegativeInfinity;
            Max = double.PositiveInfinity;
        }

        public double Size()
        {
            return Max - Min;
        }

        public bool Contains(double x)
        {
            return Min <= x && x <= Max;
        }

        public bool Around(double x)
        {
            return Min < x && x < Max;
        }

        public double Clamp(double x)
        {
            if (x < Min) return Min;
            else if (x > Max) return Max;

            return x;
        }
    }
}
