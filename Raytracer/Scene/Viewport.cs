using Raytracer.Utilities;
using Raytracer.Vectors;
using System;

namespace Raytracer.Scene
{
    public class Viewport
    {
        private static readonly Interval OffsetInterval = new Interval(-0.5d, 0.5d);

        private Vec3 firstPixel;
        private Vec3 pixelDeltaX;
        private Vec3 pixelDeltaY;
        private Vec3 cameraCenter;

        private static Vec3 OffsetPixel(Vec3 p0, Vec3 deltaU, Vec3 deltaV, double yI, double wI)
        {
            return p0 + wI * deltaU + yI * deltaV;
        }

        public Viewport(CameraSettings settings)
        {
            cameraCenter = settings.Center;

            double halfViewportHeight = Math.Tan(settings.VerticalFieldOfView / 2);

            double focalLength = 1;

            double viewportHeight = 2 * halfViewportHeight * focalLength;
            double viewportWidth = viewportHeight * settings.AspectRatio;

            Vec3 viewportX = new Vec3(viewportWidth, 0, 0);
            Vec3 viewportY = new Vec3(0, -viewportHeight, 0);

            pixelDeltaX = viewportX / settings.ImageWidth;
            pixelDeltaY = viewportY / settings.ImageHeight;

            Vec3 viewportUpperLeft = cameraCenter - new Vec3(0, 0, focalLength)
                                            - viewportX / 2 - viewportY / 2;

            // nice to have for later, makes things a lil shorter
            firstPixel = OffsetPixel(viewportUpperLeft, pixelDeltaX, pixelDeltaY, 0.5d, 0.5d);
        }

        private static double RandomOffset()
        {
            return Util.RandomInRange(OffsetInterval);
        }

        public Ray GetRay(double i, double j)
        {
            // somewhere around pixel center
            Vec3 cameraPoint = OffsetPixel(firstPixel, pixelDeltaX, pixelDeltaY, i, j);

            Vec3 rayDirection = cameraPoint - cameraCenter;

            return new Ray(cameraCenter, rayDirection);
        }

        public Ray GetRayWithRandomOffset(double i, double j)
        {
            return GetRay(i + RandomOffset(), j + RandomOffset());
        }
    }
}
