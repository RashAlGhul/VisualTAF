using System.Drawing;
using NUnit.Framework;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture, Parallelizable]
    public class ImageWorkerNUnitTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string WinPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(DesktopPath);
        }

        [Test]
        public void FindSubImageTest()
        {
            ImageWorker.FindSubImage(DesktopPath, WinPath);
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
    }
}
