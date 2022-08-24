using System;
using System.Security.Principal;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V102.Network;
using SeleniumTests.Helpers;
using SeleniumTests.PageObjects;

namespace SeleniumTests.Tests
{
    public class E2ETests : BaseTest
    {
        public E2ETests(string browser) 
            : base(browser)
        {

        }
        CommonUtils commonUtils = new CommonUtils();

    #region Identity Cloude

        [Test]
        [Category("E2E test")]
        public void Test_GoToOmadaIdentityCloude()
        {
            using(var driver = InitializeDriver())
            {
                try
                {   //Arrange
                    HomePage homePage = new HomePage(driver);
                    OmadaIdentityCloudPage omadaIdentityCloudPage = new OmadaIdentityCloudPage(driver);

                    // Act
                    homePage.MouseHover(homePage.MenuItemProducts);
                    Thread.Sleep(1000);
                    homePage.ClickElement(homePage.OmadaIdentityCloudLink);

                    // Assert
                    omadaIdentityCloudPage.AsserHeaderDisplayed(omadaIdentityCloudPage.IdentityCloudPageHeader, out bool exists);
                    Assert.IsTrue(exists);
                    AssertHelper.AssertUrlContains("omada-identity-cloud", driver.Url.ToString());
                }
                finally 
                {
                    commonUtils.PrintLogs("browser", driver);
                }
            }
        }

    #endregion

    #region Careers

        [Test]
        [Category("E2E test")]
        public void Test_CheckCareers()
        {
            using (var driver = InitializeDriver())
            {
                try
                {   //Arrange
                    HomePage homePage = new HomePage(driver);
                    CareersPage careersPage = new CareersPage(driver);

                    homePage.MouseHover(homePage.MenuItemCompany);
                    homePage.ClickElement(homePage.CareeresLink);

                    // Act
                    careersPage.ClickElement(careersPage.SearchOurJobOpeningsButton);

                    // Assert - Search Our Job Openings
                    AssertHelper.AssertUrlNotContains("omadaidentity.com", driver.Url.ToString());
                    
                    // Arrange
                    driver.Navigate().Back();

                    // Act
                    careersPage.ClickElement(careersPage.AllowAllCookiesButton); // quick fix for cookies baner
                    careersPage.ClickElement(careersPage.OpenJobPositionsButton);

                    // Assert - Open Job Positions
                    careersPage.SwitchTabAndAssert();
                }
                finally
                {
                    commonUtils.PrintLogs("browser", driver);
                }
            }
        }

        [Test]
        [Category("E2E test")]
        public void Test_MeetOurOmadians()
        {
            string startingUrl = "https://omadaidentity.com/company/careers/";
            using (var driver = InitializeDriver(startingUrl))
            {
                try
                {   //Arrange
                    HomePage homePage = new HomePage(driver);
                    CareersPage careersPage = new CareersPage(driver);

                    Thread.Sleep(1000);
                    careersPage.ClickElement(careersPage.AllowAllCookiesButton);
                    careersPage.ClickElement(careersPage.OmadianGry);

                    // Act
                    careersPage.GetNameByPositionOnTheList("Chief Financial Officer", out string firstPersonactualName);

                    // Assert information about Gry Collignon - Chief Financial Officer
                    Assert.True("Gry Collignon" == firstPersonactualName);

                    //Arrange
                    driver.Navigate().Refresh();

                    //Act information about Brooke Joyce - Director Customer Success

                    careersPage.ClickElement(careersPage.OmadianBrooke);
                    careersPage.GetNameByPositionOnTheList("Director Customer Success", out string secondPersonactualName);

                    // Assert
                    Assert.True("Brooke Joyce" == secondPersonactualName);
                }
                finally
                {
                    commonUtils.PrintLogs("browser", driver);
                }
            }
        }

    #endregion

    }
}
