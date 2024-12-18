using Raytracer.Utilities;
using Raytracer.Vectors;
using System.Collections.Generic;

namespace Raytracer.Scene
{
    public class World
    {
        public List<IPhysical> Children { get; set; }

        public World(List<IPhysical> children)
        {
            Children = children;
        }

        public World() : this(new List<IPhysical>())
        { }

        public Hit? HitClosest(Ray ray, Interval interval)
        {
            var temporaryRecord = new Hit();
            bool hasHitSomething = false;
            var closestPointSoFar = interval.Max;

            foreach (var child in Children)
            {
                var rec = child.Hit(ray, new Interval(interval.Min, closestPointSoFar));

                if (rec != null)
                {
                    temporaryRecord = rec;
                    hasHitSomething = true;
                    closestPointSoFar = temporaryRecord.TValue;
                }
            }

            if (hasHitSomething) return temporaryRecord;
            else return null;
        }
    }
}
