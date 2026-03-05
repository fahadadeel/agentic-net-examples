using System;

class Program
{
    static void Main()
    {
        // Path to the Excel workbook containing the chart
        string workbookPath = "chartData.xlsx";
        // Worksheet name that holds the chart
        string worksheetName = "Sheet1";
        // Name of the chart inside the worksheet
        string chartName = "Chart 1";

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add the chart from the Excel workbook to the slide
            Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                shapes,
                10f,
                10f,
                workbookPath,
                worksheetName,
                chartName,
                false);

            // Save the presentation to a PPTX file
            pres.Save("ChartFromWorkbook.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}