using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture]
    public class NewMouseEventCheck
    {
        [Test]
        public void TestMethod()
        {
            string chrome = @"C:\Users\IEUser\Desktop\patterns\chrome.png";
            string DesktopPath = @"C:\Users\IEUser\Desktop\patterns\Desktop.png";
            MouseMethods.DragAndDrop(1000,0);
            ImageWorker.TakeScreenshot(DesktopPath);
            ImageWorker.FindSubImage(DesktopPath, chrome);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(DesktopPath,chrome));
        }
    }
}
