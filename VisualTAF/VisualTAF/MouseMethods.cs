using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTAF
{
    class MouseMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void LMBClick(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void LMBClick(Point clickPoint)
        {
            Cursor.Position = clickPoint;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void RMBClick(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void RMBClick(Point clickPoint)
        {
            Cursor.Position = clickPoint;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void ForDebug()
        {
            Cursor Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;
            Console.WriteLine($"X:{posX},Y:{posY}");
        }

        public static void DoubleClick(int X, int Y)
        {
            LMBClick(X,Y);
            LMBClick(X, Y);
        }
    }
}
