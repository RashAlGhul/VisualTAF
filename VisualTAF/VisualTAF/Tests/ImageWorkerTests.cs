using System;
using System.Drawing;
using NUnit.Framework;

namespace VisualTAF.Tests
{
    [TestFixture, Parallelizable]
    public class ImageWorkerTests:BaseTest
    {
        private readonly string _desktopPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
        private readonly string _winPath = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            iPathReportFile = $@"{iFolderResultTest}\ImageWorkerTestsReport.html";
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
        }

        [Test]
        public void FindSubImageTest()
        {
            iTestNumCurrent = "FindSubImageTest";
            try
            {
                ImageWorker.FindSubImage(_desktopPath, _winPath);
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
        public void SubImageExistTest()
        {
            iTestNumCurrent = "SubImageExistTest";
            try
            {
                Assert.IsTrue(ImageWorker.IsSubImageExist(_desktopPath, _winPath));
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
        public void FindSubImageCoordinatesTest()
        {
            iTestNumCurrent = "FindSubImageCoordinatesTest";
            try
            {
                Point SubImageCoordinate = ImageWorker.FindSubImageCoordinate(_desktopPath, _winPath);
                Assert.False(SubImageCoordinate.IsEmpty);
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
