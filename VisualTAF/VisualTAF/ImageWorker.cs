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
    public class ImageWorker
    {
        public double FindDifference(string path1, string path2)
        {
            using (MagickImage image = new MagickImage(path1))
            {
                using (MagickImage images = new MagickImage(path2))
                {
                    return image.Compare(images).NormalizedMeanError;
                }
            }
        }

        public void TakeScreenshot(string savePath)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                screen.Write(savePath);
            }
        }

        public void FindSubImage(string imagePath, string subImagePath)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
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
            FindSpecifiedColor(imageToShow.ToBitmap());
            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }

        }

        public void FindSubImageWithClickOnIt(string imagePath, string subImagePath)
        {
            var diffImagePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResultToClick.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); // Image B
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.9)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    HelpMethods.Click(maxLocations[0].X, maxLocations[0].Y);
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }
            FindSpecifiedColor(imageToShow.ToBitmap());
            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }

        }

        public void FindSpecifiedColor(Bitmap image)
        {
            MagickColor color = new MagickColor(Color.Red);

            using (var magickImage = new MagickImage(image))
            {
                using (var pixels = magickImage.GetPixels())
                {
                    foreach (var pixel in pixels)
                    {
                        /* Exact match */
                        if (pixel.ToColor().Equals(color))
                        {
                            Console.WriteLine($"{pixel.X}, {pixel.Y}");
                            HelpMethods.DoubleClick(pixel.X,pixel.Y);
                            break;
                        }
                    }
                }
            }
        }

        public void FindSamePartsInImages(string etalonImagePath, string newImagePath)
        {
            var samePartImagePath = @"C:\Users\Yauheni_Dzima\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win";
            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {

                etalon.Compare(newImage, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath + "3.png");
            }
        }
    }
}
