using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "ChartWithDataLabels.pptx";

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

        // Populate cells with label text
        workbook.GetCell(0, "A10", "First");
        workbook.GetCell(0, "A11", "Second");
        workbook.GetCell(0, "A12", "Third");

        // Assign workbook cells to the data labels
        series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "First");
        series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Second");
        series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Third");

        // Customize the series fill color
        series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}