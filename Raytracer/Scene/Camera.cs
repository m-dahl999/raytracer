using Raytracer.Images;
using Raytracer.Vectors;
using Raytracer.Utilities;
using System;

namespace Raytracer.Scene
{
    public class CameraSettings
    {
        public int ImageWidth { get; set; }  
        public int ImageHeight { 
            get
            {
                if (AspectRatio == 0) return 0;
                else return (int)(((double)ImageWidth) / AspectRatio);
            }
        }

        public double AspectRatio;
        public int AntiAliasingSamples;
        public int MaxRays;
        public double VerticalFieldOfView;
        public Vec3 Center;

        public CameraSettings()
        {
            AntiAliasingSamples = 1;
            MaxRays = 1;
        }
    }

    public class Camera
    {
        private CameraSettings settings;
        private Viewport viewport;

        private static double GetLambertianIntensity(Vec3 incident, Vec3 normal)
        {
            return Vec3.Dot(incident, normal);
        }

        private static Vec3 GetRayColor(Ray ray, World world, int raysLeft)
        {
            if (raysLeft == 0)
                return new Vec3(0d, 0d, 0d);

            Hit? record = world.HitClosest(ray, new Interval(0.001d, double.PositiveInfinity));
            
            if (record != null)
            {
               Vec3 newRayDirection = Vec3.Unit(record.Normal + Util.RandomUnitVector());

               var hitIntensity = Math.Max(0, GetLambertianIntensity(newRayDirection, record.Normal));

               return hitIntensity * record.Object.AttenuateColor(GetRayColor(new Ray(record.Point, newRayDirection), world, raysLeft-1));
            }

            return new Vec3(0.5d, 0.7d, 1);
        }

        private Vec3 GetColorAntialiased(int i, int j, World world)
        {
            Vec3 sumColor = new Vec3();

            for (int k = 0; k < settings.AntiAliasingSamples; k++)
            {
                var ray = viewport.GetRayWithRandomOffset(i, j);
                sumColor += GetRayColor(ray, world, settings.MaxRays);
            }

            return sumColor * (1d/settings.AntiAliasingSamples);
        }

        public Camera(CameraSettings settings)
        {
            this.settings = settings;

            if (settings.ImageHeight <= 0) throw new ArgumentException("Image height can not be less than 1 pixel", "settings");

            viewport = new Viewport(settings);
        }

        public Pixel[][] Render(World world)
        {
            Pixel[][] result = new Pixel[settings.ImageHeight][];

            for (int i = 0; i < settings.ImageHeight; i++)
            {
                result[i] = new Pixel[settings.ImageWidth];

                for (int j = 0; j < settings.ImageWidth; j++)
                {
                    Vec3 color = GetColorAntialiased(i, j, world);
                    result[i][j] = new Pixel(color);
                }
            }

            return result;
        }
    }
}
