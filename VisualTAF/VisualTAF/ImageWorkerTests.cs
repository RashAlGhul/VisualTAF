using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisualTAF
{
    [TestFixture]
    public class ImageWorkerTests
    {
        [Test]
        public void FindSubImageCheck()
        {
            string path1 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Desktop.png";
            string path2 = @"C:\Users\Devil\Source\Repos\VisualTAF\VisualTAF\VisualTAF\bin\Debug\Win.png";
            ImageWorker image = new ImageWorker();
            image.TakeScreenshot(path1);
            image.FindSubImage(path1,path2);//~650 milliseconds
            MouseMethods.LMBClick(image.FindSubImageWithClickOnIt(path1,path2));
            MouseMethods.ForDebug();
        }
    }
}
