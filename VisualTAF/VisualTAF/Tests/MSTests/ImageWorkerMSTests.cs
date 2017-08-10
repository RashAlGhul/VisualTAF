using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VisualTAF.Tests.MSTests
{
    [TestClass]
    public class ImageWorkerMSTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string WinPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";
        private const string DesktopDifferencePath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\DesktopDifference.png";

        [TestInitialize]
        public void SetUp()
        {
            ImageWorker.TakeScreenshotMagick(DesktopPath);
        }

        [TestMethod]
        public void FindSubImageTest()
        {
            ImageWorker.FindSubImageAndSaveResultIntoFile(DesktopPath, WinPath);
        }

        [TestMethod]
        public void SubImageExistTest()
        {
            Assert.IsTrue(ImageWorker.IsSubImageExist(DesktopPath, WinPath));
        }

        [TestMethod]
        public void FindSubImageCoordinatesTest()
        {
            Point subImageCoordinate = ImageWorker.FindSubImageCoordinate(DesktopPath, WinPath);
            Assert.IsFalse(subImageCoordinate.IsEmpty);
        }
        
        [TestMethod]
        public void FindDifferenceBetweenImagesTest()
        {
            ImageWorker.TakeScreenshotMagick(DesktopDifferencePath);
            ImageWorker.FindDifferenceBetweenImages(DesktopPath,DesktopDifferencePath);
        }
        
        [TestMethod]
        public void FindDifferenceImagesTest()
        {
            ImageWorker.TakeScreenshotMagick(DesktopDifferencePath);
            System.Console.Write(ImageWorker.FindDifference(DesktopPath,DesktopDifferencePath));
        }
    }
}
