using System;
using System.Drawing;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.Sikuli
{
    public class GlobalActions
    {
        private Point subImageCoordinate;

        public void FindAndOpenChrome(string desktopPath, string chromePath)
        {
            System.Threading.SpinWait.SpinUntil(() => ImageWorker.IsSubImageExist(chromePath), 
                TimeSpan.FromSeconds(int.Parse(SikuliTestData.DefaultWait)));
            subImageCoordinate = ImageWorker.FindSubImageCoordinate(desktopPath, chromePath);
            MouseMethods.LMBClick(subImageCoordinate);
        }

        public void FindSearchFieldAndGoToTheTestSite(string desktopPath, string searchPath)
        {
            System.Threading.SpinWait.SpinUntil(() => ImageWorker.IsSubImageExist(searchPath), 
                TimeSpan.FromSeconds(int.Parse(SikuliTestData.DefaultWait)));
            subImageCoordinate = ImageWorker.FindSubImageCoordinate(desktopPath, searchPath);
            MouseMethods.LMBClick(subImageCoordinate.X + 100, subImageCoordinate.Y);
            KeyboardMethods.TypeText(SikuliTestData.TestSite);
            KeyboardMethods.PressEnter();
        }

        public void MoveCheirOnWorkspace(string desktopPath, string cheirPath)
        {
            System.Threading.SpinWait.SpinUntil(() => ImageWorker.IsSubImageExist(cheirPath), 
                TimeSpan.FromSeconds(int.Parse(SikuliTestData.DefaultWait)));
            Point point = ImageWorker.FindSubImageCoordinate(desktopPath, cheirPath);
            MouseMethods.DragAndDrop(point, new Point(point.X + 500, point.Y));
        }

        public void CLoseChrome(string desktopPath, string chromeClosePath, string leavePath)
        {
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktopPath, chromeClosePath));
            System.Threading.SpinWait.SpinUntil(() => ImageWorker.IsSubImageExist(leavePath),
                TimeSpan.FromSeconds(int.Parse(SikuliTestData.DefaultWait)));
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktopPath, leavePath));
        }
    }
}
