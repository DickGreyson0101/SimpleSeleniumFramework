using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverHelper.Helper;

namespace DemoAlertiframe
{
    [TestClass]
    public class IframeTest
    {
        private BrowserHelper browserHelper;
        private By xpathInput = By.XPath("//div[@class='row']/div/input[@type=\"text\"]");
        private By xpathIframeSingle = By.XPath("//iframe[@id=\"singleframe\"]");
        private By xpathButtonMultipleFrame = By.XPath("//a[text() = 'Iframe with in an Iframe']");
        
        [TestInitialize]
        public void TestInitialize()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [TestMethod]
        public void VerifyIframe()
        {
            var frame = browserHelper.Driver.FindElement(xpathIframeSingle);

            browserHelper.Driver.SwitchTo().Frame(frame);
            browserHelper.Driver.FindElement(xpathInput).SendKeys("Uyen");

            browserHelper.Driver.SwitchTo().DefaultContent();
            browserHelper.Driver.FindElement(xpathButtonMultipleFrame).Click();
        }
    }

    
}
