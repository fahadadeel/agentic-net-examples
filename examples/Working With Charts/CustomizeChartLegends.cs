using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Set legend position to top right
        chart.Legend.Position = LegendPositionType.TopRight;

        // Do not allow other chart elements to overlap the legend
        chart.Legend.Overlay = false;

        // Hide the first legend entry (optional customization)
        Aspose.Slides.Charts.ILegendEntryProperties firstEntry = chart.Legend.Entries[0];
        firstEntry.Hide = true;

        // Save the presentation
        presentation.Save("CustomizeChartLegend_out.pptx", SaveFormat.Pptx);
    }
}