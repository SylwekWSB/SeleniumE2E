using NUnit.Framework;
using System;
using OpenQA.Selenium;
using SeleniumTests.SeleniumUtils;

namespace SeleniumTests
{
    [TestFixture(BrowserTarget.Chrome)]
    public abstract class BaseTest
    {
        protected string startingUrl;
        protected string startTime;
        protected string targetBrowser;

        protected BaseTest(string browser)
        {
            this.targetBrowser = browser;
            this.startTime = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public IWebDriver InitializeDriver(string startingUrl = "https://omadaidentity.com/")
        {
            LocalDriverBuilder builder = new LocalDriverBuilder();

            var driver = builder.Launch(targetBrowser, startingUrl);

            return driver;
        }
    }
}
