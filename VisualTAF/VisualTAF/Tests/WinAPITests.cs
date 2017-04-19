using System;
using System.Drawing;
using ImageMagick;
using NUnit.Framework;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests
{
    [TestFixture,Parallelizable]
    public class WinAPITests
    {
        private readonly string _desktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private readonly string _explorerPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Explorer.png";
        private Point _clickPoint;

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(_desktopPath);
            Assert.IsTrue(ImageWorker.IsSubImageExist(_desktopPath, _explorerPath));
            _clickPoint = ImageWorker.FindSubImageCoordinate(_desktopPath, _explorerPath);
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
