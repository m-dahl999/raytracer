using Raytracer.Images;
using Raytracer.Scene;
using Raytracer.Utilities;
using Raytracer.Vectors;
using System.Collections.Generic;

namespace Raytracer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double aspectRatio = 16d / 9d;
            int imgWidth = 400;

            var settings = new CameraSettings()
            {
                ImageWidth = imgWidth,
                AspectRatio = aspectRatio,
                AntiAliasingSamples = 50,
                MaxRays = 500,
                VerticalFieldOfView = Util.DegreesToRadians(90)
            };

            var camera = new Camera(settings);

            World world = new World(new List<IPhysical>()
            {
                 new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1,0.1,0.8)),
                 new Sphere(new Vec3(-1d, 0, -1.5), 0.35d,  new Vec3(0.5, 0.5, 0.5)),
                 new Sphere(new Vec3(0, -100.5d, -1), 100d, new Vec3(0.3,1,0.3))
            });

            Pixel[][] result = camera.Render(world);

            PPM.WriteImage(result, "out.ppm");
        }
    }
}
