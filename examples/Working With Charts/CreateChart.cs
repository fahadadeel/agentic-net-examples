using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Output file path
        string outputPath = "ChartWithDataLabels.pptx";

        // Add a bubble chart with sample data
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Enable data labels to show values from workbook cells
        series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

        // Access the chart's embedded workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells A10, A11, A12 with label texts
        workbook.GetCell(0, "A10", "Label 0");
        workbook.GetCell(0, "A11", "Label 1");
        workbook.GetCell(0, "A12", "Label 2");

        // Assign the cell values to the data labels of the series
        series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0");
        series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1");
        series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}