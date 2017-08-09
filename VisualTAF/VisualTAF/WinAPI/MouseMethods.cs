using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace VisualTAF.WinAPI
{
    class MouseMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void LMBClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);
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

        public static void DoubleClick(int x, int Y)
        {
            LMBClick(x, Y);
            LMBClick(x, Y);
        }

        public static void DoubleClick(Point clickPoint)
        {
            LMBClick(clickPoint);
            LMBClick(clickPoint);
        }

        public static void MoveToElemment(int x, int y)
        {
            Cursor.Position = new Point(x,y);
        }

        public static void MoveToElemment(Point focusPoint)
        {
            Cursor.Position = new Point(focusPoint.X,focusPoint.Y);
        }

        public static string CursorPosition()
        {
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;
            return $"X:{posX},Y:{posY}";
        }

        public static void Grab(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
        }
        public static void Release(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
        }

        public static void Grab(Point grabPoint)
        {
            Cursor.Position = grabPoint;
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
        public static void Release(Point releasePoint)
        {
            Cursor.Position = releasePoint;
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void DragAndDrop(int startX, int startY, int endtX, int endY)
        {
            Cursor.Position = new Point(startX, startY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)startX, (uint)startY, 0, 0);
            Cursor.Position = new Point(endtX, endY);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)startX, (uint)startY, 0, 0);
        }

        public static void DragAndDrop(Point startPoint, Point endPoint)
        {
            Cursor.Position = startPoint;
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            Cursor.Position = endPoint;
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
    }
}
