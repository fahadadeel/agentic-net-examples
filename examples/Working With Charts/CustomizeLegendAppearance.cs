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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Customize legend appearance
        chart.Legend.X = 0.8f;               // Position X (fraction of chart width)
        chart.Legend.Y = 0.1f;               // Position Y (fraction of chart height)
        chart.Legend.Width = 0.15f;          // Legend width (fraction of chart width)
        chart.Legend.Height = 0.3f;          // Legend height (fraction of chart height)
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right; // Set legend position

        // Save the presentation before exiting
        presentation.Save("CustomizedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}