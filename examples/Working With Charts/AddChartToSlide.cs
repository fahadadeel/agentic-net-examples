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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f,    // X position
            0f,    // Y position
            500f,  // Width
            400f   // Height
        );

        // Set the layout target type for the plot area (example setting)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation to a PPTX file
        presentation.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}