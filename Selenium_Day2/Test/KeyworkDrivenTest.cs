using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium_Day2.Helper;
using TestFrameworkCore.Helper;

namespace Selenium_Day2.Test
{
    [TestClass]
    public class KeyworkDrivenTest
    {
        [TestMethod("TC04: Verify login by using Keyword driven")]
        public void VerifyLogin()
        {
            //Lay list tu file excel
            //Read keywords
            var excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            //Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }

        [TestMethod("TC05: Verify login by using Keyword driven with JSON")]
        public void VerifyLoginWithModel()
        {
            //Lay list tu file excel
            //Read keywords
            var excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven2.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            //Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }
    }
}
