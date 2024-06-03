using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertiframe
{
    [TestClass]
    public class AlertTest
    {
        private BrowserHelper browserHelper;
        
        private By xpathButton(string text) => By.XPath($"//button[text() = '{text}']");
        [TestInitialize]
        public void TestInitialize()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");
        }


        [TestMethod]
        public void VerifyAlert()
        {
            //Click button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Alert")).Click();
            browserHelper.Driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void VerifyConfirm()
        {
            //Click button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Confirm")).Click();
            browserHelper.Driver.SwitchTo().Alert().Dismiss();
        }

        [TestMethod]
        public void VerifyPrompt()
        {
            //Click button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Prompt")).Click();
            string inputValue = "Uyen" + DateTime.Now.ToFileTimeUtc();
            browserHelper.Driver.SwitchTo().Alert().SendKeys(inputValue);
            browserHelper.Driver.SwitchTo().Alert().Accept();
        }

    }
}