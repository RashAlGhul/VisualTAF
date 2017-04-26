using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VisualTAF.Tests.MSTests
{
    [TestClass]
    public class ImageWorkerMSTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string WinPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";

        [TestInitialize]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(DesktopPath);
        }

        [TestMethod]
        public void FindSubImageTest()
        {
            ImageWorker.FindSubImage(DesktopPath, WinPath);
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
    }
}
