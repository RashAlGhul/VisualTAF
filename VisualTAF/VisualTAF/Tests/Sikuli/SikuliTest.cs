using System.Drawing;
using System.Threading;
using NUnit.Framework;
using VisualTAF.Utils;
using VisualTAF.WinAPI;
using Assert = VisualTAF.Utils.Assert;

namespace VisualTAF.Tests.Sikuli
{
    [TestFixture]
    public class SikuliTest:BaseTest
    {
        private readonly string chrome = $@"{ProjectPathHelper.ProjectPath}\patterns\chrome.png";
        private readonly string desktop = $@"{ProjectPathHelper.DesktopPath}\Desktop.png";
        private readonly string result = $@"{ProjectPathHelper.DesktopPath}\StepResult.png";
        private readonly string search = $@"{ProjectPathHelper.ProjectPath}\patterns\search.png";
        private readonly string closeButton = $@"{ProjectPathHelper.ProjectPath}\patterns\close button.png";
        private readonly string mainPageWithDialog = $@"{ProjectPathHelper.ProjectPath}\patterns\main page with dialog window.png";
        private readonly string mainPage = $@"{ProjectPathHelper.ProjectPath}\patterns\main page.png";
        private readonly string furnishYourRoomButton = $@"{ProjectPathHelper.ProjectPath}\patterns\furnish your room.png";
        private readonly string itemsList = $@"{ProjectPathHelper.ProjectPath}\patterns\items list.png";
        private readonly string diningRoom = $@"{ProjectPathHelper.ProjectPath}\patterns\Dining room.png";
        private readonly string cheir = $@"{ProjectPathHelper.ProjectPath}\patterns\cheir.png";
        private readonly string cheirOnWorkspace = $@"{ProjectPathHelper.ProjectPath}\patterns\cheir on workspace.png";
        private readonly string etalonCheir = $@"{ProjectPathHelper.ProjectPath}\patterns\etalon cheir.png";
        private readonly string cheirName = $@"{ProjectPathHelper.ProjectPath}\patterns\cheir name.png";
        private readonly string cheirProperties = $@"{ProjectPathHelper.ProjectPath}\patterns\cheir properties.png";
        private readonly string deleteButton = $@"{ProjectPathHelper.ProjectPath}\patterns\delete element.png";
        private readonly string emptyScene = $@"{ProjectPathHelper.ProjectPath}\patterns\empty scene.png";
        private readonly string sceneInfo = $@"{ProjectPathHelper.ProjectPath}\patterns\scene info.png";
        private readonly GlobalActions actions = new GlobalActions();

        [Test]
        public void SiteTestMethod()
        {
            actions.FindAndOpenChrome(desktop, chrome);
            Thread.Sleep(1000);
            Logger.Instance.Info($"Open site: {SikuliTestData.TestSite}");
            actions.FindSearchFieldAndGoToTheTestSite(desktop, search);
            Thread.Sleep(2000);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, mainPageWithDialog), "Verify that main site form with dialog window is open");
            Logger.Instance.Info("Close dialog window");
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, closeButton));
            Thread.Sleep(1000);
            actions.TakeScreenshot(desktop);
            Assert.True(desktop, mainPage, "Verify that main site form without dialog window is open");
            Logger.Instance.Info("Open 'furnish your room' list");
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, furnishYourRoomButton));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(desktop, itemsList, "Verify that 'furnish your room' items list is open");
            Logger.Instance.Info("Select 'dinig room' section");
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, diningRoom));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Logger.Instance.Info("Select bar cheir and move it on workspace");
            Point point = ImageWorker.FindSubImageCoordinate(desktop, cheir);
            MouseMethods.DragAndDrop(point, new Point(point.X+500, point.Y));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(desktop, cheirOnWorkspace, "Verify that chair is on the workspace");
            Assert.True(desktop, etalonCheir, "Verify that chair is on the workspace is etalon");
            Logger.Instance.Info("Click on chair to verify it data");
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, etalonCheir));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(desktop, cheirName, "Verify that chair has right name");
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, cheirName, result);
            Assert.True(desktop, cheirProperties, "Verify that chair has right name");
            Logger.Instance.Info("Remove chair from workspace");
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, deleteButton));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(desktop, emptyScene, "Verify that chair was remove");
            Assert.True(desktop, sceneInfo, "Verify that scene has defoult parameters");
        }
    }
}
