using System.Drawing;
using NUnit.Framework;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture,Parallelizable]
    public class WinAPINUnitTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string ExplorerPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Explorer.png";
        private Point _clickPoint;

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(DesktopPath);
        }

        [Test]
        public void MouseMethodsTest()
        {
            Assert.True(ImageWorker.IsSubImageExist(DesktopPath, ExplorerPath));
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            MouseMethods.LMBClick(_clickPoint);
            MouseMethods.MoveToElemment(0,0);
        }

        [Test]
        public void KeyboardMethodsTest()
        {
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            KeyboardMethods.TypeText("V");
            KeyboardMethods.PressEnter();
            MouseMethods.MoveToElemment(0, 0);
        }
    }
}
