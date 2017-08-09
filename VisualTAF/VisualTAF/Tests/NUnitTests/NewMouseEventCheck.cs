using NUnit.Framework;
using System;
using System.Drawing;
using System.Threading;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture]
    public class NewMouseEventCheck
    {
        private static readonly string _imagesPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\patterns\";
        private readonly string _chrome = $@"{_imagesPath}chrome.png";
        private readonly string _desktop = $@"{_imagesPath}Desktop.png";
        private readonly string _result = $@"{_imagesPath}Result";
        private readonly string _search = $@"{_imagesPath}search.png";
        private readonly string _closeButton = $@"{_imagesPath}close button.png";
        private readonly string _mainPageWithDialog = $@"{_imagesPath}main page with dialog window.png";
        private readonly string _mainPage = $@"{_imagesPath}main page.png";
        private Steps steps = new Steps();

        [Test]
        public void TestMethod()
        {
            steps.FindAndOpenChrome(_desktop, _chrome);
            Thread.Sleep(1000);
            steps.FindSearchFieldAndGoToTheTestSite(_desktop, _search);
            Thread.Sleep(2000);
            steps.TakeScreenshot(_desktop);
            Assert.True(ImageWorker.IsSubImageExist(_desktop, _mainPageWithDialog));
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(_desktop, _closeButton));
            Thread.Sleep(1000);
            steps.TakeScreenshot(_desktop);
            Assert.True(ImageWorker.IsSubImageExist(_desktop, _mainPage));
            //ImageWorker.FindSubImage(_desktopPath, _search, _result);
            //_subImageCoordinate = ImageWorker.FindSubImageCoordinate(_desktopPath, _search);
            //MouseMethods.LMBClick(_subImageCoordinate.X + 100, _subImageCoordinate.Y);
            //KeyboardMethods.TypeText(Config.TestSite);
            //KeyboardMethods.PressEnter();
        }

        
    }
}
