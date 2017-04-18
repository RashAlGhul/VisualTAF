using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests
{
    [TestFixture,Parallelizable]
    public class ImageWorkerTests:BaseTest
    {
       [Test]
        public void FindSubImageCheck()
        {
            GenerateReport(0, "0", true);
            iTestNumCurrent = "FindSubImageCheck";
            try
            {

                string path1 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
                string path2 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";
                string path3 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Find.png";
                ImageWorker.TakeScreenshot(path1);
                ImageWorker.FindSubImage(path1, path2);//~650 milliseconds
                MouseMethods.MoveToElemment(ImageWorker.FindSubImageCoordinate(path1, path2));
                MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(path1, path2));
                MouseMethods.CursorPosition();
                //KeyboardMethods.TypeText(path3, "notepad");
                Assert.IsTrue(ImageWorker.IsSubImageExist(path1, path2));

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
