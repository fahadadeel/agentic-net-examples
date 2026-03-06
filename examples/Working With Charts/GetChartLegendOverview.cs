using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a clustered column chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Set legend position to the right side of the chart
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

        // Do not allow other chart elements to overlap the legend
        chart.Legend.Overlay = false;

        // Save the presentation
        presentation.Save("ChartLegendOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}