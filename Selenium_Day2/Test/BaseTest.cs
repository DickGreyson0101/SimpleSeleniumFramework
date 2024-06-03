using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
using WebDriverHelper;
using WebDriverHelper.Helper;

namespace Selenium_Day2.Test
{
    public class BaseTest
    {
        protected BrowserHelper browser;
        public static ReportHelper ReportHelper { get; set; }
        public TestContext TestContext { get; set; }
        protected ExtentTest extentTest;
        public virtual void SetupPage() { }

        [TestInitialize] 
        public void TestInitialize()
        {
            browser = new BrowserHelper();
            string url = ConfigurationHelper.GetConfig<string>("url");
            browser.OpenBrowser(url);
            SetupPage();

            //reflection 
            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);
            TestMethodAttribute displayNameAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();
        string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName :TestContext.TestName;

                extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (extentTest != null)
            {
                if(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                { 
                    extentTest.AddImageBase4(browser.TakeScreenShotAsBase4()); 
                }
                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());
            }
            browser.QuitBrowser();

        }
    }
}
