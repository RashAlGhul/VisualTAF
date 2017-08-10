using System.Drawing;
using ImageMagick;

namespace VisualTAF.Utils
{
    public class Assert
    {
        private static string message = "";
        public static void AreEqual(object expected, object actual, string condition)
        {
            if (expected.Equals(actual))
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.AreEqual(expected, actual, message);
            }
        }

        public static void True(bool expected, string condition)
        {
            if (expected)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info($"Assertion :: {condition} :: PASSED");
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.True(expected, message);
            }
        }

        public static void False(bool expected, string condition)
        {
            if (!expected)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.False(expected, message);
            }
        }

        public static void True(string pathToMainImage, string pathToSubImage, string condition)
        {
            bool findResult= ImageWorker.IsSubImageExist(pathToMainImage, pathToSubImage);
            if (findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                ImageWorker.FindSubImageAndSaveResultIntoFile(pathToMainImage, pathToSubImage, $"{ProjectPathHelper.DesktopPath}/{condition}PASS.png");
                Logger.Instance.Info($"Assertion :: {condition} :: PASSED");
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.True(findResult, message);
            }
        }

        public static void False(string pathToMainImage, string pathToSubImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(pathToMainImage, pathToSubImage);
            if (!findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FAILED";
                ImageWorker.FindSubImageAndSaveResultIntoFile(pathToMainImage, pathToSubImage, $"{ProjectPathHelper.DesktopPath}/{condition}FAIL.png");
                NUnit.Framework.Assert.False(findResult, message);
            }
        }

        public static void True(Image mainImage, Image subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{condition}PASS.png");
                Logger.Instance.Info($"Assertion :: {condition} :: PASSED");
            }
            else
            {
                message = $"Assertion :: {condition} :: FAILED";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.True(findResult, message);
            }
        }

        public static void False(Image mainImage, Image subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (!findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{message}.png");
                NUnit.Framework.Assert.False(findResult, message);
            }
        }

        public static void True(MagickImage mainImage, MagickImage subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{condition}PASS.png");
                Logger.Instance.Info($"Assertion :: {condition} :: PASSED");
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.True(findResult, message);
            }
        }

        public static void False(MagickImage mainImage, MagickImage subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (!findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{message}.png");
                NUnit.Framework.Assert.False(findResult, message);
            }
        }

        public static void True(Bitmap mainImage, Bitmap subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{condition}PASS.png");
                Logger.Instance.Info($"Assertion :: {condition} :: PASSED");
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                TakeScreenshot($"{condition}FAIL");
                NUnit.Framework.Assert.True(findResult, message);
            }
        }

        public static void False(Bitmap mainImage, Bitmap subImage, string condition)
        {
            bool findResult = ImageWorker.IsSubImageExist(mainImage, subImage);
            if (!findResult)
            {
                message = $"Assertion :: {condition} :: PASSED";
                TakeScreenshot($"{condition}PASS");
                Logger.Instance.Info(message);
            }
            else
            {
                message = $"Assertion :: {condition} :: FALSE";
                ImageWorker.FindSubImageAndSaveResultIntoFile(mainImage, subImage, $"{ProjectPathHelper.DesktopPath}/{message}.png");
                NUnit.Framework.Assert.False(findResult, message);
            }
        }

        private static void TakeScreenshot(string condition)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            string savepath = $"{ProjectPathHelper.DesktopPath}/{condition}.png";
            img.Save(savepath);
        }
    }
}
