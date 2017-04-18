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

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            iPathReportFile = $@"{iFolderResultTest}\WinAPITestsReport.html";
            GenerateReport(0, "0", true);
        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void TestFixtureTearDown()
        {
            GenerateReport(9, "0", true); // генерируем конец отчёта
            //Process.Start(iPathReportFile); // открыть отчёт в конце тестов, если надо
        }

        [SetUp]
        public void SetUp()
        {
            ImageWorker.TakeScreenshot(_desktopPath);
            Assert.IsTrue(ImageWorker.IsSubImageExist(_desktopPath, _explorerPath));
            GetClickPointCoordinates(_desktopPath, _explorerPath, out _clickPoint);
        }

        [Test]
        public void MouseMethodsTest()
        {
            iTestNumCurrent = "MouseMethodsTest";
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
        public void KeyboardMethodsTest()
        {
            iTestNumCurrent = "KeyboardMethodsTest";
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
