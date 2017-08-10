using NUnit.Framework;
using VisualTAF.Utils;

namespace VisualTAF.Tests.Sikuli
{
    public class BaseTest
    {
        [SetUp]
        public void StartApp()
        {
            Logger.Instance.Info("======== Test Case: SIKULI ========");
            Logger.Instance.Info("======== ======================================= ========");
        }

        [TearDown]
        public void TestCleanApp()
        {
            Logger.Instance.Info("======== ======================================= ========");
            Logger.Instance.Info("========               Test End                  ========");
            Logger.Instance.Info("======== ======================================= ========");
        }
    }
}
