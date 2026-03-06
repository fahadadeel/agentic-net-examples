using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportPresentationCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ExportPresentationCharts_out.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart with sample data
            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Enable data labels to show values from workbook cells
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Create cells in the workbook for data labels
            workbook.GetCell(0, "A10", "Label 0");
            workbook.GetCell(0, "A11", "Label 1");
            workbook.GetCell(0, "A12", "Label 2");

            // Assign the cells to the data labels
            series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0");
            series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1");
            series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}