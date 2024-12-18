using Raytracer.Utilities;
using System;
using System.IO;
using System.Text;

namespace Raytracer.Images
{
    public static class PPM
    {
        private static Interval ColorFloatInterval = new Interval(0, 1);

        private static double GammaCorrect(double linearEquivelent)
        {
            if (linearEquivelent > 0)
                return Math.Sqrt(linearEquivelent);

            return 0;
        }

        private static byte Translate(double v)
        {
            return (byte)(255 * ColorFloatInterval.Clamp(GammaCorrect(v)));
        }

        private static string RawToPPM(Pixel[][] image)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("P3");
            sb.AppendLine(image[0].Length + " " + image.Length); // assume all rows have same length
            sb.AppendLine("255");

            for (int i = 0; i < image.Length; i++)
            {
                foreach (var pixel in image[i])
                {
                    sb.AppendLine(Translate(pixel.R) + " " + Translate(pixel.G) + " " + Translate(pixel.B));
                }

            }

            return sb.ToString();
        }

        public static void WriteImage(Pixel[][] image, string path)
        {
            string ppm = RawToPPM(image);
            File.WriteAllText(path, ppm);
        }
    }
}
