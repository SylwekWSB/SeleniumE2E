using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.PageObjects
{
    class CareersPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

    #region Locators

        public IWebElement SearchOurJobOpeningsButton
        {
            get{ return driver.FindElement(By.XPath("//span[text()='Search our job openings']")); }
        }

        public IWebElement OpenJobPositionsButton
        {
            get { return driver.FindElement(By.XPath("//span[text()='Open job positions']")); }
        }

        public IWebElement AllowAllCookiesButton
        {
            get { return driver.FindElement(By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]")); }
        }

        public IWebElement OmadianGry
        {
            get { return driver.FindElement(By.XPath("//h4[text()='Gry Collignon']")); }
        }

        public IWebElement OmadianBrooke
        {
            get { return driver.FindElement(By.XPath("//h4[text()='Brooke Joyce']")); }
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
        /// Switch tab and check if this tab is outside omadaidentity.com domain
        /// </summary>
        /// <param name="tabPosition">Position of new tab</param>
        public void SwitchTabAndAssert(int tabPosition =1)
        {
            var newTab = driver.WindowHandles[tabPosition]; // Handler for the new tab

            Assert.IsTrue(!string.IsNullOrEmpty(newTab)); // Check if tab was opened
            StringAssert.DoesNotContain("omadaidentity.com", driver.SwitchTo().Window(newTab).Url); // Check if URL not contains omadaidentity.com domain

            driver.SwitchTo().Window(driver.WindowHandles[tabPosition]).Close(); // Close the tab
            driver.SwitchTo().Window(driver.WindowHandles[0]); // Get back to the main windo
        }

        /// <summary>
        /// Retrieves the first and last name of an employee based on his position
        /// </summary>
        /// <param name="jobPosition">Name of the position held by the person</param>
        /// <param name="actualName">The current name of the person fetched from the website</param>
        public void GetNameByPositionOnTheList(string jobPosition, out string actualName)
        {
            actualName = driver.FindElement(By.XPath($"//span[text()='{jobPosition}']/following-sibling::h2[@class='name']")).Text;
        }

    #endregion

    }
}
