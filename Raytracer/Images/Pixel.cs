using Raytracer.Vectors;

namespace Raytracer.Images
{
    public struct Pixel
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public Pixel() { }

        public Pixel(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Pixel(Vec3 vec) : this(vec.X, vec.Y, vec.Z)
        { }
    }
}
