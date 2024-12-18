using Raytracer.Images;
using Raytracer.Scene;
using Raytracer.Utilities;
using Raytracer.Vectors;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Raytracer.SceneTests
{
    internal class Program
    {
        private static void Render(World world, string fileName)
        {
            Console.WriteLine("Rendering " + fileName);

            var stopWatch = new Stopwatch();

            double aspectRatio = 16d / 9d;
            int imgWidth = 400;

            var settings = new CameraSettings()
            {
                ImageWidth = imgWidth,
                AspectRatio = aspectRatio,
                AntiAliasingSamples = 100,
                MaxRays = 1000,
                VerticalFieldOfView = Util.DegreesToRadians(90)
            };

            var camera = new Camera(settings);

            stopWatch.Start();

            Pixel[][] result = camera.Render(world);

            PPM.WriteImage(result, fileName);

            stopWatch.Stop();

            Console.WriteLine("Rendering of " + fileName + " took about " + stopWatch.Elapsed.Seconds + "s");
        }

        private static void RenderEmpty()
        {
            World world = new World(new List<IPhysical>()
            { });

            Render(world, "empty.ppm");
        }

        private static void RenderSingleSphere()
        {
            World world = new World(new List<IPhysical>()
            {
                 new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1,0.1,0.8))
            });

            Render(world, "single.ppm");
        }

        private static void RenderSmallBigSphere()
        {
            World world = new World(new List<IPhysical>()
            {
                 new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1,0.1,0.8)),
                 new Sphere(new Vec3(0, -100.5d, -1), 100d, new Vec3(0.3,1,0.3))
            });

            Render(world, "small-big.ppm");
        }

        private static void RenderTwoSmallSpheres()
        {
            World world = new World(new List<IPhysical>()
            {
                 new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1,0.1,0.8)),
                  new Sphere(new Vec3(-1d, 0, -1.5), 0.35d, new Vec3(0.5, 0.5, 0.5))
            });

            Render(world, "two-small.ppm");
        }

        private static void RenderFullScene()
        {
            World world = new World(new List<IPhysical>()
            {
                 new Sphere(new Vec3(0, 0, -1), 0.5d, new Vec3(0.1,0.1,0.8)),
                 new Sphere(new Vec3(-1d, 0, -1.5), 0.35d, new Vec3(0.5, 0.5, 0.5)),
                 new Sphere(new Vec3(0, -100.5d, -1), 100d, new Vec3(0.3,1,0.3))
            });

            Render(world, "full.ppm");
        }

        static void Main(string[] args)
        {
            RenderEmpty();
            RenderSingleSphere();
            RenderSmallBigSphere();
            RenderTwoSmallSpheres();
            RenderFullScene();
        }
    }
}
