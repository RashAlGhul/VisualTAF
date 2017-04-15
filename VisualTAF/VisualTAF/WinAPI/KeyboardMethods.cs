using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using ImageMagick;

namespace VisualTAF
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
    }
}
