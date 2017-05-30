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
        }

        [TestMethod]
        public void MouseMethodsTest()
        {
            Assert.IsTrue(ImageWorker.IsSubImageExist(DesktopPath, ExplorerPath));
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
            MouseMethods.MoveToElemment(_clickPoint);
            MouseMethods.RMBClick(_clickPoint);
            MouseMethods.LMBClick(_clickPoint);
            MouseMethods.MoveToElemment(0, 0);
        }

        [TestMethod]
        public void KeyboardMethodsTest()
        {
            _clickPoint = ImageWorker.FindSubImageCoordinate(DesktopPath, ExplorerPath);
            KeyboardMethods.TypeText("V");
            KeyboardMethods.PressEnter();
            MouseMethods.MoveToElemment(0, 0);
        }
    }
}
