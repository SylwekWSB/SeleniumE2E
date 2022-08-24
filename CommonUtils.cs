using System;
using OpenQA.Selenium;
using System.IO;
using NUnit.Framework;

namespace SeleniumTests
{
    internal class CommonUtils
    {
        public void PrintLogs(string LogType, IWebDriver driver)
        {
            var _logs = driver.Manage().Logs;

            try
            {
                var browserLogs = _logs.GetLog(LogType);
                if (browserLogs.Count > 0)
                {
                    var filePath = $"{Path.GetTempPath()}ConsoleLogs-{Guid.NewGuid()}.txt";
                    File.WriteAllText(filePath, "Start logs: ");

                    foreach (var log in browserLogs)
                    {
                        StreamWriter sw = File.AppendText(filePath);
                        sw.WriteLine(log.ToString());
                        sw.Close(); 
                    }
                    TestContext.AddTestAttachment(filePath, "Browser logs");
                }
            }
            catch
            {
                Console.WriteLine("No logs found.");
            }
        }
    }
}
