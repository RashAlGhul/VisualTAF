using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;
using ImageMagick;
using NUnit.Framework.Internal;

namespace VisualTAF.Tests
{
    public class BaseTest
    {
        public static string iTestNumCurrent = "";
        public static bool iExecTestGood = true;
        public static string iWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string iFolderResultTest = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string iFolderScreen = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string iPathReportFile = $@"{iFolderResultTest}\Report.html";
        public static int iTestCountGood;
        public static int iTestCountFail;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            GenerateReport(0, "0", true);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            GenerateReport(9, "0", true); 
        }

        /// <summary>
        /// Метод генерации отчёта о тестировании.
        /// "iStep" - этап внесения информации: 0 - начало отчёта, 1 - составление отчёта, 9 - закрытие отчёта
        /// "iTestNum" - номер теста, пример: WSP-1278
        /// "iResult" - результат выполнения теста: true/false
        /// "iMessage" - заносимая в отчёт информация (сообщение об ошибке)
        /// </summary>
        public static void GenerateReport(int iStep, string iTestNum, bool iResult, string iMessage = "-")
        {
            iMessage = iMessage.Replace("<", "&lt;")
                .Replace(">","&gt;");
            iMessage = iMessage.Replace("\n", "</br>");
            string iTime = $"{DateTime.Now:HH:mm:ss}";
            using (StreamWriter sw =
                new StreamWriter(new FileStream(iPathReportFile, FileMode.Append, FileAccess.Write)))
            {
                if (iStep == 0)
                {
                    iTestCountGood = 0;
                    iTestCountFail = 0;
                    sw.WriteLine($@"<!DOCTYPE html>{"\n"}" +
                                 $@"<html lang='en-EN'>{"\n"}" +
                                 $@"<head>{"\n"}" +
                                 $@"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />{"\n"}" +
                                 $@"<title>Test report</title>{"\n"}" +
                                 $@"</head>{"\n"}" +
                                 $@"<body>{"\n"}" +
                                 $@"<div style='font-size:22px;' align='center'><strong>Test started: " +
                                 $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}" + $@"</strong></div></br>{"\n"}" +
                                 $@"<table border='1' align='center' cellpadding='5' cellspacing='0' width='100%'>{"\n"}" +
                                 $@"<tr style='text-align:center;'>{"\n"}" +
                                 $@"<td width='100px'><strong>Test</strong></td>{"\n"}" +
                                 $@"<td width='70px'><strong>Result</strong></td>{"\n"}" +
                                 $@"<td width='70px'><strong>Time</strong></td>{"\n"}" +
                                 $@"<td width='70px'><strong>Screenshot</strong></td>{"\n"}" +
                                 $@"<td><strong>Message</strong></td>{"\n"}" +
                                 $@"</tr>");
                }
                if (iResult & iStep == 1)
                {
                    iTestCountGood = iTestCountGood + 1;
                    sw.WriteLine($@"<tr style='color: green;'>{"\n"}
                    <td>{iTestNum}</td>{"\n"}
                    <td>Succesed</td>{"\n"}
                    <td>{iTime}</td>{"\n"}
                    <td>-</td>{"\n"}
                    <td>{iMessage}</td>{"\n"}
                    </tr>{"\n"}");
                }
                if (iResult == false & iStep == 1)
                {
                    iTestCountFail = iTestCountFail + 1;
                    string iNameScreen = $"{iTestNum}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
                    ImageWorker.TakeScreenshot($@"{iFolderScreen}\{iNameScreen}");
                    sw.WriteLine($@"<tr style='color: red;'>{"\n"}
                    <td>{iTestNum}</td>{"\n"}
                    <td>Fail</td>{"\n"}
                    <td>{iTime}</td>{"\n"}
                    <td><a target='_blank' href='screen/{iNameScreen}'>watch</a></td>{"\n"}
                    <td>{iMessage}</td>\n</tr>{"\n"}");
                }
                if (iStep == 9)
                {
                    Decimal iProcent = 0;
                    if (iTestCountGood > 0 || iTestCountFail > 0)
                    {
                        iProcent = 100 * iTestCountGood /
                                   (iTestCountGood +
                                    iTestCountFail
                                   );
                    }
                    sw.WriteLine($@"<tr style='text-align:center;'>{"\n"}
                                 <td colspan='5'>&nbsp;</center></td>{"\n"}
                                 </tr>{"\n"}
                                 <tr style='text-align:center;'>{"\n"}
                                 <td colspan='5'>All test run: {iTestCountGood + iTestCountFail}
                                 || <span style='color: green;'>Pass: {iTestCountGood}
                                 </span> || <span style='color: red;'>Faild: {iTestCountFail}
                                 </span> || Pass percent: {iProcent}% || Test finished:
                                 {DateTime.Now:dd.MM.yyyy HH:mm:ss}</td>{"\n"}
                                 </tr>{"\n"}
                                 </table>{"\n"}
                                 </body>{"\n"}
                                 </html>");
                }
            }
            // iPathReportFile - указывается полный путь до файла отчёта включая имя самого файла
        }


        public void GetClickPointCoordinates(string imagePath, string subImagePath, out Point clickPoint)
        {
            clickPoint = ImageWorker.FindSubImageCoordinate(imagePath, subImagePath);
        }

        public void GetClickPointCoordinates(Image image, Image subImage, out Point clickPoint)
        {
            clickPoint = ImageWorker.FindSubImageCoordinate(image, subImage);
        }

        public void GetClickPointCoordinates(Bitmap image, Bitmap subImage, out Point clickPoint)
        {
            clickPoint = ImageWorker.FindSubImageCoordinate(image, subImage);
        }

        public void GetClickPointCoordinates(MagickImage image, MagickImage subImage, out Point clickPoint)
        {
            clickPoint = ImageWorker.FindSubImageCoordinate(image, subImage);
        }
    }
}
