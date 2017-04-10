using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisualTAF
{
    [TestFixture,Parallelizable]
    public class ImageWorkerTests
    {
        [Test]
        public void FindSubImageCheck()
        {
            string path1 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
            string path2 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";
            ImageWorker.TakeScreenshot(path1);
            ImageWorker.FindSubImage(path1,path2, @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResult.png");//~650 milliseconds
            MouseMethods.LMBClick(ImageWorker.FindSubImageWithClickOnIt(path1,path2, @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\FindResultToClick.png"));
            MouseMethods.ForDebug();
        }
    }
}
