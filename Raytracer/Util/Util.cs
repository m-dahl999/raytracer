using Raytracer.Vectors;
using System;

namespace Raytracer.Utilities
{
    public static class Util
    {
        private static Interval UnitInterval = new Interval(-1d, 1d);

        private static Random _rand = new Random();

        public static double RandomInRange(Interval interval)
        {
            return interval.Min + (double)_rand.NextDouble() * interval.Size();
        }

        public static Vec3 RandomVector(Interval interval)
        {
            return new Vec3
            {
                X = RandomInRange(interval),
                Y = RandomInRange(interval),
                Z = RandomInRange(interval)
            };
        }

        public static Vec3 RandomUnitVector()
        {
            while (true)
            {
                Vec3 rndVec = RandomVector(UnitInterval);

                var lenSquared = rndVec.LengthSquared();

                if (1e-8 < lenSquared && lenSquared <= 1)
                    return rndVec / (double)Math.Sqrt(lenSquared);
            }
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180d;
        }
    }
}
