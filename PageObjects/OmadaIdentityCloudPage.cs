using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.PageObjects
{
    class OmadaIdentityCloudPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public OmadaIdentityCloudPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

    #region Locators

        public IWebElement IdentityCloudPageHeader
        {
            get{ return driver.FindElement(By.XPath("//h1[@class='h1 title'][text()='Omada Identity Cloud']")); }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Check if header element is displayed
        /// </summary>
        /// <param name="headerElement">The header element to display</param>
        /// <param name="elementDisplayed">Displayed property value for the header element</param>
        /// <exception cref="Exception"></exception>
        public void AsserHeaderDisplayed(IWebElement headerElement, out bool elementDisplayed)
        {
            elementDisplayed = headerElement.Displayed;

            if (!elementDisplayed) 
            { 
                throw new Exception($"Element {headerElement.ToString()} not displayed."); 
            }
        }
    #endregion

    }
}