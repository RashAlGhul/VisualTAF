using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ImageMagick;
using VisualTAF.Utils;

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
                    return 1-oldImage.Compare(newImages).NormalizedMeanError;
                }
            }
        }

        public static double FindDifference(Image oldPicture, Image newPicture)
        {
            using (MagickImage oldImage = new MagickImage((Bitmap)oldPicture))
            {
                using (MagickImage newImages = new MagickImage((Bitmap)newPicture))
                {
                    return 1 - oldImage.Compare(newImages).NormalizedMeanError;
                }
            }
        }

        public static double FindDifference(Bitmap oldPicture, Bitmap newPicture)
        {
            using (MagickImage oldImage = new MagickImage(oldPicture))
            {
                using (MagickImage newImages = new MagickImage(newPicture))
                {
                    return 1 - oldImage.Compare(newImages).NormalizedMeanError;
                }
            }
        }

        public static double FindDifference(MagickImage oldPicture, MagickImage newPicture)
        {
            using (MagickImage oldImage = oldPicture)
            {
                using (MagickImage newImages = newPicture)
                {
                    return 1 - oldImage.Compare(newImages).NormalizedMeanError;
                }
            }
        }

        public static void TakeScreenshot(string desktopSavePath)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            img.Save(desktopSavePath);
        }

        public static void TakeScreenshot()
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            img.Save($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
        }

        public static void TakeScreenshotMagick(string savePath)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                screen.Write(savePath);
            }
        }

        public static void TakeScreenshotMagick()
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                screen.Write($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(string imagePath, string subImagePath)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Image image, Image subImage)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap) image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap) subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Bitmap image, Bitmap subImage)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(MagickImage image, MagickImage subImage)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(string imagePath, string subImagePath, double threshold)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Image image, Image subImage, double threshold)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Bitmap image, Bitmap subImage, double threshold)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(MagickImage image, MagickImage subImage, double threshold)
        {
            var diffImagePath = $@"{ProjectPathHelper.DesktopPath}\SearchResult.png";
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(string imagePath, string subImagePath, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }

        }

        public static void FindSubImageAndSaveResultIntoFile(Image image, Image subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Bitmap image, Bitmap subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(MagickImage image, MagickImage subImage, string resultSavePath)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(string imagePath, string subImagePath, string resultSavePath, double threshold)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(imagePath); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImagePath); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }

        }

        public static void FindSubImageAndSaveResultIntoFile(Image image, Image subImage, string resultSavePath, double threshold)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(Bitmap image, Bitmap subImage, string resultSavePath, double threshold)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > threshold)
                {
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                }
            }

            using (MagickImage image1 = new MagickImage(imageToShow.Bitmap))
            {
                image1.Write(diffImagePath);
            }
        }

        public static void FindSubImageAndSaveResultIntoFile(MagickImage image, MagickImage subImage, string resultSavePath, double threshold)
        {
            var diffImagePath = resultSavePath;
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
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
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Image image, Image subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap) image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap) subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Bitmap image, Bitmap subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(MagickImage image, MagickImage subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(string image, string subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Image image, Image subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(Bitmap image, Bitmap subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static Point FindSubImageCoordinate(MagickImage image, MagickImage subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 

            Point leftUpperAngle = new Point();

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    leftUpperAngle = maxLocations[0];
                }
            }
            return leftUpperAngle;
        }

        public static bool IsSubImageExist(string image, string subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Image image, Image subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Bitmap image, Bitmap subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(MagickImage image, MagickImage subImage)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap()); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap()); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(string image, string subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Image image, Image subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>((Bitmap)image); 
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage); 

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Bitmap image, Bitmap subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image);
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                
                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(MagickImage image, MagickImage subImage, double threshold)
        {
            Image<Bgr, byte> source = new Image<Bgr, byte>(image.ToBitmap());
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap());

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                
                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(string subImage)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Image subImage)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Bitmap subImage)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(MagickImage subImage)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap());

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(string subImage, double threshold)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Image subImage, double threshold)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>((Bitmap)subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(Bitmap subImage, double threshold)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);


                if (maxValues[0] > threshold)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSubImageExist(MagickImage subImage, double threshold)
        {
            TakeScreenshot();
            Image<Bgr, byte> source = new Image<Bgr, byte>($@"{ProjectPathHelper.DesktopPath}\Desktop.png");
            Image<Bgr, byte> template = new Image<Bgr, byte>(subImage.ToBitmap());

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);


                if (maxValues[0] > threshold)
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

        public static void FindDifferenceBetweenImages(string etalonImagePath, string newImagePath)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(Image etalonImage, Image newImage)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage((Bitmap)etalonImage))

            using (MagickImage newI = new MagickImage((Bitmap)newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(Bitmap etalonImage, Bitmap newImage)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage(etalonImage))

            using (MagickImage newI = new MagickImage(newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(MagickImage etalonImage, MagickImage newImage)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = etalonImage)

            using (MagickImage newI = newImage)

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(string etalonImagePath, string newImagePath, ErrorMetric metric)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, metric, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(Image etalonImage, Image newImage, ErrorMetric metric)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage((Bitmap)etalonImage))

            using (MagickImage newI = new MagickImage((Bitmap)newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(Bitmap etalonImage, Bitmap newImage, ErrorMetric metric)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = new MagickImage(etalonImage))

            using (MagickImage newI = new MagickImage(newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(MagickImage etalonImage, MagickImage newImage, ErrorMetric metric)
        {

            var samePartImagePath = $@"{ProjectPathHelper.DesktopPath}\SameParts.png";

            using (MagickImage etalon = etalonImage)

            using (MagickImage newI = newImage)

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(samePartImagePath);
            }
        }

        public static void FindDifferenceBetweenImages(string etalonImagePath, string newImagePath, string differenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, ErrorMetric.Absolute, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(Image etalonImage, Image newImage, string differenceImageSavePath)
        {

            using (MagickImage etalon = new MagickImage((Bitmap)etalonImage))

            using (MagickImage newI = new MagickImage((Bitmap)newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(Bitmap etalonImage, Bitmap newImage, string differenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage(etalonImage))

            using (MagickImage newI = new MagickImage(newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(MagickImage etalonImage, MagickImage newImage, string differenceImageSavePath)
        {
            using (MagickImage etalon = etalonImage)

            using (MagickImage newI = newImage)

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, ErrorMetric.Absolute, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(string etalonImagePath, string newImagePath, ErrorMetric metric, string differenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage(etalonImagePath))

            using (MagickImage newImage = new MagickImage(newImagePath))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newImage, metric, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(Image etalonImage, Image newImage, ErrorMetric metric, string differenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage((Bitmap)etalonImage))

            using (MagickImage newI = new MagickImage((Bitmap)newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(Bitmap etalonImage, Bitmap newImage, ErrorMetric metric, string differenceImageSavePath)
        {
            using (MagickImage etalon = new MagickImage(etalonImage))

            using (MagickImage newI = new MagickImage(newImage))

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }

        public static void FindDifferenceBetweenImages(MagickImage etalonImage, MagickImage newImage, ErrorMetric metric, string differenceImageSavePath)
        {
            using (MagickImage etalon = etalonImage)

            using (MagickImage newI = newImage)

            using (MagickImage diffImage = new MagickImage())
            {
                etalon.Compare(newI, metric, diffImage);

                diffImage.Write(differenceImageSavePath);
            }
        }
    }
}
