using AngleSharp.Common;
using FluentAssertions;
using Newtonsoft.Json;
using Selenium_Day2.Model;
using Selenium_Day2.Page;
using TestFrameworkCore.Model;
using WebDriverHelper.Helper;

namespace Selenium_Day2.Helper
{
    public class KeywordHelper
    {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;
        public KeywordHelper(List<KeywordData> keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Execute keyword in the list
        /// </summary>
        public void ExecuteKeywords()
        {
            foreach (var keyword in keywords) {
                ExecuteKeyword(keyword);
            }
        }

        public void ExecuteKeyword(KeywordData keyword) {
            switch (keyword.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;
                case "Close Browser":
                    browserHelper.QuitBrowser();
                    break;
                case "Go to URL":
                    browserHelper.GoToURL(keyword.Data);
                    break;
                case "Enter username":
                    EnterUserName(keyword.Data);
                    break;
                case "Enter password":
                    EnterPassword(keyword.Data);
                    break;
                case "Click login button":
                    ClickLoginButton();
                    break;
                case "Verify dashboard display":
                    VerifyDashboardModel verifyDashboardModel = JsonConvert.DeserializeObject<VerifyDashboardModel>(keyword.Data);
                    VerifyDashboardDisplay(verifyDashboardModel);
                    break;
                case "Enter username and password":
                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(keyword.Data);
                    EnterUserNameAndPassword(userModel);
                    break;
                default:
                    throw new Exception("Not support this keyword");
            }
        }

        public void EnterUserName(string username)
        {
           LoginPage loginPage = new LoginPage(browserHelper.Driver);
           loginPage.InputUsername(username);
        }

        public void EnterPassword(string password) {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputPassword(password);
        }

        public void ClickLoginButton() {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }

        public void VerifyDashboardDisplay(VerifyDashboardModel verifyDashboardModel)
        {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsLabelDashboardDisplay(verifyDashboardModel.Timeout).Should().Be(verifyDashboardModel.Expected);
        }

        public void EnterUserNameAndPassword(UserModel userModel) { 
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(userModel.Username);
            loginPage.InputPassword(userModel.Password);

        }
    }
}
