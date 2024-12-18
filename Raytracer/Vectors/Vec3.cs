using System;

namespace Raytracer.Vectors
{
    public struct Vec3
    {
        public double X { get; set; }   
        public double Y { get; set; }
        public double Z { get; set; }

        public Vec3()
        {
                
        }

        public Vec3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vec3 operator +(Vec3 u, Vec3 v)
        {
            return new Vec3
            {
                X = u.X + v.X,
                Y = u.Y + v.Y,
                Z = u.Z + v.Z
            };
        }

        public static Vec3 operator -(Vec3 u, Vec3 v)
        {
            return new Vec3
            {
                X = u.X - v.X,
                Y = u.Y - v.Y,
                Z = u.Z - v.Z
            };
        }

        public static Vec3 operator *(Vec3 u, double scalar)
        {
            return new Vec3
            {
                X = u.X * scalar,
                Y = u.Y * scalar,
                Z = u.Z * scalar
            };
        }

        public static Vec3 operator *(double scalar, Vec3 u)
        {
            return u * scalar;
        }

        public static Vec3 operator /(Vec3 u, double scalar)
        {
            return u * (1 / scalar);
        }

        public double LengthSquared()
        {
            return Dot(this, this);
        }

        public double Length()
        {
            double selfDot = LengthSquared();
            return (double)Math.Sqrt(selfDot);
        }

        public static double Dot(Vec3 u, Vec3 v)
        {
            return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
        }

        public static Vec3 Unit(Vec3 u)
        {
            return u / u.Length();
        }

        public override string ToString()
        {
            return X + " " + Y + " " + Z;
        }
    }
}
