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

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

        // Disable the vertical axis
        chart.Axes.VerticalAxis.IsVisible = false;

        // Save the presentation
        presentation.Save("LineChart_NoVerticalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}