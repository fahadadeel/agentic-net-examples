using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Presentation presentation = null;
        try
        {
            presentation = new Presentation();

            // Add a pie chart to the first slide
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);

            // Access the embedded workbook of the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // List existing worksheet names
            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                IChartDataWorksheet worksheet = workbook.Worksheets[i];
                Console.WriteLine("Worksheet: " + worksheet.Name);
            }

            // Clear data of the first worksheet if any exist
            if (workbook.Worksheets.Count > 0)
            {
                workbook.Clear(0);
                Console.WriteLine("Cleared data of worksheet at index 0.");
            }

            // Modify a cell in the first worksheet (row 0, column 0)
            IChartDataCell cell = workbook.GetCell(0, 0, 0);
            cell.Value = "Modified";

            // Save the presentation
            presentation.Save("WorksheetDemo.pptx", SaveFormat.Pptx);
            Console.WriteLine("Presentation saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}