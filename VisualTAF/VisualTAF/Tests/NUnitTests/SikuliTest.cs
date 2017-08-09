using NUnit.Framework;
using System;
using System.Drawing;
using System.Threading;
using VisualTAF.Utils;
using VisualTAF.WinAPI;

namespace VisualTAF.Tests.NUnitTests
{
    [TestFixture]
    public class SikuliTest
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
        public void TestMethod()
        {
            actions.FindAndOpenChrome(desktop, chrome);
            Thread.Sleep(1000);
            actions.FindSearchFieldAndGoToTheTestSite(desktop, search);
            Thread.Sleep(2000);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, mainPageWithDialog));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, mainPageWithDialog, result);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, closeButton));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, mainPage));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, mainPage, result);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, furnishYourRoomButton));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, itemsList));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, itemsList, result);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, diningRoom));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Point point = ImageWorker.FindSubImageCoordinate(desktop, cheir);
            MouseMethods.DragAndDrop(point, new Point(point.X+500, point.Y));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, cheirOnWorkspace));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, itemsList, result);
            Assert.True(ImageWorker.IsSubImageExist(desktop, etalonCheir));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, etalonCheir, result);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, etalonCheir));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, cheirName));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, cheirName, result);
            Assert.True(ImageWorker.IsSubImageExist(desktop, cheirProperties));
            ImageWorker.FindSubImageAndSaveResultIntoFile(result, cheirProperties, result);
            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(desktop, deleteButton));
            Thread.Sleep(500);
            actions.TakeScreenshot(desktop);
            Assert.True(ImageWorker.IsSubImageExist(desktop, emptyScene));
            Assert.True(ImageWorker.IsSubImageExist(desktop, sceneInfo));
            ImageWorker.FindSubImageAndSaveResultIntoFile(desktop, sceneInfo, result);
        }
    }
}
