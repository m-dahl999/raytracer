using Raytracer.Vectors;

namespace Raytracer.Scene
{
    public class Hit
    {
        public Vec3 Point { get; set; }
        public Vec3 Normal { get; private set; }
        public double TValue { get; set; } 
        public IPhysical Object { get; set; }

        public void SetNormal(Ray ray, Vec3 outwardNormalUnit)
        {
            bool outwards = Vec3.Dot(ray.Direction, outwardNormalUnit) < 0;
            Normal = outwards ? outwardNormalUnit : -1d*outwardNormalUnit;
        }
    }
}
