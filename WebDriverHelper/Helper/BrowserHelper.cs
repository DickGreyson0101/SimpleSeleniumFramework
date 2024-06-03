using OpenQA.Selenium;
using System.Drawing;
using TestFrameworkCore.Helper;

namespace WebDriverHelper.Helper
{
    public class BrowserHelper
    {
        public IWebDriver Driver;

        /// <summary>
        /// Init browser/open browser and navigate to url
        /// </summary>
        /// <param name="url"></param>
        public void OpenBrowser(string url = null, string browserType = null)
        {
            //Configuration/Setting Reader/Helper
            //Factory Pattern (Webdriver)

            //Nếu không truyền browserType thì đọc từ config
            //Ngược lại sử dụng cái thứ mình truyền về
            if (string.IsNullOrEmpty(browserType))
            {
                browserType = ConfigurationHelper.GetConfig<string>("browser");
            }
            Driver = DriverFactoryHelper.InitDriver(browserType);

            //Create ChromeDriver
            //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //Driver = new ChromeDriver();

            //setting implicit wait for 5 second
            int timeout = ConfigurationHelper.GetConfig<int>("timeout");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            //driver = new ChromeDriver(Path.Combine("Drivers", "Chrome"));
            Driver.Manage().Window.Maximize();
            if (!string.IsNullOrEmpty(url))
            {
                GoToURL(url);
            }
        }

        /// <summary>
        /// Quit and dispose all resource
        /// </summary>
        /// 
        public void QuitBrowser()
        {
            if (Driver is null)
            {
                return;
            }
            Driver.Quit();
        }

        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public string TakeScreenShotAsBase4()
        {
            // Convert WebDriver object to ITakesScreenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver;

            // Take the screenshot
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }
    }
}