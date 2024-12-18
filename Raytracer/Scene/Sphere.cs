using Raytracer.Utilities;
using Raytracer.Vectors;
using System;

namespace Raytracer.Scene
{
    public class Sphere : IPhysical
    {
        public Vec3 Center { get; private set; }    
        public double Radius { get; private set; }
        public Vec3 Attenuation { get; private set; }   

        public Sphere(Vec3 center, double radius, Vec3 attenuation)
        {
            Center = center;
            Radius = radius;
            Attenuation = attenuation;
        }

        public Hit? Hit(Ray ray, Interval interval)
        {
            Vec3 originToCenter = Center - ray.Origin;
            var a = ray.Direction.LengthSquared();
            var b = -2 * Vec3.Dot(ray.Direction, originToCenter);
            var c = originToCenter.LengthSquared() - Radius*Radius;

            var discriminant = b*b-4*a*c;

            if (discriminant < 0) 
                return null;

            double discrimSqrt = (double)Math.Sqrt(discriminant);

            double root = (-b - discrimSqrt) / (2*a);

            if (!interval.Around(root))
            {
                root = (-b + discrimSqrt) / (2 * a);

                if (!interval.Around(root))
                    return null;
            }

            var record = new Hit();

            record.TValue = root;
            record.Point = ray.At(root);
            record.Object = this;
            record.SetNormal(ray, (record.Point - Center) / Radius);

            return record;
        }

        public Vec3 AttenuateColor(Vec3 color)
        {
            return new Vec3(color.X*Attenuation.X, color.Y*Attenuation.Y, color.Z*Attenuation.Z);
        }
    }
}
