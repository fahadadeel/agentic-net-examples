using System;
using Aspose.Slides;
using Aspose.Slides.Import;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string presentationPath = "output.pptx";
        string workbookPath = "data.xlsx";
        string worksheetName = "Sheet1";
        string chartName = "Chart 1";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a chart from the Excel workbook to the first slide
        Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
            pres.Slides[0].Shapes,
            10f,
            10f,
            workbookPath,
            worksheetName,
            chartName,
            false);

        // Access the embedded chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook dataWorkbook = chart.ChartData.ChartDataWorkbook;

        // Modify a cell value in the workbook (e.g., cell A1 in the first worksheet)
        Aspose.Slides.Charts.IChartDataCell cell = dataWorkbook.GetCell(0, "A1");
        cell.Value = 123;

        // Save the presentation
        pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}