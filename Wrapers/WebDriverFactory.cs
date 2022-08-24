using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.SeleniumUtils.Wrapers
{
    internal class WebDriverFactory
    {
        public virtual IWebDriver CreateLocalChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            
            return new ChromeDriver(options);
        }
    }
}