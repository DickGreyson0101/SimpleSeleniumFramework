using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Day2.Page
{
    public class DashboardPage : BasePage
    {
        private By xpathLabelDashBoard = By.XPath("//h6[text()='Dashboard'] | //p[text()='@jhon.doe']");

        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
        }

        public bool IsLabelDashboardDisplay(int timeout=1)
        {
            //Save implitcit wait to a variable
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                return driver.FindElement(xpathLabelDashBoard).Displayed;
            }
            catch
            {
                return false;
            }
            finally 
            { 
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }

        }
    }
}
