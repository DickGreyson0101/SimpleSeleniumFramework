using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium_Day2.Page;
using System.Configuration;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

namespace Selenium_Day2.Test
{
    [TestClass]
    public class LoginTest:BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetupPage()
        {
            loginPage = new LoginPage(browser.Driver);
            dashboardPage = new DashboardPage(browser.Driver);

        }

        [TestMethod("TC01: Login with valid username and password")]
        public void VerifyValidUser()
        {
            

            //Input username & password
            string username = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"{username}");

            string password = ConfigurationHelper.GetConfig<string>("password");

            extentTest.LogMessage($"{password}");

            loginPage.LoginWithUsernameAndPassword(username, password);

            //Verify the dashboard page is display
            extentTest.LogMessage(" Dashboard is displayed");

            //FLUENT ASSERT
            dashboardPage.IsLabelDashboardDisplay(10).Should().BeTrue();
            //Assert.IsTrue(dashboardPage.IsLabelDashboardDisplay());
           
        }
        
        [TestMethod("TC02: Login with invalid username and password")]
        public void VerifyInValidUser()
        {
            throw new Exception();
            //Input username & password
            loginPage.LoginWithUsernameAndPassword("Admin", "admin1111");

            //Verify error message
            loginPage.GetErrorMessage().Should().Contain("Invalid");

            //Verify the dashboard page is NOT display
            dashboardPage.IsLabelDashboardDisplay().Should().BeFalse();

            /*try
            {
                browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                //Assert.AreEqual(browser.Driver.FindElements(xpathLabelDashBoard).Count, 0);

                *//*Assert.ThrowsException<NoSuchElementException>(() =>
                {
                    browser.Driver.FindElements(xpathLabelDashBoard);
                });*//*
            }
            catch
            {
                Assert.Fail();
            }
            finally
            {
                browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            };*/
        }

        [TestMethod("TC03: Dynamic data - login test")]
        [DynamicData(nameof(DataLoginUser))]
        public void VerifyLoginUser(string username, string password, bool isLabelDashboardDisplay)
        {
            loginPage.LoginWithUsernameAndPassword(username, password);
            dashboardPage.IsLabelDashboardDisplay(10).Should().Be(isLabelDashboardDisplay);
        }

        public static IEnumerable<object[]> DataLoginUser
        {
            get
            {
                return new ExcelHelper(Path.Combine("Resources", "VerifyLoginUser.xlsx")).GetLoginUserData();
            }
        }
    }
}
