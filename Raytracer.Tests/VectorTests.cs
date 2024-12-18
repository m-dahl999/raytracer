using Raytracer.Vectors;

namespace Raytracer.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void Addition()
        {
            var vec1 = new Vec3(3,2,1);
            var vec2 = new Vec3(1, 2, 3);

            var expectedResult = new Vec3(4, 4, 4);
            var actualResult = vec1+ vec2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Scaling()
        {
            var vec = new Vec3(3, 5, 2);
            double scalar = 4;

            var expectedResult = new Vec3(12, 20, 8);
            var actualResult = scalar * vec;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Dot()
        {
            var vec1 = new Vec3(6, 3, 4);
            var vec2 = new Vec3(2, 5, 3);

            double expectedResult = 39;
            double actualResult = Vec3.Dot(vec1, vec2);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
