using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net.WebSockets;

namespace TestFrameworkCore.Helper.Report
{
    public class ReportHelper
    {
        private ExtentReports extent;
        public void InitReport()
        {
            extent = new ExtentReports();
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(),"Reports",reportName);
            var spark = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(spark);
        }
        public void ExportReport()
        {
            extent.Flush();
        }
        public ExtentTest CreateTest(string testName, string description)
        {
            return extent.CreateTest(testName, description);
        }
        public void LogMessage(ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        public void AddResult(ExtentTest test, string result)
        {
            if (result.Equals("Passed"))
                test.Pass("Testcase is passed");
            else test.Fail("Tescase is failed");
        }
    }
}
