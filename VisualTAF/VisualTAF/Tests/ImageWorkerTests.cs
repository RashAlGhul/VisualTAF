using System;
using System.Drawing;
using NUnit.Framework;

namespace VisualTAF.Tests
{
    [TestFixture, Parallelizable]
    public class ImageWorkerTests
    {
        private readonly string _desktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private readonly string _winPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(_desktopPath);
        }

        [Test]
        public void FindSubImageTest()
        {
            ImageWorker.FindSubImage(_desktopPath, _winPath);
        }

        [Test]
        public void SubImageExistTest()
        {
            Assert.IsTrue(ImageWorker.IsSubImageExist(_desktopPath, _winPath));
        }

        [Test]
        public void FindSubImageCoordinatesTest()
        {
            Point subImageCoordinate = ImageWorker.FindSubImageCoordinate(_desktopPath, _winPath);
            Assert.False(subImageCoordinate.IsEmpty);
        }
    }
}
