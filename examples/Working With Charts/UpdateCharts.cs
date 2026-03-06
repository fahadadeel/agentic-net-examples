using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 600f, true);

        // Access the chart data
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Set an external workbook as the data source (do not update chart data immediately)
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook("data.xlsx", false);

        // Save the presentation
        presentation.Save("UpdatedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}