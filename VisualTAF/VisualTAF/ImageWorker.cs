using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ImageMagick;

namespace VisualTAF
{
    public static class ImageWorker
    {
        public static double FindDifference(string oldPicturePath, string newPicturePath)
        {
            using (MagickImage oldImage = new MagickImage(oldPicturePath))
            {
                using (MagickImage newImages = new MagickImage(newPicturePath))
                {
                    return oldImage.Compare(newImages).NormalizedMeanError;
                }
            }
        }

        public static void TakeScreenshot(string savePath)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                screen.Write(savePath);
            }
        }

        public static void FindSubImage(string imagePath, string subImagePath)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(Image image, Image subImage)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap) image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap) subImage); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(Bitmap image, Bitmap subImage)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(MagickImage image, MagickImage subImage)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(string imagePath, string subImagePath, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }

        }

        public static void FindSubImage(Image image, Image subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(Bitmap image, Bitmap subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImage(MagickImage image, MagickImage subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static Point FindSubImageCoordinate(string image, string subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Image image, Image subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap) image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap) subImage); // Image A

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Bitmap image, Bitmap subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(MagickImage image, MagickImage subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); // Image A

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static bool IsSubImageExist(string image, string subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Image image, Image subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); // Image A

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Bitmap image, Bitmap subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); // Image A

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(MagickImage image, MagickImage subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); // Image A

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Point> FindSpecifiedColor(Bitmap image, Color specificColor)
        {
            MagickColor color = new MagickColor(specificColor);
            List<Point> colorCoordinates = new List<Point>();
            using (var magickImage = new MagickImage(image))
            {
                using (var pixels = magickImage.GetPixels())
                {
                    foreach (var pixel in pixels)
                    {
                        /* Exact match */
                        if (pixel.ToColor().Equals(color))
                        {
                            colorCoordinates.Add(new Point(pixel.X, pixel.Y));
                        }
                    }
                }
            }
            return colorCoordinates;
        }

        public static void FindSamePartsInImages(string etalonImagePath, string newImagePath)
        {
            var samePartImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\SameParts.png";

            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindSamePartsInImages(string etalonImagePath, string newImagePath, string defferenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, ErrorMetric.Absolute, diffImage);

                diffImage.Write(defferenceImageSavePath);
            }
        }
    }
}
