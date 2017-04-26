using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.MSTests
{
    [TestClass]
    public class WinAPIMSTests
    {
        private const string DesktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private const string ExplorerPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Explorer.png";
        private Point _clickPoint;

        [TestInitialize]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(DesktopPath);
            Assert.IsTrue(ImageWorker.IsSubImageExist(DesktopPath, ExplorerPath));
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
        }

        [TestMethod]
        public void MouseMethodsTest()
        {
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            MouseMethods.LMBClick(_clickPoint);
            MouseMethods.CursorPosition();
        }

        [TestMethod]
        public void KeyboardMethodsTest()
        {
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            KeyboardMethods.TypeText("V");
            KeyboardMethods.PressEnter();
        }
    }
}
