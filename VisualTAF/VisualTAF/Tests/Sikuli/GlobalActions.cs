using System.Drawing;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.Sikuli
{
    public class GlobalActions
    {
        private Point subImageCoordinate;

        public void FindAndOpenChrome(string desktopPath, string chromePath)
        {
            TakeScreenshot(desktopPath);
            subImageCoordinate = ImageWorker.FindSubImageCoordinate(desktopPath, chromePath);
            MouseMethods.LMBClick(subImageCoordinate);
        }

        public void FindSearchFieldAndGoToTheTestSite(string desktopPath, string searchPath)
        {
            TakeScreenshot(desktopPath);
            subImageCoordinate = ImageWorker.FindSubImageCoordinate(desktopPath, searchPath);
            MouseMethods.LMBClick(subImageCoordinate.X + 100, subImageCoordinate.Y);
            KeyboardMethods.TypeText(SikuliTestData.TestSite);
            KeyboardMethods.PressEnter();
        }

        public void TakeScreenshot(string desktopSavePath)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            img.Save(desktopSavePath);
        }
    }
}
