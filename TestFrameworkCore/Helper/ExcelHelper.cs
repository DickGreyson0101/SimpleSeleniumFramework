using OfficeOpenXml;
using System.Diagnostics.Tracing;
using TestFrameworkCore.Model;

namespace TestFrameworkCore.Helper
{
    public class ExcelHelper
    {
        private string filePath;

        public ExcelHelper(string _filePath)
        {
            this.filePath = _filePath;
        }

        public List<KeywordData> GetKeywordDatas() {
            var keywords = new List<KeywordData>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(filePath))
            {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();
                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;

                //Loop one by one row in data table
                for (var i = 2; i <= totalRow; i++)
                {
                    //Data from column 1
                    var keyword = workSheet.Cells[i, 1].Value.ToString();

                    //Data from column 2
                    var data = workSheet.Cells[i, 2].Value?.ToString();

                    keywords.Add(new KeywordData
                    {
                        Keyword = keyword,
                        Data = data,
                    });
                }
            }

            return keywords;
        }

        public List<object[]> GetLoginUserData()
        {
            var result = new List<object[]>();
            //1 file excel co nhieu workbook, 1 workbook co nhieu sheet, 1 sheet co nhieu table
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(filePath))
            {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();
                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;
                for (var i = 2; i <= totalRow; i++)
                {
                    result.Add(new object[] {
                                            workSheet.Cells[i, 1].Value.ToString(),
                                            workSheet.Cells[i, 2].Value.ToString(),
                                            bool.Parse(workSheet.Cells[i, 3].Value.ToString())
                    });
                }
            }
            return result;
        }


    }
}
