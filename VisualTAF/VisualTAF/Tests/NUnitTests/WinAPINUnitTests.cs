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
            Assert.IsTrue(ImageWorker.IsSubImageExist(DesktopPath, ExplorerPath));
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
        }

        [Test]
        public void MouseMethodsTest()
        {
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            MouseMethods.LMBClick(_clickPoint);
            MouseMethods.CursorPosition();
        }

        [Test]
        public void KeyboardMethodsTest()
        {
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            KeyboardMethods.TypeText("V");
            KeyboardMethods.PressEnter();
       }
    }
}
