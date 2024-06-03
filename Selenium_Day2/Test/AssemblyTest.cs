using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]

namespace Selenium_Day2.Test
{

    [TestClass]
    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            BaseTest.ReportHelper = new ReportHelper();
            BaseTest.ReportHelper.InitReport();
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (BaseTest.ReportHelper != null)
            {
                {
                    BaseTest.ReportHelper.ExportReport();
                }

            }
        }

    }
}
