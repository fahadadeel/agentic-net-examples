using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

        // Access the chart's axes manager
        Aspose.Slides.Charts.IAxesManager axesManager = chart.Axes;

        // Configure the vertical axis
        Aspose.Slides.Charts.IAxis verticalAxis = axesManager.VerticalAxis;
        verticalAxis.HasTitle = true;
        verticalAxis.Title.AddTextFrameForOverriding("Value Axis");
        verticalAxis.MaxValue = 100;
        verticalAxis.MinValue = 0;

        // Configure the horizontal axis
        Aspose.Slides.Charts.IAxis horizontalAxis = axesManager.HorizontalAxis;
        horizontalAxis.HasTitle = true;
        horizontalAxis.Title.AddTextFrameForOverriding("Category Axis");

        // Save the presentation
        presentation.Save("ChartAxesExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}