using Raytracer.Scene;
using Raytracer.Utilities;
using Raytracer.Vectors;

namespace Raytracer.Tests
{
    [TestClass]
    public class HitTests
    {
        private static Sphere frontSphere = new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1, 0.1, 0.8));

        private static World testWorld = new World(new List<IPhysical>()
        {
           frontSphere,
           new Sphere(new Vec3(frontSphere.Center.X, frontSphere.Center.Y, frontSphere.Center.Z - 4), 0.5, new Vec3(0.1, 0.1, 0.8))
        });

        private static Ray hitRay = new Ray(new Vec3(0, 0, 0), new Vec3(0, 0, -1));
        private static Ray missRay = new Ray(new Vec3(0, 0, 0), new Vec3(0, 0.9, -0.2));

        private static Interval rayInterval = new Interval(0.0001d, double.PositiveInfinity);

        [TestMethod]
        public void HitSphere()
        {
            var record = frontSphere.Hit(hitRay, rayInterval);
            Assert.IsNotNull(record);
        }

        [TestMethod]
        public void MissSphere()
        {
            var record = frontSphere.Hit(missRay, rayInterval);
            Assert.IsNull(record);
        }

        [TestMethod]
        public void HitWorld()
        {
            var record = testWorld.HitClosest(hitRay, rayInterval);
            Assert.IsNotNull(record);
            Assert.AreEqual(record.Object, frontSphere);
        }

        [TestMethod]
        public void MissWorld()
        {
            var record = testWorld.HitClosest(missRay, rayInterval);
            Assert.IsNull(record);
        }
    }
}
