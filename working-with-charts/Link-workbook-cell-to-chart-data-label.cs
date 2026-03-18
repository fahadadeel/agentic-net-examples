using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a bubble chart
                IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f, true);

                // Get the first series
                IChartSeries series = chart.ChartData.Series[0];

                // Enable data label value from cell for all labels in the series
                series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

                // Get the workbook associated with the chart
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Create cells with label text
                workbook.GetCell(0, "A10", "Label 0");
                workbook.GetCell(0, "A11", "Label 1");
                workbook.GetCell(0, "A12", "Label 2");

                // Assign cells to data labels
                series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10");
                series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11");
                series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12");

                // Save the presentation
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "WorkbookCellDataLabel.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}