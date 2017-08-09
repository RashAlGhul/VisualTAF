using System.Drawing;
using NUnit.Framework;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture, Parallelizable]
    public class ImageWorkerNUnitTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string WinPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";
        private const string DesktopDifferencePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\DesktopDifference.png";

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(DesktopPath);
        }

        [Test]
        public void FindSubImageTest()
        {
            ImageWorker.FindSubImageAndSaveResultIntoFile(DesktopPath, WinPath);
        }

        [Test]
        public void SubImageExistTest()
        {
            Assert.IsTrue(ImageWorker.IsSubImageExist(DesktopPath, WinPath));
        }

        [Test]
        public void FindSubImageCoordinatesTest()
        {
            Point subImageCoordinate = ImageWorker.FindSubImageCoordinate(DesktopPath, WinPath);
            Assert.False(subImageCoordinate.IsEmpty);
        }
        
        [Test]
        public void FindDifferenceBetweenImagesTest()
        {
            ImageWorker.TakeScreenshot(DesktopDifferencePath);
            ImageWorker.FindDifferenceBetweenImages(DesktopPath,DesktopDifferencePath);
        }
        
        [Test]
        public void FindDifferenceImagesTest()
        {
            ImageWorker.TakeScreenshot(DesktopDifferencePath);
            System.Console.Write(ImageWorker.FindDifference(DesktopPath,DesktopDifferencePath));
        }
    }
}
