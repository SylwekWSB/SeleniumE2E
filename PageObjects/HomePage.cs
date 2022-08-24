using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests.PageObjects
{
    class HomePage
    {
        IWebDriver driver;
        WebDriverWait wait;

    #region Locators

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }
        public IWebElement MenuItemProducts
        {
            get{ return driver.FindElement(By.Id("menu-item-727")); }
        }
        public IWebElement OmadaIdentityCloudLink
        {
            get { return driver.FindElement(By.XPath("//a[text()='Omada Identity Cloud'][1]")); }
        }

        public IWebElement MenuItemCompany
        {
            get { return driver.FindElement(By.Id("menu-item-731")); }
        }

        public IWebElement CareeresLink
        {
            get { return driver.FindElement(By.XPath("//a[text()='Careers'][1]")); }
        }

    #endregion

    #region Methods

        /// <summary>
        /// Click on an element
        /// </summary>
        /// <param name="element">The element to click</param>
        public void ClickElement(IWebElement element)
        {
            wait.Until(x => element).Click();
        }

        /// <summary>
        /// Hovers the mouse over an element
        /// </summary>
        /// <param name="element">The element over which the mouse hovers</param>
        public void MouseHover(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(x => element);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

    #endregion
    }
}
