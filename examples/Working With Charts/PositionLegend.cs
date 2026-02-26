using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Position the legend at the top right of the chart
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.TopRight;

        // Save the presentation
        presentation.Save("ChartLegendPosition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}