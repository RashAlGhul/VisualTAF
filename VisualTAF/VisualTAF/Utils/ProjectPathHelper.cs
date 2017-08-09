using System;
using System.IO;

namespace VisualTAF.Utils
{
    internal class ProjectPathHelper
    {
        private static string projectPath;

        internal static string ProjectPath => projectPath ?? (projectPath = Directory.GetParent(Directory.GetParent(
                                                  AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString());

        internal static string DesktopPath => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    }
}
