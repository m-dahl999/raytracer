using Raytracer.Utilities;
using Raytracer.Vectors;

namespace Raytracer.Scene
{
    public interface IPhysical
    {
        public Hit? Hit(Ray ray, Interval interval);
        public Vec3 AttenuateColor(Vec3 color);
    }
}
