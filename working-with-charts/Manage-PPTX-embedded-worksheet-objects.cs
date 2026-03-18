using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ManageEmbeddedWorksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation.
                Presentation pres = new Presentation();

                // Add a chart to the first slide.
                IChart chart = pres.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Access the embedded workbook of the chart.
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Get the collection of worksheets.
                IChartDataWorksheetCollection worksheets = workbook.Worksheets;

                // Display worksheet names.
                Console.WriteLine("Worksheets in the chart's workbook:");
                for (int i = 0; i < worksheets.Count; i++)
                {
                    IChartDataWorksheet ws = worksheets[i];
                    Console.WriteLine($"  Index {i}: {ws.Name}");
                }

                // Clear all data from the first worksheet (index 0) as an example.
                if (worksheets.Count > 0)
                {
                    workbook.Clear(0);
                    Console.WriteLine("Cleared data from worksheet at index 0.");
                }

                // Save the presentation.
                pres.Save("ManageWorksheet_out.pptx", SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}