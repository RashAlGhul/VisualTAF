using System;
using System.Drawing;
using WindowsInput;
using WindowsInput.Native;
using ImageMagick;

namespace VisualTAF.WinAPI
{
    class KeyboardMethods
    {
        public static void TypeText(string text)
        {
            new InputSimulator().Keyboard.TextEntry(text);
        }

        public static void TypeText(string inputPlaceImagePath, string text)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                using (MagickImage inputPlace = new MagickImage(inputPlaceImagePath))
                {
                    try
                    {
                        if (ImageWorker.IsSubImageExist(screen, inputPlace))
                        {
                            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, inputPlace));
                            new InputSimulator().Keyboard.TextEntry(text);
                        }

                        else
                        {
                            throw new Exception("Such element not found");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public static void TypeText(Image inputPlace, string text)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                using (MagickImage input = new MagickImage((Bitmap) inputPlace))
                {
                    try
                    {
                        if (ImageWorker.IsSubImageExist(screen, input))
                        {
                            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, input));
                            new InputSimulator().Keyboard.TextEntry(text);
                        }

                        else
                        {
                            throw new Exception("Such element not found");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public static void TypeText(Bitmap inputPlace, string text)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                using (MagickImage input = new MagickImage(inputPlace))
                {
                    try
                    {
                        if (ImageWorker.IsSubImageExist(screen, input))
                        {
                            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, input));
                            new InputSimulator().Keyboard.TextEntry(text);
                        }

                        else
                        {
                            throw new Exception("Such element not found");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public static void TypeText(MagickImage inputPlace, string text)
        {
            using (MagickImage screen = new MagickImage("screenshot:"))
            {
                using (inputPlace)
                {
                    try
                    {
                        if (ImageWorker.IsSubImageExist(screen, inputPlace))
                        {
                            MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, inputPlace));
                            new InputSimulator().Keyboard.TextEntry(text);
                        }

                        else
                        {
                            throw new Exception("Such element not found");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public static void TypeText(string screenPath, string inputPlaceImagePath, string text)
        {
            try
            {
                if (ImageWorker.IsSubImageExist(screenPath, inputPlaceImagePath))
                {
                    MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screenPath, inputPlaceImagePath));
                    new InputSimulator().Keyboard.TextEntry(text);
                }

                else
                {
                    throw new Exception("Such element not found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void TypeText(Image screen, Image inputPlace, string text)
        {
            try
            {
                if (ImageWorker.IsSubImageExist(screen, inputPlace))
                {
                    MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, inputPlace));
                    new InputSimulator().Keyboard.TextEntry(text);
                }

                else
                {
                    throw new Exception("Such element not found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void TypeText(Bitmap screen, Bitmap inputPlace, string text)
        {
            try
            {
                if (ImageWorker.IsSubImageExist(screen, inputPlace))
                {
                    MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, inputPlace));
                    new InputSimulator().Keyboard.TextEntry(text);
                }

                else
                {
                    throw new Exception("Such element not found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void TypeText(MagickImage screen, MagickImage inputPlace, string text)
        {
            try
            {
                if (ImageWorker.IsSubImageExist(screen, inputPlace))
                {
                    MouseMethods.LMBClick(ImageWorker.FindSubImageCoordinate(screen, inputPlace));
                    new InputSimulator().Keyboard.TextEntry(text);
                }

                else
                {
                    throw new Exception("Such element not found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void PressEnter()
        {
            new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
    }
}
