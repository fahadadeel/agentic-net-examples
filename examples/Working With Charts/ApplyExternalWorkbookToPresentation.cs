using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        var chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);

        // Get the chart data
        var chartData = chart.ChartData;

        // Set an external workbook as the data source for the chart
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook("workbook.xlsx");

        // Save the presentation
        presentation.Save("ExternalWorkbookChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}