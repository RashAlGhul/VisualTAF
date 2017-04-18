using System;
using System.Drawing;
using NUnit.Framework;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests
{
    [TestFixture,Parallelizable]
    public class WinAPITests:BaseTest
    {
        private readonly string _desktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private readonly string _explorerPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Explorer.png";
        private Point _clickPoint;

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(_desktopPath);
            Assert.IsTrue(ImageWorker.IsSubImageExist(_desktopPath, _explorerPath));
            GetClickPointCoordinates(_desktopPath, _explorerPath, out _clickPoint);
        }

        [Test]
        public void MouseMethodsCheck()
        {
            iTestNumCurrent = "MouseMethodsCheck";
            try
            {
                MouseMethods.MoveToElemment(_clickPoint);
                MouseMethods.RMBClick(_clickPoint);
                MouseMethods.LMBClick(_clickPoint);
                MouseMethods.CursorPosition();
                GenerateReport(1, iTestNumCurrent, true);
                iExecTestGood = true;
            }
            catch (Exception ex)
            {
                GenerateReport(1, iTestNumCurrent, false, ex.ToString());
                iExecTestGood = false;
            }
            Assert.True(iExecTestGood);
        }

        [Test]
        public void KeyboardMethodsCheck()
        {
            iTestNumCurrent = "KeyboardMethodsCheck";
            try
            {
                MouseMethods.MoveToElemment(_clickPoint);
                MouseMethods.RMBClick(_clickPoint);
                KeyboardMethods.TypeText("V");
                KeyboardMethods.PressEnter();
                GenerateReport(1, iTestNumCurrent, true);
                iExecTestGood = true;
            }
            catch (Exception ex)
            {
                GenerateReport(1, iTestNumCurrent, false, ex.ToString());
                iExecTestGood = false;
            }
            Assert.True(iExecTestGood);
        }
    }
}
