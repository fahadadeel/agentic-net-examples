using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Excel;

class Program
{
    static void Main(string[] args)
    {
        // Define directories and file names
        string dataDir = @"C:\Data";
        string excelPath = Path.Combine(dataDir, "input.xlsx");
        string csvPath = Path.Combine(dataDir, "output.csv");
        string presentationPath = Path.Combine(dataDir, "dummy.pptx");

        // Load the Excel workbook
        Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

        // Get the first worksheet name
        System.Collections.Generic.IEnumerable<string> worksheetNames = workbook.GetWorksheetNames();
        System.Collections.Generic.IEnumerator<string> enumerator = worksheetNames.GetEnumerator();
        string worksheetName = null;
        if (enumerator.MoveNext())
        {
            worksheetName = enumerator.Current;
        }

        // Convert worksheet data to CSV, preserving blank rows
        using (StreamWriter writer = new StreamWriter(csvPath))
        {
            // Example range: rows 1-10, columns 1-5
            for (int row = 1; row <= 10; row++)
            {
                StringBuilder lineBuilder = new StringBuilder();
                for (int col = 1; col <= 5; col++)
                {
                    Aspose.Slides.Excel.IExcelDataCell cell = workbook.GetCell(worksheetName, row, col);
                    if (cell != null && cell.Value != null)
                    {
                        lineBuilder.Append(cell.Value.ToString());
                    }
                    // Append comma separator except after last column
                    if (col < 5)
                    {
                        lineBuilder.Append(",");
                    }
                }
                writer.WriteLine(lineBuilder.ToString());
            }
        }

        // Create a dummy presentation and save it before exiting
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}